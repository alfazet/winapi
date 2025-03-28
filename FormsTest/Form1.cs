namespace FormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome {nameTextBox.Text}");
        }
    }
}
