﻿namespace RM.View
{
    partial class frmReport
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
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStaff = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaleCat = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.AutoRoundedCorners = true;
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnMenu.BorderRadius = 39;
            this.btnMenu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnMenu.FillColor = System.Drawing.Color.Transparent;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = global::RM.Properties.Resources.home;
            this.btnMenu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMenu.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnMenu.Location = new System.Drawing.Point(39, 63);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(180, 81);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "MENU LIST";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reports";
            // 
            // btnStaff
            // 
            this.btnStaff.AutoRoundedCorners = true;
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnStaff.BorderRadius = 39;
            this.btnStaff.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStaff.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnStaff.FillColor = System.Drawing.Color.Transparent;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = global::RM.Properties.Resources.home;
            this.btnStaff.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStaff.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnStaff.Location = new System.Drawing.Point(264, 63);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(180, 81);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "STAFF LIST";
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnSaleCat
            // 
            this.btnSaleCat.AutoRoundedCorners = true;
            this.btnSaleCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnSaleCat.BorderRadius = 39;
            this.btnSaleCat.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSaleCat.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnSaleCat.FillColor = System.Drawing.Color.Transparent;
            this.btnSaleCat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaleCat.ForeColor = System.Drawing.Color.White;
            this.btnSaleCat.Image = global::RM.Properties.Resources.home;
            this.btnSaleCat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSaleCat.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnSaleCat.Location = new System.Drawing.Point(529, 63);
            this.btnSaleCat.Name = "btnSaleCat";
            this.btnSaleCat.Size = new System.Drawing.Size(227, 81);
            this.btnSaleCat.TabIndex = 6;
            this.btnSaleCat.Text = "SALE BY CATEGORY";
            this.btnSaleCat.Click += new System.EventHandler(this.btnSaleCat_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 437);
            this.Controls.Add(this.btnSaleCat);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnStaff;
        private Guna.UI2.WinForms.Guna2Button btnSaleCat;
    }
}