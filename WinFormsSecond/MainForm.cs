namespace WinFormsSecond
{
    public partial class MainForm : Form
    {
        private Blueprint _blueprint;

        public MainForm()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            _blueprint = new Blueprint(CanvasPanel.Width, CanvasPanel.Height);
            Canvas.Image = _blueprint.Bitmap;
            Canvas.BackColor = Color.Teal;
        }

        public class Blueprint
        {
            private Color _bkgColor = Color.Teal;
            public Bitmap Bitmap { get; private set; }

            public Blueprint(int width, int height)
            {
                Bitmap = new Bitmap(width, height);
                Draw();
            }

            public void Draw()
            {
                using (Graphics g = Graphics.FromImage(Bitmap))
                {
                    g.Clear(_bkgColor);
                }
            }
        }
    }
}
