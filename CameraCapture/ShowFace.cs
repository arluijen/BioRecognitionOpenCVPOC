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
    public partial class ShowFace : Form
    {


        public ShowFace()
        {
            InitializeComponent();
        }


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            // Check if all is filled
            if (txtLastName.TextLength > 0)
            {
                // Load the face
                ImageInDatabase dgimgObject = new ImageInDatabase();
                dgimgObject.ReadImageFromDB(txtLastName.Text);

                if (dgimgObject.FirstName.Length > 0) //@rie, not veryu nice, but lets assume that in this case a person was found...
                {
                    txtFirstName.Text = dgimgObject.FirstName;
                    txtLastName.Text = dgimgObject.LastName;
                    dtDateOfBirth.Value = dgimgObject.DateOfBirth;
                    txtCoffeePreference.Text = dgimgObject.CoffeePreference;
                    imgFaceToSave.Image = new Image<Bgr, byte>((dgimgObject.ImageOfFace));
                }
                else
                {
                    MessageBox.Show("No person was found with that name");
                }


                //Exit
               //  this.Close();
               
            }
            else
            { 
                MessageBox.Show("Vul de achternaam in...", "Check gegevens", MessageBoxButtons.OK);
            }
            

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RegisterFace_Load(object sender, EventArgs e)
        {

        }
    }
}
