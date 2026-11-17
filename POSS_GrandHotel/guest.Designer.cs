namespace POSS_GrandHotel
{
    partial class guest
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nIK_PasportLabel;
            System.Windows.Forms.Label namaLabel;
            System.Windows.Forms.Label noHandphoneLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label alamatLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guest));
            this.dB_GrandHotelDataSet = new POSS_GrandHotel.DB_GrandHotelDataSet();
            this.tbl_GuestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_GuestsTableAdapter = new POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.Tbl_GuestsTableAdapter();
            this.tableAdapterManager = new POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.TableAdapterManager();
            this.tbl_GuestsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbl_GuestsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.txt_nik = new System.Windows.Forms.TextBox();
            this.txt_nama = new System.Windows.Forms.TextBox();
            this.txt_Nohp = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_alamat = new System.Windows.Forms.TextBox();
            this.btn_simpan = new System.Windows.Forms.Button();
            this.Btn_cari = new System.Windows.Forms.Button();
            this.txt_nikcari = new System.Windows.Forms.TextBox();
            this.txt_nikhasil = new System.Windows.Forms.TextBox();
            this.txt_namahasil = new System.Windows.Forms.TextBox();
            this.txt_nohphasil = new System.Windows.Forms.TextBox();
            this.txt_emailhasil = new System.Windows.Forms.TextBox();
            this.txt_alamathasil = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            nIK_PasportLabel = new System.Windows.Forms.Label();
            namaLabel = new System.Windows.Forms.Label();
            noHandphoneLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            alamatLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dB_GrandHotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_GuestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_GuestsBindingNavigator)).BeginInit();
            this.tbl_GuestsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // nIK_PasportLabel
            // 
            nIK_PasportLabel.AutoSize = true;
            nIK_PasportLabel.Location = new System.Drawing.Point(10, 58);
            nIK_PasportLabel.Name = "nIK_PasportLabel";
            nIK_PasportLabel.Size = new System.Drawing.Size(81, 16);
            nIK_PasportLabel.TabIndex = 4;
            nIK_PasportLabel.Text = "NIK Pasport:";
            // 
            // namaLabel
            // 
            namaLabel.AutoSize = true;
            namaLabel.Location = new System.Drawing.Point(10, 86);
            namaLabel.Name = "namaLabel";
            namaLabel.Size = new System.Drawing.Size(47, 16);
            namaLabel.TabIndex = 6;
            namaLabel.Text = "Nama:";
            // 
            // noHandphoneLabel
            // 
            noHandphoneLabel.AutoSize = true;
            noHandphoneLabel.Location = new System.Drawing.Point(10, 114);
            noHandphoneLabel.Name = "noHandphoneLabel";
            noHandphoneLabel.Size = new System.Drawing.Size(102, 16);
            noHandphoneLabel.TabIndex = 8;
            noHandphoneLabel.Text = "No Handphone:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(10, 142);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(44, 16);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "Email:";
            // 
            // alamatLabel
            // 
            alamatLabel.AutoSize = true;
            alamatLabel.Location = new System.Drawing.Point(10, 170);
            alamatLabel.Name = "alamatLabel";
            alamatLabel.Size = new System.Drawing.Size(52, 16);
            alamatLabel.TabIndex = 12;
            alamatLabel.Text = "Alamat:";
            // 
            // dB_GrandHotelDataSet
            // 
            this.dB_GrandHotelDataSet.DataSetName = "DB_GrandHotelDataSet";
            this.dB_GrandHotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_GuestsBindingSource
            // 
            this.tbl_GuestsBindingSource.DataMember = "Tbl_Guests";
            this.tbl_GuestsBindingSource.DataSource = this.dB_GrandHotelDataSet;
            // 
            // tbl_GuestsTableAdapter
            // 
            this.tbl_GuestsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InvoicePaymentsTableAdapter = null;
            this.tableAdapterManager.Tbl__RolesTableAdapter = null;
            this.tableAdapterManager.Tbl__RoomsTableAdapter = null;
            this.tableAdapterManager.Tbl_GuestsTableAdapter = this.tbl_GuestsTableAdapter;
            this.tableAdapterManager.Tbl_HousekeepingTableAdapter = null;
            this.tableAdapterManager.Tbl_ReservationsTableAdapter = null;
            this.tableAdapterManager.Tbl_RoomTypesTableAdapter = null;
            this.tableAdapterManager.Tbl_UsersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbl_GuestsBindingNavigator
            // 
            this.tbl_GuestsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tbl_GuestsBindingNavigator.BindingSource = this.tbl_GuestsBindingSource;
            this.tbl_GuestsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tbl_GuestsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tbl_GuestsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tbl_GuestsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tbl_GuestsBindingNavigatorSaveItem});
            this.tbl_GuestsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tbl_GuestsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tbl_GuestsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tbl_GuestsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tbl_GuestsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tbl_GuestsBindingNavigator.Name = "tbl_GuestsBindingNavigator";
            this.tbl_GuestsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tbl_GuestsBindingNavigator.Size = new System.Drawing.Size(820, 27);
            this.tbl_GuestsBindingNavigator.TabIndex = 0;
            this.tbl_GuestsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tbl_GuestsBindingNavigatorSaveItem
            // 
            this.tbl_GuestsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbl_GuestsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tbl_GuestsBindingNavigatorSaveItem.Image")));
            this.tbl_GuestsBindingNavigatorSaveItem.Name = "tbl_GuestsBindingNavigatorSaveItem";
            this.tbl_GuestsBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.tbl_GuestsBindingNavigatorSaveItem.Text = "Save Data";
            this.tbl_GuestsBindingNavigatorSaveItem.Click += new System.EventHandler(this.tbl_GuestsBindingNavigatorSaveItem_Click);
            // 
            // txt_nik
            // 
            this.txt_nik.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_GuestsBindingSource, "NIK_Pasport", true));
            this.txt_nik.Location = new System.Drawing.Point(118, 55);
            this.txt_nik.Name = "txt_nik";
            this.txt_nik.Size = new System.Drawing.Size(118, 22);
            this.txt_nik.TabIndex = 5;
            // 
            // txt_nama
            // 
            this.txt_nama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_GuestsBindingSource, "Nama", true));
            this.txt_nama.Location = new System.Drawing.Point(118, 83);
            this.txt_nama.Name = "txt_nama";
            this.txt_nama.Size = new System.Drawing.Size(144, 22);
            this.txt_nama.TabIndex = 7;
            // 
            // txt_Nohp
            // 
            this.txt_Nohp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_GuestsBindingSource, "NoHandphone", true));
            this.txt_Nohp.Location = new System.Drawing.Point(118, 111);
            this.txt_Nohp.Name = "txt_Nohp";
            this.txt_Nohp.Size = new System.Drawing.Size(161, 22);
            this.txt_Nohp.TabIndex = 9;
            // 
            // txt_email
            // 
            this.txt_email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_GuestsBindingSource, "Email", true));
            this.txt_email.Location = new System.Drawing.Point(118, 139);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(171, 22);
            this.txt_email.TabIndex = 11;
            // 
            // txt_alamat
            // 
            this.txt_alamat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_GuestsBindingSource, "Alamat", true));
            this.txt_alamat.Location = new System.Drawing.Point(118, 167);
            this.txt_alamat.Name = "txt_alamat";
            this.txt_alamat.Size = new System.Drawing.Size(186, 22);
            this.txt_alamat.TabIndex = 13;
            // 
            // btn_simpan
            // 
            this.btn_simpan.Location = new System.Drawing.Point(37, 212);
            this.btn_simpan.Name = "btn_simpan";
            this.btn_simpan.Size = new System.Drawing.Size(75, 23);
            this.btn_simpan.TabIndex = 14;
            this.btn_simpan.Text = "tambahkan";
            this.btn_simpan.UseVisualStyleBackColor = true;
            this.btn_simpan.Click += new System.EventHandler(this.btn_simpan_Click);
            // 
            // Btn_cari
            // 
            this.Btn_cari.Location = new System.Drawing.Point(356, 79);
            this.Btn_cari.Name = "Btn_cari";
            this.Btn_cari.Size = new System.Drawing.Size(75, 23);
            this.Btn_cari.TabIndex = 15;
            this.Btn_cari.Text = "cari";
            this.Btn_cari.UseVisualStyleBackColor = true;
            this.Btn_cari.Click += new System.EventHandler(this.Btn_cari_Click);
            // 
            // txt_nikcari
            // 
            this.txt_nikcari.Location = new System.Drawing.Point(356, 51);
            this.txt_nikcari.Name = "txt_nikcari";
            this.txt_nikcari.Size = new System.Drawing.Size(100, 22);
            this.txt_nikcari.TabIndex = 16;
            this.txt_nikcari.TextChanged += new System.EventHandler(this.txt_nikcari_TextChanged);
            // 
            // txt_nikhasil
            // 
            this.txt_nikhasil.Location = new System.Drawing.Point(570, 58);
            this.txt_nikhasil.Name = "txt_nikhasil";
            this.txt_nikhasil.Size = new System.Drawing.Size(127, 22);
            this.txt_nikhasil.TabIndex = 17;
            // 
            // txt_namahasil
            // 
            this.txt_namahasil.Location = new System.Drawing.Point(570, 108);
            this.txt_namahasil.Name = "txt_namahasil";
            this.txt_namahasil.Size = new System.Drawing.Size(127, 22);
            this.txt_namahasil.TabIndex = 18;
            // 
            // txt_nohphasil
            // 
            this.txt_nohphasil.Location = new System.Drawing.Point(570, 150);
            this.txt_nohphasil.Name = "txt_nohphasil";
            this.txt_nohphasil.Size = new System.Drawing.Size(127, 22);
            this.txt_nohphasil.TabIndex = 19;
            // 
            // txt_emailhasil
            // 
            this.txt_emailhasil.Location = new System.Drawing.Point(570, 195);
            this.txt_emailhasil.Name = "txt_emailhasil";
            this.txt_emailhasil.Size = new System.Drawing.Size(127, 22);
            this.txt_emailhasil.TabIndex = 20;
            // 
            // txt_alamathasil
            // 
            this.txt_alamathasil.Location = new System.Drawing.Point(570, 239);
            this.txt_alamathasil.Name = "txt_alamathasil";
            this.txt_alamathasil.Size = new System.Drawing.Size(127, 22);
            this.txt_alamathasil.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "nik/pasport";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "nik/pasport";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "nama";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(570, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "No.HP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(570, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(570, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "alamat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(733, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "kembali";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_alamathasil);
            this.Controls.Add(this.txt_emailhasil);
            this.Controls.Add(this.txt_nohphasil);
            this.Controls.Add(this.txt_namahasil);
            this.Controls.Add(this.txt_nikhasil);
            this.Controls.Add(this.txt_nikcari);
            this.Controls.Add(this.Btn_cari);
            this.Controls.Add(this.btn_simpan);
            this.Controls.Add(nIK_PasportLabel);
            this.Controls.Add(this.txt_nik);
            this.Controls.Add(namaLabel);
            this.Controls.Add(this.txt_nama);
            this.Controls.Add(noHandphoneLabel);
            this.Controls.Add(this.txt_Nohp);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(alamatLabel);
            this.Controls.Add(this.txt_alamat);
            this.Controls.Add(this.tbl_GuestsBindingNavigator);
            this.Name = "guest";
            this.Text = "guest";
            this.Load += new System.EventHandler(this.guest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dB_GrandHotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_GuestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_GuestsBindingNavigator)).EndInit();
            this.tbl_GuestsBindingNavigator.ResumeLayout(false);
            this.tbl_GuestsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DB_GrandHotelDataSet dB_GrandHotelDataSet;
        private System.Windows.Forms.BindingSource tbl_GuestsBindingSource;
        private DB_GrandHotelDataSetTableAdapters.Tbl_GuestsTableAdapter tbl_GuestsTableAdapter;
        private DB_GrandHotelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tbl_GuestsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tbl_GuestsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox txt_nik;
        private System.Windows.Forms.TextBox txt_nama;
        private System.Windows.Forms.TextBox txt_Nohp;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_alamat;
        private System.Windows.Forms.Button btn_simpan;
        private System.Windows.Forms.Button Btn_cari;
        private System.Windows.Forms.TextBox txt_nikcari;
        private System.Windows.Forms.TextBox txt_nikhasil;
        private System.Windows.Forms.TextBox txt_namahasil;
        private System.Windows.Forms.TextBox txt_nohphasil;
        private System.Windows.Forms.TextBox txt_emailhasil;
        private System.Windows.Forms.TextBox txt_alamathasil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}