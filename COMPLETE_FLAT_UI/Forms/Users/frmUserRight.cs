using COMPLETE_FLAT_UI.Models;
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
using MaterialSkin;
using MaterialSkin.Controls;

namespace ULTRAMAVERICK.Forms.Users
{
    public partial class frmUserRight : MaterialForm
    {
        myclasses xClass = new myclasses();
        IStoredProcedures g_objStoredProcCollection = null;
        IStoredProcedures objStorProc = null;
        DataSet dSet = new DataSet();
        Boolean ready = false;
        string mode = "";
        int p_id = 0;
        int p_id_parent = 0;
        myclasses myClass = new myclasses();
        DataSet dSet_temp = new DataSet();
        myglobal pointer_module = new myglobal();
        DataSet dsetHeader = new DataSet();
        int pkey = 0;
        int pkey2 = 0;
        public Byte[] imageByte = null;
        public frmUserRight()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void HideExistingMaterialCard()
        {
            //1st Material Card
            materialTextBoxMenuAvailable.Visible = false;
            materialCard1.Visible = false;
            materialBtnUpdateMenu.Visible = false;
            materialButtonCancel.Visible = false;
            //2nd Material Card
            txtMaterialMenuName.Visible = false;
            materialCard2.Visible = false;
            materialButtonUpdateSubMenu.Visible = false;

            //3rd Material Card
           
            materialBtnShowAvailSubMenu.Visible = false;

            //4th  Material Card
  
  
     
  
            //5th Material Card
            txtGChildName.Visible = false;
            

            //6th Material Card

         
  

            //
            materialBtnNew.Visible = true;
            //MatMenu
       

        }


        private void frmUserRight_Load(object sender, EventArgs e)
        {
            g_objStoredProcCollection = myClass.g_objStoredProc.GetCollections(); // Main Stored Procedure Collections
            objStorProc = xClass.g_objStoredProc.GetCollections(); //Call the StoreProcedure With Class

      
            displayUserRights();
            listViewuser_rights_Click(sender, e);
            FalseButton();
            HideExistingMaterialCard();


            loadParentMenu();
            ListViewmenu.Enabled = false;
         

            myglobal.global_module = "Active"; // Mode for Searching

            getAllTaggedParentMenu(); //Tagged Equal ==
            lblUserID.Text = userinfo.user_id.ToString(); // ID of User
            lblFirstName.Text = userinfo.emp_name.ToUpper(); // First Name Session
            materialTxtModuelAvail.RowsDefaultCellStyle.ForeColor = Color.Black;
            loadMenu_byUsers_GChildTagged();
            loadMenu_byUsers_ParentTagged();

            showvalue();
        }

        private void checkTheDataofParentMenu()
        {
            if (listBoxParentTag.Items.Count > 0)
            {

            }
        }

        public void loadMenu_byUsers_ParentTagged()
        {

        
            ready = false;
            xClass.fillListBox_Id(listBoxParentTag, "filter_users_parenttagged_at_userights", dSet, p_id, 0, 0);
            ready = true;
        }


        public void loadMenu_byUsers_GChildTagged()
        {

            //KIKI
            ready = false;
            xClass.fillListBox_Id(listBoxGrandChildTag, "filter_users_grandchild_at_userights", dSet, p_id, 0, 0);
            ready = true;
            lbltotalGrandChildActive.Text = listBoxGrandChildTag.Items.Count.ToString();


        }




        public void loadParentMenu()
        {
            //ready = false;
            //myClass.fillComboBoxDepartment(cboParentMenu, "parentform_dropdown", dSet);
            //ready = true;

            //lblparentmenuid.Text = cboParentMenu.SelectedValue.ToString();
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

                    dv.RowFilter = "user_rights_name = '" + txtMaterialRights.Text + "' ";

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
            //buje

            //string mcolumns = "menu_id,menu_name,department";     /* ,InitialMemoReleased,ResolutionMemoReleased*/
            //pointer_module.populateModule(dsetHeader, dgvParentMenu, mcolumns, "ParentFormsRightsMenu");
            showvalue();
            dset_emp = objStorProc.sp_getMajorTables("ParentFormsRightsMenu");

            if (dset_emp.Tables.Count > 0)
            {
                DataView dv = new DataView(dset_emp.Tables[0]);
                if (myglobal.global_module == "EMPLOYEE")
                {

                }
                else if (myglobal.global_module == "Active")
                {

                    dv.RowFilter = "user_rights_id = "+p_id+" ";

                }
                else if (myglobal.global_module == "VISITORS")
                {

                }
                materialTxtModuelAvail.DataSource = dv;
                //lbltotalMenu.Text = dgvParentMenu.RowCount.ToString();
                //lblrecords.Text = dgv_table.RowCount.ToString();
            }

            this.materialTxtModuelAvail.Columns["menu_id"].Visible = false;
            this.materialTxtModuelAvail.Columns["department"].Visible = false;
            this.materialTxtModuelAvail.Columns["is_active"].Visible = false;
            this.materialTxtModuelAvail.Columns["user_rights_id"].Visible = false;
            this.materialTxtModuelAvail.Columns["ID"].Visible = false;
            this.materialTxtModuelAvail.Columns["menu_name"].HeaderText = "MENU";
        }

