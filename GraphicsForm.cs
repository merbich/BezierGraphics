using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierGraphics
{
    public partial class BezierGraphics : Form
    {
        public BezierGraphics()
        {
            InitializeComponent();

            //NormalMapCheckBox.Checked = true;
            

            LogicFile.pic = this.pic;
            //LogicFile.text = this.testTextBox;
            LogicFile.LogicInit();
            SolidColorRadioButton.Checked = true;
            KDValueTrackBar.Value = 5;
            KSValueTrackBar.Value = 5;
            MValueTrackBar.Value = 30;

            LogicFile.myTimer.Interval = 16;  // Update every 16 milliseconds (about 60 frames per second)
            //LogicFile.myTimer.Tick += new EventHandler(LogicFile.TimerEventProcessor);
            LogicFile.myTimer.Tick += LogicFile.TimerEventProcessor;
        }

        private void ShowControlPointsCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (ShowControlPointsCheckBox.Checked) LogicFile.isControlPoints = true;
            else LogicFile.isControlPoints = false;
            LogicFile.FillTriangles();
        }

        private void ShowGridCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (ShowGridCheckBox.Checked) LogicFile.isBezierGrid = true;
            else LogicFile.isBezierGrid = false;
            LogicFile.FillTriangles();
        }

        private void GridSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            LogicFile.GridSize = GridSizeTrackBar.Value;

            GridChangeLabel.Text = "Accuracy: " + GridSizeTrackBar.Value.ToString();

            LogicFile.CalculateBasicTriangles(false);
            LogicFile.InitTriangles();
            LogicFile.FillTriangles();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            LogicFile.DrawControlPoints(true);

            //-debug
            //float z = Bezier.ComputeZ(x, y, ZControlPoints);
            //Point loc = new Point()
            //LogicFile.Debug(LogicFile.pic.PointToClient(MousePosition).X, LogicFile.pic.PointToClient(MousePosition).Y);


            //-------main
            for (int i = 0; i < LogicFile.ControlPoints.Length; i++)
            {
                float x = LogicFile.ControlPoints[i].Item1 * (float)LogicFile.bm.Width;
                float y = LogicFile.ControlPoints[i].Item2 * (float)LogicFile.bm.Height;

                if (LogicFile.pic.PointToClient(MousePosition).X >= x - 20 && LogicFile.pic.PointToClient(MousePosition).X <= x + 20
                    && LogicFile.pic.PointToClient(MousePosition).Y >= y - 20 && LogicFile.pic.PointToClient(MousePosition).Y <= y + 20)
                {
                    // we are in some control point

                    if(!LogicFile.isControlPointsBool[i]) // we are not in same control point as before
                    {
                        if (!(LogicFile.zControlPoint.Item2 == -1))
                        {
                            LogicFile.isControlPointsBool[LogicFile.zControlPoint.Item2] = false;
                        }
                        LogicFile.isControlPointsBool[i] = true;
                        LogicFile.zControlPoint = (true, i);
                        ZValueTrackBar.Enabled = true;

                        ZValueTrackBar.Value = (int)LogicFile.ZControlPoints[i]*10;
                    }
                    LogicFile.Draw();
                }
            }
        }

        private void ZValueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            LogicFile.ZControlPoints[LogicFile.zControlPoint.Item2] = (float)ZValueTrackBar.Value / 20f;

            ZValueLabel.Text = "Current value:" + (ZValueTrackBar.Value/10f).ToString();

            LogicFile.InitTriangles();
            LogicFile.FillTriangles();     
        }

        private void NormalMapCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(NormalMapCheckBox.Checked)
            {
                NormalMapButton.Enabled = true;
                LogicFile.isNormalMap = true;
                LogicFile.InitTriangles();
                LogicFile.FillTriangles();
                //LogicFile.NormalMapFunction();
            }
            else
            {
                NormalMapButton.Enabled = false;
                LogicFile.isNormalMap = false;
                LogicFile.InitTriangles();
                LogicFile.FillTriangles();
            }
        }

        private void NormalMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                Image i = Image.FromFile(filename);
                LogicFile.image = new DirectBitmap(new Bitmap(i, new Size(900, 900)));

                LogicFile.InitTriangles();
                LogicFile.FillTriangles();
            }
        }

        private void ColorDialogButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = ColorFile.objColorC;
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                ColorFile.objColor = new Vector3((float)selectedColor.R/255f, (float)selectedColor.G/255f, (float)selectedColor.B/255f);
                ColorFile.objColorC = selectedColor;
            }

            LogicFile.FillTriangles();
        }

        private void SolidColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(SolidColorRadioButton.Checked)
            {
                ColorDialogButton.Enabled = true;
                LogicFile.isBackgroundImage = false;
                Color selectedColor = Color.Red;
                ColorFile.objColor = new Vector3((float)selectedColor.R / 255f, (float)selectedColor.G / 255f, (float)selectedColor.B / 255f);
                ColorFile.objColorC = selectedColor;
            }
            else
            {
                ColorDialogButton.Enabled = false;
            }
        }

        private void ImageColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(ImageColorRadioButton.Checked)
            {
                ChooseImageButton.Enabled = true;
            }
            else
            {
                ChooseImageButton.Enabled = false;
            }
        }

        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                Image i = Image.FromFile(filename);
                LogicFile.BackgroundImage = new DirectBitmap(new Bitmap(i, new Size(900, 900)));

                LogicFile.isBackgroundImage = true;

                //LogicFile.InitTriangles();
                LogicFile.FillTriangles();
            }
        }

        private void KDValueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            KDValueLabel.Text = "KD value: " + (KDValueTrackBar.Value/10f).ToString();
            ColorFile.kd = KDValueTrackBar.Value / 10f;
            LogicFile.FillTriangles();
        }

        private void KSValueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            KSValueLabel.Text = "KS value: " + (KSValueTrackBar.Value / 10f).ToString();
            ColorFile.ks = KSValueTrackBar.Value / 10f;
            LogicFile.FillTriangles();
        }

        private void MValueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            MValueLabel.Text = "M value: " + (MValueTrackBar.Value).ToString();
            ColorFile.m = MValueTrackBar.Value;
            LogicFile.FillTriangles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = ColorFile.lightColorC;
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                ColorFile.lightColor = new Vector3((float)selectedColor.R / 255f, (float)selectedColor.G / 255f, (float)selectedColor.B / 255f);
                ColorFile.lightColorC = selectedColor;
            }

            LogicFile.FillTriangles();
        }

        private void LightMoveCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (LightMoveCheckBox.Checked)
            {
                LogicFile.isAnimation = true;
                LogicFile.myTimer.Start();

                // Runs the timer, and raises the event.
                while (LogicFile.isAnimation == true)
                { 
                    // Processes all the events in the queue.
                    Application.DoEvents();
                }
                //LogicFile.myTimer.Stop();
            }
            else
            {
                LogicFile.myTimer.Stop();
                LogicFile.isAnimation = false;
            }
        }
        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    // Start the animation when the form loads
        //    ThreadPool.QueueUserWorkItem(o => LogicFile.Animate());
        //}

        private void ZCoordinateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            LogicFile.ZAmimatePosition = ZCoordinateTrackBar.Value/10f;
            LightMovementLabel.Text = "Z coordinate of the light: " + (ZCoordinateTrackBar.Value / 10f).ToString();

            ColorFile.lightPosition = new Vector3(ColorFile.lightPosition.X,
                ColorFile.lightPosition.Y, ZCoordinateTrackBar.Value / 10f);

            LogicFile.FillTriangles();
        }
    }
}
