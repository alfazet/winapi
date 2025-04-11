namespace WinFormsControls1
{
    partial class MyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.bgwSaving = new System.ComponentModel.BackgroundWorker();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // err
            // 
            this.err.ContainerControl = this;
            resources.ApplyResources(this.err, "err");
            // 
            // status
            // 
            resources.ApplyResources(this.status, "status");
            this.err.SetError(this.status, resources.GetString("status.Error"));
            this.err.SetIconAlignment(this.status, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("status.IconAlignment"))));
            this.err.SetIconPadding(this.status, ((int)(resources.GetObject("status.IconPadding"))));
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progress});
            this.status.Name = "status";
            this.tip.SetToolTip(this.status, resources.GetString("status.ToolTip"));
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // progress
            // 
            resources.ApplyResources(this.progress, "progress");
            this.progress.Name = "progress";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.err.SetError(this.lblName, resources.GetString("lblName.Error"));
            this.err.SetIconAlignment(this.lblName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblName.IconAlignment"))));
            this.err.SetIconPadding(this.lblName, ((int)(resources.GetObject("lblName.IconPadding"))));
            this.lblName.Name = "lblName";
            this.tip.SetToolTip(this.lblName, resources.GetString("lblName.ToolTip"));
            // 
            // lblEmail
            // 
            resources.ApplyResources(this.lblEmail, "lblEmail");
            this.err.SetError(this.lblEmail, resources.GetString("lblEmail.Error"));
            this.err.SetIconAlignment(this.lblEmail, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblEmail.IconAlignment"))));
            this.err.SetIconPadding(this.lblEmail, ((int)(resources.GetObject("lblEmail.IconPadding"))));
            this.lblEmail.Name = "lblEmail";
            this.tip.SetToolTip(this.lblEmail, resources.GetString("lblEmail.ToolTip"));
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.err.SetError(this.btnSave, resources.GetString("btnSave.Error"));
            this.err.SetIconAlignment(this.btnSave, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnSave.IconAlignment"))));
            this.err.SetIconPadding(this.btnSave, ((int)(resources.GetObject("btnSave.IconPadding"))));
            this.btnSave.Name = "btnSave";
            this.tip.SetToolTip(this.btnSave, resources.GetString("btnSave.ToolTip"));
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.err.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.err.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.err.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.tip.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.err.SetError(this.tbName, resources.GetString("tbName.Error"));
            this.err.SetIconAlignment(this.tbName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbName.IconAlignment"))));
            this.err.SetIconPadding(this.tbName, ((int)(resources.GetObject("tbName.IconPadding"))));
            this.tbName.Name = "tbName";
            this.tip.SetToolTip(this.tbName, resources.GetString("tbName.ToolTip"));
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            this.tbName.Validated += new System.EventHandler(this.tbValidated);
            // 
            // tbEmail
            // 
            resources.ApplyResources(this.tbEmail, "tbEmail");
            this.err.SetError(this.tbEmail, resources.GetString("tbEmail.Error"));
            this.err.SetIconAlignment(this.tbEmail, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbEmail.IconAlignment"))));
            this.err.SetIconPadding(this.tbEmail, ((int)(resources.GetObject("tbEmail.IconPadding"))));
            this.tbEmail.Name = "tbEmail";
            this.tip.SetToolTip(this.tbEmail, resources.GetString("tbEmail.ToolTip"));
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            this.tbEmail.Validated += new System.EventHandler(this.tbValidated);
            // 
            // bgwSaving
            // 
            this.bgwSaving.WorkerReportsProgress = true;
            this.bgwSaving.WorkerSupportsCancellation = true;
            this.bgwSaving.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSaving_DoWork);
            this.bgwSaving.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSaving_ProgressChanged);
            this.bgwSaving.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSaving_RunWorkerCompleted);
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 5000;
            this.tip.InitialDelay = 500;
            this.tip.ReshowDelay = 100;
            // 
            // MyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CausesValidation = false;
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.status);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MyForm";
            this.tip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.ComponentModel.BackgroundWorker bgwSaving;
        private System.Windows.Forms.ToolTip tip;
    }
}

