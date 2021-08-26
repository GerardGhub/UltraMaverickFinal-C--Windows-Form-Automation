﻿using COMPLETE_FLAT_UI.Models;
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

namespace ULTRAMAVERICK.Forms.Users
{
    public partial class frmUserRight : Form
    {
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        Boolean ready = false;
        string mode = "";
        int p_id = 0;
        myclasses myClass = new myclasses();
        DataSet dSet_temp = new DataSet();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        int pkey = 0;
        public frmUserRight()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserRight_Load(object sender, EventArgs e)
        {
            objStorProc = xClass.g_objStoredProc.GetCollections();
            displayUserRights();
            listViewuser_rights_Click(sender, e);
            FalseButton();
          
            loadParentMenu();
            ListViewmenu.Enabled = false;
            dataView.Enabled = false;
            myglobal.global_module = "Active"; // Mode for Searching

            getAllTaggedParentMenu(); //Tagged Equal ==
            lblUserID.Text = userinfo.user_id.ToString(); // ID of User
            lblFirstName.Text = userinfo.emp_name.ToUpper(); // First Name Session
            dgvParentMenu.RowsDefaultCellStyle.ForeColor = Color.Black;
            loadMenu_byUsers_GChildTagged();
            loadMenu_byUsers_ParentTagged();
        }



        public void loadMenu_byUsers_ParentTagged()
        {

        
            ready = false;
            xClass.fillListBox_Id(listBoxParentTag, "filter_users_parenttagged_at_userights", dSet, p_id, 0, 0);
            ready = true;
        }


        public void loadMenu_byUsers_GChildTagged()
        {

            //GetMenuByUsers
            ready = false;
            xClass.fillListBox_Id(listBoxGrandChildTag, "filter_users_grandchild_at_userights", dSet, p_id, 0, 0);
            ready = true;
            lbltotalGrandChildActive.Text = listBoxGrandChildTag.Items.Count.ToString();


        }




        public void loadParentMenu()
        {
            ready = false;
            myClass.fillComboBoxDepartment(cboParentMenu, "parentform_dropdown", dSet);
            ready = true;

            lblparentmenuid.Text = cboParentMenu.SelectedValue.ToString();
        }



        private void getAllTaggedParentMenu()
        {
            dset_emp = objStorProc.sp_getMajorTables("ParentFormsTaggedRightsMenu");

            if (dset_emp.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_emp.Tables[0]);
                if (myglobal.global_module == "EMPLOYEE")
                {

                }
                else if (myglobal.global_module == "Active")
                {

                    dv.RowFilter = "user_rights_name = '" + txtRights.Text + "' ";

                }
                else if (myglobal.global_module == "VISITORS")
                {

                }
                dgvTagParentMenu.DataSource = dv;
                //lblrecords.Text = dgv_table.RowCount.ToString();
            }


        }

