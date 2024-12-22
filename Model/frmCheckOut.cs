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

namespace RM.Model
{
    public partial class frmCheckOut : SampleAdd
    {
        public frmCheckOut()
        {
            InitializeComponent();
        }
        public double amt;
        public int MainID = 0;

        private void txtPaymentReceived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            double.TryParse(txtBillAmount.Text,out amt);
            double.TryParse(txtPaymentReceived.Text,out receipt);

            change =Math.Abs(amt - receipt);
            txtChange.Text = change.ToString();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set total=@total,
                          received=@rec,
                     change=@change,status='Paid' where mainID=@id";
            Hashtable ht = new Hashtable();
            ht.Add(@"id", MainID);
            ht.Add(@"total",txtBillAmount.Text);
            ht.Add(@"rec", txtPaymentReceived.Text);
            ht.Add(@"change",txtChange.Text);

            if (MainClass.SQL(qry,ht)>0)
            {
                guna2MessageDialog1.Buttons=Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Saved Successfully");
                this.Close();   

            }

        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text=amt.ToString();      
        }
    }
}
