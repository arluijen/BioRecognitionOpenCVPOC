/*=================================================
 * This code is brought to you by Mahvish
 * visit http://fewtutorials.bravesites.com/ for more
 * tutorials on EmguCV and C#
 * **************************************************
 *        PLEASE DO NOT REMOVE THIS NOTE!
 * **************************************************
 * ================================================== */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;



namespace LiveFaceDetection
{
    public partial class FaceRecognizer : Form
    {
        //declaring global variables

        //.............FOR LIVE CAMERA CAPTURE.............
        //-----------------------------------------------------------------------------------
        private Capture capture;        //takes images from camera as image frames
        Image<Bgr, Byte> TestImage;    //EmguCV type color image

        //.............FOR FACE DETECTION.............
        //-----------------------------------------------------------------------------------
        private HaarCascade haar;            //the viola-jones classifier (detector)       
        //Lets set the Default values of the parameters, to be used as a variable in call to DetectHaarCascase()
        private int WindowsSize = 25;
        private Double ScaleIncreaseRate = 1.4;
        private int MinNeighbors = 3;

        private int iMaxItereations = 16;
        private double dEPS = (1 / 1000);
        private double dDistTreshHold = 4000;


        private Graphics g;
        private Bitmap ExtractedFace;  // an empty "box"/"image" to hold the extracted face.
        private Emgu.CV.EigenObjectRecognizer recognizer;


        public FaceRecognizer()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Load the haarcascade XML
        /// Train the recognizer (load all faces from the database)
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaceRecognizer_Load(object sender, EventArgs e)
        {
            ReloadAndReset();
            btnStart.Enabled = true;
            StartFilming();
        }

        private void ReloadAndReset()
        {
            // adjust path to find your xml at loading
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            //Load all parameters
            // Detection Parameters
            ScaleIncreaseRate = Double.Parse(comboBoxScIncRte.Text); //the 2nd parameter
            MinNeighbors = int.Parse(comboBoxMinNeigh.Text);  // the 3rd parameter
            WindowsSize = int.Parse(textBoxWinSiz.Text);   // the 5th parameter

            // Traing and Recognition parameters
            iMaxItereations = int.Parse(txtMaxIts.Text);
            dEPS = Double.Parse(txtEPS.Text);
            dDistTreshHold = Double.Parse(txtDistThresh.Text);

            //Load the DB faces to the recognizer
            TrainRecognizer();

        }

        /// <summary>
        /// Main function that analyze the 
        /// </summary>
        private void StartAnalyzing()
        {
            //fetch the frame captured by web camera
            TestImage = capture.QueryFrame();

            if (TestImage != null)
            {
                Image<Gray, byte> grayframe = TestImage.Convert<Gray, byte>();
                var faces = grayframe.DetectHaarCascade(haar, ScaleIncreaseRate, MinNeighbors, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(WindowsSize, WindowsSize))[0];

                foreach (var face in faces)
                {
                    TestImage.Draw(face.rect, new Bgr(Color.Green), 3);
                }

                //@rie, now as soon as a face is detected, it'll try to recognize it.
                if (faces.Length > 0)
                {
                    DetectAndRecognizeFaces();
                }
            }
            CamImageBox.Image = TestImage;
        }

        //------------------------------------------------------------------------------//
        //Process Frame() below is our user defined function in which we will create an EmguCv 
        //type image called ImageFrame. capture a frame from camera and allocate it to our 
        //ImageFrame. then show this image in ourEmguCV imageBox
        //------------------------------------------------------------------------------//
        private void ProcessFrame(object sender, EventArgs arg)
        {
            StartAnalyzing();
        }


        /// <summary>
        /// Starts live video streaming, Pauses it to detect faces, Resumes it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartFilming();
        }


        /// <summary>
        /// @rie
        /// Starts or stops the filming process
        /// TODO: Still not happy about using the .idle as a loop for this process....
        /// </summary>
        private void StartFilming()
        {

            int CamNumber = int.Parse(cbCamIndex.Text);
            StartVideo(CamNumber);

            if (capture != null)
            {
                if (btnStart.Text == "Detect Face")
                {  //if camera is getting frames then pause the capture and set button Text to
                    // "Resume" for resuming capture
                    btnStart.Text = "Resume Live Video"; //

                    //Pause the live streaming video
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Pause" for pausing capture
                    btnStart.Text = "Detect Face";
                    StartVideo(CamNumber);
                    Application.Idle += ProcessFrame;
                }
            }
        }


        /// <summary>
        /// Mainly this just activates the webcam and connects it to the capture control
        /// </summary>
        /// <param name="iCamIndex"></param>
        private void StartVideo(Int32 iCamIndex)
        {
            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new Capture(iCamIndex);
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            btnStart.Enabled = true;
        }
        
