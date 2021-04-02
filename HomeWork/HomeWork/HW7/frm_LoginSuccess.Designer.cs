
namespace HomeWork.HW7
{
    partial class frm_LoginSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoginSuccess));
            this.btn_MyAlbum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_MyAlbum
            // 
            this.btn_MyAlbum.BackColor = System.Drawing.Color.Bisque;
            this.btn_MyAlbum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_MyAlbum.Location = new System.Drawing.Point(178, 78);
            this.btn_MyAlbum.Name = "btn_MyAlbum";
            this.btn_MyAlbum.Size = new System.Drawing.Size(202, 58);
            this.btn_MyAlbum.TabIndex = 2;
            this.btn_MyAlbum.Text = "進入相簿管理器";
            this.btn_MyAlbum.UseVisualStyleBackColor = false;
            this.btn_MyAlbum.Click += new System.EventHandler(this.btn_MyAlbum_Click);
            // 
            // frm_LoginSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 218);
            this.Controls.Add(this.btn_MyAlbum);
            this.Name = "frm_LoginSuccess";
            this.Text = "登入成功";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_MyAlbum;
    }
}