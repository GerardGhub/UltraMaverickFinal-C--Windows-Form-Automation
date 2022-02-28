﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ULTRAMAVERICK.Models;
using ULTRAMAVERICK.Wizard.Helpers;

namespace ULTRAMAVERICK.Forms.Lab_Test
{
    public partial class frmLabTestModule : MaterialForm
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        IStoredProcedures g_objStoredProcCollection = null;
        myclasses myClass = new myclasses();
        DataSet dSet = new DataSet();


        int p_id = 0;

        DateTime dNow = DateTime.Now;

        DataSet dSet_temp = new DataSet();
        PopupNotifierClass GlobalStatePopup = new PopupNotifierClass();
        public frmLabTestModule()
        {
            InitializeComponent();
        }

        public string SpItemCode { get; set; }
        public string SpCategory { get; set; }
        public string SpTransactionType { get; set; }
        public string SpQuantity { get; set; }
        public string SpMftgDate { get; set; }
        public string SpExpiryDate { get; set; }
        public string SpLotNumber { get; set; }
        public string SpLotDescription { get; set; }
        public string SpDateOfLastUsed { get; set; }
        public string SpExpiryDays { get; set; }
        public string SpReceivedDate { get; set; }
        public string SpRemarks { get; set; }
        public string SpLabStatus { get; set; }
        public string SplblLabRequestDate { get; set; }

        private void frmLabTestModule_Load(object sender, EventArgs e)
        {
            this.ConnectionInitialization();
            this.showRawMaterialsNearlyExpiry();
            this.WindowLoadState();
        }
        private void WindowLoadState()
        {
            if (this.lbltotalrecords.Text != "0")
            {
                this.SearchMethodJarVarCallingSP();

            }
        }

        private void ConnectionInitialization()
        {
            this.g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections(); // Main Stored Procedure Collections
            this.objStorProc = xClass.g_objStoredProc.GetCollections(); //Call the StoreProcedure With Class
        }


