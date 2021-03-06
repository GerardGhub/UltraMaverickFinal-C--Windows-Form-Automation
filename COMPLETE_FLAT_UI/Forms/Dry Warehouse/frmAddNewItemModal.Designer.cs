
namespace ULTRAMAVERICK.Forms.Dry_Warehouse
{
    partial class frmAddNewItemModal
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrimaryUnitID = new System.Windows.Forms.Label();
            this.lblItemTypeID = new System.Windows.Forms.Label();
            this.lblIDSubCat = new System.Windows.Forms.Label();
            this.lblMajorCatId = new System.Windows.Forms.Label();
            this.lblItemClassID = new System.Windows.Forms.Label();
            this.txtmatConversion = new MaterialSkin.Controls.MaterialTextBox();
            this.cboPrimaryUnit = new MetroFramework.Controls.MetroComboBox();
            this.cboItemType = new MetroFramework.Controls.MetroComboBox();
            this.cboSubCat = new MetroFramework.Controls.MetroComboBox();
            this.cboMajorCategory = new MetroFramework.Controls.MetroComboBox();
            this.cboItemClass = new MetroFramework.Controls.MetroComboBox();
            this.txtMatItemDesc = new MaterialSkin.Controls.MaterialTextBox();
            this.txtMatItemCode = new MaterialSkin.Controls.MaterialTextBox();
            this.txtcreatedBy = new System.Windows.Forms.TextBox();
            this.matBtnSave = new MaterialSkin.Controls.MaterialButton();
            this.txtcreatedAt = new System.Windows.Forms.TextBox();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(528, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 471;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.label5);
            this.materialCard1.Controls.Add(this.label4);
            this.materialCard1.Controls.Add(this.label3);
            this.materialCard1.Controls.Add(this.label2);
            this.materialCard1.Controls.Add(this.label1);
            this.materialCard1.Controls.Add(this.lblPrimaryUnitID);
            this.materialCard1.Controls.Add(this.lblItemTypeID);
            this.materialCard1.Controls.Add(this.lblIDSubCat);
            this.materialCard1.Controls.Add(this.lblMajorCatId);
            this.materialCard1.Controls.Add(this.lblItemClassID);
            this.materialCard1.Controls.Add(this.txtmatConversion);
            this.materialCard1.Controls.Add(this.cboPrimaryUnit);
            this.materialCard1.Controls.Add(this.cboItemType);
            this.materialCard1.Controls.Add(this.cboSubCat);
            this.materialCard1.Controls.Add(this.cboMajorCategory);
            this.materialCard1.Controls.Add(this.cboItemClass);
            this.materialCard1.Controls.Add(this.txtMatItemDesc);
            this.materialCard1.Controls.Add(this.txtMatItemCode);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(24, 81);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.materialCard1.Size = new System.Drawing.Size(679, 262);
            this.materialCard1.TabIndex = 472;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(22, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 596;
            this.label5.Text = "Primary Unit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(259, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 595;
            this.label4.Text = "Sub Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(503, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 594;
            this.label3.Text = "Item Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(502, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 593;
            this.label2.Text = "Item Class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(24, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 592;
            this.label1.Text = "Major Category:";
            // 
            // lblPrimaryUnitID
            // 
            this.lblPrimaryUnitID.AutoSize = true;
            this.lblPrimaryUnitID.BackColor = System.Drawing.Color.Transparent;
            this.lblPrimaryUnitID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryUnitID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPrimaryUnitID.Location = new System.Drawing.Point(114, 160);
            this.lblPrimaryUnitID.Name = "lblPrimaryUnitID";
            this.lblPrimaryUnitID.Size = new System.Drawing.Size(66, 13);
            this.lblPrimaryUnitID.TabIndex = 591;
            this.lblPrimaryUnitID.Text = "Primary Unit:";
            this.lblPrimaryUnitID.Visible = false;
            // 
            // lblItemTypeID
            // 
            this.lblItemTypeID.AutoSize = true;
            this.lblItemTypeID.BackColor = System.Drawing.Color.Transparent;
            this.lblItemTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTypeID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblItemTypeID.Location = new System.Drawing.Point(593, 93);
            this.lblItemTypeID.Name = "lblItemTypeID";
            this.lblItemTypeID.Size = new System.Drawing.Size(57, 13);
            this.lblItemTypeID.TabIndex = 590;
            this.lblItemTypeID.Text = "Item Type:";
            this.lblItemTypeID.Visible = false;
            // 
            // lblIDSubCat
            // 
            this.lblIDSubCat.AutoSize = true;
            this.lblIDSubCat.BackColor = System.Drawing.Color.Transparent;
            this.lblIDSubCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDSubCat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIDSubCat.Location = new System.Drawing.Point(352, 93);
            this.lblIDSubCat.Name = "lblIDSubCat";
            this.lblIDSubCat.Size = new System.Drawing.Size(74, 13);
            this.lblIDSubCat.TabIndex = 589;
            this.lblIDSubCat.Text = "Sub Category:";
            this.lblIDSubCat.Visible = false;
            // 
            // lblMajorCatId
            // 
            this.lblMajorCatId.AutoSize = true;
            this.lblMajorCatId.BackColor = System.Drawing.Color.Transparent;
            this.lblMajorCatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMajorCatId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMajorCatId.Location = new System.Drawing.Point(120, 93);
            this.lblMajorCatId.Name = "lblMajorCatId";
            this.lblMajorCatId.Size = new System.Drawing.Size(81, 13);
            this.lblMajorCatId.TabIndex = 588;
            this.lblMajorCatId.Text = "Major Category:";
            this.lblMajorCatId.Visible = false;
            // 
            // lblItemClassID
            // 
            this.lblItemClassID.AutoSize = true;
            this.lblItemClassID.BackColor = System.Drawing.Color.Transparent;
            this.lblItemClassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemClassID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblItemClassID.Location = new System.Drawing.Point(599, 29);
            this.lblItemClassID.Name = "lblItemClassID";
            this.lblItemClassID.Size = new System.Drawing.Size(58, 13);
            this.lblItemClassID.TabIndex = 587;
            this.lblItemClassID.Text = "Item Class:";
            this.lblItemClassID.Visible = false;
            // 
            // txtmatConversion
            // 
            this.txtmatConversion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmatConversion.Depth = 0;
            this.txtmatConversion.Enabled = false;
            this.txtmatConversion.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtmatConversion.Hint = "Conversion";
            this.txtmatConversion.Location = new System.Drawing.Point(260, 156);
            this.txtmatConversion.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtmatConversion.MaxLength = 50;
            this.txtmatConversion.MouseState = MaterialSkin.MouseState.OUT;
            this.txtmatConversion.Multiline = false;
            this.txtmatConversion.Name = "txtmatConversion";
            this.txtmatConversion.Size = new System.Drawing.Size(155, 50);
            this.txtmatConversion.TabIndex = 586;
            this.txtmatConversion.Text = "";
            this.txtmatConversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmatConversion_KeyPress);
            // 
            // cboPrimaryUnit
            // 
            this.cboPrimaryUnit.FormattingEnabled = true;
            this.cboPrimaryUnit.ItemHeight = 23;
            this.cboPrimaryUnit.Location = new System.Drawing.Point(22, 178);
            this.cboPrimaryUnit.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cboPrimaryUnit.Name = "cboPrimaryUnit";
            this.cboPrimaryUnit.PromptText = "Primary Unit";
            this.cboPrimaryUnit.Size = new System.Drawing.Size(160, 29);
            this.cboPrimaryUnit.TabIndex = 585;
            this.cboPrimaryUnit.UseSelectable = true;
            this.cboPrimaryUnit.SelectionChangeCommitted += new System.EventHandler(this.cboPrimaryUnit_SelectionChangeCommitted);
            // 
            // cboItemType
            // 
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.ItemHeight = 23;
            this.cboItemType.Location = new System.Drawing.Point(502, 107);
            this.cboItemType.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.PromptText = "Item Type";
            this.cboItemType.Size = new System.Drawing.Size(158, 29);
            this.cboItemType.TabIndex = 583;
            this.cboItemType.UseSelectable = true;
            this.cboItemType.SelectionChangeCommitted += new System.EventHandler(this.cboItemType_SelectionChangeCommitted);
            // 
            // cboSubCat
            // 
            this.cboSubCat.FormattingEnabled = true;
            this.cboSubCat.ItemHeight = 23;
            this.cboSubCat.Location = new System.Drawing.Point(260, 107);
            this.cboSubCat.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cboSubCat.Name = "cboSubCat";
            this.cboSubCat.PromptText = "Sub Category";
            this.cboSubCat.Size = new System.Drawing.Size(158, 29);
            this.cboSubCat.TabIndex = 581;
            this.cboSubCat.UseSelectable = true;
            this.cboSubCat.SelectionChangeCommitted += new System.EventHandler(this.cboSubCat_SelectionChangeCommitted);
            // 
            // cboMajorCategory
            // 
            this.cboMajorCategory.FormattingEnabled = true;
            this.cboMajorCategory.ItemHeight = 23;
            this.cboMajorCategory.Location = new System.Drawing.Point(24, 108);
            this.cboMajorCategory.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cboMajorCategory.Name = "cboMajorCategory";
            this.cboMajorCategory.PromptText = "Major Category";
            this.cboMajorCategory.Size = new System.Drawing.Size(160, 29);
            this.cboMajorCategory.TabIndex = 579;
            this.cboMajorCategory.UseSelectable = true;
            this.cboMajorCategory.SelectionChangeCommitted += new System.EventHandler(this.cboMajorCategory_SelectionChangeCommitted);
            // 
            // cboItemClass
            // 
            this.cboItemClass.FormattingEnabled = true;
            this.cboItemClass.ItemHeight = 23;
            this.cboItemClass.Location = new System.Drawing.Point(502, 45);
            this.cboItemClass.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cboItemClass.Name = "cboItemClass";
            this.cboItemClass.PromptText = "Item Class";
            this.cboItemClass.Size = new System.Drawing.Size(158, 29);
            this.cboItemClass.TabIndex = 577;
            this.cboItemClass.UseSelectable = true;
            this.cboItemClass.SelectionChangeCommitted += new System.EventHandler(this.cboItemClass_SelectionChangeCommitted);
            this.cboItemClass.SelectedValueChanged += new System.EventHandler(this.cboItemClass_SelectedValueChanged);
            // 
            // txtMatItemDesc
            // 
            this.txtMatItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatItemDesc.Depth = 0;
            this.txtMatItemDesc.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtMatItemDesc.Hint = "Item Description";
            this.txtMatItemDesc.Location = new System.Drawing.Point(260, 29);
            this.txtMatItemDesc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtMatItemDesc.MaxLength = 50;
            this.txtMatItemDesc.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatItemDesc.Multiline = false;
            this.txtMatItemDesc.Name = "txtMatItemDesc";
            this.txtMatItemDesc.Size = new System.Drawing.Size(155, 50);
            this.txtMatItemDesc.TabIndex = 1;
            this.txtMatItemDesc.Text = "";
            this.txtMatItemDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatItemDesc_KeyPress);
            // 
            // txtMatItemCode
            // 
            this.txtMatItemCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatItemCode.Depth = 0;
            this.txtMatItemCode.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtMatItemCode.Hint = "Item Code";
            this.txtMatItemCode.Location = new System.Drawing.Point(26, 29);
            this.txtMatItemCode.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtMatItemCode.MaxLength = 50;
            this.txtMatItemCode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatItemCode.Multiline = false;
            this.txtMatItemCode.Name = "txtMatItemCode";
            this.txtMatItemCode.Size = new System.Drawing.Size(155, 50);
            this.txtMatItemCode.TabIndex = 0;
            this.txtMatItemCode.Text = "";
            this.txtMatItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatItemCode_KeyPress);
            this.txtMatItemCode.Validated += new System.EventHandler(this.txtMatItemCode_Validated);
            // 
            // txtcreatedBy
            // 
            this.txtcreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcreatedBy.Enabled = false;
            this.txtcreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreatedBy.Location = new System.Drawing.Point(36, 396);
            this.txtcreatedBy.Name = "txtcreatedBy";
            this.txtcreatedBy.Size = new System.Drawing.Size(145, 20);
            this.txtcreatedBy.TabIndex = 473;
            this.txtcreatedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcreatedBy.Visible = false;
            // 
            // matBtnSave
            // 
            this.matBtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.matBtnSave.Depth = 0;
            this.matBtnSave.DrawShadows = true;
            this.matBtnSave.HighEmphasis = true;
            this.matBtnSave.Icon = null;
            this.matBtnSave.Location = new System.Drawing.Point(36, 359);
            this.matBtnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.matBtnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.matBtnSave.Name = "matBtnSave";
            this.matBtnSave.Size = new System.Drawing.Size(58, 36);
            this.matBtnSave.TabIndex = 474;
            this.matBtnSave.Text = "Save";
            this.matBtnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.matBtnSave.UseAccentColor = false;
            this.matBtnSave.UseVisualStyleBackColor = true;
            this.matBtnSave.Click += new System.EventHandler(this.matBtnSave_Click);
            // 
            // txtcreatedAt
            // 
            this.txtcreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcreatedAt.Enabled = false;
            this.txtcreatedAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreatedAt.Location = new System.Drawing.Point(211, 396);
            this.txtcreatedAt.Name = "txtcreatedAt";
            this.txtcreatedAt.Size = new System.Drawing.Size(145, 20);
            this.txtcreatedAt.TabIndex = 475;
            this.txtcreatedAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcreatedAt.Visible = false;
            // 
            // frmAddNewItemModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 402);
            this.Controls.Add(this.txtcreatedAt);
            this.Controls.Add(this.matBtnSave);
            this.Controls.Add(this.txtcreatedBy);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "frmAddNewItemModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Raw Material";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddNewItemModal_FormClosed);
            this.Load += new System.EventHandler(this.frmAddNewItemModal_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TextBox txtcreatedBy;
        private MaterialSkin.Controls.MaterialTextBox txtMatItemDesc;
        private MaterialSkin.Controls.MaterialTextBox txtMatItemCode;
        private MetroFramework.Controls.MetroComboBox cboItemClass;
        private MetroFramework.Controls.MetroComboBox cboMajorCategory;
        private MetroFramework.Controls.MetroComboBox cboSubCat;
        private MetroFramework.Controls.MetroComboBox cboItemType;
        private MetroFramework.Controls.MetroComboBox cboPrimaryUnit;
        private MaterialSkin.Controls.MaterialTextBox txtmatConversion;
        private System.Windows.Forms.Label lblItemClassID;
        private System.Windows.Forms.Label lblMajorCatId;
        private System.Windows.Forms.Label lblIDSubCat;
        private System.Windows.Forms.Label lblItemTypeID;
        private System.Windows.Forms.Label lblPrimaryUnitID;
        private MaterialSkin.Controls.MaterialButton matBtnSave;
        private System.Windows.Forms.TextBox txtcreatedAt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}