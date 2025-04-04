namespace FormsExampleTask
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fIleToolStripMenuItem = new ToolStripMenuItem();
            newBlueprintToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            Canvas = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            AddFurniture = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ButtonCoffeeTable = new Button();
            ButtonTable = new Button();
            ButtonSofa = new Button();
            ButtonDoubleBed = new Button();
            ButtonWall = new Button();
            CreatedFurniture = new GroupBox();
            FurnitureListBox = new ListBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            AddFurniture.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            CreatedFurniture.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fIleToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1032, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            fIleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBlueprintToolStripMenuItem });
            fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            fIleToolStripMenuItem.Size = new Size(37, 20);
            fIleToolStripMenuItem.Text = "FIle";
            // 
            // newBlueprintToolStripMenuItem
            // 
            newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            newBlueprintToolStripMenuItem.ShortcutKeys = Keys.F2;
            newBlueprintToolStripMenuItem.Size = new Size(168, 22);
            newBlueprintToolStripMenuItem.Text = "New Blueprint";
            newBlueprintToolStripMenuItem.Click += newBlueprintToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Canvas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(1032, 646);
            splitContainer1.SplitterDistance = 344;
            splitContainer1.TabIndex = 1;
            // 
            // Canvas
            // 
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(344, 646);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.MouseDown += Canvas_MouseDown;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(AddFurniture, 0, 0);
            tableLayoutPanel1.Controls.Add(CreatedFurniture, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(684, 646);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AddFurniture
            // 
            AddFurniture.Controls.Add(flowLayoutPanel1);
            AddFurniture.Dock = DockStyle.Fill;
            AddFurniture.Location = new Point(3, 3);
            AddFurniture.Name = "AddFurniture";
            AddFurniture.Size = new Size(678, 317);
            AddFurniture.TabIndex = 0;
            AddFurniture.TabStop = false;
            AddFurniture.Text = "Add furniture";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(ButtonCoffeeTable);
            flowLayoutPanel1.Controls.Add(ButtonTable);
            flowLayoutPanel1.Controls.Add(ButtonSofa);
            flowLayoutPanel1.Controls.Add(ButtonDoubleBed);
            flowLayoutPanel1.Controls.Add(ButtonWall);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(672, 295);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // ButtonCoffeeTable
            // 
            ButtonCoffeeTable.BackColor = Color.White;
            ButtonCoffeeTable.BackgroundImage = Properties.Resources.coffee_table;
            ButtonCoffeeTable.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonCoffeeTable.Location = new Point(3, 3);
            ButtonCoffeeTable.Name = "ButtonCoffeeTable";
            ButtonCoffeeTable.Size = new Size(75, 75);
            ButtonCoffeeTable.TabIndex = 0;
            ButtonCoffeeTable.Tag = "Coffee Table";
            ButtonCoffeeTable.UseVisualStyleBackColor = false;
            ButtonCoffeeTable.Click += ButtonCoffeeTable_Click;
            // 
            // ButtonTable
            // 
            ButtonTable.BackColor = Color.White;
            ButtonTable.BackgroundImage = Properties.Resources.table;
            ButtonTable.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonTable.Location = new Point(84, 3);
            ButtonTable.Name = "ButtonTable";
            ButtonTable.Size = new Size(75, 75);
            ButtonTable.TabIndex = 1;
            ButtonTable.Tag = "Table";
            ButtonTable.UseVisualStyleBackColor = false;
            ButtonTable.Click += ButtonCoffeeTable_Click;
            // 
            // ButtonSofa
            // 
            ButtonSofa.BackColor = Color.White;
            ButtonSofa.BackgroundImage = Properties.Resources.sofa;
            ButtonSofa.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonSofa.Location = new Point(165, 3);
            ButtonSofa.Name = "ButtonSofa";
            ButtonSofa.Size = new Size(75, 75);
            ButtonSofa.TabIndex = 2;
            ButtonSofa.Tag = "Sofa";
            ButtonSofa.UseVisualStyleBackColor = false;
            ButtonSofa.Click += ButtonCoffeeTable_Click;
            // 
            // ButtonDoubleBed
            // 
            ButtonDoubleBed.BackColor = Color.White;
            ButtonDoubleBed.BackgroundImage = Properties.Resources.double_bed;
            ButtonDoubleBed.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonDoubleBed.Location = new Point(246, 3);
            ButtonDoubleBed.Name = "ButtonDoubleBed";
            ButtonDoubleBed.Size = new Size(75, 75);
            ButtonDoubleBed.TabIndex = 3;
            ButtonDoubleBed.Tag = "Double Bed";
            ButtonDoubleBed.UseVisualStyleBackColor = false;
            ButtonDoubleBed.Click += ButtonCoffeeTable_Click;
            // 
            // ButtonWall
            // 
            ButtonWall.BackColor = Color.White;
            ButtonWall.BackgroundImage = Properties.Resources.wall;
            ButtonWall.BackgroundImageLayout = ImageLayout.Stretch;
            ButtonWall.Location = new Point(327, 3);
            ButtonWall.Name = "ButtonWall";
            ButtonWall.Size = new Size(75, 75);
            ButtonWall.TabIndex = 4;
            ButtonWall.Tag = "Wall";
            ButtonWall.UseVisualStyleBackColor = false;
            ButtonWall.Click += ButtonCoffeeTable_Click;
            // 
            // CreatedFurniture
            // 
            CreatedFurniture.Controls.Add(FurnitureListBox);
            CreatedFurniture.Dock = DockStyle.Fill;
            CreatedFurniture.Location = new Point(3, 326);
            CreatedFurniture.Name = "CreatedFurniture";
            CreatedFurniture.Size = new Size(678, 317);
            CreatedFurniture.TabIndex = 1;
            CreatedFurniture.TabStop = false;
            CreatedFurniture.Text = "Created furniture";
            // 
            // FurnitureListBox
            // 
            FurnitureListBox.Dock = DockStyle.Fill;
            FurnitureListBox.FormattingEnabled = true;
            FurnitureListBox.ItemHeight = 15;
            FurnitureListBox.Location = new Point(3, 19);
            FurnitureListBox.Name = "FurnitureListBox";
            FurnitureListBox.Size = new Size(672, 295);
            FurnitureListBox.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 670);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 300);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Room Planner";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            AddFurniture.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            CreatedFurniture.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fIleToolStripMenuItem;
        private ToolStripMenuItem newBlueprintToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox AddFurniture;
        private GroupBox CreatedFurniture;
        private PictureBox Canvas;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button ButtonCoffeeTable;
        private Button ButtonTable;
        private Button ButtonSofa;
        private Button ButtonDoubleBed;
        private Button ButtonWall;
        private ListBox FurnitureListBox;
    }
}
