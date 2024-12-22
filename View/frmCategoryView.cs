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
using RM.Model;

namespace RM.View
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "Select * from category where catName like '%"+ txtsearch.Text +"%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView2, lb);
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();

        }
        public override void btnimage_CheckedChanged(object sender, EventArgs e)
        {
            MainClass.BlurBlackground(new frmCategoryAdd());
            //frmCategoryAdd frm = new frmCategoryAdd();
            //frm.ShowDialog();
            GetData();

        }
        public override void txtsearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView2.CurrentRow.Cells["dgvName"].Value);
                MainClass.BlurBlackground(frm);
                GetData();
 }
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialogView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialogView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialogView.Show("Are you sure that to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from category where catID=" + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);

                    guna2MessageDialogView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialogView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialogView.Show("Deleted Successfully");
                    GetData();
                }

            }

        }
    }
}
