using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using System.IO;
using System.Data.SqlClient;
using DPFP.Gui.Enrollment;
using DPFP.Gui.Verification;
using DPFP.Verification;
using DPFP.Error;

namespace ACUDECIDE
{
    public partial class CaptureForm2 : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;

        public CaptureForm2()
        {
            InitializeComponent();
        }

        private void CaptureForm2_Load(object sender, EventArgs e)
        {
            Init();
            Start();
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                if (null != Capturer)
                {
                    Capturer.EventHandler = this;

                }
                else
                {
                    SetPrompt("Can't initiate capture operation!");
                }
            }
            catch
            {

            }
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt2();
                    SetPrompt("Using the fingerprint reader, Scan the fingerprint!");

                }
                catch (Exception ex)
                {
                    SetPrompt("Can't initiate capture !");
                    MessageBox.Show(ex.ToString());
                }
                Capturer.EventHandler = this;

            }

        }


        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();

                }
                catch
                {
                    //MessageBox.Show("Capture stop Error !");

                }

            }

        }

        protected void SetStatus(string status)
        {
            this.Invoke((Action)delegate ()
            {
                StatusLine.Text = status;
            });
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke((Action)delegate ()
            {
                StatusText.AppendText(prompt + "\r\n");
            });
        }

        protected void SetPrompt2()
        {
            this.Invoke((Action)delegate ()
            {
                StatusText.Text = "";
            });
        }

        public void DrawPicture(Bitmap bitmap)
        {
            this.Invoke((Action)delegate ()
            {
                Picture.Image = new Bitmap(bitmap, Picture.Size);
            });
        }





        protected virtual void Process(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
        }


        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new SampleConversion();
            Bitmap bitmap = null;
            Convertor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }



        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return features;
            }
            else
            {
                return null;
            }
        }


        protected void MakeReport(string message)
        {
            //            this.Invoke((Action)(delegate () {
            //
            //              StatusText.AppendText(message + "\r\n");
            //        }));

        }



       

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("The fingerprint sample was captured. ");
            SetPrompt("Scan Same fingerPrint again. ");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The finger was Removed. ");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched. ");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched. ");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The finger print reader was connected. ");

        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                MessageBox.Show("Good");

            }
            else
            {
                MessageBox.Show("Bad");
            }
        }

        private void CaptureForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
    }
}
