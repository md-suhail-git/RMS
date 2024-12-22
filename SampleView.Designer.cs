namespace RM
{
    partial class SampleView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnimage = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2MessageDialogView = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(693, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // btnimage
            // 
            this.btnimage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnimage.CheckedState.BorderThickness = 0;
            this.btnimage.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnimage.CheckedState.InnerColor = System.Drawing.Color.White;
            this.btnimage.Location = new System.Drawing.Point(24, 66);
            this.btnimage.Name = "btnimage";
            this.btnimage.Size = new System.Drawing.Size(56, 51);
            this.btnimage.TabIndex = 2;
            this.btnimage.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnimage.UncheckedState.BorderThickness = 2;
            this.btnimage.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnimage.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.btnimage.CheckedChanged += new System.EventHandler(this.btnimage_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category List";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(24, 123);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1038, 19);
            this.guna2Separator1.TabIndex = 4;
            // 
            // txtsearch
            // 
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.IconRight = global::RM.Properties.Resources.serach1;
            this.txtsearch.Location = new System.Drawing.Point(696, 68);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PlaceholderText = "Search Here";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(364, 47);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // guna2MessageDialogView
            // 
            this.guna2MessageDialogView.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialogView.Caption = "RMS";
            this.guna2MessageDialogView.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.guna2MessageDialogView.Parent = null;
            this.guna2MessageDialogView.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialogView.Text = null;
            // 
            // SampleView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 588);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnimage);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SampleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SampleView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2CustomRadioButton btnimage;
        public Guna.UI2.WinForms.Guna2TextBox txtsearch;
        public Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialogView;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}