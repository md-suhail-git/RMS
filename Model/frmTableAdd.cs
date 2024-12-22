using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO tables  VALUES(@Name)";

            }
            else
            {
                qry = "UPDATE tables SET tname = @Name WHERE tId = @id";

            }
            Hashtable ht = new Hashtable();
            ht.Add("@Id", id);
            ht.Add("@Name", txtName.Text);
            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved Successfully..");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }

        }

    }
}
