namespace PictureOrganizer
{
	partial class ProgressBar
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
			fileProcessingProgressBar=new System.Windows.Forms.ProgressBar();
			timeRemaining=new TextBox();
			backgroundWorker1=new System.ComponentModel.BackgroundWorker();
			SuspendLayout();
			// 
			// fileProcessingProgressBar
			// 
			fileProcessingProgressBar.Location=new Point(12, 79);
			fileProcessingProgressBar.Name="fileProcessingProgressBar";
			fileProcessingProgressBar.Size=new Size(678, 34);
			fileProcessingProgressBar.TabIndex=0;
			fileProcessingProgressBar.Click+=fileProcessingProgressBar_Click;
			// 
			// timeRemaining
			// 
			timeRemaining.Location=new Point(12, 42);
			timeRemaining.Name="timeRemaining";
			timeRemaining.Size=new Size(678, 31);
			timeRemaining.TabIndex=1;
			// 
			// backgroundWorker1
			// 
			backgroundWorker1.DoWork+=backgroundWorker1_DoWork;
			// 
			// ProgressBar
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(702, 156);
			Controls.Add(timeRemaining);
			Controls.Add(fileProcessingProgressBar);
			Name="ProgressBar";
			Text="ProgressBar";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.ProgressBar fileProcessingProgressBar;
		private TextBox timeRemaining;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}