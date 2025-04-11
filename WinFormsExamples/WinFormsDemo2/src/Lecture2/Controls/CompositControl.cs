using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lecture2.Infrastucture;
using Lecture2.Models;

namespace Lecture2.Controls
{
    public partial class CompositControl : UserControl, IBindable<AddressModel>
    {
        public CompositControl()
        {
            InitializeComponent();
            MaximumSize = new Size(500, 95);
            MinimumSize = new Size(400, 90);
        }

        public Task<bool> Bind(AddressModel bindContext)
        {
            txtCity.DataBindings.Add("Text", bindContext, "City");
            txtStreet.DataBindings.Add("Text", bindContext, "Street");
            txtFlatNo.DataBindings.Add("Text", bindContext, "FlatNumber");
            txtHouseNo.DataBindings.Add("Text", bindContext, "HouseNumber");
            return Task.FromResult(true);
        }

        public Task ClearBinding()
        {
            txtCity.DataBindings.Clear();
            txtStreet.DataBindings.Clear();
            txtFlatNo.DataBindings.Clear();
            txtHouseNo.DataBindings.Clear();
            return Task.CompletedTask;
        }
    }
}
