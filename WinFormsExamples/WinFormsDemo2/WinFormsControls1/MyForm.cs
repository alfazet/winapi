using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControls1.Properties;

namespace WinFormsControls1
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            if (Settings.Default.autoLoad)
            {
                tbName.Text = Settings.Default.name;
                tbEmail.Text = Settings.Default.email;
            }
        }

        private void bgwSaving_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 10; ++i)
            {
                bgwSaving.ReportProgress(i * 10);
                Thread.Sleep(500);
                if (bgwSaving.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            e.Result = Resources.finishedMessage;
        }

        private void bgwSaving_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void bgwSaving_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Settings.Default.name = tbName.Text;
            Settings.Default.email = tbEmail.Text;
            Settings.Default.Save();
            MessageBox.Show(this, e.Cancelled ? Resources.cancelledMessage : e.Result as string, Resources.messageTitle);
            ClearForm();
            EnableForm();
        }

        private void EnableForm(bool enabled = true)
        {
            tbName.Enabled = enabled;
            tbEmail.Enabled = enabled;
            btnSave.Enabled = enabled;
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
        }

        private void ClearForm()
        {
            tbName.Clear();
            err.SetError(tbName, string.Empty);
            tbEmail.Clear();
            err.SetError(tbEmail, string.Empty);
            lblStatus.Text = Resources.prompt;
            progress.Visible = false;
            progress.Value = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwSaving.IsBusy)
                bgwSaving.CancelAsync();
            else
                ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                EnableForm(false);
                lblStatus.Text = Resources.progress;
                progress.Visible = true;
                bgwSaving.RunWorkerAsync();
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                e.Cancel = true;
                err.SetError(tbName, Resources.nameError);
            }
        }

        private void tbValidated(object sender, EventArgs e)
        {
            err.SetError(sender as Control, string.Empty);
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidEmailAddress(tbEmail.Text))
            {
                e.Cancel = true;
                err.SetError(tbEmail, Resources.emailError);
                tbEmail.SelectAll();
            }
        }

        public bool ValidEmailAddress(string emailAddress)
        {
            // Confirm that the email address string is not empty.
            if (emailAddress.Length == 0)
                return false;

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                    return true;
            return false;
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
