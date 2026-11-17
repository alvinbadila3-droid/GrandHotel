namespace POSS_GrandHotel
{
    partial class Master_Room
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
            System.Windows.Forms.Label roomNumberLabel;
            System.Windows.Forms.Label statusRoomLabel;
            System.Windows.Forms.Label roomTypeIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master_Room));
            this.dB_GrandHotelDataSet = new POSS_GrandHotel.DB_GrandHotelDataSet();
            this.tbl__RoomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl__RoomsTableAdapter = new POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.Tbl__RoomsTableAdapter();
            this.tableAdapterManager = new POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.TableAdapterManager();
            this.tbl_RoomTypesTableAdapter = new POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.Tbl_RoomTypesTableAdapter();
            this.tbl__RoomsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.tbl__RoomsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.txt_roomNumber = new System.Windows.Forms.TextBox();
            this.txt_statusRoom = new System.Windows.Forms.TextBox();
            this.tbl__RoomsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl_RoomTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_RoomTypesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_typeroom = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_roomfloor = new System.Windows.Forms.TextBox();
            this.btn_simpan = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            roomNumberLabel = new System.Windows.Forms.Label();
            statusRoomLabel = new System.Windows.Forms.Label();
            roomTypeIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dB_GrandHotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsBindingNavigator)).BeginInit();
            this.tbl__RoomsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoomTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoomTypesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomNumberLabel
            // 
            roomNumberLabel.AutoSize = true;
            roomNumberLabel.Location = new System.Drawing.Point(8, 19);
            roomNumberLabel.Name = "roomNumberLabel";
            roomNumberLabel.Size = new System.Drawing.Size(98, 16);
            roomNumberLabel.TabIndex = 3;
            roomNumberLabel.Text = "Room Number:";
            roomNumberLabel.Click += new System.EventHandler(this.roomNumberLabel_Click);
            // 
            // statusRoomLabel
            // 
            statusRoomLabel.AutoSize = true;
            statusRoomLabel.Location = new System.Drawing.Point(8, 100);
            statusRoomLabel.Name = "statusRoomLabel";
            statusRoomLabel.Size = new System.Drawing.Size(87, 16);
            statusRoomLabel.TabIndex = 7;
            statusRoomLabel.Text = "Status Room:";
            statusRoomLabel.Click += new System.EventHandler(this.statusRoomLabel_Click);
            // 
            // roomTypeIDLabel
            // 
            roomTypeIDLabel.AutoSize = true;
            roomTypeIDLabel.Location = new System.Drawing.Point(8, 71);
            roomTypeIDLabel.Name = "roomTypeIDLabel";
            roomTypeIDLabel.Size = new System.Drawing.Size(98, 16);
            roomTypeIDLabel.TabIndex = 10;
            roomTypeIDLabel.Text = "Room Type ID:";
            roomTypeIDLabel.Click += new System.EventHandler(this.roomTypeIDLabel_Click);
            // 
            // dB_GrandHotelDataSet
            // 
            this.dB_GrandHotelDataSet.DataSetName = "DB_GrandHotelDataSet";
            this.dB_GrandHotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl__RoomsBindingSource
            // 
            this.tbl__RoomsBindingSource.DataMember = "Tbl_ Rooms";
            this.tbl__RoomsBindingSource.DataSource = this.dB_GrandHotelDataSet;
            // 
            // tbl__RoomsTableAdapter
            // 
            this.tbl__RoomsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InvoicePaymentsTableAdapter = null;
            this.tableAdapterManager.Tbl__RolesTableAdapter = null;
            this.tableAdapterManager.Tbl__RoomsTableAdapter = this.tbl__RoomsTableAdapter;
            this.tableAdapterManager.Tbl_GuestsTableAdapter = null;
            this.tableAdapterManager.Tbl_HousekeepingTableAdapter = null;
            this.tableAdapterManager.Tbl_ReservationsTableAdapter = null;
            this.tableAdapterManager.Tbl_RoomTypesTableAdapter = this.tbl_RoomTypesTableAdapter;
            this.tableAdapterManager.Tbl_UsersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = POSS_GrandHotel.DB_GrandHotelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbl_RoomTypesTableAdapter
            // 
            this.tbl_RoomTypesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl__RoomsBindingNavigator
            // 
            this.tbl__RoomsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tbl__RoomsBindingNavigator.BindingSource = this.tbl__RoomsBindingSource;
            this.tbl__RoomsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tbl__RoomsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tbl__RoomsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tbl__RoomsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tbl__RoomsBindingNavigatorSaveItem});
            this.tbl__RoomsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tbl__RoomsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tbl__RoomsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tbl__RoomsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tbl__RoomsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tbl__RoomsBindingNavigator.Name = "tbl__RoomsBindingNavigator";
            this.tbl__RoomsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tbl__RoomsBindingNavigator.Size = new System.Drawing.Size(831, 27);
            this.tbl__RoomsBindingNavigator.TabIndex = 0;
            this.tbl__RoomsBindingNavigator.Text = "bindingNavigator1";
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
            // tbl__RoomsBindingNavigatorSaveItem
            // 
            this.tbl__RoomsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbl__RoomsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tbl__RoomsBindingNavigatorSaveItem.Image")));
            this.tbl__RoomsBindingNavigatorSaveItem.Name = "tbl__RoomsBindingNavigatorSaveItem";
            this.tbl__RoomsBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.tbl__RoomsBindingNavigatorSaveItem.Text = "Save Data";
            this.tbl__RoomsBindingNavigatorSaveItem.Click += new System.EventHandler(this.tbl__RoomsBindingNavigatorSaveItem_Click);
            // 
            // txt_roomNumber
            // 
            this.txt_roomNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl__RoomsBindingSource, "RoomNumber", true));
            this.txt_roomNumber.Location = new System.Drawing.Point(112, 16);
            this.txt_roomNumber.Name = "txt_roomNumber";
            this.txt_roomNumber.Size = new System.Drawing.Size(100, 22);
            this.txt_roomNumber.TabIndex = 4;
            this.txt_roomNumber.TextChanged += new System.EventHandler(this.roomNumberTextBox_TextChanged);
            // 
            // txt_statusRoom
            // 
            this.txt_statusRoom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl__RoomsBindingSource, "StatusRoom", true));
            this.txt_statusRoom.Location = new System.Drawing.Point(112, 97);
            this.txt_statusRoom.Name = "txt_statusRoom";
            this.txt_statusRoom.Size = new System.Drawing.Size(100, 22);
            this.txt_statusRoom.TabIndex = 8;
            this.txt_statusRoom.TextChanged += new System.EventHandler(this.statusRoomTextBox_TextChanged);
            // 
            // tbl__RoomsDataGridView
            // 
            this.tbl__RoomsDataGridView.AutoGenerateColumns = false;
            this.tbl__RoomsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl__RoomsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.tbl__RoomsDataGridView.DataSource = this.tbl__RoomsBindingSource;
            this.tbl__RoomsDataGridView.Location = new System.Drawing.Point(0, 262);
            this.tbl__RoomsDataGridView.Name = "tbl__RoomsDataGridView";
            this.tbl__RoomsDataGridView.RowHeadersWidth = 51;
            this.tbl__RoomsDataGridView.RowTemplate.Height = 24;
            this.tbl__RoomsDataGridView.Size = new System.Drawing.Size(428, 168);
            this.tbl__RoomsDataGridView.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RoomID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RoomID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RoomNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "RoomNumber";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RoomTypeID";
            this.dataGridViewTextBoxColumn3.HeaderText = "RoomTypeID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StatusRoom";
            this.dataGridViewTextBoxColumn4.HeaderText = "StatusRoom";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // tbl_RoomTypesBindingSource
            // 
            this.tbl_RoomTypesBindingSource.DataMember = "Tbl_RoomTypes";
            this.tbl_RoomTypesBindingSource.DataSource = this.dB_GrandHotelDataSet;
            // 
            // tbl_RoomTypesDataGridView
            // 
            this.tbl_RoomTypesDataGridView.AutoGenerateColumns = false;
            this.tbl_RoomTypesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_RoomTypesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.tbl_RoomTypesDataGridView.DataSource = this.tbl_RoomTypesBindingSource;
            this.tbl_RoomTypesDataGridView.Location = new System.Drawing.Point(450, 262);
            this.tbl_RoomTypesDataGridView.Name = "tbl_RoomTypesDataGridView";
            this.tbl_RoomTypesDataGridView.RowHeadersWidth = 51;
            this.tbl_RoomTypesDataGridView.RowTemplate.Height = 24;
            this.tbl_RoomTypesDataGridView.Size = new System.Drawing.Size(361, 168);
            this.tbl_RoomTypesDataGridView.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RoomTypeID";
            this.dataGridViewTextBoxColumn5.HeaderText = "RoomTypeID";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn6.HeaderText = "TypeName";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "kapasitas";
            this.dataGridViewTextBoxColumn7.HeaderText = "kapasitas";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "HargaPermalam";
            this.dataGridViewTextBoxColumn8.HeaderText = "HargaPermalam";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "deskirpsi";
            this.dataGridViewTextBoxColumn9.HeaderText = "deskirpsi";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // cbb_typeroom
            // 
            this.cbb_typeroom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl__RoomsBindingSource, "RoomTypeID", true));
            this.cbb_typeroom.FormattingEnabled = true;
            this.cbb_typeroom.Location = new System.Drawing.Point(112, 68);
            this.cbb_typeroom.Name = "cbb_typeroom";
            this.cbb_typeroom.Size = new System.Drawing.Size(121, 24);
            this.cbb_typeroom.TabIndex = 11;
            this.cbb_typeroom.SelectedIndexChanged += new System.EventHandler(this.roomTypeIDComboBox_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Room Floor";
            // 
            // txt_roomfloor
            // 
            this.txt_roomfloor.Location = new System.Drawing.Point(112, 40);
            this.txt_roomfloor.Name = "txt_roomfloor";
            this.txt_roomfloor.Size = new System.Drawing.Size(100, 22);
            this.txt_roomfloor.TabIndex = 14;
            // 
            // btn_simpan
            // 
            this.btn_simpan.Location = new System.Drawing.Point(20, 153);
            this.btn_simpan.Name = "btn_simpan";
            this.btn_simpan.Size = new System.Drawing.Size(75, 23);
            this.btn_simpan.TabIndex = 15;
            this.btn_simpan.Text = "simpan";
            this.btn_simpan.UseVisualStyleBackColor = true;
            this.btn_simpan.Click += new System.EventHandler(this.btn_simpan_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(134, 152);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 16;
            this.btn_update.Text = "update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delate
            // 
            this.btn_delate.Location = new System.Drawing.Point(275, 153);
            this.btn_delate.Name = "btn_delate";
            this.btn_delate.Size = new System.Drawing.Size(75, 23);
            this.btn_delate.TabIndex = 17;
            this.btn_delate.Text = "delate";
            this.btn_delate.UseVisualStyleBackColor = true;
            this.btn_delate.Click += new System.EventHandler(this.btn_delate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.btn_delate);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.btn_simpan);
            this.groupBox1.Controls.Add(this.txt_roomfloor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(roomTypeIDLabel);
            this.groupBox1.Controls.Add(this.cbb_typeroom);
            this.groupBox1.Controls.Add(roomNumberLabel);
            this.groupBox1.Controls.Add(this.txt_roomNumber);
            this.groupBox1.Controls.Add(statusRoomLabel);
            this.groupBox1.Controls.Add(this.txt_statusRoom);
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 220);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // Master_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbl_RoomTypesDataGridView);
            this.Controls.Add(this.tbl__RoomsDataGridView);
            this.Controls.Add(this.tbl__RoomsBindingNavigator);
            this.Name = "Master_Room";
            this.Text = "Master_Room";
            this.Load += new System.EventHandler(this.Master_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dB_GrandHotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsBindingNavigator)).EndInit();
            this.tbl__RoomsBindingNavigator.ResumeLayout(false);
            this.tbl__RoomsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl__RoomsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoomTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RoomTypesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DB_GrandHotelDataSet dB_GrandHotelDataSet;
        private System.Windows.Forms.BindingSource tbl__RoomsBindingSource;
        private DB_GrandHotelDataSetTableAdapters.Tbl__RoomsTableAdapter tbl__RoomsTableAdapter;
        private DB_GrandHotelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tbl__RoomsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tbl__RoomsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox txt_roomNumber;
        private System.Windows.Forms.TextBox txt_statusRoom;
        private DB_GrandHotelDataSetTableAdapters.Tbl_RoomTypesTableAdapter tbl_RoomTypesTableAdapter;
        private System.Windows.Forms.DataGridView tbl__RoomsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource tbl_RoomTypesBindingSource;
        private System.Windows.Forms.DataGridView tbl_RoomTypesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ComboBox cbb_typeroom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_roomfloor;
        private System.Windows.Forms.Button btn_simpan;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delate;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}