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
            if (File.Exists(pathAvatarImg))
            {

                 
                anhdaidien.Image = Image.FromFile(pathAvatarImg);
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
                anhdaidien.Image = null;
                anhdaidien.Update();
                if (File.Exists(pathAvatarImg))
                {
                    File.Delete(pathAvatarImg);
                }
                image.Save(pathAvatarImg);
            }
        }
    }
}