        private void showRawMaterialsNearlyExpiry()    //method for loading available_menus
        {
            try
            {

                xClass.fillDataGridView(this.dgvRawMats, "DryWarehouseNearlyExpiryLabTestViewing", dSet);

                this.lbltotalrecords.Text = this.dgvRawMats.RowCount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.dgvRawMats.Columns["mfg_date"].Visible = false;
            this.dgvRawMats.Columns["date_added"].Visible = false;
            this.dgvRawMats.Columns["exp_date"].Visible = false;
            this.dgvRawMats.Columns["lot_description"].Visible = false;
            this.dgvRawMats.Columns["STANDARDEXPIRYDAYS"].Visible = false;
            this.dgvRawMats.Columns["lot_no"].Visible = false;
            this.dgvRawMats.Columns["lab_request_date"].Visible = false;


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }



        DataSet dset_emp_SearchEngines = new DataSet();
        private void SearchMethodJarVarCallingSP()
        {
            this.dset_emp_SearchEngines.Clear();


            this.dset_emp_SearchEngines = objStorProc.sp_getMajorTables("DryWarehouseNearlyExpiryMajor");

        }


        private void doSearchInTextBoxCmb()
        {
            try
            {
                if (this.dset_emp_SearchEngines.Tables.Count > 0)
                {
                    DataView dv = new DataView(this.dset_emp_SearchEngines.Tables[0]);


                    dv.RowFilter = "or item_code like '%" + this.txtSearch.Text + "%' or item_description like '%" + this.txtSearch.Text + "%'   ";


                    this.dgvRawMats.DataSource = dv;
                    this.lbltotalrecords.Text = this.dgvRawMats.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found Syntax Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found Evaluation Exception!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }




        }

        private void dgvRawMats_CurrentCellChanged(object sender, EventArgs e)
        {
            this.showValueCell();
        }

        private void showValueCell()
        {
            if (dgvRawMats.Rows.Count > 0)
            {
                if (dgvRawMats.CurrentRow != null)
                {
                    if (dgvRawMats.CurrentRow.Cells["item_code"].Value != null)
                    {
                        p_id = Convert.ToInt32(this.dgvRawMats.CurrentRow.Cells["id"].Value);
                         this.matTxtItemCode.Text = this.dgvRawMats.CurrentRow.Cells["item_code"].Value.ToString();
                        this.matTxtCategory.Text = this.dgvRawMats.CurrentRow.Cells["category"].Value.ToString();
                        this.matTxtQty.Text = this.dgvRawMats.CurrentRow.Cells["qty_received"].Value.ToString();
                        this.matTxtMftgDate.Text = this.dgvRawMats.CurrentRow.Cells["mfg_date"].Value.ToString();
                        this.matTxtExpiryDate.Text = this.dgvRawMats.CurrentRow.Cells["exp_date"].Value.ToString();
                        this.matTxtExpiryDays.Text = this.dgvRawMats.CurrentRow.Cells["DAYSTOEXPIRED"].Value.ToString();
                        this.matTxtDateAdded.Text = this.dgvRawMats.CurrentRow.Cells["date_added"].Value.ToString();
                        this.mattxtLotNumber.Text = this.dgvRawMats.CurrentRow.Cells["lot_no"].Value.ToString();
                        this.SpLabStatus = this.dgvRawMats.CurrentRow.Cells["lab_status"].Value.ToString();
                        this.SplblLabRequestDate = this.dgvRawMats.CurrentRow.Cells["lab_request_date"].Value.ToString();
                    }
                }
            }

            if(this.SpLabStatus == "LAB REQUEST")
            {
                this.matViewLabRecords.Enabled = false;
                this.btnCancelLabRequest.Visible = true;
         
            }
            else
            {
                this.matViewLabRecords.Enabled = true;
                this.btnCancelLabRequest.Visible = false;
              
            }

           if(this.SpLabStatus == "LAB REQUEST")
            {
                WizardBalloon1.Image = Properties.Resources.completed;
            }
           else
            {
                WizardBalloon1.Image = Properties.Resources.current;
            }

        }

        private void matViewLabRecords_Click(object sender, EventArgs e)
        {

            //Start
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to request a new data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.dSet.Clear();
                this.dSet = objStorProc.sp_tblDryWHReceiving(p_id,
                    p_id, "BUje", "0", "0", "", "0", "0", "", "0",
                    "0", "0", "0", "0", 
                    "0", "0", "0", 0, 0, "dry_wh_lab_request");

                this.GlobalStatePopup.CommittedSuccessFully();
                this.frmLabTestModule_Load(sender, e);


            }
            else
            {
                return;
            }

                //End
            }

        private void matBtnNew_Click(object sender, EventArgs e)
        {

            DryWhLabTestRecentLogs fm = new DryWhLabTestRecentLogs();
            fm.ShowDialog();
        }

        private void btnCancelLabRequest_Click(object sender, EventArgs e)
        {
            //Start
            if (MetroFramework.MetroMessageBox.Show(this, "Cancel the lab test request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.dSet.Clear();
                this.dSet = objStorProc.sp_tblDryWHReceiving(p_id,
                    p_id, "BUje", "0", "0", "", "0", "0", "", "0",
                    "0", "0", "0", "0",
                    "0", "0", "0", 0, 0, "dry_wh_lab_request_cancel_by_drywh");

                this.GlobalStatePopup.CommittedSuccessFully();
                this.frmLabTestModule_Load(sender, e);
            }
            else
            {
                return;
            }

            }

        private void ChooseImage_MouseHover(object sender, EventArgs e)
        {
            this.GlobalStatePopup.BallonNotifyHover();
        }

        private void ChooseImage_MouseLeave(object sender, EventArgs e)
        {
            this.GlobalStatePopup.BallonNotifyHover();
        }

        private void siticoneHtmlLabel1_MouseHover(object sender, EventArgs e)
        {
            this.GlobalStatePopup.BallonNotifyHover();
        }

        private void siticoneHtmlLabel1_Click(object sender, EventArgs e)
        {
            this.GlobalStatePopup.BallonNotifyHover();
            MessageBox.Show("Samop");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.GlobalStatePopup.WizzardMesage1 = this.SplblLabRequestDate;
            this.GlobalStatePopup.BallonNotifyHover();
        }
    }
}
