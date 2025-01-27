﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RM.Reports;

namespace RM.Model
{
    public partial class frmBillList : SampleAdd
    {
        public frmBillList()
        {
            InitializeComponent();
        }
        public int MainID = 0;

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            string qry = @"select MainID,TableName,WaiterName,orderType,status,total from tblMain where status <> 'pending' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);


            MainClass.LoadData(qry, guna2DataGridView2, lb);
        }
        private void guna2DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                MainID = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                this.Close();
            }
            if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                MainID = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dgvid"].Value);
                string qry =
                @"Select * from tblMain m inner join tblDetails d on d.MainID=m.MainID
                inner join products p on p.PID=d.proID where m.MainID = " + MainID + " ";
                SqlCommand cmd = new SqlCommand(qry,MainClass.con);
                MainClass.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                MainClass.con.Close();
                frmPrint frm=new frmPrint();
                rptBill cr =new rptBill();

                cr.SetDatabaseLogon("sa","Jaihind777#");
                cr.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource=cr;
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            }

        }
    }
}