        /// <summary>
        /// This function is the Selected Index changed event of the comboBox
        /// It allows the user to select a desired camera and starts it for him/her
        /// </summary>
        private void cbCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartFilming();
        }
        
        //@rie
        // Save a scanned face to the database
        private void cmdSaveImage_Click(object sender, EventArgs e)
        {
            RegisterFace frmRegister = new RegisterFace(ExtractedFace);
            frmRegister.ShowDialog();      
        }



        //----------------------------------------------------------------------------//
        //<<<<<<<<------FUNCTION USED TO DETECT AND RECOGNIZE FACES---------->>>>>>>>
        //----------------------------------------------------------------------------//
        private void DetectAndRecognizeFaces()
        {
            Image<Gray, byte> grayframe = TestImage.Convert<Gray, byte>();

            //detect faces from the gray-scale image and store into an array of type 'var',i.e 'MCvAvgComp[]'
            var faces = grayframe.DetectHaarCascade(haar, ScaleIncreaseRate, MinNeighbors, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(WindowsSize, WindowsSize))[0];
            Bitmap BmpInput = grayframe.ToBitmap();          
            MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);

            //draw a green rectangle on each detected face in image
            foreach (var face in faces)
            {
                //locate the detected face & mark with a rectangle
                TestImage.Draw(face.rect, new Bgr(Color.Green), 3);
                CamImageBox.Image = TestImage;
                //set the size of the empty box(ExtractedFace) which will later contain the detected face
                ExtractedFace = new Bitmap(face.rect.Width, face.rect.Height);
                
                //assign the empty box to graphics for painting
                g = Graphics.FromImage(ExtractedFace);

                //graphics fills the empty box with exact pixels of the face to be extracted from input image
                g.DrawImage(BmpInput, 0, 0, face.rect, GraphicsUnit.Pixel);
                ImBoxEigen.Image = new Image<Gray, Byte>(ExtractedFace);

                TryRecognizePerson(ImBoxEigen.Image);
                cmdSaveImage.Enabled = true;
            }
        }

        //-------------------------------------------------------------------------------------//
        //<<<<<----------------FUNCTIONS USED TO TRAIN RECOGNIZER ON TRAINING SET----------->>>>
        //-------------------------------------------------------------------------------------//
 
        /// <summary>
        /// Trains recognizer on fetched face-label pairs and saves the trained data to recognition variables
        /// </summary>
        public void TrainRecognizer()
        {
            MCvTermCriteria termCrit = new MCvTermCriteria(iMaxItereations, dEPS);
            ImageInDatabase dbTrainingSet = new ImageInDatabase();

            // This will fill the training images array AND labels array
            dbTrainingSet.LoadCompleteTrainingSet();
            recognizer = new EigenObjectRecognizer(dbTrainingSet.m_trainingImages, dbTrainingSet.m_TrainingLabels, dDistTreshHold, ref termCrit);
        }

        /// <summary>
        /// button used call TrainRecognizer()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrainRecog_Click(object sender, EventArgs e)
        {
            TrainRecognizer();
        }



        /// <summary>
        /// @rie
        /// Searches the database for a given name
        /// to return the details And the picture
        /// Mainly for test purposes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ShowFace frmShowFace = new ShowFace();
            frmShowFace.Show();
        }

        private void cmdRecognize_Click(object sender, EventArgs e)
        {
            try
            {
                string RecognizeResult = recognizer.Recognize((Image<Gray, Byte>)ImBoxEigen.Image);
                MessageBox.Show("Recognizer Result = " + RecognizeResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        
        private void TryRecognizePerson(IImage imageToRecognize)
        {
            // This will result in a facialID
            string RecognizeResultID = recognizer.Recognize((Image<Gray, Byte>)imageToRecognize);
            string sResultOfRecognize = "Nope, couldn't find you. Please click save if you want me to recognize you next time...";

            if (RecognizeResultID.Length > 0)
            {
                ImageInDatabase iidRecPerson = new ImageInDatabase();
                iidRecPerson.ReadImageFromDBWithID(RecognizeResultID);
                sResultOfRecognize = "Hallo " + iidRecPerson.FirstName + " " + iidRecPerson.LastName + ",\r\n";
                sResultOfRecognize += "Wilt u weer een " + iidRecPerson.CoffeePreference + "?\r\n";
                sResultOfRecognize += "Paremeters: Tresh - " + dDistTreshHold.ToString() + " \r\n";
                sResultOfRecognize += "Paremeters: EPS - " + dEPS.ToString() + " \r\n";
                sResultOfRecognize += "Paremeters: MaxIt - " + iMaxItereations.ToString();

            }
            lblResult.Text = sResultOfRecognize;
        }

        private void cmdReladParams_Click(object sender, EventArgs e)
        {
            ReloadAndReset();
        }

        private void cmdReladParams_Click_1(object sender, EventArgs e)
        {
            ReloadAndReset();
        }

        private void cmdSaveImage_Click_1(object sender, EventArgs e)
        {
            RegisterFace frmRegister = new RegisterFace(ExtractedFace);
            frmRegister.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
