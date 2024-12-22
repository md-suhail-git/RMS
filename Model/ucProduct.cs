using System;
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
    
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;
        public int id {  get; set; }    
        public string PPrice {  get; set; } 
        public string PCategory {  get; set; }
        public string PName {
            get {  return lblProductName.Text; }
            set {lblProductName.Text=value; } 
        }


        public Image PImage
        {
            get { return lblProductName.Image; }
            set { txtImage.Image = value; }
        }

        

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void txtImage_Click_1(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);

        }
    }
}
