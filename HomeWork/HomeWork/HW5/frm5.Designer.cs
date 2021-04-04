namespace HomeWork.HW5
{
    partial class frm5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm5));
            this.cb_AlbumSelect = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ImagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.tb_addAlbum = new System.Windows.Forms.TextBox();
            this.btn_addAlbum = new System.Windows.Forms.Button();
            this.btn_deleteAlbum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_DBchange = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_SelectAll = new System.Windows.Forms.CheckBox();
            this.btn_selectOpen = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lb_SelectCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_AlbumSelect
            // 
            this.cb_AlbumSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AlbumSelect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_AlbumSelect.FormattingEnabled = true;
            this.cb_AlbumSelect.Location = new System.Drawing.Point(12, 158);
            this.cb_AlbumSelect.MaxDropDownItems = 50;
            this.cb_AlbumSelect.Name = "cb_AlbumSelect";
            this.cb_AlbumSelect.Size = new System.Drawing.Size(211, 28);
            this.cb_AlbumSelect.TabIndex = 0;
            this.cb_AlbumSelect.SelectedIndexChanged += new System.EventHandler(this.cb_AlbumSelect_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_browse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_browse.Location = new System.Drawing.Point(11, 835);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(102, 27);
            this.btn_browse.TabIndex = 1;
            this.btn_browse.Text = "瀏覽...";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.Color.MistyRose;
            this.ImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImagePanel.Location = new System.Drawing.Point(231, 58);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1197, 804);
            this.ImagePanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(228, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "拖曳加入照片";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "選擇相簿:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 658);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_insert
            // 
            this.btn_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_insert.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_insert.Location = new System.Drawing.Point(123, 835);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(102, 27);
            this.btn_insert.TabIndex = 8;
            this.btn_insert.Text = "加入";
            this.btn_insert.UseVisualStyleBackColor = false;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // tb_addAlbum
            // 
            this.tb_addAlbum.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_addAlbum.Location = new System.Drawing.Point(10, 247);
            this.tb_addAlbum.MaxLength = 100;
            this.tb_addAlbum.Name = "tb_addAlbum";
            this.tb_addAlbum.Size = new System.Drawing.Size(211, 27);
            this.tb_addAlbum.TabIndex = 9;
            // 
            // btn_addAlbum
            // 
            this.btn_addAlbum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_addAlbum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_addAlbum.Location = new System.Drawing.Point(10, 284);
            this.btn_addAlbum.Name = "btn_addAlbum";
            this.btn_addAlbum.Size = new System.Drawing.Size(213, 47);
            this.btn_addAlbum.TabIndex = 10;
            this.btn_addAlbum.Text = "加入新相簿";
            this.btn_addAlbum.UseVisualStyleBackColor = false;
            this.btn_addAlbum.Click += new System.EventHandler(this.btn_addAlbum_Click);
            // 
            // btn_deleteAlbum
            // 
            this.btn_deleteAlbum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_deleteAlbum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_deleteAlbum.Location = new System.Drawing.Point(10, 337);
            this.btn_deleteAlbum.Name = "btn_deleteAlbum";
            this.btn_deleteAlbum.Size = new System.Drawing.Size(211, 50);
            this.btn_deleteAlbum.TabIndex = 11;
            this.btn_deleteAlbum.Text = "移除此相簿及其圖片";
            this.btn_deleteAlbum.UseVisualStyleBackColor = false;
            this.btn_deleteAlbum.Click += new System.EventHandler(this.btn_deleteAlbum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(326, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "右鍵可刪除圖片";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MistyRose;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(73, 698);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 81);
            this.label4.TabIndex = 12;
            this.label4.Text = "+";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "選擇資料庫:";
            // 
            // cb_DBchange
            // 
            this.cb_DBchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DBchange.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_DBchange.FormattingEnabled = true;
            this.cb_DBchange.Items.AddRange(new object[] {
            "LocalDB",
            "SQLSERVER"});
            this.cb_DBchange.Location = new System.Drawing.Point(11, 78);
            this.cb_DBchange.Name = "cb_DBchange";
            this.cb_DBchange.Size = new System.Drawing.Size(211, 28);
            this.cb_DBchange.TabIndex = 14;
            this.cb_DBchange.SelectedIndexChanged += new System.EventHandler(this.cb_DBchange_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Lavender;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 878);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1440, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // cb_SelectAll
            // 
            this.cb_SelectAll.AutoSize = true;
            this.cb_SelectAll.BackColor = System.Drawing.Color.Transparent;
            this.cb_SelectAll.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_SelectAll.Location = new System.Drawing.Point(978, 19);
            this.cb_SelectAll.Name = "cb_SelectAll";
            this.cb_SelectAll.Size = new System.Drawing.Size(92, 24);
            this.cb_SelectAll.TabIndex = 17;
            this.cb_SelectAll.Text = "選擇全部";
            this.cb_SelectAll.UseVisualStyleBackColor = false;
            this.cb_SelectAll.Visible = false;
            this.cb_SelectAll.CheckedChanged += new System.EventHandler(this.cb_SelectAll_CheckedChanged);
            // 
            // btn_selectOpen
            // 
            this.btn_selectOpen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_selectOpen.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_selectOpen.Location = new System.Drawing.Point(438, 11);
            this.btn_selectOpen.Name = "btn_selectOpen";
            this.btn_selectOpen.Size = new System.Drawing.Size(174, 41);
            this.btn_selectOpen.TabIndex = 19;
            this.btn_selectOpen.Text = "多選刪除";
            this.btn_selectOpen.UseVisualStyleBackColor = false;
            this.btn_selectOpen.Click += new System.EventHandler(this.btn_selectOpen_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Delete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Delete.Location = new System.Drawing.Point(618, 11);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(174, 41);
            this.btn_Delete.TabIndex = 20;
            this.btn_Delete.Text = "確定刪除";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Visible = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Cancel.Location = new System.Drawing.Point(798, 11);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(174, 41);
            this.btn_Cancel.TabIndex = 21;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lb_SelectCount
            // 
            this.lb_SelectCount.AutoSize = true;
            this.lb_SelectCount.BackColor = System.Drawing.Color.Transparent;
            this.lb_SelectCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_SelectCount.Location = new System.Drawing.Point(1098, 20);
            this.lb_SelectCount.Name = "lb_SelectCount";
            this.lb_SelectCount.Size = new System.Drawing.Size(13, 20);
            this.lb_SelectCount.TabIndex = 22;
            this.lb_SelectCount.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(9, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "相簿名稱不可使用空白字元";
            // 
            // frm5
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_SelectCount);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_selectOpen);
            this.Controls.Add(this.cb_SelectAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cb_DBchange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_deleteAlbum);
            this.Controls.Add(this.btn_addAlbum);
            this.Controls.Add(this.tb_addAlbum);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.cb_AlbumSelect);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MinimumSize = new System.Drawing.Size(1241, 677);
            this.Name = "frm5";
            this.Text = " ";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_AlbumSelect;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel ImagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox tb_addAlbum;
        private System.Windows.Forms.Button btn_addAlbum;
        private System.Windows.Forms.Button btn_deleteAlbum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_DBchange;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox cb_SelectAll;
        private System.Windows.Forms.Button btn_selectOpen;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_SelectCount;
        private System.Windows.Forms.Label label6;
    }
}