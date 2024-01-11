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
			tableLayoutPanel1=new TableLayoutPanel();
			pictureBox1=new PictureBox();
			renamingBox=new TextBox();
			openFolder=new Button();
			flowLayoutPanel1=new FlowLayoutPanel();
			skipLeft=new Button();
			skipRight=new Button();
			rename=new Button();
			fileName=new Label();
			inputFolder=new Button();
			outputFolder=new Button();
			flowLayoutPanel2=new FlowLayoutPanel();
			folderBrowserDialog1=new FolderBrowserDialog();
			inputFolderDialog=new FolderBrowserDialog();
			outputFolderDialog=new FolderBrowserDialog();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
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
			tableLayoutPanel1.Size=new Size(1157, 551);
			tableLayoutPanel1.TabIndex=0;
			// 
			// pictureBox1
			// 
			pictureBox1.BorderStyle=BorderStyle.Fixed3D;
			pictureBox1.Dock=DockStyle.Fill;
			pictureBox1.Location=new Point(3, 3);
			pictureBox1.Name="pictureBox1";
			tableLayoutPanel1.SetRowSpan(pictureBox1, 2);
			pictureBox1.Size=new Size(1151, 545);
			pictureBox1.TabIndex=1;
			pictureBox1.TabStop=false;
			// 
			// renamingBox
			// 
			renamingBox.Location=new Point(420, 3);
			renamingBox.Name="renamingBox";
			renamingBox.Size=new Size(150, 31);
			renamingBox.TabIndex=2;
			// 
			// openFolder
			// 
			openFolder.Location=new Point(3, 3);
			openFolder.Name="openFolder";
			openFolder.Size=new Size(133, 34);
			openFolder.TabIndex=3;
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
			flowLayoutPanel1.Controls.Add(outputFolder);
			flowLayoutPanel1.Location=new Point(15, 569);
			flowLayoutPanel1.Name="flowLayoutPanel1";
			flowLayoutPanel1.Size=new Size(1130, 114);
			flowLayoutPanel1.TabIndex=4;
			// 
			// skipLeft
			// 
			skipLeft.Location=new Point(142, 3);
			skipLeft.Name="skipLeft";
			skipLeft.Size=new Size(133, 34);
			skipLeft.TabIndex=3;
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
			rename.Text="rename";
			rename.UseVisualStyleBackColor=true;
			rename.Click+=rename_Click;
			// 
			// fileName
			// 
			fileName.AutoSize=true;
			fileName.Dock=DockStyle.Bottom;
			fileName.Location=new Point(715, 15);
			fileName.Name="fileName";
			fileName.Size=new Size(82, 25);
			fileName.TabIndex=6;
			fileName.Text="Filename";
			// 
			// inputFolder
			// 
			inputFolder.Location=new Point(803, 3);
			inputFolder.Name="inputFolder";
			inputFolder.Size=new Size(133, 34);
			inputFolder.TabIndex=7;
			inputFolder.Text="Open input";
			inputFolder.UseVisualStyleBackColor=true;
			inputFolder.Click+=inputFolder_Click;
			// 
			// outputFolder
			// 
			outputFolder.Location=new Point(942, 3);
			outputFolder.Name="outputFolder";
			outputFolder.Size=new Size(133, 34);
			outputFolder.TabIndex=8;
			outputFolder.Text="Open output";
			outputFolder.UseVisualStyleBackColor=true;
			outputFolder.Click+=outputFolder_Click;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.Location=new Point(18, 566);
			flowLayoutPanel2.Name="flowLayoutPanel2";
			flowLayoutPanel2.Size=new Size(743, 114);
			flowLayoutPanel2.TabIndex=5;
			// 
			// Form1
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(1157, 695);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(flowLayoutPanel1);
			Controls.Add(flowLayoutPanel2);
			Name="Form1";
			Text="Picture Organizer";
			tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private PictureBox pictureBox1;
		private TextBox renamingBox;
		private Button openFolder;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button skipLeft;
		private Button skipRight;
		private FlowLayoutPanel flowLayoutPanel2;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button rename;
		private Label fileName;
		private Button inputFolder;
		private Button outputFolder;
		private FolderBrowserDialog inputFolderDialog;
		private FolderBrowserDialog outputFolderDialog;
	}
}