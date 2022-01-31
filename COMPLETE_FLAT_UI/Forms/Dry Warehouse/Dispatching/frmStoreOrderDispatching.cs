﻿using COMPLETE_FLAT_UI.Models;
using CrystalDecisions.CrystalReports.Engine;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using ULTRAMAVERICK.Models;
using ULTRAMAVERICK.Properties;

namespace ULTRAMAVERICK.Forms.Dry_Warehouse.Dispatching
{
    public partial class frmStoreOrderDispatching : MaterialForm
    {
        //Main Classs
        myclasses myClass = new myclasses();
        myclasses xClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        IStoredProcedures objStorProc = null;
        //Data Set Initialization
        public DataSet dset = new DataSet();
        DataSet dset2 = new DataSet();
        DataSet dset3 = new DataSet();
        DataSet dSet = new DataSet();
        //Variable Declaration
        int p_id = 0;

        string Rpt_Path = "";
        ReportDocument rpt = new ReportDocument();

        public frmStoreOrderDispatching()
        {
            InitializeComponent();
        }

        public int Sp_user_id { get; set; }
        public string sp_final_id { get; set; }
        public string Sp_Fox { get; set; }
        public string Sp_Selected_Item { get; set; }
        private void frmStoreOrderDispatching_Load(object sender, EventArgs e)
        {
            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections(); // Main Stored Procedure Collections
            objStorProc = xClass.g_objStoredProc.GetCollections(); //Call the StoreProcedure With Class
            this.loadPreparationDateDropdown();
            this.useStateWindowLoad();
            this.ShowDataActivated();
        }



        private void ShowDataActivated()
        {
   
            this.Sp_user_id = userinfo.user_id;
        }

        public void useStateWindowLoad()
        {
            //Visibility
            this.crV1.Visible = false;

            if (this.matCmbPreparationDate.Text == String.Empty)
            {
                this.materialCheckboxSelectAll.Visible = false;
            }
            else
            {
                this.materialCheckboxSelectAll.Visible = true;
                this.loadCategoryDropdown();

                if (this.matcmbCategory.Text != String.Empty)
                {
                    this.loadPrepaDate_AND_Category();
                }

                if (this.metroCmbStoreName.Text != String.Empty)
                {
                    this.loadPrepaDate_Category_StoreName_Dropdown();
                }
            }
        }



