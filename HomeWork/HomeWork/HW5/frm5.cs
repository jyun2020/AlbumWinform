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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork.HW5
{
    public partial class frm5 : Form
    {
        string ConnString = Settings.Default.MyAlbumConnectionString;
        string AlbumID = "";
        List<PictureBox> pics = new List<PictureBox>();
        List<int> ImageIds = new List<int>();

        public frm5()
        {
            InitializeComponent();

            cb_DBchange.SelectedIndex =0;
            
            ImagePanel.AllowDrop = true;
            ImagePanel.DragDrop += FlowLayoutPanel1_DragDrop;
            ImagePanel.DragEnter += FlowLayoutPanel1_DragEnter;

            pictureBox1.AllowDrop = true;
            pictureBox1.DragDrop += PictureBox1_DragDrop;
            pictureBox1.DragEnter += PictureBox1_DragEnter;
        }
        private void cb_DBchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DBchange.SelectedIndex == 0 )
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
        private void AddComboboxItem()
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
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
                            comboBox1.Items.Add(reader["AlbumName"]);
                        }
                        this.comboBox1.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }
        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] x = (string[])e.Data.GetData(DataFormats.FileDrop);//丟進來的檔案,取得路徑
            for (int i = 0; i < x.Length; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(x[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ContextMenuStrip = contextMenuStrip1;
                pic.Click += Pic_Click;
                
                this.ImagePanel.Controls.Add(pic);
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Success !");
            LoadImage();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //一層一層往外抓到picture
            //sender是ToolStripItem(delete)>找到他的ContextMenuStrip>再找到他的圖片
            ToolStripItem clickedItem = sender as ToolStripItem; 
            ContextMenuStrip owner = clickedItem.Owner as ContextMenuStrip;
            PictureBox pic = owner.SourceControl as PictureBox;
            
            int imageid = ImageIds[ImagePanel.Controls.IndexOf(pic)];

            MemoryStream ms = new MemoryStream();//建立一個資料流物件
            pic.Image.Save(ms, ImageFormat.Jpeg);//儲存成jpeg格式到ms
            byte[] bytes = ms.GetBuffer();//將資料流轉換成byte[]陣列
            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand command = new SqlCommand("DELETE AlbumImage WHERE ImageId=@ImageId", conn);
                    command.Parameters.Add("@ImageId",SqlDbType.Int).Value=imageid;
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Delete Success !");
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadImage();
        }
        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox s = sender as PictureBox;
                if (s != null)
                {
                    Form f = new Form();
                    f.BackgroundImage = s.Image;
                    f.BackgroundImageLayout = ImageLayout.Stretch;
                    f.Show();
                }
            }
        private void LoadImage()
        {
            pics.Clear();
            ImageIds.Clear();
            this.ImagePanel.Controls.Clear();
            if (AlbumID != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
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
                                pic.Size = new System.Drawing.Size(200,200);
                                pic.ContextMenuStrip = contextMenuStrip1;
                                pic.Click += Pic_Click;

                                ImagePanel.Controls.Add(pic);
                                pics.Add(pic);
                                ImageIds.Add((int)dataReader["ImageId"]);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImagePanel.Controls.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM Album WHERE AlbumName = N'{comboBox1.Text}'", conn);
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
        private void btn_browse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.jpg|*.jpg|*.gif|*.gif";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
                formfile = this.openFileDialog1.FileName;
            }
        }


        string formfile = "";
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (tb_addAlbum.Text == "")
            {
                MessageBox.Show("請選擇相簿");
            }
            else
            {
                PictureBox pic = new PictureBox();
                pic.Image = pictureBox1.Image;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new System.Drawing.Size(200, 200);
                pic.ContextMenuStrip = contextMenuStrip1;
                pic.Click += Pic_Click;

                this.ImagePanel.Controls.Add(pic);
                try
                {
                    string connString = Settings.Default.LocalMyAlbumConnectionString;
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
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
                        MessageBox.Show("Success !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadImage();
            }
        }

        private void btn_addAlbum_Click(object sender, EventArgs e)
        {
            if (tb_addAlbum.Text == "")
            {
                MessageBox.Show("請選擇相簿");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO Album(AlbumName) VALUES(@AlbumName)", conn);
                        command.Parameters.Add("@AlbumName", SqlDbType.NVarChar, 100).Value = tb_addAlbum.Text;
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("新增成功");
                        tb_addAlbum.Clear();
                        comboBox1.Text = "";
                        comboBox1.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                AddComboboxItem();
            }
        }

        private void btn_deleteAlbum_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
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
                            SqlCommand command = new SqlCommand($"DELETE Album WHERE AlbumId = {AlbumID}", conn);
                            conn.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("刪除相簿成功");
                        }
                        using (SqlConnection conn = new SqlConnection(ConnString))
                        {
                            SqlCommand command = new SqlCommand($"DELETE AlbumImage WHERE AlbumId = {AlbumID}", conn);
                            conn.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("刪除相簿圖片成功");
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
    }
}
