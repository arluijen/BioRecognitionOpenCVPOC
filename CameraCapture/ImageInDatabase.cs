using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace LiveFaceDetection
{
    class ImageInDatabase
    {
        private SqlConnection m_conMyConnection;
        private Bitmap m_ImageOfFace;
        private string strFirstName = "NA";
        private string strLastName = "NA";
        private DateTime dtDateOfBirth;
        private string strCoffeePreference = "NA";

        public Emgu.CV.Image<Gray, Byte>[] m_trainingImages;
        public string[] m_TrainingLabels;

        // Properties of the class image in database
        public Bitmap ImageOfFace
        {
            get { return m_ImageOfFace; }
            set { m_ImageOfFace = value; }
        }
        public string FirstName { get { return strFirstName; } set { strFirstName = value; } }
        public string LastName { get { return strLastName; } set { strLastName = value; } }
        public DateTime DateOfBirth { get { return dtDateOfBirth; } set { dtDateOfBirth = value; } }
        public string CoffeePreference { get { return strCoffeePreference; } set { strCoffeePreference = value; } }
        //End of props

        //----------------------------------------------------------------------------//
        //<<<<<<<<------FUNCTION USED TO CONNECT TO DB---------------->>>>>>>>>>>>>>
        //----------------------------------------------------------------------------//
        private void ConnectToDatabase()
        {

            string connetionString = null;
            m_conMyConnection = new SqlConnection();

            if (m_conMyConnection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connetionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=ariel_000;Initial Catalog=AllianderFacialRecognition;Data Source=MAX\\LISTRISQLEXPRESS";
                    m_conMyConnection = new SqlConnection(connetionString);
                    m_conMyConnection.Open();
                }
                catch (Exception ex)
                {
                    //@rie TODO, write to log or something
                    // MessageBox.Show("Can not open connection ! " + ex.Message);
                }

            }
        }
        private void DisconnectFromDatabase()
        {
            if (m_conMyConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    m_conMyConnection.Close();
                }
                catch (Exception ex)
                {
                    //@rie TODO, write to log or something
                    // MessageBox.Show("Can not open connection ! " + ex.Message);
                }
            }
        }


        // Function to retrieve from the database
        public void ReadImageFromDB(string strLastName)
        {

            ConnectToDatabase();
            //Retrieve the image

            ImageInDatabase imageToStore = new ImageInDatabase();
            SqlCommand cmd = new SqlCommand("SP_Select_Face", m_conMyConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Byte[] imageToSaveInBytes = ConvertImage(ImageOfFace);

            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = strLastName;

            SqlDataReader sdResult = cmd.ExecuteReader();
            if (sdResult.Read())
            {
                LastName = (string)sdResult["LastName"];
                FirstName = (string)sdResult["FirstName"];
                DateOfBirth = (DateTime)sdResult["DateOfBirth"];
                CoffeePreference = (string)sdResult["CoffeePreference"];
                byte[] ImageByteArrayToConert = (byte[])sdResult["FacialPic"];

                ImageOfFace = new Bitmap(ConvertByteArray(ImageByteArrayToConert));
            }
            sdResult.Close();

            DisconnectFromDatabase();
        }


        public void ReadImageFromDBWithID(string strFacialID)
        {

            ConnectToDatabase();
            //Retrieve the image

            ImageInDatabase imageToStore = new ImageInDatabase();
            SqlCommand cmd = new SqlCommand("SP_Select_Face_by_ID", m_conMyConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FacialID", SqlDbType.NVarChar).Value = strFacialID;

            SqlDataReader sdResult = cmd.ExecuteReader();
            if (sdResult.Read())
            {
                LastName = (string)sdResult["LastName"];
                FirstName = (string)sdResult["FirstName"];
                DateOfBirth = (DateTime)sdResult["DateOfBirth"];
                CoffeePreference = (string)sdResult["CoffeePreference"];
                byte[] ImageByteArrayToConert = (byte[])sdResult["FacialPic"];

                ImageOfFace = new Bitmap(ConvertByteArray(ImageByteArrayToConert));
            }
            sdResult.Close();

            DisconnectFromDatabase();
        }
        public void StoreImageToDataBase()
        {
            ConnectToDatabase();
            SqlCommand cmd = new SqlCommand("SP_Insert_Picture", m_conMyConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            Byte[] imageToSaveInBytes = ConvertImage(ImageOfFace);

            SqlParameter param = cmd.Parameters.AddWithValue("@FacePicToInsert", imageToSaveInBytes);
            param.SqlDbType = SqlDbType.VarBinary;
            param.Size = imageToSaveInBytes.Length;

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            cmd.Parameters.Add("@DateOFBirth", SqlDbType.DateTime).Value = DateOfBirth;
            cmd.Parameters.Add("@CoffeePreference", SqlDbType.NVarChar).Value = CoffeePreference;

            cmd.ExecuteNonQuery();

            DisconnectFromDatabase();
        }

        private Byte[] ConvertImage(Bitmap myImage)
        {
            MemoryStream mstream = new MemoryStream();
            myImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] btImageAsBytes = mstream.ToArray();
            return btImageAsBytes;
        }

        public Image ConvertByteArray(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void LoadCompleteTrainingSet()
        {

            int i = 0;

            ConnectToDatabase();
     
            ImageInDatabase imageToStore = new ImageInDatabase();
            SqlCommand cmd = new SqlCommand("SP_Select_All_FAces", m_conMyConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sDataAdapter = new SqlDataAdapter();
            sDataAdapter.SelectCommand = cmd;
            DataSet sDataSet = new DataSet();
            sDataAdapter.Fill(sDataSet);
            DisconnectFromDatabase();

            int iUlngthTrainingArray = sDataSet.Tables[0].Rows.Count;

            m_trainingImages =  new Emgu.CV.Image<Gray, Byte>[iUlngthTrainingArray];
            m_TrainingLabels = new string[iUlngthTrainingArray];

            foreach (DataRow row in sDataSet.Tables[0].Rows)
            {
                byte[] ImageByteArrayToConert = (byte[])row["FacialPic"];
                ImageOfFace = new Bitmap(ConvertByteArray(ImageByteArrayToConert));

                m_trainingImages[i] = new Emgu.CV.Image<Gray, byte>(ImageOfFace);
                m_TrainingLabels[i] = row["ID"].ToString();
                i++;

            }
            DisconnectFromDatabase();
        }
    }
}
