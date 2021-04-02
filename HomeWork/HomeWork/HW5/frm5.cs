using HomeWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW5
{
    public partial class frm5 : Form
    {
        string ConnString = Settings.Default.MyAlbumConnectionString;
        string AlbumID = "";
        int SelectCount = 0;
        List<PictureBox> pics = new List<PictureBox>();
        List<CheckBox> cbs = new List<CheckBox>();
        List<Panel> Panels = new List<Panel>();
        List<int> ImageIds = new List<int>();

        public frm5(string memberName)
        {
            InitializeComponent();

            this.Text = memberName + "的相簿";
            AddComboboxItem();
            cb_DBchange.SelectedIndex = 1;

            ImagePanel.AllowDrop = true;
            ImagePanel.DragDrop += FlowLayoutPanel1_DragDrop;
            ImagePanel.DragEnter += FlowLayoutPanel1_DragEnter;

            pictureBox1.AllowDrop = true;
            pictureBox1.DragDrop += PictureBox1_DragDrop;
            pictureBox1.DragEnter += PictureBox1_DragEnter;
        }

        private void AddComboboxItem()
        {
            cb_AlbumSelect.Text = "";
            cb_AlbumSelect.Items.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Album", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cb_AlbumSelect.Items.Add(reader["AlbumName"]);
                        }
                        this.cb_AlbumSelect.SelectedIndex = cb_AlbumSelect.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadImage()
        {
            pics.Clear();
            ImageIds.Clear();
            Panels.Clear();
            cbs.Clear();
            this.ImagePanel.Controls.Clear();

            if (cb_AlbumSelect.Text != "")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.StateChange += Connection_StateChange;
                        SqlCommand command = new SqlCommand($"SELECT * FROM AlbumImage WHERE AlbumId = {AlbumID}", conn);
                        conn.Open();
                        SqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                byte[] bytes = (byte[])dataReader["Image"];
                                MemoryStream ms = new MemoryStream(bytes);

                                PictureBox pic = new PictureBox();
                                pic.Image = Image.FromStream(ms);
                                pic.SizeMode = PictureBoxSizeMode.Zoom;
                                pic.Size = new Size(200, 200);
                                pic.Name = dataReader["ImageId"].ToString();
                                pic.Click += Pic_Click;

                                CheckBox cb = new CheckBox();
                                cb.BackColor = Color.Transparent;
                                cb.Size = new Size(20, 20);
                                cb.Visible = false;
                                cb.Name = dataReader["ImageId"].ToString();
                                cb.CheckStateChanged += cb_CheckStateChanged;

                                Panel panel = new Panel();
                                pic.Location = new Point(20, 20);
                                panel.Size = pic.Size + new Size(10, 10);
                                panel.Name = dataReader["ImageId"].ToString();
                                panel.ContextMenuStrip = contextMenuStrip1;
                                panel.Controls.Add(cb);
                                panel.Controls.Add(pic);


                                //ImagePanel.Controls.Add(pic);
                                ImagePanel.Controls.Add(panel);
                                pics.Add(pic);
                                cbs.Add(cb);
                                Panels.Add(panel);
                                ImageIds.Add((int)dataReader["ImageId"]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("錯誤 : " + e.Message);
                }
            }
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] x = (string[])e.Data.GetData(DataFormats.FileDrop);//丟進來的檔案,取得路徑,加入陣列
            this.pictureBox1.Image = Image.FromFile(x[0]);//FormFile(路徑)
            this.label4.Visible = false;
        }
        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] x = (string[])e.Data.GetData(DataFormats.FileDrop);//丟進來的檔案,取得路徑
            if (cb_AlbumSelect.Text != "")
            {
                for (int i = 0; i < x.Length; i++)
                {
                    try
                    {
                        PictureBox pic = new PictureBox();
                        pic.Image = Image.FromFile(x[i]);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.ContextMenuStrip = contextMenuStrip1;
                        pic.Click += Pic_Click;
                        using (SqlConnection conn = new SqlConnection(ConnString))
                        {
                            SqlCommand command = new SqlCommand();
                            command.CommandText = "INSERT INTO AlbumImage(AlbumId,ImageFileName,Image) VALUES(@AlbumId,@ImageFileName,@Image)";

                            MemoryStream ms = new MemoryStream();//建立一個資料流物件
                            pic.Image.Save(ms, ImageFormat.Jpeg);//儲存成jpeg格式到ms
                            byte[] bytes = ms.GetBuffer();//將資料流轉換成byte[]陣列

                            command.Parameters.Add("@AlbumId", SqlDbType.Int, 2).Value = AlbumID;
                            command.Parameters.Add("@ImageFileName", SqlDbType.NVarChar, 50).Value = x[i];
                            command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;
                            command.Connection = conn;
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (OutOfMemoryException ex2)
                    {
                        MessageBox.Show("請放入圖片檔案");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("新增圖片成功 !");
            }
            else
            {
                MessageBox.Show("此資料庫無相簿");
            }
            LoadImage();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //一層一層往外抓到picture
            //sender是ToolStripItem(delete)>找到他的ContextMenuStrip>再找到他的圖片
            ToolStripItem clickedItem = sender as ToolStripItem;
            ContextMenuStrip owner = clickedItem.Owner as ContextMenuStrip;
            Panel panel = owner.SourceControl as Panel;

            int imageid = ImageIds[ImagePanel.Controls.IndexOf(panel)];

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.StateChange += Connection_StateChange;
                    SqlCommand command = new SqlCommand("DELETE AlbumImage WHERE ImageId=@ImageId", conn);
                    command.Parameters.Add("@ImageId", SqlDbType.Int).Value = imageid;
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("刪除成功 !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadImage();
        }

        private void cb_DBchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DBchange.SelectedIndex == 0)
            {
                ImagePanel.Controls.Clear();
                ConnString = Settings.Default.LocalMyAlbumConnectionString;
                AddComboboxItem();
            }
            else
            {
                ImagePanel.Controls.Clear();
                ConnString = Settings.Default.MyAlbumConnectionString;
                AddComboboxItem();
            }
        }

        private void cb_AlbumSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImagePanel.Controls.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM Album WHERE AlbumName = N'{cb_AlbumSelect.Text}'", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AlbumID = reader["AlbumId"].ToString();
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            LoadImage();
        }

        string formfile = "";
        private void btn_browse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.gif|*.gif";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
                formfile = this.openFileDialog1.FileName;
            }
            this.label4.Visible = false;
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (cb_AlbumSelect.Text != "")
            {
                PictureBox pic = new PictureBox();
                pic.Image = pictureBox1.Image;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(200, 200);
                pic.ContextMenuStrip = contextMenuStrip1;
                pic.Click += Pic_Click;

                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.StateChange += Connection_StateChange;
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "INSERT INTO AlbumImage(AlbumId,ImageFileName,Image) VALUES(@AlbumId,@ImageFileName,@Image)";

                        MemoryStream ms = new MemoryStream();//建立一個資料流物件
                        pic.Image.Save(ms, ImageFormat.Jpeg);//儲存成jpeg格式到ms
                        byte[] bytes = ms.GetBuffer();//將資料流轉換成byte[]陣列

                        command.Parameters.Add("@AlbumId", SqlDbType.Int, 2).Value = AlbumID;
                        command.Parameters.Add("@ImageFileName", SqlDbType.NVarChar).Value = formfile;
                        command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;
                        command.Connection = conn;
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("新增圖片成功 !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    pictureBox1.Image = null;
                    this.label4.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("此資料庫無相簿");
            }
            LoadImage();
        }

        private void btn_addAlbum_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cb_AlbumSelect.Items.Count; i++)
            {
                if (cb_AlbumSelect.Items[i].ToString() == tb_addAlbum.Text)
                {
                    MessageBox.Show("已存在的相簿名稱");
                }
            }
            if (tb_addAlbum.Text == "")
            {
                MessageBox.Show("請輸入相簿名稱");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.StateChange += Connection_StateChange;
                        SqlCommand command = new SqlCommand("INSERT INTO Album(AlbumName) VALUES(@AlbumName)", conn);
                        command.Parameters.Add("@AlbumName", SqlDbType.NVarChar, 100).Value = tb_addAlbum.Text;
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("新增相簿成功 !");
                        tb_addAlbum.Clear();
                        tb_addAlbum.Text = "";
                        cb_AlbumSelect.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                AddComboboxItem();
                cb_AlbumSelect.SelectedIndex = cb_AlbumSelect.Items.Count - 1;
            }
        }

