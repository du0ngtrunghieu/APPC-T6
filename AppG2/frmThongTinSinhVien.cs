using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2
{
    
    public partial class frmThongTinSinhVien : Form
    {
        Image image;
        string pathAvatarImg;
        string pathDirectoryImg;
        public frmThongTinSinhVien()
        {
            InitializeComponent();
            pathDirectoryImg = Application.StartupPath + "/Img";
            pathAvatarImg = pathDirectoryImg + "/avatar.png";
            anhdaidien.AllowDrop = true;
            if (File.Exists(pathAvatarImg))
            {

                FileStream fileStream = new FileStream(pathAvatarImg, FileMode.Open, FileAccess.Read);
                anhdaidien.Image = Image.FromStream(fileStream);
                fileStream.Close();

            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "File ảnh(*.png,*.jpg,*.gif)|*.png;*.jpg;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                anhdaidien.Image = image;
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Application.SatrtupPath = url projects
           
            if (image != null)
            {
               
                if (!Directory.Exists(pathDirectoryImg))
                {
                    Directory.CreateDirectory(pathDirectoryImg);
                }
                
                image.Save(pathAvatarImg);
                

            }
            
        }

        private void Anhdaidien_Click(object sender, EventArgs e)
        {

        }

        private void Anhdaidien_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Anhdaidien_DragDrop(object sender, DragEventArgs e)
        {
            var rs=(string[])e.Data.GetData(DataFormats.FileDrop);
            var filePath = rs.FirstOrDefault();
            anhdaidien.Image = Image.FromFile(filePath);
        }
    }
}
