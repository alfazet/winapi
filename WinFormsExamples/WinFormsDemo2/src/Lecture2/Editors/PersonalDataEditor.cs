using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lecture2.Infrastucture;
using Lecture2.Models;

namespace Lecture2.Editors
{
    public partial class PersonalDataEditor : Form, IBindable<PersonalDataEditorModel>
    {
        private PersonalDataEditorModel _bindContext;
        public PersonalDataEditor()
        {
            InitializeComponent();
        }

        public Task<bool> Bind(PersonalDataEditorModel bindContext)
        {
            _bindContext = bindContext;
            txtFirstName.DataBindings.Add("Text", _bindContext, "FirstName");
            txtLastName.DataBindings.Add("Text", _bindContext, "LastName");
            txtAdditionalFirstNames.DataBindings.Add("Text", _bindContext, "AdditionalFirstNames");
            txtAdditionalLastNames.DataBindings.Add("Text", _bindContext, "AdditionalLastNames");

            cbUseDash.DataBindings.Add("Checked", _bindContext, "UseDashBeetwenLastNames");
            rbMale.DataBindings.Add("Checked", _bindContext, "IsMale");
            rbFemale.DataBindings.Add("Checked", _bindContext, "IsFemale");
            rbUnknown.DataBindings.Add("Checked", _bindContext, "IsUnknown");

            clbRelations.DataSource = _bindContext.Relations;
            clbRelations.DisplayMember = "Name";
            clbRelations.ValueMember = "Name";
            for (int i = 0; i < clbRelations.Items.Count; i++)
            {
                clbRelations.SetItemChecked(i, ((RelationItem)clbRelations.Items[i]).IsChecked);
            }
            AvaliablityOfUseDash();
            return Task.FromResult(true);
        }

        public Task ClearBinding()
        {
            txtFirstName.DataBindings.Clear();
            txtLastName.DataBindings.Clear();
            txtAdditionalFirstNames.DataBindings.Clear();
            txtAdditionalLastNames.DataBindings.Clear();

            cbUseDash.DataBindings.Clear();
            rbMale.DataBindings.Clear();
            rbFemale.DataBindings.Clear();
            rbUnknown.DataBindings.Clear();

            clbRelations.DataSource = new List<RelationItem>();
            clbRelations.DisplayMember = "Name";
            clbRelations.ValueMember = "IsChecked";

            return Task.FromResult(true);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //_bindContext.Relations=
            for (int i = 0; i < clbRelations.Items.Count; i++)
            {
                var tmp = clbRelations.Items[i] as RelationItem;
                var toChangeSelection = _bindContext.Relations.FirstOrDefault(bc => bc.RelationType == tmp.RelationType);
                if(toChangeSelection!=null)
                    toChangeSelection.IsChecked = clbRelations.GetItemChecked(i);
            }
        }

        private void txtLastName_TextChanged(object sender, System.EventArgs e)
        {
            AvaliablityOfUseDash();

        }


        private void txtAdditionalLastNames_TextChanged(object sender, EventArgs e)
        {
            AvaliablityOfUseDash();
        }


        private void AvaliablityOfUseDash()
        {
            cbUseDash.Enabled = !string.IsNullOrEmpty(txtFirstName.Text)
                                && !string.IsNullOrEmpty(txtLastName.Text)
                                && !string.IsNullOrEmpty(txtAdditionalLastNames.Text)
                                && txtAdditionalLastNames.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Length == 1;
        }
    }
}
