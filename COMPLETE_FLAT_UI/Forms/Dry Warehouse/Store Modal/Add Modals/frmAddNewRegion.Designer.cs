﻿
namespace ULTRAMAVERICK.Forms.Dry_Warehouse.Store_Modal.Add_Modals
{
    partial class frmAddNewRegion
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.matTxtRegion = new MaterialSkin.Controls.MaterialTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.matbtnSave = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.matTxtRegion);
            this.materialCard1.Controls.Add(this.textBox1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(34, 88);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(495, 200);
            this.materialCard1.TabIndex = 476;
            // 
            // matTxtRegion
            // 
            this.matTxtRegion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matTxtRegion.Depth = 0;
            this.matTxtRegion.Font = new System.Drawing.Font("Roboto", 12F);
            this.matTxtRegion.Hint = "Region";
            this.matTxtRegion.Location = new System.Drawing.Point(42, 72);
            this.matTxtRegion.MaxLength = 50;
            this.matTxtRegion.MouseState = MaterialSkin.MouseState.OUT;
            this.matTxtRegion.Multiline = false;
            this.matTxtRegion.Name = "matTxtRegion";
            this.matTxtRegion.Size = new System.Drawing.Size(401, 50);
            this.matTxtRegion.TabIndex = 0;
            this.matTxtRegion.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(130, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 13);
            this.textBox1.TabIndex = 478;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // matbtnSave
            // 
            this.matbtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matbtnSave.Depth = 0;
            this.matbtnSave.DrawShadows = true;
            this.matbtnSave.HighEmphasis = true;
            this.matbtnSave.Icon = null;
            this.matbtnSave.Location = new System.Drawing.Point(470, 305);
            this.matbtnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.matbtnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.matbtnSave.Name = "matbtnSave";
            this.matbtnSave.Size = new System.Drawing.Size(58, 36);
            this.matbtnSave.TabIndex = 477;
            this.matbtnSave.Text = "Save";
            this.matbtnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.matbtnSave.UseAccentColor = false;
            this.matbtnSave.UseVisualStyleBackColor = true;
            this.matbtnSave.Click += new System.EventHandler(this.matbtnSave_Click);
            // 
            // frmAddNewRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 357);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.matbtnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewRegion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Region";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddNewRegion_FormClosed);
            this.Load += new System.EventHandler(this.frmAddNewRegion_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox matTxtRegion;
        private System.Windows.Forms.TextBox textBox1;
        private MaterialSkin.Controls.MaterialButton matbtnSave;
    }
}