        public void FalseButton()

        {
     
            btnRemoveMenu.Enabled = false;
            btnCancelUpdateMenu.Enabled = false;
 


        }

        public void displayUserRights()
        {
            ready = false;
            xClass.fillListBox(listViewuser_rights, "user_rights", dSet);
            ready = true;
            lbltotalrecordsrights.Text = listViewuser_rights.Items.Count.ToString();
            if (lbltotalrecordsrights.Text == "0")
            {

            }
            else
            {
                btnEditTool.Visible = true;
            }
        }

        private void listViewuser_rights_Click(object sender, EventArgs e)
        {
            if(materialCard1.Visible ==true)
            {
                btnDeleteTool.Visible = false;
            }
            else
            {
                btnDeleteTool.Visible = true;
            }
        
            btnUpdateTheMenu.Visible = true;
            showvalue();
            loadMenu_byUsers();
            loadMenu_byUsers_GChildTagged();
    
            loadMenu_byUsers_ParentTagged();
            if (listBoxParentTag.Items.Count > 0)
            {
               
                materialTextBoxMenuAvailable.Text = listBoxParentTag.Text;

            }
            else
            {
                materialTextBoxMenuAvailable.Text = String.Empty;
            }
        }

        public void showvalue()
        {
            if (ready == true)
            {
                if (listViewuser_rights.Items.Count > 0)
                {
                    p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                    txtMaterialRights.Text = listViewuser_rights.Text;
                    //p_id = int.Parse(lbl.Text);
                }
            }
        }

