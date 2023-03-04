namespace TiktokRender
{
    partial class fMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtVideo = new System.Windows.Forms.DataGridView();
            this.SelectVideo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownVideo = new System.Windows.Forms.Button();
            this.btnGetVideo = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dtVideo);
            this.tabPage1.Controls.Add(this.btnDownVideo);
            this.tabPage1.Controls.Add(this.btnGetVideo);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1258, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Download video";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(964, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(279, 29);
            this.progressBar1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // dtVideo
            // 
            this.dtVideo.AllowUserToAddRows = false;
            this.dtVideo.AllowUserToDeleteRows = false;
            this.dtVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVideo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectVideo,
            this.ID,
            this.Title,
            this.Time,
            this.Size,
            this.Link});
            this.dtVideo.Location = new System.Drawing.Point(6, 85);
            this.dtVideo.Name = "dtVideo";
            this.dtVideo.RowHeadersWidth = 51;
            this.dtVideo.RowTemplate.Height = 29;
            this.dtVideo.Size = new System.Drawing.Size(1246, 433);
            this.dtVideo.TabIndex = 2;
            this.dtVideo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtVideo_CellClick);
            this.dtVideo.DoubleClick += new System.EventHandler(this.dtVideo_DoubleClick);
            // 
            // SelectVideo
            // 
            this.SelectVideo.HeaderText = "Chọn video";
            this.SelectVideo.MinimumWidth = 6;
            this.SelectVideo.Name = "SelectVideo";
            this.SelectVideo.Width = 125;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 200;
            // 
            // Title
            // 
            this.Title.HeaderText = "Tiêu đề";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 600;
            // 
            // Time
            // 
            this.Time.HeaderText = "Thời gian";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 125;
            // 
            // Size
            // 
            this.Size.HeaderText = "Kích thước";
            this.Size.MinimumWidth = 6;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 125;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.MinimumWidth = 6;
            this.Link.Name = "Link";
            this.Link.Visible = false;
            this.Link.Width = 125;
            // 
            // btnDownVideo
            // 
            this.btnDownVideo.Location = new System.Drawing.Point(384, 21);
            this.btnDownVideo.Name = "btnDownVideo";
            this.btnDownVideo.Size = new System.Drawing.Size(113, 58);
            this.btnDownVideo.TabIndex = 1;
            this.btnDownVideo.Text = "Down";
            this.btnDownVideo.UseVisualStyleBackColor = true;
            this.btnDownVideo.Click += new System.EventHandler(this.btnDownVideo_Click);
            // 
            // btnGetVideo
            // 
            this.btnGetVideo.Location = new System.Drawing.Point(220, 21);
            this.btnGetVideo.Name = "btnGetVideo";
            this.btnGetVideo.Size = new System.Drawing.Size(113, 58);
            this.btnGetVideo.TabIndex = 1;
            this.btnGetVideo.Text = "Get";
            this.btnGetVideo.UseVisualStyleBackColor = true;
            this.btnGetVideo.Click += new System.EventHandler(this.btnGetVideo_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(26, 37);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(163, 27);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "thanhdinhbao";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1258, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Render video";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(701, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 27);
            this.textBox1.TabIndex = 5;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 567);
            this.Controls.Add(this.tabControl1);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiktok Renderer by ThanhDB v1.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnDownVideo;
        private Button btnGetVideo;
        private TextBox txtUsername;
        private TabPage tabPage2;
        private DataGridView dtVideo;
        private DataGridViewCheckBoxColumn SelectVideo;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Link;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private TextBox textBox1;
    }
}