namespace ClientDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbYID = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbCard = new System.Windows.Forms.TextBox();
            this.tbCommunity = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbDns = new System.Windows.Forms.TextBox();
            this.rbDns = new System.Windows.Forms.RadioButton();
            this.rbIP = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 167);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "提交远程数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(96, 70);
            this.tbIP.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(143, 29);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = "127.0.0.1";
            this.tbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 111);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 29);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "8885";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCommunity);
            this.groupBox1.Controls.Add(this.tbCard);
            this.groupBox1.Controls.Add(this.tbPhone);
            this.groupBox1.Controls.Add(this.tbYID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(479, 206);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "YID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "CarID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Community:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 220);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(769, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbYID
            // 
            this.tbYID.Location = new System.Drawing.Point(121, 33);
            this.tbYID.Name = "tbYID";
            this.tbYID.Size = new System.Drawing.Size(335, 29);
            this.tbYID.TabIndex = 4;
            this.tbYID.Text = "ED0854545";
            this.tbYID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(121, 76);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(335, 29);
            this.tbPhone.TabIndex = 5;
            this.tbPhone.Text = "13800138000";
            this.tbPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCard
            // 
            this.tbCard.Location = new System.Drawing.Point(121, 119);
            this.tbCard.Name = "tbCard";
            this.tbCard.Size = new System.Drawing.Size(335, 29);
            this.tbCard.TabIndex = 6;
            this.tbCard.Text = "20140302";
            this.tbCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCommunity
            // 
            this.tbCommunity.Location = new System.Drawing.Point(121, 161);
            this.tbCommunity.Name = "tbCommunity";
            this.tbCommunity.Size = new System.Drawing.Size(335, 29);
            this.tbCommunity.TabIndex = 7;
            this.tbCommunity.Text = "浦东新区";
            this.tbCommunity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbIP);
            this.groupBox2.Controls.Add(this.rbDns);
            this.groupBox2.Controls.Add(this.tbDns);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.tbIP);
            this.groupBox2.Location = new System.Drawing.Point(501, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 153);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置远程服务器地址 ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "IP端口:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tbDns
            // 
            this.tbDns.Enabled = false;
            this.tbDns.Location = new System.Drawing.Point(96, 29);
            this.tbDns.Name = "tbDns";
            this.tbDns.Size = new System.Drawing.Size(143, 29);
            this.tbDns.TabIndex = 6;
            this.tbDns.Text = "www.baidu.com";
            this.tbDns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbDns
            // 
            this.rbDns.AutoSize = true;
            this.rbDns.Location = new System.Drawing.Point(16, 31);
            this.rbDns.Name = "rbDns";
            this.rbDns.Size = new System.Drawing.Size(64, 25);
            this.rbDns.TabIndex = 8;
            this.rbDns.Text = "域名:";
            this.rbDns.UseVisualStyleBackColor = true;
            this.rbDns.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbIP
            // 
            this.rbIP.AutoSize = true;
            this.rbIP.Checked = true;
            this.rbIP.Location = new System.Drawing.Point(16, 70);
            this.rbIP.Name = "rbIP";
            this.rbIP.Size = new System.Drawing.Size(79, 25);
            this.rbIP.TabIndex = 9;
            this.rbIP.TabStop = true;
            this.rbIP.Text = "IP地址:";
            this.rbIP.UseVisualStyleBackColor = true;
            this.rbIP.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 242);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "客户端演示";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCommunity;
        private System.Windows.Forms.TextBox tbCard;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbYID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbDns;
        private System.Windows.Forms.RadioButton rbIP;
        private System.Windows.Forms.RadioButton rbDns;
    }
}