        public void GrandChildshowvalue()
        {
       
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = "add";
            materialBtnNew.Visible = false;

            btnUpdateTool.Visible = true;
            txtMaterialRights.ReadOnly = false;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            txtMaterialRights.Text = "";
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtMaterialRights.Focus();
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
                dSet = objStorProc.sp_user_rights(0, txtMaterialRights.Text, "getbyname");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    UserRightexists();
                    //MessageBox.Show(lblName.Text + " : [ " + txtMaterialRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaterialRights.Focus();
                    return false;
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(0, txtMaterialRights.Text, "add");
                    displayUserRights();
                    SaveMenus();

                    return true;
                }
            }
            else if (mode == "edit")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(0, txtMaterialRights.Text, "getbyname");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtMaterialRights.Text, "getbyid");

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    int tmpID = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());
                    if (tmpID == p_id)
                    {
                        dSet.Clear();
                        dSet = objStorProc.sp_user_rights(p_id, txtMaterialRights.Text, "edit");


                        return true;
                    }
                    else
                    {
                        //sample muna
                        //MessageBox.Show(lblName.Text + " : [ " + txtMaterialRights.Text + " ] already exist...", lblName.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaterialRights.Focus();
                        return false;
                    }
                }
                else
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights(p_id, txtMaterialRights.Text, "edit");

                    return true;
                }
            }
            else if (mode == "delete")
            {
                dSet.Clear();
                dSet = objStorProc.sp_user_rights(p_id, txtMaterialRights.Text, "delete");

                dSet_temp.Clear();
                dSet_temp = objStorProc.sp_user_rights(p_id, txtMaterialRights.Text, "delete");

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
            popup.ContentText = "WARNING USER RIGHTS ALREADY EXISTS " + txtMaterialRights.Text + " ";
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
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtMaterialRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;

         
        }

        private void btnMetroSave_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Save the New User Type", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (txtMaterialRights.Text.Trim() == string.Empty)
                {
                    FillUserRights();
                    txtMaterialRights.Focus();
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
                            int index = listViewuser_rights.FindString(txtMaterialRights.Text, 0);
                            if (index == -1) { index = 0; }
                            listViewuser_rights.SelectedIndex = index;
                        }
                        btnCancel_Click("", e);
                        materialBtnNew.Visible = true;
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
       
            btnCancelUpdateMenu.Visible = true;
            dataView.Enabled = true;
            ListViewmenu.Enabled = true;
           listViewuser_rights.Enabled = false;




            materialBtnNew.Visible = false;
            btnUpdateTool.Visible = false;
            btnDeleteTool.Visible = false;
            btnCancelTool.Visible = false;
            btnEditTool.Visible = false;
         
        
            panel3Enabled();
            //UpdateMenu();
            //loadAvailableMenu();
            load_search_ChildMenu(); //Bind the Information
        }



        DataSet dset_emp = new DataSet();
       private void doSearch()
        {
            //showvalue();

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



                        //p_id = Convert.ToInt32(listBoxParentTag.SelectedValue.ToString());
                        if (listBoxParentTag.Items.Count > 0)
                        {
                            //var SelectedDataRowParent = (listBoxParentTag.SelectedItem as DataRowView)["parent_id"].ToString();


                            var SelectedDataRowParent = (listBoxParentTag.SelectedItem as DataRowView)["user_rights_id"].ToString();




                            dv.RowFilter = "user_rights_id = " + SelectedDataRowParent + "";
                            //dv.RowFilter = "count = '" + lblparentmenuid.Text + "'";
                        }
                    }
                    else if (myglobal.global_module == "VISITORS")
                    {

                    }
                    dataView.DataSource = dv;
                    //lblrecords.Text = dgv_table.RowCount.ToString();
                }
                this.dataView.Columns["menu_id"].Visible = false;
                this.dataView.Columns["menu_form_name"].Visible = false;
                this.dataView.Columns["count"].Visible = false;
                this.dataView.Columns["is_active"].Visible = false;
                this.dataView.Columns["menu_id1"].Visible = false;
                this.dataView.Columns["user_rights_id"].Visible = false;
                this.dataView.Columns["menu_name"].HeaderText = "MENU";

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

                        if (ListViewmenu.Items.Count > 0)
                        {

                            showvalue();
                            //Gerard Singian Developer Man
                            var SelectedDataRowParent = (ListViewmenu.SelectedItem as DataRowView)["menu_id"].ToString();


                            dv.RowFilter = "parent_menu = " + SelectedDataRowParent + " and user_rights_id = " + p_id + " ";

                        }
                        //dv.RowFilter = "parent_menu = '" + txtchildid.Text + "'";

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


            this.dgvGrandChild.Columns["primary_menu_id"].Visible = false;
            this.dgvGrandChild.Columns["menu_form_name"].Visible = false;
            this.dgvGrandChild.Columns["parent_menu"].Visible = false;
            this.dgvGrandChild.Columns["primary_menu_id"].Visible = false;
            this.dgvGrandChild.Columns["primary_menu_id1"].Visible = false;
            this.dgvGrandChild.Columns["menu_name"].HeaderText = "MENU";
            this.dgvGrandChild.Columns["user_rights_id"].Visible = false;
            this.dgvGrandChild.Columns["is_active"].Visible = false;

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
   


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtMaterialRights.ReadOnly = false;
            txtMaterialRights.Focus();
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
     
    
       
            btnCancelUpdateMenu.Visible = false;
    
            deselectAll();
            dataView.Enabled = false;
            ListViewmenu.Enabled = false;
            listViewuser_rights.Enabled = true;
         
     
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = true;
            btnDeleteTool.Visible = true;
            btnCancelTool.Visible = true;
           
        }


        public void selectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = true; }
            btnSelectAll.Visible = false;
    
        }
        public void deselectAll()
        {
            for (int i = 0; i < dataView.RowCount; i++) { dataView.Rows[i].Cells[0].Value = false; }
    
        
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
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                listViewuser_rights.Enabled = true;
             
                txtMaterialRights.Focus();
             
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
                            int index = listViewuser_rights.FindString(txtMaterialRights.Text, 0);
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
            materialBtnNew.Visible = false;
            btnCancelTool.Visible = true;
            btnUpdateTool.Visible = true;
            txtMaterialRights.ReadOnly = false;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            txtMaterialRights.Text = "";
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void btnCancelTool_Click(object sender, EventArgs e)
        {
            mode = "";
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtMaterialRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;
          
       
        }

        private void btnEditTool_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtMaterialRights.ReadOnly = false;
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
            btnUpdateTool.Visible = true;
            btnEditTool.Visible = false;
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateTool_Click(object sender, EventArgs e)
        {

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

            //int x = 0;
            //for (int i = 0; i < dgvParentMenu.RowCount; i++)
            //{
            //    if (Convert.ToBoolean(dgvParentMenu.Rows[i].Cells[0].Value))
            //        x++;
            //}
            //if (x <= 0)
            //{
            //    MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //else
            //{

                showvalue();
                //for (int n = 0; n < dgvParentMenu.RowCount; n++)
                //{
                //    if (Convert.ToBoolean(dgvParentMenu.Rows[n].Cells[0].Value))
                //    {
                //        dSet.Clear();
                //        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_Parent", 0, p_id, Convert.ToInt32(dgvParentMenu.Rows[n].Cells[1].Value));
                //        if (dSet.Tables[0].Rows.Count > 0)
                //        {
                //            string temp = dSet.Tables[0].Rows[0][2].ToString();
                //            AlreadyAddedOnYourParentMenu();
                //            //MessageBox.Show("This menu is already added on your rights: " + temp);
                //            deselectAll();
                //            return;
                //        }
                //    }
                //}

                //for (int i = 0; i < dgvParentMenu.RowCount; i++)
                //{
                    dSet.Clear();
                    //if (Convert.ToBoolean(dgvParentMenu.Rows[i].Cells[0].Value))
                    //{
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(txtmenuid.Text),"" , lblUserID.Text.Trim(), "Parent", lblFirstName.Text.Trim(), txtIDParent.Text.Trim(), "add");
                //    }
                //}

                loadMenu_byUsers();
                loadMenu_byUsers_ParentTagged();
                getAllParentMenu();
                SaveUpdateMenuNotifications();
                btnUnselectAll_Click(new object(), new System.EventArgs());
                btnCancelListViewMenu_Click(new object(), new System.EventArgs());
                getAllTaggedParentMenu(); //Tag Menu Refresh
                load_search_ChildMenu(); // Select the Child
            
            //}



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
                //for (int n = 0; n < dataView.RowCount; n++)
                //{
                //    if (Convert.ToBoolean(dataView.Rows[n].Cells[0].Value))
                //    {
                //        dSet.Clear();
                //        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms", 0, p_id, Convert.ToInt32(dataView.Rows[n].Cells[1].Value));
                //        if (dSet.Tables[0].Rows.Count > 0)
                //        {
                //            string temp = dSet.Tables[0].Rows[0][2].ToString();
                //            //MessageBox.Show("This menu is already added on your rights: " + temp);
                //            AlreadyAddedOnYourParentMenu();
                //            deselectAll();
                //            return;
                //        }
                //    }
                //}

                for (int i = 0; i < dataView.RowCount; i++)
                {
                    dSet.Clear();
                    if (Convert.ToBoolean(dataView.Rows[i].Cells[0].Value))
                    {
                        p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(dataView.Rows[i].Cells[1].Value),"", lblUserID.Text.Trim(), "Child", lblFirstName.Text.Trim(), Convert.ToString(dataView.Rows[i].Cells[6].Value), "add");
                    }
                }

                loadMenu_byUsers();
                //loadMenu_byUsers_ParentTagged();
                SaveUpdateMenuNotifications();
                btnUnselectAll_Click(sender, e);
                load_search_ChildMenu();
                //btnCancelListViewMenu_Click(sender, e);
              
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
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to the update the Sub Menu ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void txtMaterialRights_TextChanged(object sender, EventArgs e)
        {
            if(lbltotalrecordsrights.Text.Trim() == "0")
            {

            }
            else
            {
                //getAllTaggedParentMenu(); //Tagged Equal ==
            
                //getAllParentMenu();
           
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
                //showvalue();
                if (listBoxParentTag.Items.Count > 0)
                {
                    showKeyParent();


                    if (listViewuser_rights.Items.Count > 0)
                    {
                        p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                    }
                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(pkey, "delete");

                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(p_id, 0,0,"","","","",materialTextBoxMenuAvailable.Text.Trim(), "delete_LogsParent");

                   
                    SuccessFullyUntag();

                    listViewuser_rights_Click(sender, e);
                    //loadMenu_byUsers_ParentTagged();
                    //getAllTaggedParentMenu();

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
        
            btnCancelUpdateMenu.Visible = true;
            dataView.Enabled = true;
            ListViewmenu.Enabled = true;
            listViewuser_rights.Enabled = false;
            dgvGrandChild.Visible = true;
        
            dgvTagParentMenu.Enabled = true;

            materialBtnNew.Visible = false;
            btnUpdateTool.Visible = false;
            btnDeleteTool.Visible = false;
            btnCancelTool.Visible = false;
            btnEditTool.Visible = false;
          
     
            panel3Enabled();
            //UpdateMenu();

            getAllTaggedParentMenu(); //Tagged Equal ==
            cboParentMenu_SelectedValueChanged(sender, e);
            //load_search_ChildMenu(); //Bind the Information //8/25/2021
        }

        private void btnCancelUpdateMenu_Click(object sender, EventArgs e)
        {
      
       
   
            btnCancelUpdateMenu.Visible = false;
            dgvTagParentMenu.Enabled = false;

            deselectAll();
            dataView.Enabled = false;
            ListViewmenu.Enabled = false;
            listViewuser_rights.Enabled = true;
           
      
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = true;
            btnDeleteTool.Visible = true;
            btnCancelTool.Visible = true;

            dgvGrandChild.Visible = false;
        }

        private void dgvParentMenu_CurrentCellChanged(object sender, EventArgs e)
        {
            if (materialTxtModuelAvail.RowCount > 0)
            {
                if (materialTxtModuelAvail.CurrentRow != null)
                {
                    if (materialTxtModuelAvail.CurrentRow.Cells["menu_name"].Value != null)
                    {

                        txtMaterialMenuName.Text = materialTxtModuelAvail.CurrentRow.Cells["menu_name"].Value.ToString();
                        txtIDParent.Text = materialTxtModuelAvail.CurrentRow.Cells["ID"].Value.ToString();
                       txtmenuid.Text = materialTxtModuelAvail.CurrentRow.Cells["menu_id"].Value.ToString();


                    }

                }
            }
        }

        private void ListViewmenu_DoubleClick(object sender, EventArgs e)
        {
            txtMaterialChildName.Text = ListViewmenu.Text;

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The Access on Selected Form Menu", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ListViewmenu.Items.Count > 0)
                {
                    showKey();

                    if (listViewuser_rights.Items.Count > 0)
                    {
                        p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                    }

                    dSet.Clear();
                    dSet = objStorProc.sp_user_rights_details(pkey, "delete");


                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(p_id, 0, 0, "", "", "", "", txtMaterialChildName.Text.Trim(), "delete_LogsChild");


                   
                    loadMenu_byUsers();
                    ListViewmenu_Click(sender, e);
                    load_search_ChildMenu();
            
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
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
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
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to tag the Modules ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            //int x = 0;
            //for (int i = 0; i < dgvGrandChild.RowCount; i++)
            //{
            //    if (Convert.ToBoolean(dgvGrandChild.Rows[i].Cells[0].Value))
            //        x++;
            //}

            //if (x <= 0)
            //{
            //    MessageBox.Show("Please select a menu before updating.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //else
            //{

                showvalue();
                //for (int n = 0; n < dgvGrandChild.RowCount; n++)
                //{
                //    if (Convert.ToBoolean(dgvGrandChild.Rows[n].Cells[0].Value))
                //    {
                //        dSet.Clear();
                //        dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_grandChild", 0, p_id, Convert.ToInt32(dgvGrandChild.Rows[n].Cells[1].Value));
                //        if (dSet.Tables[0].Rows.Count > 0)
                //        {
                //            string temp = dSet.Tables[0].Rows[0][2].ToString();
                //            //MessageBox.Show("This menu is already added on your rights: " + temp);
                //            AlreadyAddedOnYourParentMenu();
                //            //deselectAll();
                //            btnUnSelectAlGrandChild_Click(sender , e);
                //            return;
                //        }
                //    }
                //}

                //for (int i = 0; i < dgvGrandChild.RowCount; i++)
                //{
                    dSet.Clear();
                    //if (Convert.ToBoolean(dgvGrandChild.Rows[i].Cells[0].Value))
                    //{
                        dSet = objStorProc.sp_user_rights_details(0, p_id, Convert.ToInt32(txtchildprimarymenuid.Text), "", lblUserID.Text.Trim(), "GrandChild", lblFirstName.Text.Trim(), Convert.ToString(txtchildprimarymenuid.Text), "add");
                //    }
                //}

                //loadMenu_byUsers();
                loadMenu_byUsers_GChildTagged();
                SaveUpdateMenuNotifications();
                btnUnSelectAlGrandChild_Click(sender, e);
                btnCancelListViewMenu_Click(sender, e);
            ListViewmenu_Click_1(sender, e);
            //}
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

                        materialTextBoxSubMenuAvail.Text = dataView.CurrentRow.Cells["menu_name"].Value.ToString();


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
            //lblparentmenuid.Text = cboParentMenu.SelectedValue.ToString();

            load_search_ChildMenu();
            load_search_GrandChildMenu();
        }

        private void btnSelectAlGrandChild_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrandChild.RowCount; i++) { dgvGrandChild.Rows[i].Cells[0].Value = true; }
       
        }

        private void btnUnSelectAlGrandChild_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrandChild.RowCount; i++) { dgvGrandChild.Rows[i].Cells[0].Value = false; }
     
        }

        private void dataView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dataView.CurrentCell.OwningColumn == dataView.Columns["chkSelected"] && dataView.IsCurrentCellDirty)
            //{
            //    dataView.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //    //your code goes here
            //    CheckChildTagging();
            //}
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
            if (materialTxtModuelAvail.CurrentCell.OwningColumn == materialTxtModuelAvail.Columns["chkSelected"] && materialTxtModuelAvail.IsCurrentCellDirty)
            {
                materialTxtModuelAvail.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //your code goes here
                CheckParentTaggingMenu();
            }

      
        }


        private void CheckParentTaggingMenu()
        {
            showvalue();
            for (int n = 0; n < materialTxtModuelAvail.RowCount; n++)
            {
                if (Convert.ToBoolean(materialTxtModuelAvail.Rows[n].Cells[0].Value))
                {
                    dSet.Clear();
                    dSet = objStorProc.sp_getMenu_by_user("get_already_added_forms_Parent", 0, p_id, Convert.ToInt32(materialTxtModuelAvail.Rows[n].Cells[1].Value));
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



        private void showKeyGrandChild()
        {
            if (ready == true)
            {
                if (listBoxGrandChildTag.Items.Count > 0)
                {
                    pkey = Convert.ToInt32(listBoxGrandChildTag.SelectedValue.ToString());
                    loadMenu_byUsers_GChildTagged();

                }
            }
        }


        private void listBoxGrandChildTag_DoubleClick(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to Removed The Access on Selected Form Menu", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (listBoxGrandChildTag.Items.Count > 0)
                {
                    showKeyGrandChild();

                    if (listViewuser_rights.Items.Count > 0)
                    {
                        p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());
                    }

                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(pkey, "delete");


                    dSet_temp.Clear();
                    dSet_temp = objStorProc.sp_user_rights_details(p_id, 0, 0, "", "", "", "", txtGChildName.Text.Trim(), "delete_LogsGChild");


                    SuccessFullyUntag();

                    getAllTaggedParentMenu();
                    loadMenu_byUsers_GChildTagged();
                    ListViewmenu_Click_1(sender, e);
                }


            }
            else
            {

                return;
            }
        }

        private void btnUpdateRequest_Click(object sender, EventArgs e)
        {
        


            btnUpdateTheMenu_Click(sender, e);
        
            load_search_ChildMenu();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCancelUpdateMenu_Click(sender,  e);
    
        }

        private void listBoxParentTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ValueofUntaggedParent();
            //load_search_ChildMenu(); ;
        }

        private void ValueofUntaggedParent()
        {
            if (ready == true)
            {
                if (listBoxParentTag.Items.Count > 0)
                {
                    p_id = Convert.ToInt32(listBoxParentTag.SelectedValue.ToString());
                   materialTextBoxMenuAvailable.Text = listBoxParentTag.Text;

                }
            }
        }

        private void listBoxParentTag_Click(object sender, EventArgs e)
        {
            ValueofUntaggedParent();
            load_search_ChildMenu();
            ListViewmenu_Click_1(sender, e);
        }

        private void ListViewmenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListViewmenu_Click_1(object sender, EventArgs e)
        {
            btnUpdateTheMenu.Visible = true;
            showvalue();
            txtMaterialChildName.Text = ListViewmenu.Text;
            load_search_GrandChildMenu();
            ListViewmenu.Enabled = true;
      
            Sample();
            txtGChildName.Text = listBoxGrandChildTag.Text;
        }

        public void Sample()
        {
            ready = false;
            if(ListViewmenu.Items.Count > 0)
            {
                var SelectedDataRowParent = (ListViewmenu.SelectedItem as DataRowView)["menu_id"].ToString();

                xClass.fillListBox_Id(listBoxGrandChildTag, "filter_users_grandchild_at_userights", dSet, p_id, 0, Convert.ToInt32(SelectedDataRowParent));
                ready = true;
                lbltotalGrandChildActive.Text = listBoxGrandChildTag.Items.Count.ToString();
            }
         
        }

        private void dgvGrandChild_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgvGrandChild.Rows.Count > 0)
            {
                if (dgvGrandChild.CurrentRow != null)
                {
                    if (dgvGrandChild.CurrentRow.Cells["primary_menu_id"].Value != null)
                    {

                        txtchildprimarymenuid.Text = dgvGrandChild.CurrentRow.Cells["primary_menu_id"].Value.ToString();
                        materialTextBoxModuleAvail.Text = dgvGrandChild.CurrentRow.Cells["menu_name"].Value.ToString();
                    }
                }
            }

        }

        private void listBoxGrandChildTag_Click(object sender, EventArgs e)
        {
            txtGChildName.Text = listBoxGrandChildTag.Text;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialBtnNew_Click(object sender, EventArgs e)
        {
            mode = "add";
            materialBtnNew.Visible = false;
            btnCancelTool.Visible = true;
            btnUpdateTool.Visible = true;
            txtMaterialRights.ReadOnly = false;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            btnEditTool.Visible = false;
            txtMaterialRights.Text = "";
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void btnCancelTool_Click_1(object sender, EventArgs e)
        {
            mode = "";
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtMaterialRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;
            btnCancelTool.Visible = false;
            
            materialButtonCancel.Visible = false;
            MenuDeActivate();
        }

        private void btnUpdateTool_Click_1(object sender, EventArgs e)
        {
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtMaterialRights.Focus();
                return;

            }
            btnMetroSave_Click(sender, e);
        }

        private void btnEditTool_Click_1(object sender, EventArgs e)
        {
            mode = "edit";
            txtMaterialRights.ReadOnly = false;
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
            btnUpdateTool.Visible = true;
            btnEditTool.Visible = false;
            materialBtnNew.Visible = false;
            btnCancelTool.Visible = true;
            btnDeleteTool.Visible = false;
            //Menu
            //MenuActivate();
         
        }
        private void MenuActivate()
        {
            materialTextBoxMenuAvailable.Visible = true;
            materialCard1.Visible = true;
            materialBtnUpdateMenu.Visible = true;
            materialButtonCancel.Visible = true;
        }
        private void MenuDeActivate()
        {
            materialTextBoxMenuAvailable.Visible = false;
            materialCard1.Visible = false;
            materialBtnUpdateMenu.Visible = false;
        
        }
        private void btnDeleteTool_Click_1(object sender, EventArgs e)
        {
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                listViewuser_rights.Enabled = true;

                txtMaterialRights.Focus();

                return;

            }
            metroButtonDelete_Click(sender, e);
        }

        private void materialBtnUpdateMenu_Click(object sender, EventArgs e)
        {
            
            getAllTaggedParentMenu(); //Tagged Equal ==

            getAllParentMenu();
            //
            AvailableMajor();
            btnUpdateTheMenu_Click(sender, e);
         
            load_search_ChildMenu();

        }

        private void AvailableMajor()
        {
            materialCard2.Visible = true;
            materialButtonCancel.Visible = false;
            materialBtnUpdateMenu.Visible = false;
            txtMaterialMenuName.Visible = true;


            materialButtonUpdateSubMenu.Visible = true;
        }

        private void materialButtonCancel_Click(object sender, EventArgs e)
        {
            MenuDeActivate();
            materialButtonCancel.Visible = false;
        


            //Rights Button
            materialBtnNew.Visible = true;
            btnEditTool.Visible = true;
            listViewuser_rights.Enabled = true;
            btnDeleteTool.Visible = true;

        }

        private void materialButtonUpdateSubMenu_Click(object sender, EventArgs e)
        {
            showSubMenu();
            listBoxParentTag.Enabled = false;
            materialTxtModuelAvail.Enabled = false;

        }

        private void showSubMenu()
        {
            
        
            materialButtonUpdateSubMenu.Visible = false;
          


            materialBtnShowAvailSubMenu.Visible = true;
  

            ListViewmenu_Click_1(new object(), new System.EventArgs());
   
      
        }

        private void materialBtnMenuAVlCancel_Click(object sender, EventArgs e)
        {
            CanAvailableMajorMenu();
        }

        private void CanAvailableMajorMenu()
        {
            materialCard2.Visible = false;
            materialButtonCancel.Visible = true;
            materialBtnUpdateMenu.Visible = true;
            txtMaterialMenuName.Visible = false;


            materialButtonUpdateSubMenu.Visible = false;
        }

        private void materialBtnShowAvailSubMenu_Click(object sender, EventArgs e)
        {
            materialBtnShowAvailSubMenu.Visible = false;
      
         
            materialTextBoxSubMenuAvail.Visible = true;
            //
  
            //dataView
            dataView.Enabled = true;
        }

        private void materialSubMenuCancel_Click(object sender, EventArgs e)
        {
   


            materialBtnShowAvailSubMenu.Visible = false;

            listBoxParentTag.Enabled = true;
            materialTxtModuelAvail.Enabled = true;
            //true
            materialButtonUpdateSubMenu.Visible = true;
        
        }

        private void materialBtnShowModuleCancel_Click(object sender, EventArgs e)
        {
    
            showSubMenuTagged();
            ListViewmenu.Enabled = true;
        }

        private void showSubMenuTagged()
        {
      
           
            materialBtnShowAvailSubMenu.Visible = true;
  
        }


        private void materialBtnShowModule_Click(object sender, EventArgs e)
        {
            ShowModule();

        }
        private void ShowModule()
        {
      
            txtGChildName.Visible = true;

        }

        private void matCancelmaterialBtnShowModuleAvail_Click(object sender, EventArgs e)
        {
     
            CancelModuleSelection();
        }

        private void CancelModuleSelection()
        {
          
            txtGChildName.Visible = false;
       
        }

        private void materialBtnShowModuleAvail_Click(object sender, EventArgs e)
        {
         
      
            //Buttons
       

  
        }

        private void materialBtnCancelModule_Click(object sender, EventArgs e)
        {
            



        }

 

        private void materialBtnReset_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to reset?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                frmUserRight_Load(sender, e);
            }
            else
            {
                return;
            }


            }

        private void matBtnMenu_Click(object sender, EventArgs e)
        {
            MenuActivate();
        
            listBoxParentTag.Enabled = true;
            materialTxtModuelAvail.Enabled = true;
            //Rights Hide
            materialBtnNew.Visible = false;
            btnEditTool.Visible = false;
            btnUpdateTool.Visible = false;
            btnDeleteTool.Visible = false;
            btnCancelTool.Visible = false;
        }



        private void SaveMenus()
        {
            p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());

            dSet.Clear();
            dSet = g_objStoredProcCollection.sp_userfileIncrement(0,
                p_id,
                "s",
                "s",
               "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "addModuleRights");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            p_id = Convert.ToInt32(listViewuser_rights.SelectedValue.ToString());

            dSet.Clear();
            dSet = g_objStoredProcCollection.sp_userfileIncrement(0,
                p_id,
                "s",
                "s",
               "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
                "s",
            
                "addModuleRights");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])//your specific tabname
            {
                // your stuff
                materialButtonCancel_Click(sender, e);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])//your specific tabname
            {
                matBtnMenu_Click(sender, e);
                materialBtnMenuAVlCancel_Click(sender, e);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])//your specific tabname
            {
                materialBtnUpdateMenu_Click(sender, e);
                materialSubMenuCancel_Click(sender, e);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])//your specific tabname
            {
                materialBtnShowModule_Click(sender, e);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage5"])//your specific tabname
            {
                materialButtonUpdateSubMenu_Click(sender, e);
            }

        }

        private void matBtnNew_Click(object sender, EventArgs e)
        {
            mode = "add";
            materialBtnNew.Visible = false;
            btnCancelTool.Visible = true;
            btnUpdateTool.Visible = true;
            txtMaterialRights.ReadOnly = false;
            txtMaterialRights.Enabled = true;
            btnDeleteTool.Visible = false;
            btnUpdateTheMenu.Visible = false;
            btnEditTool.Visible = false;
            txtMaterialRights.Text = "";
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
        }

        private void matBtnCancel_Click(object sender, EventArgs e)
        {
            mode = "";
            materialBtnNew.Visible = true;
            btnUpdateTool.Visible = false;
            btnEditTool.Visible = true;
            txtMaterialRights.ReadOnly = true;
            listViewuser_rights.Enabled = true;
            dataView.Visible = false;
            btnCancelTool.Visible = false;

            materialButtonCancel.Visible = false;
            MenuDeActivate();
        }

        private void listViewuser_rights_DrawItem(object sender, DrawItemEventArgs e)
        {
            //if (e.Index < 0) return;
            ////if the item state is selected them change the back color 
            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //    e = new DrawItemEventArgs(e.Graphics,
            //                              e.Font,
            //                              e.Bounds,
            //                              e.Index,
            //                              e.State ^ DrawItemState.Selected,
            //                              e.ForeColor,
            //                              Color.Yellow);//Choose the color

            //// Draw the background of the ListBox control for each item.
            //e.DrawBackground();
            //// Draw the current item text
            //e.Graphics.DrawString(listViewuser_rights.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            //// If the ListBox has focus, draw a focus rectangle around the selected item.
            //e.DrawFocusRectangle();
        }

        private void matBtnSave_Click(object sender, EventArgs e)
        {
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                FillUserRights();
                txtMaterialRights.Focus();
                return;

            }
            btnMetroSave_Click(sender, e);
        }

        private void matBtnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtMaterialRights.ReadOnly = false;
            txtMaterialRights.Focus();
            listViewuser_rights.Enabled = false;
            btnUpdateTool.Visible = true;
            btnEditTool.Visible = false;
            materialBtnNew.Visible = false;
            btnCancelTool.Visible = true;
            btnDeleteTool.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void matBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaterialRights.Text.Trim() == string.Empty)
            {
                SelectUserRights();
                listViewuser_rights.Enabled = true;

                txtMaterialRights.Focus();

                return;

            }
            metroButtonDelete_Click(sender, e);
        }
    }
}
