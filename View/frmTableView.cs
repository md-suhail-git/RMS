﻿using System;
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
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }

        private void frmTableView_Load(object sender, EventArgs e)
        {
            GetData();

        }
        public void GetData()
        {
            string qry = "Select * from tables where tname like '%" + txtsearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView2, lb);
        }
        public override void btnimage_CheckedChanged(object sender, EventArgs e)
        {
            //frmTableAdd frm = new frmTableAdd();
            //frm.ShowDialog();
            MainClass.BlurBlackground(new frmTableAdd());
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
                frm.ShowDialog();
                GetData();
            }
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialogView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialogView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialogView.Show("Are you sure that to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from tables where tID=" + id + "";
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
