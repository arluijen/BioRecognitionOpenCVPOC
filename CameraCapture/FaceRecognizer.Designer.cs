using System;

namespace LiveFaceDetection
{
    partial class FaceRecognizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceRecognizer));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdReladParams = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmdSaveImage = new System.Windows.Forms.Button();
            this.ImBoxEigen = new Emgu.CV.UI.ImageBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDistThresh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaxIts = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdRecognize = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.btnTrainRecog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWinSiz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMinNeigh = new System.Windows.Forms.ComboBox();
            this.comboBoxScIncRte = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImBoxEigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 619);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdReladParams);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.cmdSaveImage);
            this.tabPage1.Controls.Add(this.ImBoxEigen);
            this.tabPage1.Controls.Add(this.lblResult);
            this.tabPage1.Controls.Add(this.CamImageBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(645, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cmdReladParams
            // 
            this.cmdReladParams.Location = new System.Drawing.Point(537, 531);
            this.cmdReladParams.Name = "cmdReladParams";
            this.cmdReladParams.Size = new System.Drawing.Size(101, 43);
            this.cmdReladParams.TabIndex = 46;
            this.cmdReladParams.Text = "Reload Parameters";
            this.cmdReladParams.UseVisualStyleBackColor = true;
            this.cmdReladParams.Click += new System.EventHandler(this.cmdReladParams_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(537, 502);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 23);
            this.btnStart.TabIndex = 43;
            this.btnStart.Text = "Start Live Video!";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // cmdSaveImage
            // 
            this.cmdSaveImage.Location = new System.Drawing.Point(537, 473);
            this.cmdSaveImage.Name = "cmdSaveImage";
            this.cmdSaveImage.Size = new System.Drawing.Size(102, 23);
            this.cmdSaveImage.TabIndex = 42;
            this.cmdSaveImage.Text = "Save Pic";
            this.cmdSaveImage.UseVisualStyleBackColor = true;
            this.cmdSaveImage.Click += new System.EventHandler(this.cmdSaveImage_Click_1);
            // 
            // ImBoxEigen
            // 
            this.ImBoxEigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImBoxEigen.Location = new System.Drawing.Point(5, 472);
            this.ImBoxEigen.Margin = new System.Windows.Forms.Padding(2);
            this.ImBoxEigen.Name = "ImBoxEigen";
            this.ImBoxEigen.Size = new System.Drawing.Size(95, 107);
            this.ImBoxEigen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImBoxEigen.TabIndex = 34;
            this.ImBoxEigen.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(105, 472);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(221, 20);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "...nothing recognized yet...";
            // 
            // CamImageBox
            // 
            this.CamImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CamImageBox.Location = new System.Drawing.Point(5, 5);
            this.CamImageBox.Margin = new System.Windows.Forms.Padding(2);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(635, 463);
            this.CamImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CamImageBox.TabIndex = 3;
            this.CamImageBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.cmdRecognize);
            this.tabPage2.Controls.Add(this.cmdSearch);
            this.tabPage2.Controls.Add(this.btnTrainRecog);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbCamIndex);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(645, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parameters";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDistThresh);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtEPS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMaxIts);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 116);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training and Recognition Parameters";
            // 
            // txtDistThresh
            // 
            this.txtDistThresh.Location = new System.Drawing.Point(186, 84);
            this.txtDistThresh.Name = "txtDistThresh";
            this.txtDistThresh.Size = new System.Drawing.Size(64, 20);
            this.txtDistThresh.TabIndex = 21;
            this.txtDistThresh.Text = "4000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Distance Threshold";
            // 
            // txtEPS
            // 
            this.txtEPS.Location = new System.Drawing.Point(186, 54);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(64, 20);
            this.txtEPS.TabIndex = 19;
            this.txtEPS.Text = "0,001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "EPS (Double)";
            // 
            // txtMaxIts
            // 
            this.txtMaxIts.Location = new System.Drawing.Point(186, 16);
            this.txtMaxIts.Name = "txtMaxIts";
            this.txtMaxIts.Size = new System.Drawing.Size(64, 20);
            this.txtMaxIts.TabIndex = 17;
            this.txtMaxIts.Text = "16";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Maximum Iterations (int)\r\n";
            // 
            // cmdRecognize
            // 
            this.cmdRecognize.Location = new System.Drawing.Point(272, 59);
            this.cmdRecognize.Name = "cmdRecognize";
            this.cmdRecognize.Size = new System.Drawing.Size(102, 23);
            this.cmdRecognize.TabIndex = 43;
            this.cmdRecognize.Text = "Recognize";
            this.cmdRecognize.UseVisualStyleBackColor = true;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(271, 86);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(102, 23);
            this.cmdSearch.TabIndex = 42;
            this.cmdSearch.Text = "Search Pic";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // btnTrainRecog
            // 
            this.btnTrainRecog.BackColor = System.Drawing.Color.LightGreen;
            this.btnTrainRecog.Location = new System.Drawing.Point(271, 12);
            this.btnTrainRecog.Name = "btnTrainRecog";
            this.btnTrainRecog.Size = new System.Drawing.Size(103, 45);
            this.btnTrainRecog.TabIndex = 40;
            this.btnTrainRecog.Text = "Train the Recognizer";
            this.btnTrainRecog.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Select Camera:";
            // 
            // cbCamIndex
            // 
            this.cbCamIndex.FormattingEnabled = true;
            this.cbCamIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbCamIndex.Location = new System.Drawing.Point(119, 138);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(143, 21);
            this.cbCamIndex.TabIndex = 38;
            this.cbCamIndex.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxWinSiz);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxMinNeigh);
            this.groupBox1.Controls.Add(this.comboBoxScIncRte);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(257, 119);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tune Detection Parameters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Scale Increase Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Min Neighbors:";
            // 
            // textBoxWinSiz
            // 
            this.textBoxWinSiz.Location = new System.Drawing.Point(130, 81);
            this.textBoxWinSiz.Name = "textBoxWinSiz";
            this.textBoxWinSiz.Size = new System.Drawing.Size(64, 20);
            this.textBoxWinSiz.TabIndex = 15;
            this.textBoxWinSiz.Text = "25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Min.detection Scale\r\n(Window Size)";
            // 
            // comboBoxMinNeigh
            // 
            this.comboBoxMinNeigh.FormattingEnabled = true;
            this.comboBoxMinNeigh.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxMinNeigh.Location = new System.Drawing.Point(130, 54);
            this.comboBoxMinNeigh.Name = "comboBoxMinNeigh";
            this.comboBoxMinNeigh.Size = new System.Drawing.Size(64, 21);
            this.comboBoxMinNeigh.TabIndex = 14;
            this.comboBoxMinNeigh.Text = "2";
            // 
            // comboBoxScIncRte
            // 
            this.comboBoxScIncRte.FormattingEnabled = true;
            this.comboBoxScIncRte.Items.AddRange(new object[] {
            "1.1",
            "1.2",
            "1.3",
            "1.4"});
            this.comboBoxScIncRte.Location = new System.Drawing.Point(130, 28);
            this.comboBoxScIncRte.Name = "comboBoxScIncRte";
            this.comboBoxScIncRte.Size = new System.Drawing.Size(64, 21);
            this.comboBoxScIncRte.TabIndex = 13;
            this.comboBoxScIncRte.Text = "1.1";
            // 
            // FaceRecognizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 626);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FaceRecognizer";
            this.Text = "Face Recognizer";
            this.Load += new System.EventHandler(this.FaceRecognizer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImBoxEigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button cmdSaveImage;
        private Emgu.CV.UI.ImageBox ImBoxEigen;
        private System.Windows.Forms.Label lblResult;
        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdRecognize;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button btnTrainRecog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWinSiz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMinNeigh;
        private System.Windows.Forms.ComboBox comboBoxScIncRte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDistThresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaxIts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdReladParams;
    }
}