        private void getAllParentMenu()
        {

            //string mcolumns = "menu_id,menu_name,department";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            //pointer_module.populateModule(dsetHeader, dgvParentMenu, mcolumns, "ParentFormsRightsMenu");

            dset_emp = objStorProc.sp_getMajorTables("ParentFormsRightsMenu");

            if (dset_emp.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_emp.Tables[0]);
                if (myglobal.global_module == "EMPLOYEE")
                {

                }
                else if (myglobal.global_module == "Active")
                {

                    dv.RowFilter = "is_active = '1' ";

                }
                else if (myglobal.global_module == "VISITORS")
                {

                }
                dgvParentMenu.DataSource = dv;
                lbltotalMenu.Text = dgvParentMenu.RowCount.ToString();
                //lblrecords.Text = dgv_table.RowCount.ToString();
            }



        }

        public void FalseButton()

        {
     
            btnRemoveMenu.Enabled = false;
            btnCancelUpdateMenu.Enabled = false;
            btnSelectAll.Enabled = false;
            btnUnselectAll.Enabled = false;


        }
        public void displayUserRights()
        {
            ready = false;
            xClass.fillListBox(listViewuser_rights, "user_rights", dSet);
            ready = true;
            lbltotalrecordsrights.Text = listViewuser_rights.Items.Count.ToString();
        }

        private void listViewuser_rights_Click(object sender, EventArgs e)
        {
            btnDeleteTool.Visible = true;
            btnUpdateTheMenu.Visible = true;
            showvalue();
            loadMenu_byUsers();
            loadMenu_byUsers_GChildTagged();
    
            loadMenu_byUsers_ParentTagged();
        }
        public void showvalue()
        {
            if (ready == true)
            {
                if (listViewuser_rights.Items.Count > 0)
                {
                    p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                    txtRights.Text = listViewuser_rights.Text;
                  
                }
            }
        }

        public void GrandChildshowvalue()
        {
       
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = "add";
            btnAddTool.Visible = false;

            btnUpdateTool.Visible = true;
            txtRights.ReadOnly = false;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            txtRights.Text = "";
            txtRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtRights.Focus();
                return;

            }
            btnMetroSave_Click(sender, e);
         
        }

        void FillUserRights()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING FILL UP THE REQUIRED FIELDS ";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }



        public bool saveMode()
        {
            if (mode == "add")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(0, txtRights.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    UserRightexists();
                    //MessageBox.Show(lblName.Text + " : [ " + txtRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRights.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(0, txtRights.Text, "add");


                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(0, txtRights.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtRights.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "edit");


                        return true;
                    }
                    else
                    {
                        //sample muna
                        //MessageBox.Show(lblName.Text + " : [ " + txtRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRights.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(p_id, txtRights.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtRights.Text, "delete");

                return true;
            }
            return false;
        }

        public void UserRightsUpdated()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER RIGHTS UPDATED";
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

        void UserRightexists()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "WARNING USER RIGHTS ALREADY EXISTS " + txtRights.Text + " ";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            btnAddTool.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;
            cboParentMenu.Visible = false;
            lblAvailableMenu.Visible = false;
        }

        private void btnMetroSave_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the New User Type", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtRights.Text.Trim() == string.Empty)
                {
                    FillUserRights();
                    txtRights.Focus();
                    //MessageBox.Show("Please enter " + lblName.Text + ". ", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (saveMode())
                    {
                        displayUserRights();
                        btnEditTool.Visible = true;
                        btnUpdateTool.Visible = false;
                        if (listViewuser_rights.Items.Count > 0)
                        {
                            int index = listViewuser_rights.FindString(txtRights.Text, 0);
                            if (index == -1) { index = 0; }
                            listViewuser_rights.SelectedIndex = index;
                        }
                        btnCancel_Click("", e);
                        btnAddTool.Visible = true;
                        UserRightsUpdated();
                    }
                }

            }
            else
            {

                return;
            }
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            dataView.Visible = true;
            lblAvailableMenu.Visible = true;
            btnCancelUpdateMenu.Visible = true;
            dataView.Enabled = true;
            ListViewmenu.Enabled = true;
           listViewuser_rights.Enabled = false;

            cboParentMenu.Visible = true;
      

            btnAddTool.Visible = false;
            btnUpdateTool.Visible = false;
            btnDeleteTool.Visible = false;
            btnCancelTool.Visible = false;
            btnEditTool.Visible = false;
            cboParentMenu.Enabled = true;
        
            panel3Enabled();
            UpdateMenu();
            //loadAvailableMenu();
            load_search_ChildMenu(); //Bind the Information
        }



        DataSet dset_emp = new DataSet();
       private void doSearch()
        {
            try
            {
                if (dset_emp_childTagging.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp_childTagging.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "count = '" + lblparentmenuid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataView.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found xxx!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                return;
            }
        }



     

        private void doSearchGrandChildredMenu()
        {
            try
            {
                if (dset_emp_grandchildTagging.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp_grandchildTagging.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "parent_menu = '" + txtchildid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                     dgvGrandChild.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found xxx!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
        }




        private  void doSearchTagParentMenu()
        {
            try
            {
                if (dset_emp.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset_emp.Tables[0]);
                    if (myglobal.global_module == "EMPLOYEE")
                    {

                    }
                    else if (myglobal.global_module == "Active")
                    {

                        dv.RowFilter = "count = '" + lblparentmenuid.Text + "'";

                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dgvTagParentMenu.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
        }


        DataSet dset_emp_childTagging = new DataSet();
        public void load_search_ChildMenu()
        {
            dset_emp_childTagging.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp_childTagging = objStorProc.sp_getMajorTables("employee"); }

            else if (myglobal.global_module == "Active")
            { dset_emp_childTagging = objStorProc.sp_getMajorTables("ParentMenuTagging"); }
            else if (myglobal.global_module == "InActive")
            { dset_emp_childTagging = objStorProc.sp_getMajorTables("InactiveFeedCode"); }


            doSearch();

        }


        DataSet dset_emp_grandchildTagging = new DataSet();
        public void load_search_GrandChildMenu()
        {
            dset_emp_grandchildTagging.Clear();

        
             dset_emp_grandchildTagging = objStorProc.sp_getMajorTables("GrandChildMenuTagging"); 
      

            doSearchGrandChildredMenu();

        }





        public void load_search_TaggedChildMenu()
        {
            dset_emp.Clear();

            if (myglobal.global_module == "EMPLOYEE")
            { dset_emp = objStorProc.sp_getMajorTables("employee"); }

            else if (myglobal.global_module == "Active")
            { dset_emp = objStorProc.sp_getMajorTables("ParentMenuTagging"); }
            else if (myglobal.global_module == "InActive")
            { dset_emp = objStorProc.sp_getMajorTables("InactiveFeedCode"); }


            doSearchTagParentMenu();

        }


        public void panel3Enabled()
        {
   
            btnRemoveMenu.Enabled = true;
            btnCancelUpdateMenu.Enabled = true;
            btnSelectAll.Enabled = true;
            btnUnselectAll.Enabled = true;
            GbSelectionSide.Visible = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtRights.ReadOnly = false;
            txtRights.Focus();
            listViewuser_rights.Enabled = false;
            btnUpdateTool.Visible = true;
            btnEditTool.Visible = false;
        }

        public void UpdateMenu()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Forms Available Activated Ready for Tagging !";
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

        private void btnCancelListViewMenu_Click(object sender, EventArgs e)
        {
            btnSelectAll.Visible = false;
            btnUnselectAll.Visible = false;
            dataView.Visible = false;
            cboParentMenu.Enabled = false;
            btnCancelUpdateMenu.Visible = false;
    
            deselectAll();
            dataView.Enabled = false;
            ListViewmenu.Enabled = false;
            listViewuser_rights.Enabled = true;
            cboParentMenu.Visible = false;
            lblAvailableMenu.Visible = false;
            btnAddTool.Visible = true;
            btnUpdateTool.Visible = true;
            btnDeleteTool.Visible = true;
            btnCancelTool.Visible = true;
           
        }


        public void selectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = true; }
            btnSelectAll.Visible = false;
            btnUnselectAll.Visible = true;
        }
        public void deselectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = false; }
            btnSelectAll.Visible = true;
            btnUnselectAll.Visible = false;
        }

        private void listViewuser_rights_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMenu_byUsers();
            loadMenu_byUsers_GChildTagged();
            loadMenu_byUsers_ParentTagged();
            lbltotalGrandChildActive.Text = listBoxGrandChildTag.Items.Count.ToString();
        }
         public void loadMenu_byUsers()
        {

            //GetMenuByUsers
            ready = false;
            xClass.fillListBox_Id(ListViewmenu, "filter_users", dSet, p_id, 0, 0);
            ready = true;
            lbltotalChildActive.Text = ListViewmenu.Items.Count.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                listViewuser_rights.Enabled = true;
             
                txtRights.Focus();
             
                return;

            }
            metroButtonDelete_Click(sender, e);
        }

        public void SelectUserRights()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Fedora Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Please Select User Rights";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();

            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);

            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;


            popup.ShowOptionsButton = true;


        }

        public void UserRighstDeleted()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "USER RIGHTS DELETED SUCCESSFULLY !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton = true;


        }

        public void AlreadyAddedOnYourParentMenu()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "This menu is already added on your rights !";
            popup.ContentColor = Color.White;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            popup.Size = new Size(350, 100);
            popup.ImageSize = new Size(70, 80);
            popup.BodyColor = Color.Red;
            popup.Popup();
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.Delay = 500;
            popup.AnimationInterval = 10;
            popup.AnimationDuration = 1000;
            popup.ShowOptionsButton = true;


        }

        private void metroButtonDelete_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The User Right ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (listViewuser_rights.Items.Count > 0)
                {
           

                    mode = "delete";
                    if (saveMode())
                    {
                        displayUserRights();
                        if (listViewuser_rights.Items.Count > 0)
                        {
                            int index = listViewuser_rights.FindString(txtRights.Text, 0);
                            if (index == -1) { index = 0; }
                            listViewuser_rights.SelectedIndex = index;
                        }
                        mode = "";
                        listViewuser_rights_Click(sender, e);
                        UserRighstDeleted();
                    }
                }
                //}

            }
            else
            {

                return;
            }
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            mode = "add";
            btnAddTool.Visible = false;
            btnCancelTool.Visible = true;
            btnUpdateTool.Visible = true;
            txtRights.ReadOnly = false;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            txtRights.Text = "";
            txtRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void btnCancelTool_Click(object sender, EventArgs e)
        {
            mode = "";
            btnAddTool.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;
            cboParentMenu.Visible = false;
            lblAvailableMenu.Visible = false;
        }

        private void btnEditTool_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtRights.ReadOnly = false;
            txtRights.Focus();
            listViewuser_rights.Enabled = false;
            btnUpdateTool.Visible = true;
            btnEditTool.Visible = false;
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                listViewuser_rights.Enabled = true;

                txtRights.Focus();

                return;

            }
            metroButtonDelete_Click(sender, e);
        }

        private void btnUpdateTool_Click(object sender, EventArgs e)
        {
            if (txtRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtRights.Focus();
                return;

            }
            btnMetroSave_Click(sender, e);
        }


        private void loadAvailableMenu()
        {
            //xClass.fillDataGridView(dataView, cboParentMenu.Text, dSet);
            //dataView.Columns[2].Width = 500;
            //dataView.Columns[1].Width = 50;
            //dataView.Columns[0].Width = 30;
            //dataView.Columns[2].HeaderText = "Menu Name";
            //dataView.Columns[3].Visible = false;
        }

        private void cbcategory_DropDownClosed(object sender, EventArgs e)
        {
            //loadAvailableMenu();
            //btnselect.Visible = true;
            //btndeselect.Visible = true;
        }

        private void cboParentMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            //lblparentmenuid.Text = cboParentMenu.SelectedValue.ToString();

            //load_search_ChildMenu();
            //load_search_GrandChildMenu();
           
        }

        private void lblparentmenuid_Click(object sender, EventArgs e)
        {
         
        }

        private void TagParentMenu()
        {

            int x = 0;
            for (int i = 0; i < dgvParentMenu.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvParentMenu.Rows[i].Cells[0].Value))
                    x++;
            }
            if (x <= 0)
            {
                MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                showvalue();
                for (int n = 0; n < dgvParentMenu.RowCount; n++)
                {
                    if (Convert.ToBoolean(dgvParentMenu.Rows[n].Cells[0].Value))
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_Parent", 0, p_id, Convert.ToInt32(dgvParentMenu.Rows[n].Cells[1].Value));
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            string temp = dSet.Tables[0].Rows[0][2].ToString();
                            AlreadyAddedOnYourParentMenu();
                            //MessageBox.Show("This menu is already added on your rights: " + temp);
                            deselectAll();
                            return;
                        }
                    }
                }

                for (int i = 0; i < dgvParentMenu.RowCount; i++)
                {
                    dSet.Clear();
                    if (Convert.ToBoolean(dgvParentMenu.Rows[i].Cells[0].Value))
                    {
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(dgvParentMenu.Rows[i].Cells[1].Value),"" , lblUserID.Text.Trim(), "Parent", lblFirstName.Text.Trim(), "add");
                    }
                }

                loadMenu_byUsers();
                loadMenu_byUsers_ParentTagged();
                SaveUpdateMenuNotifications();
                btnUnselectAll_Click(new object(), new System.EventArgs());
                btnCancelListViewMenu_Click(new object(), new System.EventArgs());
                getAllTaggedParentMenu(); //Tag Menu Refresh
                load_search_ChildMenu(); // Select the Child
            
            }



        }

        private void SaveUpdateMenuNotifications()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "SUCCESSFULLY UPDATE THE FORMS";
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



        private void CheckChildTagging()
        {
            showvalue();
            for (int n = 0; n < dataView.RowCount; n++)
            {
                if (Convert.ToBoolean(dataView.Rows[n].Cells[0].Value))
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms", 0, p_id, Convert.ToInt32(dataView.Rows[n].Cells[1].Value));
                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        string temp = dSet.Tables[0].Rows[0][2].ToString();
                        MessageBox.Show("This menu is already added on your rights: " + temp);
                        //AlreadyAddedOnYourParentMenu();
                        //deselectAll();
                        return;
                    }
                }
            }

        }


        private void btnMenuUpdate_Click(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < dataView.RowCount; i++)
            {
                if (Convert.ToBoolean(dataView.Rows[i].Cells[0].Value))
                    x++;
            }
            if (x <= 0)
            {
                MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                showvalue();
                for (int n = 0; n < dataView.RowCount; n++)
                {
                    if (Convert.ToBoolean(dataView.Rows[n].Cells[0].Value))
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms", 0, p_id, Convert.ToInt32(dataView.Rows[n].Cells[1].Value));
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            string temp = dSet.Tables[0].Rows[0][2].ToString();
                            //MessageBox.Show("This menu is already added on your rights: " + temp);
                            AlreadyAddedOnYourParentMenu();
                            deselectAll();
                            return;
                        }
                    }
                }

                for (int i = 0; i < dataView.RowCount; i++)
                {
                    dSet.Clear();
                    if (Convert.ToBoolean(dataView.Rows[i].Cells[0].Value))
                    {
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(dataView.Rows[i].Cells[1].Value),"", lblUserID.Text.Trim(), "Child", lblFirstName.Text.Trim(), "add");
                    }
                }

                loadMenu_byUsers();
                loadMenu_byUsers_ParentTagged();
                SaveUpdateMenuNotifications();
                btnUnselectAll_Click(sender, e);
                btnCancelListViewMenu_Click(sender, e);
              
            }


        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            selectAll();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            deselectAll();
        }

        private void dataView_DoubleClick(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to the Child Menu ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                btnMenuUpdate_Click(sender, e);
                //this.ParentForm.Refresh();

            }
            else
            {

                return;
            }
        }

        private void dgvParentMenu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void txtRights_TextChanged(object sender, EventArgs e)
        {
            if(lbltotalrecordsrights.Text.Trim() == "0")
            {

            }
            else
            {
                getAllTaggedParentMenu(); //Tagged Equal ==
            
                getAllParentMenu();
           
            }
        
        }

        private void dgvParentMenu_DoubleClick(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Insert The Policy", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                TagParentMenu();
             

            }
            else
            {

                return;
            }



        }

        private void dgvTagParentMenu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void SuccessFullyUntag()
        {

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.new_logo;
            popup.TitleText = "Ultra Maverick Notifications";
            popup.TitleColor = Color.White;
            popup.TitlePadding = new Padding(95, 7, 0, 0);
            popup.TitleFont = new Font("Tahoma", 10);
            popup.ContentText = "Successfully Untagged";
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


        private void ToolDeleteTagMenu_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The Access on Selected Form Menu", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (dgvTagParentMenu.RowCount > 0)
                {
                    showKeyParent();
                    //dSet.Clear();
                    //dSet = objStorProc.sp_user_rights_details(Convert.ToInt32(this.txtparentidmenu.Text), "delete");

                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(pkey, "delete");

                  
                    SuccessFullyUntag();
                   
                    getAllTaggedParentMenu();

                }


            }
            else
            {

                return;
            }


        }

        private void dgvTagParentMenu_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvTagParentMenu.RowCount > 0)
            {
                if (dgvTagParentMenu.CurrentRow != null)
                {
                    if (dgvTagParentMenu.CurrentRow.Cells["menu_name"].Value != null)
                    {


                        txtparentidmenu.Text = dgvTagParentMenu.CurrentRow.Cells["user_rights_details_id"].Value.ToString();
    



                    }

                }
            }



        }

        private void btnUpdateTheMenu_Click(object sender, EventArgs e)
        {
            dataView.Visible = true;
            lblAvailableMenu.Visible = true;
            btnCancelUpdateMenu.Visible = true;
            dataView.Enabled = true;
            ListViewmenu.Enabled = true;
            listViewuser_rights.Enabled = false;
            dgvGrandChild.Visible = true;
            cboParentMenu.Visible = true;
            dgvTagParentMenu.Enabled = true;
            toolStripTagMenu.Visible = true;
            btnAddTool.Visible = false;
            btnUpdateTool.Visible = false;
            btnDeleteTool.Visible = false;
            btnCancelTool.Visible = false;
            btnEditTool.Visible = false;
            cboParentMenu.Enabled = true;
     
            panel3Enabled();
            UpdateMenu();

            getAllTaggedParentMenu(); //Tagged Equal ==
            cboParentMenu_SelectedValueChanged(sender, e);
            //load_search_ChildMenu(); //Bind the Information //8/25/2021
        }

        private void btnCancelUpdateMenu_Click(object sender, EventArgs e)
        {
            btnSelectAll.Visible = false;
            btnUnselectAll.Visible = false;
            dataView.Visible = false;
            cboParentMenu.Enabled = false;
            btnCancelUpdateMenu.Visible = false;
            dgvTagParentMenu.Enabled = false;
            toolStripTagMenu.Visible = true;
            deselectAll();
            dataView.Enabled = false;
            ListViewmenu.Enabled = false;
            listViewuser_rights.Enabled = true;
            cboParentMenu.Visible = false;
            lblAvailableMenu.Visible = false;
            btnAddTool.Visible = true;
            btnUpdateTool.Visible = true;
            btnDeleteTool.Visible = true;
            btnCancelTool.Visible = true;
            GbSelectionSide.Visible = false;
            dgvGrandChild.Visible = false;
        }

        private void dgvParentMenu_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void ListViewmenu_DoubleClick(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The Access on Selected Form Menu", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ListViewmenu.Items.Count > 0)
                {
                    showKey();
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights_details(pkey, "delete");



                    ListViewmenu_Click(sender, e);
                    UserRightsUpdated();

                }

            }
            else
            {

                return;
            }
        }

        private void showKey()
        {
            if (ready == true)
            {
                if (ListViewmenu.Items.Count > 0)
                {
                    pkey = Convert.ToInt32(ListViewmenu.SelectedValue.ToString());
                    loadMenu_byUsers();
                }
            }
        }


        private void showKeyParent()
        {
            if (ready == true)
            {
                if (listBoxParentTag.Items.Count > 0)
                {
                    pkey = Convert.ToInt32(listBoxParentTag.SelectedValue.ToString());
                    loadMenu_byUsers_ParentTagged();
                }
            }
        }


        private void ListViewmenu_Click(object sender, EventArgs e)
        {
          
         btnUpdateTheMenu.Visible = true;
            showvalue();
            //loadMenu_byUsers();  8/26/2021
        }

        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvGrandChild_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvGrandChild_DoubleClick(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to the GrandChild Menu ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                btnTaggingGchild_Click(sender, e);

            }
            else
            {

                return;
            }


        }

        private void btnTaggingGchild_Click(object sender, EventArgs e)
        {
            int x = 0;
            for (int i = 0; i < dgvGrandChild.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvGrandChild.Rows[i].Cells[0].Value))
                    x++;
            }

            if (x <= 0)
            {
                MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                showvalue();
                for (int n = 0; n < dgvGrandChild.RowCount; n++)
                {
                    if (Convert.ToBoolean(dgvGrandChild.Rows[n].Cells[0].Value))
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_grandChild", 0, p_id, Convert.ToInt32(dgvGrandChild.Rows[n].Cells[1].Value));
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            string temp = dSet.Tables[0].Rows[0][2].ToString();
                            //MessageBox.Show("This menu is already added on your rights: " + temp);
                            AlreadyAddedOnYourParentMenu();
                            //deselectAll();
                            btnUnSelectAlGrandChild_Click(sender , e);
                            return;
                        }
                    }
                }

                for (int i = 0; i < dgvGrandChild.RowCount; i++)
                {
                    dSet.Clear();
                    if (Convert.ToBoolean(dgvGrandChild.Rows[i].Cells[0].Value))
                    {
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(dgvGrandChild.Rows[i].Cells[1].Value), "", lblUserID.Text.Trim(), "GrandChild", lblFirstName.Text.Trim(), "add");
                    }
                }

                //loadMenu_byUsers();
                loadMenu_byUsers_GChildTagged();
                SaveUpdateMenuNotifications();
                btnUnSelectAlGrandChild_Click(sender, e);
                btnCancelListViewMenu_Click(sender, e);

            }
        }

        private void dataView_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataView.Rows.Count > 0)
            {
                if (dataView.CurrentRow != null)
                {
                    if (dataView.CurrentRow.Cells["menu_id"].Value != null)
                    {
                        p_id = Convert.ToInt32(dataView.CurrentRow.Cells["menu_id"].Value);
                       txtchildid.Text = dataView.CurrentRow.Cells["menu_id"].Value.ToString();
                    
                    }
                }
            }


        }

        private void txtchildid_TextChanged(object sender, EventArgs e)
        {
            load_search_GrandChildMenu();
        }

        private void listBoxParentTag_DoubleClick(object sender, EventArgs e)
        {
            ToolDeleteTagMenu_Click(sender, e);
        }

        private void cboParentMenu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblparentmenuid.Text = cboParentMenu.SelectedValue.ToString();

            load_search_ChildMenu();
            load_search_GrandChildMenu();
        }

        private void btnSelectAlGrandChild_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrandChild.RowCount; i++) { dgvGrandChild.Rows[i].Cells[0].Value = true; }
            btnSelectAlGrandChild.Visible = false;
            btnUnSelectAlGrandChild.Visible = true;
        }

        private void btnUnSelectAlGrandChild_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrandChild.RowCount; i++) { dgvGrandChild.Rows[i].Cells[0].Value = false; }
            btnUnSelectAlGrandChild.Visible = false;
            btnSelectAlGrandChild.Visible = true;
        }

        private void dataView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataView.CurrentCell.OwningColumn == dataView.Columns["chkSelected"] && dataView.IsCurrentCellDirty)
            {
                dataView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //your code goes here
                CheckChildTagging();
            }
        }

        private void dgvGrandChild_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvGrandChild.CurrentCell.OwningColumn == dgvGrandChild.Columns["chkSelected"] && dgvGrandChild.IsCurrentCellDirty)
            {
                dgvGrandChild.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //your code goes here
                CheckGrandChildTagging();
            }

          
        }
        private void  CheckGrandChildTagging()
        {

            showvalue();
            for (int n = 0; n < dgvGrandChild.RowCount; n++)
            {
                if (Convert.ToBoolean(dgvGrandChild.Rows[n].Cells[0].Value))
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_grandChild", 0, p_id, Convert.ToInt32(dgvGrandChild.Rows[n].Cells[1].Value));
                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        string temp = dSet.Tables[0].Rows[0][2].ToString();
                        MessageBox.Show("This menu is already added on your rights: " + temp);


                        return;
                    }
                }
            }

        }

        private void dgvParentMenu_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvParentMenu.CurrentCell.OwningColumn == dgvParentMenu.Columns["chkSelected"] && dgvParentMenu.IsCurrentCellDirty)
            {
                dgvParentMenu.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //your code goes here
                CheckParentTaggingMenu();
            }

      
        }


        private void CheckParentTaggingMenu()
        {
            showvalue();
            for (int n = 0; n < dgvParentMenu.RowCount; n++)
            {
                if (Convert.ToBoolean(dgvParentMenu.Rows[n].Cells[0].Value))
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_Parent", 0, p_id, Convert.ToInt32(dgvParentMenu.Rows[n].Cells[1].Value));
                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        string temp = dSet.Tables[0].Rows[0][2].ToString();
                        //AlreadyAddedOnYourParentMenu();
                        MessageBox.Show("This menu is already added on your rights: " + temp);

                        return;
                    }
                }
            }
        }

    }
}
