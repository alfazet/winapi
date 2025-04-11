using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lecture2.Controls
{
    public class UIEditor : UserControl
    {
        private CroppingType _croppingType = CroppingType.Rectangle;
        private IWindowsFormsEditorService _editorService = null;
        private System.Windows.Forms.Panel _squarePanel;
        private System.Windows.Forms.Panel _circlePanel;

        // Required designer variable. 
        private System.ComponentModel.Container _components = null;
        public UIEditor(CroppingType croppingType,
            IWindowsFormsEditorService editorService)
        {
            // This call is required by the designer.
            InitializeComponent();

            // Cache the light shape value provided by the  
            // design-time environment. 
            _croppingType = croppingType;

            // Cache the reference to the editor service. 
            _editorService = editorService;

            // Handle the Click event for the two panels.  
            _squarePanel.Click += new EventHandler(squarePanel_Click);
            _circlePanel.Click += new EventHandler(circlePanel_Click);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Be sure to unhook event handlers 
                // to prevent "lapsed listener" leaks.
                _squarePanel.Click -=
                    new EventHandler(squarePanel_Click);
                _circlePanel.Click -=
                    new EventHandler(circlePanel_Click);

                if (_components != null)
                {
                    _components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        // LightShape is the property for which this control provides 
        // a custom user interface in the Properties window. 
        public CroppingType CroppingType
        {
            get
            {
                return _croppingType;
            }

            set
            {
                if (_croppingType != value)
                {
                    _croppingType = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (
                Graphics gSquare = _squarePanel.CreateGraphics(),
                gCircle = _circlePanel.CreateGraphics())
            {
                // Draw a filled square in the client area of 
                // the squarePanel control.
                gSquare.FillRectangle(
                    Brushes.Red,
                    0,
                    0,
                    _squarePanel.Width,
                    _squarePanel.Height
                    );

                // If the Square option has been selected, draw a  
                // border inside the squarePanel. 
                if (_croppingType ==CroppingType.Rectangle)
                {
                    gSquare.DrawRectangle(
                        Pens.Black,
                        0,
                        0,
                        _squarePanel.Width - 1,
                        _squarePanel.Height - 1);
                }

                // Draw a filled circle in the client area of 
                // the circlePanel control.
                gCircle.Clear(_circlePanel.BackColor);
                gCircle.FillEllipse(
                    Brushes.Blue,
                    0,
                    0,
                    _circlePanel.Width,
                    _circlePanel.Height
                    );

                // If the Circle option has been selected, draw a  
                // border inside the circlePanel. 
                if (_croppingType == CroppingType.Circle)
                {
                    gCircle.DrawRectangle(
                        Pens.Black,
                        0,
                        0,
                        _circlePanel.Width - 1,
                        _circlePanel.Height - 1);
                }
            }
        }

        private void squarePanel_Click(object sender, EventArgs e)
        {
            _croppingType = CroppingType.Rectangle;

            this.Invalidate(false);

            _editorService.CloseDropDown();
        }

        private void circlePanel_Click(object sender, EventArgs e)
        {
            _croppingType = CroppingType.Circle;

            this.Invalidate(false);

            _editorService.CloseDropDown();
        }

        /// <summary>  
        /// Required method for Designer support - do not modify  
        /// the contents of this method with the code editor. 
        /// </summary> 
        private void InitializeComponent()
        {
            _squarePanel = new System.Windows.Forms.Panel();
            _circlePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //  
            // squarePanel 
            //  
            _squarePanel.Location = new System.Drawing.Point(8, 10);
            _squarePanel.Name = "squarePanel";
            _squarePanel.Size = new System.Drawing.Size(60, 60);
            _squarePanel.TabIndex = 2;
            //  
            // circlePanel 
            //  
            _circlePanel.Location = new System.Drawing.Point(80, 10);
            _circlePanel.Name = "circlePanel";
            _circlePanel.Size = new System.Drawing.Size(60, 60);
            _circlePanel.TabIndex = 3;
            //  
            // LightShapeSelectionControl 
            //  
            this.Controls.Add(_squarePanel);
            this.Controls.Add(_circlePanel);
            this.Name = "UIEditorControl";
            this.Size = new System.Drawing.Size(150, 80);
            this.ResumeLayout(false);

        }
    }
}