private void btn_deleteAlbum_Click(object sender, EventArgs e)
{
    if (cb_AlbumSelect.Text == "")
    {
        MessageBox.Show("請選擇相簿");
    }
    else
    {
        DialogResult result;
        result = MessageBox.Show("確定刪除?", "", MessageBoxButtons.YesNo);
        if (result == System.Windows.Forms.DialogResult.Yes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.StateChange += Connection_StateChange;
                    SqlCommand command = new SqlCommand($"DELETE AlbumImage WHERE AlbumId = {AlbumID}", conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("刪除相簿圖片成功");
                }
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.StateChange += Connection_StateChange;
                    SqlCommand command = new SqlCommand($"DELETE Album WHERE AlbumId = {AlbumID}", conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("刪除相簿成功");
                }
                AddComboboxItem();
                LoadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

private void btn_selectOpen_Click(object sender, EventArgs e)
{
    btn_selectOpen.Enabled = false;
    btn_Delete.Visible = true;
    btn_Cancel.Visible = true;
    btn_addAlbum.Enabled = false;
    btn_deleteAlbum.Enabled = false;
    btn_browse.Enabled = false;
    btn_insert.Enabled = false;
    cb_SelectAll.Visible = true;
    cb_AlbumSelect.Enabled = false;
    cb_DBchange.Enabled = false;
    tb_addAlbum.Enabled = false;
    ImagePanel.AllowDrop = false;
    pictureBox1.AllowDrop = false;

    for (int i = 0; i < cbs.Count; i++)
    {
        cbs[i].Visible = true;
    }
    for (int i = 0; i < Panels.Count; i++)
    {
        Panels[i].ContextMenuStrip = null;
        pics[i].Click -= Pic_Click;
        pics[i].Click += Pic_Click2;
    }
}

private void Pic_Click2(object sender, EventArgs e)
{
    PictureBox pic = sender as PictureBox;
    if (cbs[pics.IndexOf(pic)].CheckState == CheckState.Checked)
    {
        cbs[pics.IndexOf(pic)].CheckState = CheckState.Unchecked;
    }
    else
    {
        cbs[pics.IndexOf(pic)].CheckState = CheckState.Checked;
    }
    SelectCount = 0;
    for (int i = 0; i < cbs.Count; i++)
    {
        if (cbs[i].CheckState == CheckState.Checked)
        {
            Panels[i].BorderStyle = BorderStyle.Fixed3D;
            SelectCount += 1;
        }
        else
        {
            Panels[i].BorderStyle = BorderStyle.None;
        }
    }
    lb_SelectCount.Text = SelectCount + "個照片已選擇";
}

private void btn_Delete_Click(object sender, EventArgs e)
{
    string commandString = "Delete AlbumImage WHERE ImageId IN (";
    if (SelectCount == 0)
    {
        MessageBox.Show("請選擇相片");
    }
    else
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (Panels[i].BorderStyle == BorderStyle.Fixed3D)
            {
                commandString += ImageIds[i].ToString() + ",";
            }
        }
        commandString = commandString.Remove(commandString.Length - 1);
        commandString += ")";

        DialogResult result;
        result = MessageBox.Show("確定刪除?", "", MessageBoxButtons.YesNo);
        if (result == System.Windows.Forms.DialogResult.Yes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.StateChange += Connection_StateChange;
                    SqlCommand command = new SqlCommand(commandString, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("刪除照片成功 !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cb_AlbumSelect.Enabled = true;
                cb_DBchange.Enabled = true;
                cb_SelectAll.Visible = false;
                cb_SelectAll.CheckState = CheckState.Unchecked;
                btn_selectOpen.Enabled = true;
                btn_Delete.Visible = false;
                btn_Cancel.Visible = false;
                btn_addAlbum.Enabled = true;
                btn_deleteAlbum.Enabled = true;
                btn_browse.Enabled = true;
                btn_insert.Enabled = true;
                tb_addAlbum.Enabled = true;
                ImagePanel.AllowDrop = true;
                pictureBox1.AllowDrop = true;


                for (int i = 0; i < cbs.Count; i++)
                {
                    cbs[i].Visible = false;
                    cbs[i].CheckState = CheckState.Unchecked;
                    Panels[i].BorderStyle = BorderStyle.None;
                }
                for (int i = 0; i < Panels.Count; i++)
                {
                    Panels[i].ContextMenuStrip = contextMenuStrip1;
                    pics[i].Click += Pic_Click;
                }
                lb_SelectCount.Text = "";
                LoadImage();
            }
        }
    }
}

private void btn_Cancel_Click(object sender, EventArgs e)
{
    cb_AlbumSelect.Enabled = true;
    cb_DBchange.Enabled = true;
    cb_SelectAll.Visible = false;
    cb_SelectAll.CheckState = CheckState.Unchecked;
    btn_selectOpen.Enabled = true;
    btn_Delete.Visible = false;
    btn_Cancel.Visible = false;
    btn_addAlbum.Enabled = true;
    btn_deleteAlbum.Enabled = true;
    btn_browse.Enabled = true;
    btn_insert.Enabled = true;
    tb_addAlbum.Enabled = true;
    ImagePanel.AllowDrop = true;
    pictureBox1.AllowDrop = true;

    for (int i = 0; i < cbs.Count; i++)
    {
        cbs[i].Visible = false;
        cbs[i].CheckState = CheckState.Unchecked;
        Panels[i].BorderStyle = BorderStyle.None;
    }
    for (int i = 0; i < Panels.Count; i++)
    {
        Panels[i].ContextMenuStrip = contextMenuStrip1;
        pics[i].Click += Pic_Click;
        pics[i].Click -= Pic_Click2;
    }
    lb_SelectCount.Text = "";
    SelectCount = 0;
}

private void cb_SelectAll_CheckedChanged(object sender, EventArgs e)
{
    SelectCount = 0;
    if (cb_SelectAll.CheckState == CheckState.Checked)
    {
        for (int i = 0; i < cbs.Count; i++)
        {
            cbs[i].CheckState = CheckState.Checked;
            lb_SelectCount.Text = cbs.Count + "個照片已選擇";
        }
    }
    else
    {
        for (int i = 0; i < cbs.Count; i++)
        {
            cbs[i].CheckState = CheckState.Unchecked;
            lb_SelectCount.Text = 0 + "個照片已選擇";
            SelectCount = 0;
        }
    }
}

private void Connection_StateChange(object sender, StateChangeEventArgs e)
{
    this.toolStripStatusLabel1.Text = "資料庫狀態  :  " + e.CurrentState.ToString();
    Application.DoEvents();
    Thread.Sleep(50);
}

private void Pic_Click(object sender, EventArgs e)
{
    PictureBox s = sender as PictureBox;
    if (s != null)
    {
        Form f = new Form();
        f.BackgroundImage = s.Image;
        f.BackgroundImageLayout = ImageLayout.Zoom;
        f.Show();
    }
}

private void cb_CheckStateChanged(object sender, EventArgs e)
{
    SelectCount = 0;
    if (cbs.Count == 0)
    {
        MessageBox.Show("無相片");
    }
    else
    {
        for (int i = 0; i < cbs.Count; i++)
        {
            if (cbs[i].CheckState == CheckState.Checked)
            {
                Panels[i].BorderStyle = BorderStyle.Fixed3D;
                SelectCount += 1;
            }
            else
            {
                Panels[i].BorderStyle = BorderStyle.None;
            }
        }
        lb_SelectCount.Text = SelectCount + "個照片已選擇";
    }
}
    }
}
