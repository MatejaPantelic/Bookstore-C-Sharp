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
    public partial class Register : Form
    {
        private readonly EmployeeBusiness employeeBusiness;
        public Register()
        {
            InitializeComponent();
            this.employeeBusiness = new EmployeeBusiness();
        }
        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text != "" && tbSurname.Text != "" && tbPhone.Text != "" && tbEmail.Text != "" && tbUsername.Text != "" && tbPassword.Text != "" && tbPassword.Text != "")
                {
                    if (tbPassword.Text == tbConfirm.Text)
                    {
                        Employee emp = new Employee();
                        emp.name = tbName.Text;
                        emp.surname = tbSurname.Text;
                        emp.birth_date = dtpBirthDate.Value;
                        emp.phone = tbPhone.Text;
                        emp.email = tbEmail.Text;
                        emp.username = tbUsername.Text;
                        emp.password = tbPassword.Text.Trim();
                        this.employeeBusiness.InsertEmployee(emp);

                        tbName.Text = "";
                        tbSurname.Text = "";
                        tbPhone.Text = "";
                        tbEmail.Text = "";
                        tbUsername.Text = "";
                        tbPassword.Text = "";
                        tbConfirm.Text = "";
                        dtpBirthDate.Value = DateTime.Now;
                        MessageBox.Show("Successful registration.");
                        var login = new LoginForm();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Passwords are not equal.");
                        tbPassword.Text = "";
                        tbConfirm.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Fill required feilds");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format.");
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
