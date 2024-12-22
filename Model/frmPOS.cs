using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RM.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        public int MainID = 0;
        public string objectType = "";
        public int driverID = 0;
        public string customerName = "";
        public string customerPhone = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView2.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            ProductPanel.Controls.Clear();
            LoadProducts();
        }
        private void AddCategory()
        {
            string qry = "Select * from category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CategoryPanel.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(134, 35);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    b.Click += new EventHandler(_Click);
                    CategoryPanel.Controls.Add(b);
                }

            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;

            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string proID, string name, string cat, string price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(proID)

            };
            ProductPanel.Controls.Add(w);
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in guna2DataGridView2.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                     double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        return;
                        //guna2DataGridView2.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                    }


                }
                guna2DataGridView2.Rows.Add(new object[] { 0, 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });

                GetTotal();


            };

        }
        private void LoadProducts()
        {
            string qry = "Select * from products inner join category on catID = CategoryID ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {

                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;

                AddItems("0", item["pID"].ToString(),
                    item["pName"].ToString(),
                    item["catName"].ToString(),
                    item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray))
                );
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtsearch.Text.Trim().ToLower());
            }
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
        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView2.Rows)
            {
                tot = tot + double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text = tot.ToString("N2");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView2.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "00";

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            objectType = "Delivery";


            frmAddCustomer frm = new frmAddCustomer();
            frm.MainID = MainID;
            frm.objectType = objectType;
            MainClass.BlurBlackground(frm);
            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriver.Text = "Customer Name: " + frm.txtName.Text + "Phone: " + frm.txtPhone.Text + " Driver: " + frm.cbDriver.Text;
                lblDriver.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {

            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            objectType = "Take Away";

            frmAddCustomer frm = new frmAddCustomer();
            frm.MainID = MainID;
            frm.objectType = objectType;
            MainClass.BlurBlackground(frm);
            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriver.Text = "Customer Name: " + frm.txtName.Text + "Phone: " + frm.txtPhone.Text;
                lblDriver.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }

        }

        private void btnDin_Click(object sender, EventArgs e)
        {
            objectType = "Din In";
            lblDriver.Visible = false;


            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBlackground(frm);
            if (frm.TableName != "")
            {
                lblTable.Text = frm.TableName;
                lblTable.Visible = true;

            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }
            frmWaiterSelect frm2 = new frmWaiterSelect();
            MainClass.BlurBlackground(frm2);
            if (frm2.WaiterName != "")
            {
                lblWaiter.Text = frm2.WaiterName;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }

        }

        private void btnKOT_Click(object sender, EventArgs e)
        {
            string qry1 = "";
            string qry2 = "";
            int detailID = 0;


            if (MainID == 0)
            {
                qry1 = @"Insert into tblMain Values (@aDate,@aTime,@TableName,@WaiterName,
            @status, @orderType,@total,@received,@change,@driverID,@CustName,@CustPhone);
            Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = @"Update tblMain Set status = @status, total = @total,
            received =@ received, change = @change where MainID = @ID)";
            }
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@orderType", objectType);
            //doubt if is error exist check here
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CustName", customerName);
            cmd.Parameters.AddWithValue("@CustPhone", customerPhone);


            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0)
            {
                MainID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);
                if (detailID == 0)
                {
                    qry2 = @"Insert into tblDetails Values(@MainID,@proID,@qty,@price,@amount)";
                }
                else
                {
                    qry2 = @"Update tblDetails Set proID=@proID,qty=@qty,price=@price,amount=@amount where DetailID=@ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));


                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                guna2MessageDialog1.Show("Saved SuccessFully");
                MainID = 0;
                detailID = 0;
                guna2DataGridView2.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "00";
                lblDriver.Text = "";


            }
        }
        public int id = 0;
        private void btnBill_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList();
            MainClass.BlurBlackground(frm);

            if (frm.MainID > 0)
            {
                id = frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
            }

        }

        private void LoadEntries()
        {
            string qry = @"Select * from tblMain m inner join tblDetails d on m.MainID =d.MainID
                                                         inner join products p on p.pID=d.proID where m.MainID = " + id + " ";
            SqlCommand cmd2 = new SqlCommand(qry, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            if (dt2.Rows[0]["orderType"].ToString() == "Delivery")
            {
                btnDelivery.Visible = true;
                lblWaiter.Visible = false;
                lblTotal.Visible = false;
            }
            else if (dt2.Rows[0]["orderType"].ToString() == "Take away")
            {
                btnTake.Visible = true;
                lblWaiter.Visible = false;
                lblTotal.Visible = false;
            }
            else
            {
                btnDin.Visible = true;
                lblWaiter.Visible = false;
                lblTotal.Visible = false;
            }

            guna2DataGridView2.Rows.Clear();


            foreach (DataRow item in dt2.Rows)
            {

                lblTable.Text = item["TableName"].ToString();
                lblWaiter.Text = item["WaiterName"].ToString();
                string detailid = item["DetailID"].ToString();
                string proName = item["pName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["price"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();


                object[] obj = { 0, detailid, proid, proName, qty, price, amount };
                guna2DataGridView2.Rows.Add(obj);

            }
            GetTotal();

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            frmCheckOut frm = new frmCheckOut();
            frm.MainID = id;
            frm.amt = Convert.ToDouble(lblTotal.Text);
            MainClass.BlurBlackground(frm);

            //guna2MessageDialog1.Show("Saved SuccessFully");
            MainID = 0;
            guna2DataGridView2.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00";

        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            string qry1 = "";
            string qry2 = "";
            int detailID = 0;

            if (objectType == "")
            {
                guna2MessageDialog1.Show("Please select order Type");
                return;
            }


            if (MainID == 0)
            {
                qry1 = @"Insert into tblMain Values (@aDate,@aTime,@TableName,@WaiterName,
            @status, @orderType,@total,@received,@change,@driverID,@CustName,@CustPhone);
            Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = @"Update tblMain Set status = @status, total = @total,
            received =@ received, change = @change where MainID = @ID";
            }
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Hold");
            cmd.Parameters.AddWithValue("@orderType", objectType);
            //doubt if is error exist check here
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CustName", customerName);
            cmd.Parameters.AddWithValue("@CustPhone", customerPhone);


            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0)
            {
                MainID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);
                if (detailID == 0)
                {
                    qry2 = @"Insert into tblDetails Values(@MainID,@proID,@qty,@price,@amount)";
                }
                else
                {
                    qry2 = @"Update tblDetails Set proID=@proID,qty=@qty,price=@price,amount=@amount where DetailID=@ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));


                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                guna2MessageDialog1.Show("Saved SuccessFully");
                MainID = 0;
                detailID = 0;
                guna2DataGridView2.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "00";
                lblDriver.Text = "";


            }
        }
    }
}
