﻿namespace PictureOrganizer
{
	partial class FileHistoryManager
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
			treeView1=new TreeView();
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.Location=new Point(12, 12);
			treeView1.Name="treeView1";
			treeView1.Size=new Size(1551, 426);
			treeView1.TabIndex=0;
			treeView1.AfterSelect+=treeView1_AfterSelect;
			// 
			// FileHistoryManager
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(1575, 450);
			Controls.Add(treeView1);
			Name="FileHistoryManager";
			Text="FileHistoryManager";
			ResumeLayout(false);
		}

		#endregion

		private TreeView treeView1;
	}
}