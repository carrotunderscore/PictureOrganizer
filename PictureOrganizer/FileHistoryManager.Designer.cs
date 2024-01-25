namespace PictureOrganizer
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
			components=new System.ComponentModel.Container();
			treeView1=new TreeView();
			contextMenuStrip1=new ContextMenuStrip(components);
			helloToolStripMenuItem=new ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.Dock=DockStyle.Fill;
			treeView1.Location=new Point(0, 0);
			treeView1.Name="treeView1";
			treeView1.Size=new Size(1575, 450);
			treeView1.TabIndex=0;
			treeView1.AfterSelect+=treeView1_AfterSelect;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize=new Size(24, 24);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { helloToolStripMenuItem });
			contextMenuStrip1.Name="contextMenuStrip1";
			contextMenuStrip1.Size=new Size(241, 69);
			// 
			// helloToolStripMenuItem
			// 
			helloToolStripMenuItem.Name="helloToolStripMenuItem";
			helloToolStripMenuItem.Size=new Size(240, 32);
			helloToolStripMenuItem.Text="hello";
			helloToolStripMenuItem.Click+=helloToolStripMenuItem_Click;
			// 
			// FileHistoryManager
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(1575, 450);
			Controls.Add(treeView1);
			Name="FileHistoryManager";
			Text="FileHistoryManager";
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TreeView treeView1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem helloToolStripMenuItem;
	}
}