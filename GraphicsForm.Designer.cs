
namespace BezierGraphics
{
    partial class BezierGraphics
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ZValueLabel = new System.Windows.Forms.Label();
            this.ZValueTrackBar = new System.Windows.Forms.TrackBar();
            this.ShowControlPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ShowColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.GridChangeLabel = new System.Windows.Forms.Label();
            this.GridSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.ShowGridCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MValueLabel = new System.Windows.Forms.Label();
            this.KSValueLabel = new System.Windows.Forms.Label();
            this.KDValueLabel = new System.Windows.Forms.Label();
            this.MValueTrackBar = new System.Windows.Forms.TrackBar();
            this.KSValueTrackBar = new System.Windows.Forms.TrackBar();
            this.KDValueTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.NormalMapButton = new System.Windows.Forms.Button();
            this.NormalMapCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ChooseImageButton = new System.Windows.Forms.Button();
            this.ColorDialogButton = new System.Windows.Forms.Button();
            this.ImageColorRadioButton = new System.Windows.Forms.RadioButton();
            this.SolidColorRadioButton = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.isReflectorsCheckBox = new System.Windows.Forms.CheckBox();
            this.isLightCheckBox = new System.Windows.Forms.CheckBox();
            this.LightMovementLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ZCoordinateTrackBar = new System.Windows.Forms.TrackBar();
            this.LightMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.isRotateCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZValueTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSizeTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MValueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KSValueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KDValueTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZCoordinateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(12, 24);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(900, 900);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ZValueLabel);
            this.groupBox1.Controls.Add(this.ZValueTrackBar);
            this.groupBox1.Controls.Add(this.ShowControlPointsCheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(918, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bezier surface control points";
            // 
            // ZValueLabel
            // 
            this.ZValueLabel.AutoSize = true;
            this.ZValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ZValueLabel.Location = new System.Drawing.Point(253, 27);
            this.ZValueLabel.Name = "ZValueLabel";
            this.ZValueLabel.Size = new System.Drawing.Size(111, 20);
            this.ZValueLabel.TabIndex = 2;
            this.ZValueLabel.Text = "Current value: 0";
            // 
            // ZValueTrackBar
            // 
            this.ZValueTrackBar.Enabled = false;
            this.ZValueTrackBar.Location = new System.Drawing.Point(253, 62);
            this.ZValueTrackBar.Maximum = 20;
            this.ZValueTrackBar.Name = "ZValueTrackBar";
            this.ZValueTrackBar.Size = new System.Drawing.Size(281, 56);
            this.ZValueTrackBar.TabIndex = 1;
            this.ZValueTrackBar.ValueChanged += new System.EventHandler(this.ZValueTrackBar_ValueChanged);
            // 
            // ShowControlPointsCheckBox
            // 
            this.ShowControlPointsCheckBox.AutoSize = true;
            this.ShowControlPointsCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowControlPointsCheckBox.Location = new System.Drawing.Point(6, 49);
            this.ShowControlPointsCheckBox.Name = "ShowControlPointsCheckBox";
            this.ShowControlPointsCheckBox.Size = new System.Drawing.Size(163, 24);
            this.ShowControlPointsCheckBox.TabIndex = 0;
            this.ShowControlPointsCheckBox.Text = "Show control points";
            this.ShowControlPointsCheckBox.UseVisualStyleBackColor = true;
            this.ShowControlPointsCheckBox.CheckStateChanged += new System.EventHandler(this.ShowControlPointsCheckBox_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ShowColorsCheckBox);
            this.groupBox2.Controls.Add(this.GridChangeLabel);
            this.groupBox2.Controls.Add(this.GridSizeTrackBar);
            this.groupBox2.Controls.Add(this.ShowGridCheckBox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(918, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 109);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Triangle grid";
            // 
            // ShowColorsCheckBox
            // 
            this.ShowColorsCheckBox.AutoSize = true;
            this.ShowColorsCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowColorsCheckBox.Location = new System.Drawing.Point(6, 58);
            this.ShowColorsCheckBox.Name = "ShowColorsCheckBox";
            this.ShowColorsCheckBox.Size = new System.Drawing.Size(111, 24);
            this.ShowColorsCheckBox.TabIndex = 3;
            this.ShowColorsCheckBox.Text = "Show colors";
            this.ShowColorsCheckBox.UseVisualStyleBackColor = true;
            this.ShowColorsCheckBox.CheckStateChanged += new System.EventHandler(this.ShowColorsCheckBox_CheckStateChanged);
            // 
            // GridChangeLabel
            // 
            this.GridChangeLabel.AutoSize = true;
            this.GridChangeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GridChangeLabel.Location = new System.Drawing.Point(208, 28);
            this.GridChangeLabel.Name = "GridChangeLabel";
            this.GridChangeLabel.Size = new System.Drawing.Size(87, 20);
            this.GridChangeLabel.TabIndex = 2;
            this.GridChangeLabel.Text = "Accuracy : 6";
            // 
            // GridSizeTrackBar
            // 
            this.GridSizeTrackBar.LargeChange = 3;
            this.GridSizeTrackBar.Location = new System.Drawing.Point(208, 51);
            this.GridSizeTrackBar.Maximum = 15;
            this.GridSizeTrackBar.Minimum = 6;
            this.GridSizeTrackBar.Name = "GridSizeTrackBar";
            this.GridSizeTrackBar.Size = new System.Drawing.Size(283, 56);
            this.GridSizeTrackBar.SmallChange = 3;
            this.GridSizeTrackBar.TabIndex = 1;
            this.GridSizeTrackBar.Value = 6;
            this.GridSizeTrackBar.ValueChanged += new System.EventHandler(this.GridSizeTrackBar_ValueChanged);
            // 
            // ShowGridCheckBox
            // 
            this.ShowGridCheckBox.AutoSize = true;
            this.ShowGridCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowGridCheckBox.Location = new System.Drawing.Point(6, 28);
            this.ShowGridCheckBox.Name = "ShowGridCheckBox";
            this.ShowGridCheckBox.Size = new System.Drawing.Size(153, 24);
            this.ShowGridCheckBox.TabIndex = 0;
            this.ShowGridCheckBox.Text = "Show triangle grid";
            this.ShowGridCheckBox.UseVisualStyleBackColor = true;
            this.ShowGridCheckBox.CheckStateChanged += new System.EventHandler(this.ShowGridCheckBox_CheckStateChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MValueLabel);
            this.groupBox3.Controls.Add(this.KSValueLabel);
            this.groupBox3.Controls.Add(this.KDValueLabel);
            this.groupBox3.Controls.Add(this.MValueTrackBar);
            this.groupBox3.Controls.Add(this.KSValueTrackBar);
            this.groupBox3.Controls.Add(this.KDValueTrackBar);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(917, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 145);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Light equation parameters";
            // 
            // MValueLabel
            // 
            this.MValueLabel.AutoSize = true;
            this.MValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MValueLabel.Location = new System.Drawing.Point(384, 36);
            this.MValueLabel.Name = "MValueLabel";
            this.MValueLabel.Size = new System.Drawing.Size(84, 20);
            this.MValueLabel.TabIndex = 5;
            this.MValueLabel.Text = "M value: 30";
            // 
            // KSValueLabel
            // 
            this.KSValueLabel.AutoSize = true;
            this.KSValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KSValueLabel.Location = new System.Drawing.Point(193, 36);
            this.KSValueLabel.Name = "KSValueLabel";
            this.KSValueLabel.Size = new System.Drawing.Size(91, 20);
            this.KSValueLabel.TabIndex = 4;
            this.KSValueLabel.Text = "KS value: 0.5";
            // 
            // KDValueLabel
            // 
            this.KDValueLabel.AutoSize = true;
            this.KDValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KDValueLabel.Location = new System.Drawing.Point(21, 36);
            this.KDValueLabel.Name = "KDValueLabel";
            this.KDValueLabel.Size = new System.Drawing.Size(94, 20);
            this.KDValueLabel.TabIndex = 3;
            this.KDValueLabel.Text = "KD value: 0.5";
            // 
            // MValueTrackBar
            // 
            this.MValueTrackBar.LargeChange = 10;
            this.MValueTrackBar.Location = new System.Drawing.Point(384, 72);
            this.MValueTrackBar.Maximum = 100;
            this.MValueTrackBar.Name = "MValueTrackBar";
            this.MValueTrackBar.Size = new System.Drawing.Size(130, 56);
            this.MValueTrackBar.SmallChange = 5;
            this.MValueTrackBar.TabIndex = 2;
            this.MValueTrackBar.ValueChanged += new System.EventHandler(this.MValueTrackBar_ValueChanged);
            // 
            // KSValueTrackBar
            // 
            this.KSValueTrackBar.LargeChange = 2;
            this.KSValueTrackBar.Location = new System.Drawing.Point(193, 72);
            this.KSValueTrackBar.Name = "KSValueTrackBar";
            this.KSValueTrackBar.Size = new System.Drawing.Size(130, 56);
            this.KSValueTrackBar.TabIndex = 1;
            this.KSValueTrackBar.ValueChanged += new System.EventHandler(this.KSValueTrackBar_ValueChanged);
            // 
            // KDValueTrackBar
            // 
            this.KDValueTrackBar.LargeChange = 2;
            this.KDValueTrackBar.Location = new System.Drawing.Point(21, 72);
            this.KDValueTrackBar.Name = "KDValueTrackBar";
            this.KDValueTrackBar.Size = new System.Drawing.Size(130, 56);
            this.KDValueTrackBar.TabIndex = 0;
            this.KDValueTrackBar.ValueChanged += new System.EventHandler(this.KDValueTrackBar_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.NormalMapButton);
            this.groupBox4.Controls.Add(this.NormalMapCheckBox);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(917, 735);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(553, 125);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Normal Map";
            // 
            // NormalMapButton
            // 
            this.NormalMapButton.Enabled = false;
            this.NormalMapButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NormalMapButton.Location = new System.Drawing.Point(179, 49);
            this.NormalMapButton.Name = "NormalMapButton";
            this.NormalMapButton.Size = new System.Drawing.Size(94, 29);
            this.NormalMapButton.TabIndex = 1;
            this.NormalMapButton.Text = "Select...";
            this.NormalMapButton.UseVisualStyleBackColor = true;
            this.NormalMapButton.Click += new System.EventHandler(this.NormalMapButton_Click);
            // 
            // NormalMapCheckBox
            // 
            this.NormalMapCheckBox.AutoSize = true;
            this.NormalMapCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NormalMapCheckBox.Location = new System.Drawing.Point(21, 54);
            this.NormalMapCheckBox.Name = "NormalMapCheckBox";
            this.NormalMapCheckBox.Size = new System.Drawing.Size(115, 24);
            this.NormalMapCheckBox.TabIndex = 0;
            this.NormalMapCheckBox.Text = "Normal Map";
            this.NormalMapCheckBox.UseVisualStyleBackColor = true;
            this.NormalMapCheckBox.CheckStateChanged += new System.EventHandler(this.NormalMapCheckBox_CheckStateChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ChooseImageButton);
            this.groupBox5.Controls.Add(this.ColorDialogButton);
            this.groupBox5.Controls.Add(this.ImageColorRadioButton);
            this.groupBox5.Controls.Add(this.SolidColorRadioButton);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(918, 427);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(552, 125);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Color of the object";
            // 
            // ChooseImageButton
            // 
            this.ChooseImageButton.Enabled = false;
            this.ChooseImageButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChooseImageButton.Location = new System.Drawing.Point(103, 80);
            this.ChooseImageButton.Name = "ChooseImageButton";
            this.ChooseImageButton.Size = new System.Drawing.Size(94, 29);
            this.ChooseImageButton.TabIndex = 3;
            this.ChooseImageButton.Text = "Select...";
            this.ChooseImageButton.UseVisualStyleBackColor = true;
            this.ChooseImageButton.Click += new System.EventHandler(this.ChooseImageButton_Click);
            // 
            // ColorDialogButton
            // 
            this.ColorDialogButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColorDialogButton.Location = new System.Drawing.Point(103, 35);
            this.ColorDialogButton.Name = "ColorDialogButton";
            this.ColorDialogButton.Size = new System.Drawing.Size(94, 29);
            this.ColorDialogButton.TabIndex = 2;
            this.ColorDialogButton.Text = "Select...";
            this.ColorDialogButton.UseVisualStyleBackColor = true;
            this.ColorDialogButton.Click += new System.EventHandler(this.ColorDialogButton_Click);
            // 
            // ImageColorRadioButton
            // 
            this.ImageColorRadioButton.AutoSize = true;
            this.ImageColorRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImageColorRadioButton.Location = new System.Drawing.Point(14, 86);
            this.ImageColorRadioButton.Name = "ImageColorRadioButton";
            this.ImageColorRadioButton.Size = new System.Drawing.Size(72, 24);
            this.ImageColorRadioButton.TabIndex = 1;
            this.ImageColorRadioButton.TabStop = true;
            this.ImageColorRadioButton.Text = "Image";
            this.ImageColorRadioButton.UseVisualStyleBackColor = true;
            this.ImageColorRadioButton.CheckedChanged += new System.EventHandler(this.ImageColorRadioButton_CheckedChanged);
            // 
            // SolidColorRadioButton
            // 
            this.SolidColorRadioButton.AutoSize = true;
            this.SolidColorRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SolidColorRadioButton.Location = new System.Drawing.Point(14, 40);
            this.SolidColorRadioButton.Name = "SolidColorRadioButton";
            this.SolidColorRadioButton.Size = new System.Drawing.Size(64, 24);
            this.SolidColorRadioButton.TabIndex = 0;
            this.SolidColorRadioButton.TabStop = true;
            this.SolidColorRadioButton.Text = "Solid";
            this.SolidColorRadioButton.UseVisualStyleBackColor = true;
            this.SolidColorRadioButton.CheckedChanged += new System.EventHandler(this.SolidColorRadioButton_CheckedChanged);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.DarkRed;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.isReflectorsCheckBox);
            this.groupBox6.Controls.Add(this.isLightCheckBox);
            this.groupBox6.Controls.Add(this.LightMovementLabel);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.ZCoordinateTrackBar);
            this.groupBox6.Controls.Add(this.LightMoveCheckBox);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox6.Location = new System.Drawing.Point(918, 558);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(552, 171);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Light";
            // 
            // isReflectorsCheckBox
            // 
            this.isReflectorsCheckBox.AutoSize = true;
            this.isReflectorsCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isReflectorsCheckBox.Location = new System.Drawing.Point(328, 135);
            this.isReflectorsCheckBox.Name = "isReflectorsCheckBox";
            this.isReflectorsCheckBox.Size = new System.Drawing.Size(97, 24);
            this.isReflectorsCheckBox.TabIndex = 6;
            this.isReflectorsCheckBox.Text = "Reflectors";
            this.isReflectorsCheckBox.UseVisualStyleBackColor = true;
            this.isReflectorsCheckBox.CheckStateChanged += new System.EventHandler(this.isReflectorsCheckBox_CheckStateChanged);
            // 
            // isLightCheckBox
            // 
            this.isLightCheckBox.AutoSize = true;
            this.isLightCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isLightCheckBox.Location = new System.Drawing.Point(328, 105);
            this.isLightCheckBox.Name = "isLightCheckBox";
            this.isLightCheckBox.Size = new System.Drawing.Size(64, 24);
            this.isLightCheckBox.TabIndex = 5;
            this.isLightCheckBox.Text = "Light";
            this.isLightCheckBox.UseVisualStyleBackColor = true;
            this.isLightCheckBox.CheckStateChanged += new System.EventHandler(this.isLightCheckBox_CheckStateChanged);
            // 
            // LightMovementLabel
            // 
            this.LightMovementLabel.AutoSize = true;
            this.LightMovementLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LightMovementLabel.Location = new System.Drawing.Point(179, 27);
            this.LightMovementLabel.Name = "LightMovementLabel";
            this.LightMovementLabel.Size = new System.Drawing.Size(186, 20);
            this.LightMovementLabel.TabIndex = 4;
            this.LightMovementLabel.Text = "Z coordinate of the light: 2";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(155, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Select...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color of the light:";
            // 
            // ZCoordinateTrackBar
            // 
            this.ZCoordinateTrackBar.Location = new System.Drawing.Point(179, 58);
            this.ZCoordinateTrackBar.Maximum = 50;
            this.ZCoordinateTrackBar.Minimum = 20;
            this.ZCoordinateTrackBar.Name = "ZCoordinateTrackBar";
            this.ZCoordinateTrackBar.Size = new System.Drawing.Size(264, 56);
            this.ZCoordinateTrackBar.SmallChange = 2;
            this.ZCoordinateTrackBar.TabIndex = 1;
            this.ZCoordinateTrackBar.Value = 20;
            this.ZCoordinateTrackBar.ValueChanged += new System.EventHandler(this.ZCoordinateTrackBar_ValueChanged);
            // 
            // LightMoveCheckBox
            // 
            this.LightMoveCheckBox.AutoSize = true;
            this.LightMoveCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LightMoveCheckBox.Location = new System.Drawing.Point(11, 58);
            this.LightMoveCheckBox.Name = "LightMoveCheckBox";
            this.LightMoveCheckBox.Size = new System.Drawing.Size(139, 24);
            this.LightMoveCheckBox.TabIndex = 0;
            this.LightMoveCheckBox.Text = "Light movement";
            this.LightMoveCheckBox.UseVisualStyleBackColor = true;
            this.LightMoveCheckBox.CheckStateChanged += new System.EventHandler(this.LightMoveCheckBox_CheckStateChanged);
            // 
            // isRotateCheckBox
            // 
            this.isRotateCheckBox.AutoSize = true;
            this.isRotateCheckBox.Location = new System.Drawing.Point(932, 884);
            this.isRotateCheckBox.Name = "isRotateCheckBox";
            this.isRotateCheckBox.Size = new System.Drawing.Size(75, 24);
            this.isRotateCheckBox.TabIndex = 8;
            this.isRotateCheckBox.Text = "Rotate";
            this.isRotateCheckBox.UseVisualStyleBackColor = true;
            this.isRotateCheckBox.CheckStateChanged += new System.EventHandler(this.isRotateCheckBox_CheckStateChanged);
            // 
            // BezierGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.isRotateCheckBox);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "BezierGraphics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BezierGraphics";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZValueTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSizeTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MValueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KSValueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KDValueTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZCoordinateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ShowControlPointsCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ShowGridCheckBox;
        private System.Windows.Forms.TrackBar GridSizeTrackBar;
        private System.Windows.Forms.Label GridChangeLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label MValueLabel;
        private System.Windows.Forms.Label KSValueLabel;
        private System.Windows.Forms.Label KDValueLabel;
        private System.Windows.Forms.TrackBar MValueTrackBar;
        private System.Windows.Forms.TrackBar KSValueTrackBar;
        private System.Windows.Forms.TrackBar KDValueTrackBar;
        private System.Windows.Forms.Label ZValueLabel;
        private System.Windows.Forms.TrackBar ZValueTrackBar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button NormalMapButton;
        private System.Windows.Forms.CheckBox NormalMapCheckBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton ImageColorRadioButton;
        private System.Windows.Forms.RadioButton SolidColorRadioButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorDialogButton;
        private System.Windows.Forms.Button ChooseImageButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar ZCoordinateTrackBar;
        private System.Windows.Forms.CheckBox LightMoveCheckBox;
        private System.Windows.Forms.Label LightMovementLabel;
        private System.Windows.Forms.CheckBox ShowColorsCheckBox;
        private System.Windows.Forms.CheckBox isReflectorsCheckBox;
        private System.Windows.Forms.CheckBox isLightCheckBox;
        private System.Windows.Forms.CheckBox isRotateCheckBox;
    }
}

