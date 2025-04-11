namespace PWSG_Examples
{
    partial class AddingControlsFromCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCountControls = new System.Windows.Forms.Button();
            this.pnlAddedControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddControls = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCountControls
            // 
            this.btnCountControls.Location = new System.Drawing.Point(297, 280);
            this.btnCountControls.Name = "btnCountControls";
            this.btnCountControls.Size = new System.Drawing.Size(127, 26);
            this.btnCountControls.TabIndex = 9;
            this.btnCountControls.Text = "Zlicz kontrolki";
            this.btnCountControls.UseVisualStyleBackColor = true;
            this.btnCountControls.Click += new System.EventHandler(this.BtnCountControls_Click);
            // 
            // pnlAddedControls
            // 
            this.pnlAddedControls.Location = new System.Drawing.Point(12, 45);
            this.pnlAddedControls.Name = "pnlAddedControls";
            this.pnlAddedControls.Size = new System.Drawing.Size(412, 220);
            this.pnlAddedControls.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Podaj liczbę od 1-10";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 22);
            this.textBox1.TabIndex = 6;
            // 
            // btnAddControls
            // 
            this.btnAddControls.Location = new System.Drawing.Point(308, 7);
            this.btnAddControls.Name = "btnAddControls";
            this.btnAddControls.Size = new System.Drawing.Size(116, 23);
            this.btnAddControls.TabIndex = 5;
            this.btnAddControls.Text = "Dodaj kontrolki";
            this.btnAddControls.UseVisualStyleBackColor = true;
            this.btnAddControls.Click += new System.EventHandler(this.BtnAddControls_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Znajdź";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(131, 282);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Znajdź";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(69, 282);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(56, 22);
            this.txtFind.TabIndex = 10;
            // 
            // AddingControlsFromCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnCountControls);
            this.Controls.Add(this.pnlAddedControls);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAddControls);
            this.Name = "AddingControlsFromCode";
            this.Text = "AddingControlsFromCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCountControls;
        private System.Windows.Forms.Panel pnlAddedControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddControls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
    }
}