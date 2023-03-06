using Bookstore.BusinessLayer;
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
    public partial class LoginForm : Form
    {
        private readonly EmployeeBusiness employeeBusiness;
        
        public LoginForm()
        {
            InitializeComponent();
            this.employeeBusiness = new EmployeeBusiness();
        }

        private void btAddEmployee_Click(object sender, EventArgs e)
        {
            var registration = new Register();
            registration.Show();
            this.Hide();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (this.employeeBusiness.LoginEmployee(tbUsername.Text, tbPassword.Text))
            {
                this.Hide();
                var bookstore = new Form1();
                bookstore.Show();
            }
            else
                MessageBox.Show("Invalid username or password");
        }
    }
}
