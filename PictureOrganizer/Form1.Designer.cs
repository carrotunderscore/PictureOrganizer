namespace PictureOrganizer
{
	partial class Form1
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
			renamingBox=new TextBox();
			openFolder=new Button();
			flowLayoutPanel1=new FlowLayoutPanel();
			skipLeft=new Button();
			skipRight=new Button();
			rename=new Button();
			fileName=new Label();
			inputFolder=new Button();
			label2=new Label();
			inputFolderLabel=new Label();
			outputFolder=new Button();
			label3=new Label();
			outputFolderLabel=new Label();
			sortYear=new Button();
			sortMonth=new Button();
			label1=new Label();
			folderBrowserDialog1=new FolderBrowserDialog();
			inputFolderDialog=new FolderBrowserDialog();
			outputFolderDialog=new FolderBrowserDialog();
			flowLayoutPanel2=new FlowLayoutPanel();
			pictureBox1=new PictureBox();
			tableLayoutPanel1=new TableLayoutPanel();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// renamingBox
			// 
			renamingBox.Location=new Point(420, 3);
			renamingBox.Name="renamingBox";
			renamingBox.Size=new Size(150, 31);
			renamingBox.TabIndex=0;
			// 
			// openFolder
			// 
			openFolder.Location=new Point(3, 3);
			openFolder.Name="openFolder";
			openFolder.Size=new Size(133, 34);
			openFolder.TabIndex=3;
			openFolder.TabStop=false;
			openFolder.Text="Open folder";
			openFolder.UseVisualStyleBackColor=true;
			openFolder.Click+=openFolder_Click;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.Controls.Add(openFolder);
			flowLayoutPanel1.Controls.Add(skipLeft);
			flowLayoutPanel1.Controls.Add(skipRight);
			flowLayoutPanel1.Controls.Add(renamingBox);
			flowLayoutPanel1.Controls.Add(rename);
			flowLayoutPanel1.Controls.Add(fileName);
			flowLayoutPanel1.Controls.Add(inputFolder);
			flowLayoutPanel1.Controls.Add(label2);
			flowLayoutPanel1.Controls.Add(inputFolderLabel);
			flowLayoutPanel1.Controls.Add(outputFolder);
			flowLayoutPanel1.Controls.Add(label3);
			flowLayoutPanel1.Controls.Add(outputFolderLabel);
			flowLayoutPanel1.Controls.Add(sortYear);
			flowLayoutPanel1.Controls.Add(sortMonth);
			flowLayoutPanel1.Controls.Add(label1);
			flowLayoutPanel1.Location=new Point(15, 569);
			flowLayoutPanel1.Name="flowLayoutPanel1";
			flowLayoutPanel1.Size=new Size(1736, 193);
			flowLayoutPanel1.TabIndex=4;
			// 
			// skipLeft
			// 
			skipLeft.Location=new Point(142, 3);
			skipLeft.Name="skipLeft";
			skipLeft.Size=new Size(133, 34);
			skipLeft.TabIndex=3;
			skipLeft.TabStop=false;
			skipLeft.Text="Skip left";
			skipLeft.UseVisualStyleBackColor=true;
			skipLeft.Click+=skipLeft_Click_1;
			// 
			// skipRight
			// 
			skipRight.Location=new Point(281, 3);
			skipRight.Name="skipRight";
			skipRight.Size=new Size(133, 34);
			skipRight.TabIndex=4;
			skipRight.TabStop=false;
			skipRight.Text="Skip right";
			skipRight.UseVisualStyleBackColor=true;
			skipRight.Click+=skipRight_Click;
			// 
			// rename
			// 
			rename.Location=new Point(576, 3);
			rename.Name="rename";
			rename.Size=new Size(133, 34);
			rename.TabIndex=5;
			rename.TabStop=false;
			rename.Text="rename";
			rename.UseVisualStyleBackColor=true;
			rename.Click+=rename_Click;
			// 
			// fileName
			// 
			fileName.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
			fileName.AutoSize=true;
			flowLayoutPanel1.SetFlowBreak(fileName, true);
			fileName.Location=new Point(715, 0);
			fileName.Name="fileName";
			fileName.Size=new Size(82, 40);
			fileName.TabIndex=6;
			fileName.Text="Filename";
			// 
			// inputFolder
			// 
			inputFolder.Location=new Point(3, 43);
			inputFolder.Name="inputFolder";
			inputFolder.Size=new Size(133, 34);
			inputFolder.TabIndex=7;
			inputFolder.TabStop=false;
			inputFolder.Text="Open input";
			inputFolder.UseVisualStyleBackColor=true;
			inputFolder.Click+=inputFolder_Click;
			// 
			// label2
			// 
			label2.AutoSize=true;
			label2.Location=new Point(142, 40);
			label2.Name="label2";
			label2.Size=new Size(198, 25);
			label2.TabIndex=13;
			label2.Text="Folder you want to sort";
			// 
			// inputFolderLabel
			// 
			inputFolderLabel.AutoSize=true;
			flowLayoutPanel1.SetFlowBreak(inputFolderLabel, true);
			inputFolderLabel.Location=new Point(346, 40);
			inputFolderLabel.Name="inputFolderLabel";
			inputFolderLabel.Size=new Size(174, 25);
			inputFolderLabel.TabIndex=10;
			inputFolderLabel.Text="Input folder location";
			// 
			// outputFolder
			// 
			outputFolder.Location=new Point(3, 83);
			outputFolder.Name="outputFolder";
			outputFolder.Size=new Size(133, 34);
			outputFolder.TabIndex=8;
			outputFolder.TabStop=false;
			outputFolder.Text="Open output";
			outputFolder.UseVisualStyleBackColor=true;
			outputFolder.Click+=outputFolder_Click;
			// 
			// label3
			// 
			label3.AutoSize=true;
			label3.Location=new Point(142, 80);
			label3.Name="label3";
			label3.Size=new Size(346, 25);
			label3.TabIndex=14;
			label3.Text="Folder where you want to save sorted files";
			// 
			// outputFolderLabel
			// 
			outputFolderLabel.AutoSize=true;
			flowLayoutPanel1.SetFlowBreak(outputFolderLabel, true);
			outputFolderLabel.Location=new Point(494, 80);
			outputFolderLabel.Name="outputFolderLabel";
			outputFolderLabel.Size=new Size(189, 25);
			outputFolderLabel.TabIndex=11;
			outputFolderLabel.Text="Output folder location";
			// 
			// sortYear
			// 
			sortYear.Location=new Point(3, 123);
			sortYear.Name="sortYear";
			sortYear.Size=new Size(133, 34);
			sortYear.TabIndex=12;
			sortYear.TabStop=false;
			sortYear.Text="Sort by year";
			sortYear.UseVisualStyleBackColor=true;
			sortYear.Click+=sortYear_Click;
			// 
			// sortMonth
			// 
			sortMonth.Location=new Point(142, 123);
			sortMonth.Name="sortMonth";
			sortMonth.Size=new Size(143, 34);
			sortMonth.TabIndex=15;
			sortMonth.TabStop=false;
			sortMonth.Text="Sort by month";
			sortMonth.UseVisualStyleBackColor=true;
			sortMonth.Click+=sortMonth_Click;
			// 
			// label1
			// 
			label1.Location=new Point(291, 120);
			label1.Name="label1";
			label1.Size=new Size(100, 23);
			label1.TabIndex=9;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Location=new Point(18, 566);
			flowLayoutPanel2.Name="flowLayoutPanel2";
			flowLayoutPanel2.Size=new Size(743, 114);
			flowLayoutPanel2.TabIndex=5;
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle=BorderStyle.Fixed3D;
			pictureBox1.Dock=DockStyle.Fill;
			pictureBox1.Location=new Point(3, 3);
			pictureBox1.Name="pictureBox1";
			tableLayoutPanel1.SetRowSpan(pictureBox1, 2);
			pictureBox1.Size=new Size(1757, 545);
			pictureBox1.TabIndex=1;
			pictureBox1.TabStop=false;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount=1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
			tableLayoutPanel1.Dock=DockStyle.Top;
			tableLayoutPanel1.Location=new Point(0, 0);
			tableLayoutPanel1.Name="tableLayoutPanel1";
			tableLayoutPanel1.RowCount=2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size=new Size(1763, 551);
			tableLayoutPanel1.TabIndex=0;
			// 
			// Form1
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(1763, 774);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(flowLayoutPanel1);
			Controls.Add(flowLayoutPanel2);
			Name="Form1";
			Text="Picture Organizer";
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private TextBox renamingBox;
		private Button openFolder;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button skipLeft;
		private Button skipRight;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button rename;
		private Label fileName;
		private Button inputFolder;
		private Button outputFolder;
		private FolderBrowserDialog inputFolderDialog;
		private FolderBrowserDialog outputFolderDialog;
		private FlowLayoutPanel flowLayoutPanel2;
		private PictureBox pictureBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private Label inputFolderLabel;
		private Label outputFolderLabel;
		private Button sortYear;
		private Label label2;
		private Label label3;
		private Button sortMonth;
	}
}