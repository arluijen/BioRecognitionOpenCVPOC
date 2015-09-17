using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV;

using System.Windows.Forms;

namespace LiveFaceDetection
{
    public partial class RegisterFace : Form
    {

        Bitmap m_ImageOfFaceToRegister;

        public RegisterFace(Bitmap ImageOfFaceToRegister)
        {
            InitializeComponent();
            this.imgFaceToSave.Image = new Image<Bgr, byte>(ImageOfFaceToRegister);
            m_ImageOfFaceToRegister = ImageOfFaceToRegister;
            this.imgFaceToSave.Refresh();
        }


        private void cmdOk_Click(object sender, EventArgs e)
        {
            // Check if all is filled
            if (txtCoffeePreference.TextLength > 0 && txtLastName.TextLength > 0 && txtFirstName.TextLength > 0)
            {
                // Save the face
                ImageInDatabase dgimgObject = new ImageInDatabase();

                dgimgObject.FirstName = txtFirstName.Text;
                dgimgObject.LastName = txtLastName.Text;
                dgimgObject.DateOfBirth = dtDateOfBirth.Value;
                dgimgObject.CoffeePreference = txtCoffeePreference.Text;
                dgimgObject.ImageOfFace = m_ImageOfFaceToRegister;

                dgimgObject.StoreImageToDataBase();

                //Exit
                RegisterFace.ActiveForm.Close();
            }
            else
            { 
                MessageBox.Show("Vul alle gegevens in aub", "Check gegevens", MessageBoxButtons.OK);
            }
            

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            RegisterFace.ActiveForm.Close();
        }


        private void RegisterFace_Load(object sender, EventArgs e)
        {

        }
    }
}
