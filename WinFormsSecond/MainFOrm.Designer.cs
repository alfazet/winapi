namespace WinFormsSecond
{
    partial class MainForm
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
            CanvasPanel = new Panel();
            Canvas = new PictureBox();
            CanvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // CanvasPanel
            // 
            CanvasPanel.AutoScroll = true;
            CanvasPanel.Controls.Add(Canvas);
            CanvasPanel.Dock = DockStyle.Fill;
            CanvasPanel.Location = new Point(0, 0);
            CanvasPanel.Name = "CanvasPanel";
            CanvasPanel.Size = new Size(800, 450);
            CanvasPanel.TabIndex = 0;
            // 
            // Canvas
            // 
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(800, 450);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasPanel);
            Name = "MainForm";
            Text = "Form1";
            CanvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel CanvasPanel;
        private PictureBox Canvas;
    }
}
