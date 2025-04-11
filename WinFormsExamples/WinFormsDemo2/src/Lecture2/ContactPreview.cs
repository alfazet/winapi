using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Domain.Commands;
using ContactsApp.Domain.Events;
using ContactsApp.Domain.Repositories;
using Lecture2.Editors;
using Lecture2.Infrastucture;
using Lecture2.Models;

namespace Lecture2
{
    public partial class ContactPreview : Form, IBindable<ContactInfoModel>
    {
        private ContactInfoModel _bindingContext;
        private IContactInfoRepository _contactInfoRepository=new ContactInfoRepository();
        public ContactPreview()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        public Task<bool> Bind(ContactInfoModel bindContext)
        {
            _bindingContext = bindContext;
            //lblName.Texts
            lblName.DataBindings.Add("Text", _bindingContext, "Name");
            lblPrimaryPhone.DataBindings.Add("Text", _bindingContext, "PhoneNumber");
            lblAddress.DataBindings.Add("Text", _bindingContext, "AddressDisplay");
            lblBirthDate.DataBindings.Add("Text", _bindingContext, "DateOfBirthDisplay");
            lblFirstNames.DataBindings.Add("Text", _bindingContext, "FirstName");
            lblSurnames.DataBindings.Add("Text", _bindingContext, "LastName");
            lblSex.DataBindings.Add("Text", _bindingContext, "SexDisplay");
            lblRelation.DataBindings.Add("Text", _bindingContext, "RelationshipDisplay");

            pictureBox1.Image = _bindingContext.Picture;
            pictureBox1.Refresh();

            if (_bindingContext.AlterantePhonse!=null)
            {
                foreach (var phone in _bindingContext.AlterantePhonse)
                {
                    panel1.Controls.Add(new Label()
                    {
                        Text = phone,
                        AutoSize = true
                    });
                }
            }

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            if (_bindingContext.Emails != null)
            {
                foreach (var email in _bindingContext.Emails)
                {
                    flowLayoutPanel1.Controls.Add(new Label()
                    {
                        Text = email,
                        AutoSize = true
                    });
                }
            }

            return Task.FromResult(true);
        }

        public Task ClearBinding()
        {
            foreach (Control control in Controls)
            {
                if (control.DataBindings.Count > 0)
                {
                    Binding toDeleateBinding=null;
                    for (int i = 0; i < control.DataBindings.Count; i++)
                    {
                        if (control.DataBindings[i].DataSource == _bindingContext)
                        {
                            toDeleateBinding = control.DataBindings[i];
                            break;
                        }
                    }
                    if (toDeleateBinding != null)
                    {
                        control.DataBindings.Remove(toDeleateBinding);
                    }
                }
            }

            lblName.DataBindings.Clear();
            lblPrimaryPhone.DataBindings.Clear();
            lblAddress.DataBindings.Clear();
            lblBirthDate.DataBindings.Clear();
            lblFirstNames.DataBindings.Clear();
            lblSurnames.DataBindings.Clear();
            lblSex.DataBindings.Clear();
            lblRelation.DataBindings.Clear();
            flowLayoutPanel1.Controls.Clear();
            panel1.Controls.Clear();
            _bindingContext = null;
            return Task.CompletedTask;

        }

        private async void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadPhoto=new OpenFileDialog();
            uploadPhoto.CheckFileExists = true;
            uploadPhoto.Filter= "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            if (uploadPhoto.ShowDialog() == DialogResult.OK)
            {
                //await Dispatchers.RiseCommand(
                //    new PhotoChanging(_bindingContext.Id.Value
                //        , File.ReadAllBytes(uploadPhoto.FileName)
                //        , uploadPhoto.FileName));
                await RefreshBinding();
            }
        }

        private async Task RefreshBinding()
        {
            var model = new ContactInfoModel(_contactInfoRepository.GetById(_bindingContext.Id.Value));
            await ClearBinding();
            await Bind(model);
        }

        private async void btnEditPersonalData_Click(object sender, EventArgs e)
        {
            if(!_bindingContext.Id.HasValue)
                return;
            using (PersonalDataEditor editor = new PersonalDataEditor())
            {
                var aggreage= _contactInfoRepository.GetById(_bindingContext.Id.Value);
                var model = new PersonalDataEditorModel(aggreage);
                await editor.Bind(model);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    //await Dispatchers.RiseCommand(new PersonalDataChanging(aggreage.Id, model.CreateValueObject()));
                    await RefreshBinding();
                }
            }
        }
    }
}
