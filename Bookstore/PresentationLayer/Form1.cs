using Bookstore.BusinessLayer;
using Bookstore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class Form1 : Form
    {
        private readonly ItemBusiness itemBusiness;
        public Form1()
        {
            InitializeComponent();
            this.itemBusiness = new ItemBusiness();
        }
        private void btInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTitle.Text != "" && tbPrice.Text != "" && tbQuantity.Text != "" && cbCategory.SelectedIndex != -1)
                {
                    Item i = new Item();
                    i.title = tbTitle.Text;
                    i.price = double.Parse(tbPrice.Text);
                    i.quantity = int.Parse(tbQuantity.Text);
                    i.description = tbDescription.Text;
                    i.insert_date = DateTime.Now;
                    i.category = cbCategory.Text;
                    this.itemBusiness.InsertItem(i);
                    BindData();
                    tbTitle.Text = "";
                    tbPrice.Text = "";
                    tbQuantity.Text = "";
                    tbDescription.Text = "";
                    cbCategory.SelectedIndex = -1;
                }
                else
                { 
                    MessageBox.Show("Fill required feilds");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Invalid format.");
            }
        }

        void BindData()
        {
            List<Item> items = this.itemBusiness.GetAllItems();
            dgwShow.DataSource = items;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbId.Text == "")
                {
                    MessageBox.Show("You must select the item to update.");
                }
                else if (tbTitle.Text != "" && tbPrice.Text != "" && tbQuantity.Text != "" && cbCategory.SelectedIndex != -1)
                {
                    Item i = new Item();
                    i.id = int.Parse(tbId.Text);
                    i.title = tbTitle.Text;
                    i.price = double.Parse(tbPrice.Text);
                    i.quantity = int.Parse(tbQuantity.Text);
                    i.description = tbDescription.Text;
                    i.insert_date = DateTime.Now;
                    i.category = cbCategory.Text;
                    this.itemBusiness.UpdateItem(i);
                    MessageBox.Show("Update successful.");
                }
                else
                {
                    MessageBox.Show("Fill required feilds");
                }
                BindData();
                tbTitle.Text = "";
                tbPrice.Text = "";
                tbQuantity.Text = "";
                tbDescription.Text = "";
                cbCategory.SelectedIndex = -1;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format.");
            }
            catch
            {
                MessageBox.Show("Invalid format.");
            }
            
        }

        private void dgwShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                DataGridViewRow row = dgwShow.Rows[e.RowIndex];
                tbTitle.Text = row.Cells[1].Value.ToString();
                tbId.Text = row.Cells[0].Value.ToString();
                tbPrice.Text = row.Cells[2].Value.ToString();
                tbQuantity.Text = row.Cells[3].Value.ToString();
                tbDescription.Text = row.Cells[4].Value.ToString();
                cbCategory.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbId.Text != "")
            {
                if (MessageBox.Show("Are you sure to delete?", "Delete item", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.itemBusiness.DeleteItem(int.Parse(tbId.Text));
                    BindData();
                    tbTitle.Text = "";
                    tbPrice.Text = "";
                    tbQuantity.Text = "";
                    tbDescription.Text = "";
                    cbCategory.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("You must select the item to delete");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            List<Item> items = this.itemBusiness.SearchItems(tbSearch.Text);
            dgwShow.DataSource = items;
            tbSearch.Text = "";
        }
    }
}
