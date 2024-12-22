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
    public partial class frmStafffAdd : SampleAdd
    {
        public frmStafffAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO staff VALUES (@Name,@phone,@role)";

            }
            else
            {
                qry = "UPDATE staff SET sName = @Name,sPhone=@phone,sRole=@role WHERE staffID = @id";

            }
            Hashtable ht = new Hashtable();
            ht.Add("@Id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone",txtPhone.Text);
            ht.Add("@role",cbRole.Text);





            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved Successfully..");
                id = 0;
                txtPhone.Text = "";
                txtName.Text = "";
                cbRole.SelectedIndex = -1;
                txtName.Focus();
            }

        }

    }
}
