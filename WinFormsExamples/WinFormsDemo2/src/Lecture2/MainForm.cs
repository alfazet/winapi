using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Domain;
using ContactsApp.Domain.Repositories;
using Lecture2.Controls;
using Lecture2.Models;

namespace Lecture2
{
    public partial class MainForm : Form
    {
        private readonly IContactInfoRepository _contactInfoRepository = new ContactInfoRepository();

        public MainForm()
        {
            InitializeComponent();

            //This doesn't work properly:( 
            //AddColumnsProgramical();

            //dataGridView1.DataSource = _contactInfos.Select(c => new ContactInfoModel(c)).ToList();
            dataGridView1.AutoGenerateColumns = false;
            var binary = File.ReadAllBytes(@"../../../../resources/male.jpg");
            using (MemoryStream memoryStream = new MemoryStream(binary))
            {
                var a= Bitmap.FromStream(memoryStream);
                a = new Bitmap(a, customControl1.Width, customControl1.Height);
                customControl1.BackColor = Color.Red;
                customControl1.Picture = a;
                customControl1.ImageCroppingType = CroppingType.Circle;
                customControl1.UpdatePeriod = 100;
                customControl1.PercentChange = 1;
                customControl1.ImageCroppingMode = CroppingMode.Automatic;
            }

            //This doesn't work too :(
            //AddColumnsProgramical();

        }

        private void AddColumnsProgramatically()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "ContactId",
                    HeaderText = "Id",
                    DataPropertyName = "Id",
                    Visible = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    ReadOnly = true
                }
            );
            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "ContactInfoName",
                    HeaderText = "Name",
                    DataPropertyName = "Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    ReadOnly = true
                }
            );
            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn()
                {
                    Name = "ContactInfoPhoneNumber",
                    HeaderText = "Phone number",
                    DataPropertyName = "PhoneNumber",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    ReadOnly = true
                }
            );
            dataGridView1.Columns.Add(
                new DataGridViewButtonColumn()
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    ReadOnly = true,
                }
            );

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private async void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsEditButton(e) && btnEdit.Enabled)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells["ContactId"].Value as Guid?;
                await Edit(id);
            }
        }



        private bool IsEditButton(DataGridViewCellEventArgs e)
        {
            var column = dataGridView1.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
            if (column != null && e.RowIndex != -1 && column.Text == "Edit")
            {
                return true;
            }
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //This work properly:)
            AddColumnsProgramatically();
        }

        private async Task<IEnumerable<ContactInfoModel>> DownloadData()
        {
            var result = Task.Run(
                () =>
                {
                    Thread.Sleep(1000);
                    return _contactInfoRepository.GetAll().Select(c => new ContactInfoModel(c)).AsEnumerable();
                });

            return await result;

        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            var result = await DownloadData();
            dataGridView1.DataSource = result.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                btnEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow.DataBoundItem as ContactInfoModel;
            if (row != null)
            {
                await Edit(row.Id);
            }
        }

        private async Task<bool> Edit(Guid? id)
        {
            var data = GetFromDb(id);
            ContactPreview personalForm = new ContactPreview();
            bool result = false;
            if (id.HasValue)
            {
                btnEdit.Enabled = false;
                await personalForm.Bind(new ContactInfoModel(await data));
                result = personalForm.ShowDialog() == DialogResult.OK;
                btnEdit.Enabled = true;
            }

            return result;
        }

        private async Task<ContactInfo> GetFromDb(Guid? id)
        {
            return await Task.Run(() =>
            {
                if (!id.HasValue)
                    return null;
                var entity = _contactInfoRepository.GetById(id.Value);
                Thread.Sleep(1000);
                return entity;
            });
        }
    }
}
