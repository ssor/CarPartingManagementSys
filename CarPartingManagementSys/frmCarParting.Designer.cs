namespace CarPartingManagementSys
{
    partial class frmCarParting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarParting));
            this.btnNewCarIn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PieChart1 = new Nexus.Windows.Forms.PieChart();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCanbeUsedCount = new System.Windows.Forms.Label();
            this.lblUsedCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLeaveTimeAccount = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnCarLeave = new System.Windows.Forms.Button();
            this.dtpLeave = new System.Windows.Forms.DateTimePicker();
            this.dtpIn = new System.Windows.Forms.DateTimePicker();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewCarIn
            // 
            this.btnNewCarIn.Location = new System.Drawing.Point(212, 427);
            this.btnNewCarIn.Name = "btnNewCarIn";
            this.btnNewCarIn.Size = new System.Drawing.Size(80, 28);
            this.btnNewCarIn.TabIndex = 0;
            this.btnNewCarIn.Text = "发卡";
            this.btnNewCarIn.UseVisualStyleBackColor = true;
            this.btnNewCarIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PieChart1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCanbeUsedCount);
            this.groupBox1.Controls.Add(this.lblUsedCount);
            this.groupBox1.Controls.Add(this.lblTotalCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(455, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 472);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用状态";
            // 
            // PieChart1
            // 
            this.PieChart1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PieChart1.Location = new System.Drawing.Point(17, 20);
            this.PieChart1.Name = "PieChart1";
            this.PieChart1.Radius = 200F;
            this.PieChart1.Size = new System.Drawing.Size(293, 262);
            this.PieChart1.TabIndex = 2;
            this.PieChart1.Text = "pieChart1";
            this.PieChart1.Thickness = 10F;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "可用车位数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "已用车位数：";
            // 
            // lblCanbeUsedCount
            // 
            this.lblCanbeUsedCount.AutoSize = true;
            this.lblCanbeUsedCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanbeUsedCount.Location = new System.Drawing.Point(104, 357);
            this.lblCanbeUsedCount.Name = "lblCanbeUsedCount";
            this.lblCanbeUsedCount.Size = new System.Drawing.Size(82, 14);
            this.lblCanbeUsedCount.TabIndex = 0;
            this.lblCanbeUsedCount.Text = "车位总数：";
            // 
            // lblUsedCount
            // 
            this.lblUsedCount.AutoSize = true;
            this.lblUsedCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUsedCount.Location = new System.Drawing.Point(104, 331);
            this.lblUsedCount.Name = "lblUsedCount";
            this.lblUsedCount.Size = new System.Drawing.Size(82, 14);
            this.lblUsedCount.TabIndex = 0;
            this.lblUsedCount.Text = "车位总数：";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(104, 305);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(82, 14);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "车位总数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车位总数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLeaveTimeAccount);
            this.groupBox2.Controls.Add(this.txtNote);
            this.groupBox2.Controls.Add(this.btnCarLeave);
            this.groupBox2.Controls.Add(this.dtpLeave);
            this.groupBox2.Controls.Add(this.btnNewCarIn);
            this.groupBox2.Controls.Add(this.dtpIn);
            this.groupBox2.Controls.Add(this.txtCarID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTag);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 469);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lblLeaveTimeAccount
            // 
            this.lblLeaveTimeAccount.AutoSize = true;
            this.lblLeaveTimeAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeaveTimeAccount.Location = new System.Drawing.Point(21, 402);
            this.lblLeaveTimeAccount.Name = "lblLeaveTimeAccount";
            this.lblLeaveTimeAccount.Size = new System.Drawing.Size(55, 14);
            this.lblLeaveTimeAccount.TabIndex = 5;
            this.lblLeaveTimeAccount.Text = "label9";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(79, 218);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(326, 167);
            this.txtNote.TabIndex = 4;
            // 
            // btnCarLeave
            // 
            this.btnCarLeave.Location = new System.Drawing.Point(325, 427);
            this.btnCarLeave.Name = "btnCarLeave";
            this.btnCarLeave.Size = new System.Drawing.Size(80, 28);
            this.btnCarLeave.TabIndex = 0;
            this.btnCarLeave.Text = "收卡";
            this.btnCarLeave.UseVisualStyleBackColor = true;
            this.btnCarLeave.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtpLeave
            // 
            this.dtpLeave.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpLeave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeave.Location = new System.Drawing.Point(79, 168);
            this.dtpLeave.Name = "dtpLeave";
            this.dtpLeave.Size = new System.Drawing.Size(326, 21);
            this.dtpLeave.TabIndex = 3;
            // 
            // dtpIn
            // 
            this.dtpIn.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIn.Location = new System.Drawing.Point(79, 120);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(326, 21);
            this.dtpIn.TabIndex = 3;
            // 
            // txtCarID
            // 
            this.txtCarID.Location = new System.Drawing.Point(79, 76);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(326, 21);
            this.txtCarID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "备注：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "出场时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "入场时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "车牌号：";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(79, 31);
            this.txtTag.Name = "txtTag";
            this.txtTag.ReadOnly = true;
            this.txtTag.Size = new System.Drawing.Size(326, 21);
            this.txtTag.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "卡号：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "退出（&X)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(13, 516);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 225);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "历史记录";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 205);
            this.textBox1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(566, 504);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 27);
            this.button4.TabIndex = 5;
            this.button4.Text = "设置(&C)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(457, 504);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 27);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "启动(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmCarParting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 547);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCarParting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "停车场管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewCarIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCarLeave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCanbeUsedCount;
        private System.Windows.Forms.Label lblUsedCount;
        private System.Windows.Forms.Label lblTotalCount;
        private Nexus.Windows.Forms.PieChart PieChart1;
        private System.Windows.Forms.DateTimePicker dtpLeave;
        private System.Windows.Forms.DateTimePicker dtpIn;
        private System.Windows.Forms.TextBox txtCarID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblLeaveTimeAccount;
    }
}

