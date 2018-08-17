using Entity;
using MonopoliyBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolyUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Id = Convert.ToInt64(this.tbxId.Text);
            emp.Name = this.tbxName.Text;

            EmployeeBusiness empBus = new EmployeeBusiness();
            empBus.Save(emp);

            this.tbxName.Clear();
            this.tbxId.Clear();

            this.LoadGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        private void LoadGrid()
        {
            EmployeeBusiness emp = new EmployeeBusiness();
            this.dtgvwEmployees.DataSource = emp.LoadEmployee();
        }
    }
}
