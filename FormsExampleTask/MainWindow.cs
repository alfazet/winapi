using System.ComponentModel;
using System.Net.NetworkInformation;

namespace FormsExampleTask
{
    // MainWindow must be the first class in a file
    public partial class MainWindow : Form
    {
        private Blueprint _blueprint;
        private Button _selectedButton;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            _blueprint = new Blueprint(Canvas.Width, Canvas.Height);
            Canvas.Image = _blueprint.Bitmap;
            FurnitureListBox.DataSource = _blueprint.Furniture;
        }

        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeCanvas();
        }

        private void ButtonCoffeeTable_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (_selectedButton == null)
            {
                btn.BackColor = Color.AntiqueWhite;
                _selectedButton = btn;
            }
            else if (_selectedButton == btn)
            {
                btn.BackColor = Color.White;
                _selectedButton = null;
            }
            else
            {
                btn.BackColor = Color.AntiqueWhite;
                _selectedButton.BackColor = Color.White;
                _selectedButton = btn;
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _selectedButton != null)
            {
                _blueprint.AddFurniture(new Furniture(e.Location, _selectedButton.BackgroundImage, _selectedButton.Tag.ToString()));
                _selectedButton.BackColor = Color.White;
                _selectedButton = null;
                _blueprint.Draw();
                Canvas.Refresh();
            }
        }
    }

    public class Blueprint
    {
        private Color _bkgColor = Color.White;
        public Bitmap Bitmap { get; private set; }
        public BindingList<Furniture> Furniture { get; }

        public Blueprint(int width, int height)
        {
            Bitmap = new Bitmap(width, height);
            Furniture = new BindingList<Furniture>();
            Draw();
        }

        public void Draw()
        {
            using (Graphics g = Graphics.FromImage(Bitmap))
            {
                g.Clear(_bkgColor);
                foreach (var item in Furniture)
                {
                    item.Draw(g);
                }
            }
        }

        public void AddFurniture(Furniture item)
        {
            Furniture.Add(item);
        }
    }

    public class Furniture
    {
        private Point _pos;
        private Image _icon;
        private string _name;

        public Furniture(Point pos, Image icon, string name)
        {
            _pos = pos;
            _icon = icon;
            _name = name;
        }

        public void Draw(Graphics g)
        {
            var center = new Point(_pos.X - _icon.Size.Width / 2, _pos.Y - _icon.Size.Height / 2);
            g.DrawImage(_icon, center);
        }

        public override string ToString()
        {
            return $"{_name} {_pos.ToString()}";
        }
    }
}
