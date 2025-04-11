using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lecture2.Controls
{
    public enum CroppingType
    {
        Rectangle,
        Circle
    }

    public enum CroppingMode
    {
        Automatic,
        Manual
    }

    public class CustomControl : Control
    {
        [Category("Cropping")]
        [Browsable(true)]
        [DisplayName("Crroping Type")]
        [EditorAttribute(typeof(CroppingTypeEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        public CroppingType ImageCroppingType { get; set; }
        [Category("Cropping")]
        [Browsable(true)]
        [DisplayName("Percent Change")]
        [DefaultValue(5)]
        public int PercentChange { get; set; }
        [Category("Cropping")]
        [Browsable(true)]
        public Image Picture
        {
            get { return _image; }
            set
            {
                if (value != null)
                {
                    _pictureBrush = new TextureBrush(value, new Rectangle(0, 0, value.Width, value.Height));
                }
                else
                    _pictureBrush = null;
                _image = value;
            }
        }
        [Category("Marquee")]
        [Browsable(true)]
        [DisplayName("Update Period")]
        [DefaultValue(100)]
        public virtual int UpdatePeriod
        {
            get
            {
                return _updatePeriod;
            }

            set
            {
                if (value > 0)
                {
                    _updatePeriod = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("UpdatePeriod", "must be > 0");
                }
            }
        }
        [Category("Cropping")]
        [Browsable(true)]
        [DisplayName("Cropping Mode")]
        public CroppingMode ImageCroppingMode { get; set; }
        private Image _image;
        private Brush _pictureBrush;
        private int _updatePeriod;
        private float _scale = 1.0f;
        private float _directory = 1.0f;


        private BackgroundWorker _backgroundWorker;

        public CustomControl()
        {
            InitializeComponent();
            _pictureBrush = null;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void InitializeComponent()
        {
            _backgroundWorker = new BackgroundWorker();

            //  
            // backgroundWorker1 
            //  
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.ProgressChanged += ProgressChangedInBackground;
            _backgroundWorker.DoWork += DoWorkInBackground;
        }

        public void Animate()
        {
            _backgroundWorker.RunWorkerAsync(UpdatePeriod);
        }


        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            // Repaint when the layout has changed. 
            Refresh();
        }
        private void ProgressChangedInBackground(object sender, ProgressChangedEventArgs e)
        {
            _scale = _scale - (_directory * (float)e.ProgressPercentage / (100f));
            if (_scale < 0.5f || _scale>1.1f)
                _directory = -1.0f * _directory;
            Refresh();
        }

        private void DoWorkInBackground(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                Thread.Sleep((int)e.Argument);

                worker.ReportProgress(PercentChange);
            }
        }

        // This method paints the lights around the border of the  
        // control. It paints the top row first, followed by the 
        // right side, the bottom row, and the left side. The color 
        // of each light is determined by the IsLit method and 
        // depends on the light's position relative to the value 
        // of currentOffset. 
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_backgroundWorker.IsBusy && ImageCroppingMode==CroppingMode.Automatic)
            {
                Animate();
            }
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);

            base.OnPaint(e);

            if (_pictureBrush != null)
            {
                var rect = GetRectangle(g);

                switch (ImageCroppingType)
                {
                    case CroppingType.Rectangle:
                        g.FillRectangle(_pictureBrush, rect);
                        break;
                    case CroppingType.Circle:
                        g.FillEllipse(_pictureBrush, rect);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }

        private RectangleF GetRectangle(Graphics graphics)
        {
            var newWidht = graphics.ClipBounds.Width * _scale;
            var newHeight = graphics.ClipBounds.Height * _scale;
            var x = (graphics.ClipBounds.Width - newWidht) / 2;
            var y = (graphics.ClipBounds.Height - newHeight) / 2;

            return new RectangleF(x, y, newWidht, newHeight);
        }
        
    }

    public class CroppingTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService = null;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(
            ITypeDescriptorContext context,
            IServiceProvider provider,
            object value)
        {
            if (provider != null)
            {
                editorService =
                    provider.GetService(
                            typeof(IWindowsFormsEditorService))
                        as IWindowsFormsEditorService;
            }

            if (editorService != null)
            {
                UIEditor selectionControl =
                    new UIEditor(
                        (CroppingType)value,
                        editorService);

                editorService.DropDownControl(selectionControl);

                value = selectionControl.CroppingType;
            }

            return value;
        }
    }
}
