using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ContactsApp.Domain;
using ContactsApp.Domain.Shared;
using Lecture2.Models;

namespace Lecture2
{
    public partial class PersonalForm : Form
    {
        private ContactInfoModel _entityModel;

        public PersonalForm()
        {
            InitializeComponent();
        }

        public void Bind(ContactInfo model)
        {
            _entityModel = new ContactInfoModel(model);
            txtName.DataBindings.Add("Text", _entityModel, "FirstName");
            txtSurname.DataBindings.Add("Text", _entityModel, "LastName");
            //rbUnknown.DataBindings.Add("Checked", _entityModel, "HasUnknowSex");
            //rbMale.DataBindings.Add("Checked", _entityModel, "IsMale");
            //rbFemale.DataBindings.Add("Checked", _entityModel, "IsFemale");
            //dpDateOfBirth.DataBindings.Add("Value", _entityModel, "DateOfBirth");
            //cbHasDate.DataBindings.Add("Checked", _entityModel, "HasNoDateOfBirth");
            cbHasDate.CheckedChanged += CbHasDate_CheckedChanged;
            dpDateOfBirth.MinDate=DateTime.MinValue;
            pbPhoto.Image = _entityModel.Picture;
            mtxtPhoneNumber.Mask = Consts.PhoneRegex;

        }

        private void CbHasDate_CheckedChanged(object sender, System.EventArgs e)
        {
            dpDateOfBirth.Enabled = !((CheckBox) sender).Checked;
        }

        private void btnUploadPhoto_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog uploadFile = new OpenFileDialog();
            uploadFile.Multiselect = false;
            uploadFile.CheckFileExists = true;
            uploadFile.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            if (uploadFile.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = Image.FromFile(uploadFile.FileName);
                //_entityModel.Picture = pbPhoto.Image;
            }
        }

        private void btnChangeAdress_Click(object sender, EventArgs e)
        {

        }
    }
}