        public void loadPrepaDate_AND_Category()
        {
            try
            {



                this.dset.Clear();

                this.dset = objStorProc.sp_getMajorTables("Store_Order_Dispatched_by_Logistic_Checker_Per_Items_RestFull_Major");

                this.doSearch();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //this.lblMajorCatId.Text = cboMajorCategory.SelectedValue.ToString();
        }




        public void loadPreparationDateDropdown()
        {
            try
            {
                

                myClass.fillComboBoxStoreOrderApprovalSync(this.matCmbPreparationDate, "Store_Order_Dispatched_by_Logistic_Checker_Per_Items_Categories_DropDown", 
                    this.dSet, "BunifuPrepaDate", "cmdDateOrder", this.matcmbCategory.Text, this.metroCmbStoreName.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //this.lblMajorCatId.Text = cboMajorCategory.SelectedValue.ToString();
        }

        public void loadCategoryDropdown()
        {
            try
            {


                myClass.fillComboBoxStoreOrderApprovalSync(this.matcmbCategory, "Store_Order_Dispatched_by_Logistic_Checker_Per_Items_Categories_DropDown_Category", this.dSet, this.matCmbPreparationDate.Text, "cmdDateOrder", this.matcmbCategory.Text, this.metroCmbStoreName.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //this.lblMajorCatId.Text = cboMajorCategory.SelectedValue.ToString();
        }



        public void loadStoreNameDropdown()
        {
            try
            {


                myClass.fillComboBoxStoreOrderApprovalSync(this.metroCmbStoreName, "Store_Order_Dispatched_by_Logistic_Checker_Per_Items_Categories_DropDown_StoreName", this.dSet, this.matCmbPreparationDate.Text, this.matcmbCategory.Text, this.matcmbCategory.Text, this.metroCmbStoreName.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //this.lblMajorCatId.Text = cboMajorCategory.SelectedValue.ToString();
        }


        public void loadPrepaDate_Category_StoreName_Dropdown()
        {
            try
            {



                this.dset.Clear();

                this.dset = objStorProc.sp_getMajorTables("Store_Order_Dispatched_by_Logistic_Checker_Per_Items_RestFull_Major");
   
                this.doSearch();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //this.lblMajorCatId.Text = cboMajorCategory.SelectedValue.ToString();
        }



        private void doSearch()
        {
            try
            {
                if (this.dset.Tables.Count > 0)
                {
                    DataView dv = new DataView(this.dset.Tables[0]);

                    if (this.metroCmbStoreName.Text == String.Empty)
                    {
                        dv.RowFilter = " is_approved_prepa_date = '" + this.matCmbPreparationDate.Text + "' and   category = '" + this.matcmbCategory.Text + "'   ";

                    }
                    else
                    {
                        dv.RowFilter = " is_approved_prepa_date = '" + this.matCmbPreparationDate.Text + "' and   category = '" + this.matcmbCategory.Text + "' and store_name ='" + this.metroCmbStoreName.Text + "'  ";

                    }


                    this.dgvGunaMoveItems.DataSource = dv;
                    this.lbltotaldata.Text = dgvGunaMoveItems.RowCount.ToString();

                    //gerard
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 20.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //END
        }

        private void matCmbPreparationDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.loadCategoryDropdown();
            if (this.matcmbCategory.Text != String.Empty)
            {
                this.loadPrepaDate_AND_Category();
            }

        }

        private void matcmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.loadStoreNameDropdown();
        }

        private void CountAllQtyOrder()
        {
            int sum = 0;
            for (int i = 0; i < this.dgvGunaMoveItems.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(this.dgvGunaMoveItems.Rows[i].Cells["prepared_allocated_qty"].Value);
            }
            this.lbltotalOrderQty.Text = sum.ToString();
        }

        private void materialCheckboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {


            if (this.materialCheckboxSelectAll.Checked == true)
            {
                this.labelSelectedSum.Visible = true;
                this.materialCheckboxSelectAll.Text = "UnSelect ALL";
                for (int i = 0; i < this.dgvGunaMoveItems.RowCount; i++) { this.dgvGunaMoveItems.Rows[i].Cells[0].Value = true; }
                //MessageBox.Show(dgvReprinting.SelectedRows.Count.ToString());

                this.labelSelectedSum.Text = "Selected Items: " + this.dgvGunaMoveItems.RowCount.ToString();
                this.num = this.dgvGunaMoveItems.RowCount;
                this.SaveButtonManipulator();
                if(num != 0)
                {
                    this.matbtnEdit.Visible = true;
                }
          
            }
            else
            {
                this.materialCheckboxSelectAll.Text = "Select ALL";
                //this.labelSelectedSum.Visible = false;
                for (int i = 0; i < dgvGunaMoveItems.RowCount; i++) { dgvGunaMoveItems.Rows[i].Cells[0].Value = false; }
                this.labelSelectedSum.Text = "Selected Items: " + 0;
                this.num = 0;
                this.SaveButtonManipulator();
                this.lbltotalOrderQty.Text = "0";
                if (num == 0)
                {
                    this.matbtnEdit.Visible = false;
                }
            }
        }


        private void SaveButtonManipulator()
        {
            if (this.labelSelectedSum.Text == "0")
            {
                this.matbtnCancel.Visible = false;
            }
            else if (num == 0)
            {
                this.matbtnCancel.Visible = false;
                this.materialLabelNoPrintPages.Visible = false;
                this.metroCMbFilterPrintPages.Visible = false;
            }
            else
            {
                //this.matbtnCancel.Visible = true;
                this.materialLabelNoPrintPages.Visible = true;
                this.metroCMbFilterPrintPages.Visible = true;
            }
        }

        double num = 0;
        double num_static_value = 0;
        private void dgvGunaMoveItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

            bool isChecked = (bool)dgvGunaMoveItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
            CheckCount(isChecked);


 
        }

        private void CheckCount(bool isChecked)
        {
            if (isChecked)
            {
                double totalRecords = Convert.ToInt32(this.lbltotaldata.Text.ToString());
                if (num == totalRecords)
                {

                }
                else
                {
                    num++;
                    num_static_value = num;
                }
            }
            else
            {
                num--;

            }
            //Store in Static Value Integer Type of Variable

            this.labelSelectedSum.Text = "Selected Items: " + num;
            this.labelSelectedSum.Visible = true;
            this.SaveButtonManipulator();
            this.EditManipulator();

        }

        private void EditManipulator()
        {
            if (this.num == 1)
            {
                //this.matbtnCancel.Visible = true;
                this.matbtnEdit.Visible = true;
            }
            else
            {
                //this.matbtnEdit.Visible = false;

            }
        }

        private void lbltotaldata_TextChanged(object sender, EventArgs e)
        {
            if(this.lbltotaldata.Text != "0")
            {
                this.dgvGunaMoveItems.Enabled = true;
                //this.CountAllQtyOrder();
            }
            else
            {
                this.dgvGunaMoveItems.Enabled = false;
            }
        }


        public void NoOfPagesforPrinting()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Select number of pages for printing set-up";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.DarkSlateBlue;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        private void matbtnEdit_Click(object sender, EventArgs e)
        {
            if(this.metroCMbFilterPrintPages.Text == String.Empty)
            {
                this.NoOfPagesforPrinting();
                return;
            }

            if (MetroFramework.MetroMessageBox.Show(this, "Print the move Order Slip? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                this.ApproveFunctionality();
            }
            else
            {

                return;
            }
        }

        private void ApproveFunctionality()
        {
 
            for (int i = 0; i <= this.dgvGunaMoveItems.RowCount - 1; i++)
            {
                try
                {
                    if (this.dgvGunaMoveItems.CurrentRow != null)
                    {

                        if (Convert.ToBoolean(this.dgvGunaMoveItems.Rows[i].Cells["selected"].Value) == true)
                        {
                            this.dgvGunaMoveItems.CurrentCell = this.dgvGunaMoveItems.Rows[i].Cells[this.dgvGunaMoveItems.CurrentCell.ColumnIndex];
                            dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvGunaMoveItems.Rows[i].Cells["fox"].Value.ToString()), "PUTStoreOrderMoveDispatching", this.dgvGunaMoveItems.Rows[i].Cells["is_approved_prepa_date"].Value.ToString(), 
                                dgvGunaMoveItems.Rows[i].Cells["category"].Value.ToString(), this.Sp_user_id);

                        }
                        else
                        {
                            //dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvReprinting.Rows[i].Cells["id"].Value.ToString()), "updaterepacking", "", "", 1);

                        }
                    }
                }
                catch (Exception ex)
                {

                    this.dgvGunaMoveItems.CurrentCell = this.dgvGunaMoveItems.Rows[i].Cells[this.dgvGunaMoveItems.CurrentCell.ColumnIndex];
                    dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvGunaMoveItems.Rows[i].Cells["fox"].Value.ToString()), "PUTStoreOrderMoveDispatching", this.dgvGunaMoveItems.Rows[i].Cells["is_approved_prepa_date"].Value.ToString(), dgvGunaMoveItems.Rows[i].Cells["category"].Value.ToString(), this.Sp_user_id);

                    //this.dgvGunaMoveItems.CurrentCell = this.dgvGunaMoveItems.Rows[i].Cells[this.dgvGunaMoveItems.CurrentCell.ColumnIndex];
                    //dset = g_objStoredProcCollection.sp_IDGenerator(int.Parse(dgvGunaMoveItems.Rows[i].Cells["primary_id"].Value.ToString()), "PUTStoreOrderMoveDispatching", 
                    //    this.matCmbPreparationDate.Text, this.Sp_user_id.ToString(), 1);

                    MessageBox.Show(ex.Message);
                }

            }
            this.ForLoopProcessAutoPrint();
            this.DispatchedSuccessfully();
            this.materialCheckboxSelectAll.Checked = false;
            this.labelSelectedSum.Visible = false;
        
            //Pahinga
            this.frmStoreOrderDispatching_Load(new object(), new System.EventArgs());
    
        }

        public void DispatchedSuccessfully()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Dispatched Successfully";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Green;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void labelSelectedSum_TextChanged(object sender, EventArgs e)
        {
            if (num == 0)
            {
                if (this.materialCheckboxSelectAll.Checked == true)
                {

                }
                else
                {
                    this.frmStoreOrderDispatching_Load(sender, e);
                }




            }
            else
            {
                
            }
        }

        private void metroCmbStoreName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.loadPrepaDate_Category_StoreName_Dropdown();
        }


        private void GridResetIntoFirstLine()
        {
            this.dgvGunaMoveItems.CurrentCell = this.dgvGunaMoveItems.Rows[0].Cells[this.dgvGunaMoveItems.CurrentCell.ColumnIndex];
          
        }
        private void btnPrintSample_Click(object sender, EventArgs e)
        {
            this.GridResetIntoFirstLine();
      
            this.NextDatainDryStorePreparationEntry();
        }

        private void ForLoopProcessAutoPrint()
        {
            this.GridResetIntoFirstLine();

            this.NextDatainDryStorePreparationEntry();
        }

        private void NextDatainDryStorePreparationEntry()
        {
            //for (int i = 0; i <= this.dgvGunaMoveItems.RowCount - 1; i++)
            //{
            //    if (Convert.ToBoolean(this.dgvGunaMoveItems.Rows[i].Cells["selected"].Value) == true)
            //    {
            //        this.PrintingProcess();
            //    }
            //}
            dgvGunaMoveItems_CurrentCellChanged(new object(), new System.EventArgs());
            MessageBox.Show("" + this.Sp_Selected_Item);



            if (this.Sp_Selected_Item == "selected")
            {
                if(this.metroCMbFilterPrintPages.Text == "2")
                {
                    this.PrintingProcess();
                    this.PrintingProcess();
                }
                else if(this.metroCMbFilterPrintPages.Text == "1")
                {
                    this.PrintingProcess();
                }
                else
                {
  
                }
              

            }
                

            if (this.dgvGunaMoveItems.Rows.Count >= 1)
            {
                int i = this.dgvGunaMoveItems.CurrentRow.Index + 1;
                if (i >= -1 && i < this.dgvGunaMoveItems.Rows.Count)
                    this.dgvGunaMoveItems.CurrentCell = this.dgvGunaMoveItems.Rows[i].Cells[0];
              
                else
                {
                    //this.LastLineofPreparationSubject();
                    //for (int ia = 0; ia <= this.dgvGunaMoveItems.RowCount - 1; ia++)
                    //{
                    //    if (Convert.ToBoolean(this.dgvGunaMoveItems.Rows[ia].Cells["selected"].Value) == true)
                    //    {
                    //        this.PrintingProcess();
                    //    }
                    //}


                    return;
                }
            }

            this.Sp_Selected_Item = "";
            this.NextDatainDryStorePreparationEntry();
        }

        private void PrintingProcess()
        {
            Rpt_Path = ULTRAMAVERICK.Properties.Settings.Default.fdg;



            PrintDialog printDialog = new PrintDialog();
            rpt.Load(Rpt_Path + "\\StoreMoveOrderPickSlip.rpt");

            //rpt.SetDatabaseLogon("sa", "FMf3dor@2o20");
            //MessageBox.Show(sp_final_id);
            this.sp_final_id = "01/12/2022";
            rpt.Refresh();
            myglobal.DATE_REPORT2 = sp_final_id;
       
            rpt.SetParameterValue("@approved_prepa_date", this.matCmbPreparationDate.Text);
            rpt.SetParameterValue("@category", this.matcmbCategory.Text);
            rpt.SetParameterValue("@fox", this.Sp_Fox);

            crV1.ReportSource = rpt;
            crV1.Refresh();



            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;


            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.ToPage);

        }

        private void dgvGunaMoveItems_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvGunaMoveItems.Rows.Count > 0)
                {
                    if (this.dgvGunaMoveItems.CurrentRow != null)
                    {
                        if (this.dgvGunaMoveItems.CurrentRow.Cells["fox"].Value != null)
                        {

                            this.Sp_Fox = this.dgvGunaMoveItems.CurrentRow.Cells["fox"].Value.ToString();

                            if (Convert.ToBoolean(this.dgvGunaMoveItems.CurrentRow.Cells["selected"].Value) == true)
                            {
                                this.Sp_Selected_Item = "selected";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }
    }
}