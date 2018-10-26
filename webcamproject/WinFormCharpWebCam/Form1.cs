using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace WinFormCharpWebCam
{
    //Design by Pongsakorn Poosankam
    public partial class mainWinForm : Form
    {

        private const string subscriptionKey = "b4ef8cadf25d4e84aa32c3caf38b0d42";
        private const string faceEndpoint =
            "https://eastus2.api.cognitive.microsoft.com";

        // https://eastus2.api.cognitive.microsoft.com/face/v1.0

        private const string personGroupId = "cloudhackathon";

        // localImagePath = @"C:\Documents\LocalImage.jpg"
        private const string localImagePath = @"C:\CapturedImages\Snapshot_20181025_064914.667.bmp";

        private const string remoteImageUrl =
            "https://upload.wikimedia.org/wikipedia/commons/3/37/Dagestani_man_and_woman.jpg";

        private readonly string connectionString;
        private static readonly FaceAttributeType[] faceAttributes =
            { FaceAttributeType.Age, FaceAttributeType.Gender,FaceAttributeType.Emotion };
        FaceClient faceClient;
        public mainWinForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.AppSettings["connectionString"];
        }
        WebCam webcam;
        private void mainWinForm_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();

             faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });
            faceClient.Endpoint = faceEndpoint;
            webcam.InitializeWebCam(ref imgVideo);
            webcam.Start();
            
            imgVideo.Height = 720;
            imgVideo.Width = 720;

            imgCapture.Visible = false;
            imgCapture.Height = 720;
            imgCapture.Width = 720;
            

        }

        private void bntStart_Click(object sender, EventArgs e)
        {
           // webcam.Start();
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
            imgCapture.Visible = true;
            imgVideo.Visible = false;
            webcam.Stop();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            Helper.SaveImageCapture(imgCapture.Image);
        }

        private void bntVideoFormat_Click(object sender, EventArgs e)
        {
            webcam.ResolutionSetting();
        }

        private void bntVideoSource_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
            imgCapture.Visible = true;
            imgVideo.Visible = false;
            webcam.Stop();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgCapture.Visible = false;
            imgVideo.Visible = true;
            webcam.Continue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //To-Do Authenticate
            imgCapture.Image = imgVideo.Image;
            imgCapture.Visible = true;
            imgVideo.Visible = false;
            webcam.Stop();


            var imageName = DateTime.Now.ToString("MMddyyyyhhmmtt");
            string ImageDirectory = Path.Combine(Environment.CurrentDirectory, imageName);
            using (FileStream fstream = new FileStream(ImageDirectory, FileMode.Create))
            {
                imgCapture.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();

            }
            using (Stream imageStream = File.OpenRead(ImageDirectory))
            {
                IList<DetectedFace> faceList =
                         faceClient.Face.DetectWithStreamAsync(
                            imageStream, true, false, faceAttributes).Result;
                IList<IdentifyResult> verifyResults = faceClient.Face.IdentifyAsync(new List<Guid> { (Guid)faceList[0].FaceId }, personGroupId, maxNumOfCandidatesReturned: 1, confidenceThreshold: 0.6).Result;
                if (verifyResults != null && verifyResults[0]?.Candidates != null && verifyResults[0]?.Candidates.Count>0)
                {
                    var personConfidence = verifyResults[0]?.Candidates?.Max(x => x.Confidence);
                    var personId = verifyResults[0]?.Candidates.Where(x => x.Confidence == personConfidence).FirstOrDefault();
                    var person = faceClient.PersonGroupPerson.GetAsync(personGroupId, personId.PersonId).Result;
                    

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.InsertAuthenticatedUser", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = person.Name;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
            }
            File.Delete(ImageDirectory);       

            imgCapture.Visible = false;
            imgVideo.Visible = true;
            webcam.Continue();


        }
    }
}
