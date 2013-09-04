using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexus.Windows.Forms;

namespace CarPartingManagementSys
{
    public delegate void deleControlInvoke(object o);
    public partial class frmCarParting : Form, IListener
    {
        DataTable dt = null;
        private System.IO.Ports.SerialPort comport = new System.IO.Ports.SerialPort(staticClass.comport_name, 115200);//定义串口
        HFReaderHelper reader_helper = null;
        public frmCarParting()
        {
            InitializeComponent();

            PieChart1.ItemStyle.SurfaceAlphaTransparency = 0.75F;
            PieChart1.FocusedItemStyle.SurfaceAlphaTransparency = 0.75F;
            PieChart1.FocusedItemStyle.SurfaceBrightnessFactor = 0.3F;
            PieChart1.Inclination = (float)(50 * Math.PI / 180);
            PieChart1.Thickness = 61;
            PieChart1.AutoSizePie = true;

            this.dtpIn.Value = DateTime.Now;
            this.dtpIn.Value = DateTime.Now;

            this.refresh();

            dt = new DataTable("cars");
            dt.Columns.Add("tag", typeof(string));
            dt.Columns.Add("carID", typeof(string));
            dt.Columns.Add("time_in", typeof(string));
            dt.Columns.Add("time_left", typeof(string));
            dt.Columns.Add("note", typeof(string));
            dt.Columns.Add("state", typeof(string));

            this.lblLeaveTimeAccount.Text = string.Empty;

            reader_helper = new HFReaderHelper();
            reader_helper.serial_port = this.comport;
            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
            reader_helper.Listener = this;

            this.FormClosing += new FormClosingEventHandler(frmCarParting_FormClosing);
        }

        void frmCarParting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.comport.DataReceived -= comport_DataReceived;
            try
            {
                comport.Close();
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string temp = comport.ReadExisting();
            this.reader_helper.protocal_parse(temp);
        }

        public void refresh()
        {
            this.lblTotalCount.Text = staticClass.total_count.ToString();
            this.lblUsedCount.Text = staticClass.current_used_count.ToString();
            this.lblCanbeUsedCount.Text = (staticClass.total_count - staticClass.current_used_count).ToString();

            PieChart1.Items.Clear();
            PieChart1.Items.Add(new PieChartItem(staticClass.current_used_count, Color.Red, staticClass.current_used_count.ToString(), "使用数量", 0));
            PieChart1.Items.Add(new PieChartItem(staticClass.total_count - staticClass.current_used_count, Color.Green, (staticClass.total_count - staticClass.current_used_count).ToString(), "空余数量", 0));

            this.txtCarID.Text = string.Empty;
            this.txtNote.Text = string.Empty;
            this.txtTag.Text = string.Empty;
            this.dtpIn.Value = DateTime.Now;
            this.dtpLeave.Value = DateTime.Now;

            this.btnNewCarIn.Enabled = false;
            this.btnCarLeave.Enabled = false;
        }

        void new_tag(string tag)
        {
            DataRow[] rows = this.dt.Select(string.Format("tag = '{0}'", tag));
            if (rows.Length > 0)
            {
                //可能离场
                this.txtTag.Text = tag;
                this.txtCarID.Text = rows[0]["carID"] as string;
                string time_in = rows[0]["time_in"] as string;
                DateTime dt_time_in = DateTime.Parse(time_in);
                TimeSpan ts = DateTime.Now - dt_time_in;
                this.dtpLeave.Value = DateTime.Now;
                this.txtNote.Text = rows[0]["note"] as string;

                this.lblLeaveTimeAccount.Text = string.Format("{0}停车时间: {1}小时 {2}分 {3}秒",
                                                                this.txtCarID.Text, ts.Hours, ts.Minutes.ToString(), ts.Seconds.ToString());
                this.btnCarLeave.Enabled = true;
            }
            else
            {
                //可能进场
                if (staticClass.current_used_count < staticClass.total_count)
                {
                    this.dtpIn.Value = DateTime.Now;
                    this.txtTag.Text = tag;
                    this.dtpLeave.Value = DateTime.Now;

                    this.btnNewCarIn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("这里没有更多车位了，请到别处停车吧！");
                }
            }
        }

        void updateHistory(string h)
        {
            this.textBox1.Text = h + "\r\n" + this.textBox1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //发卡
        //可用数减一，已用数加一。如果大于总数，提示无车位
        private void button1_Click(object sender, EventArgs e)
        {
            string time_in = this.dtpIn.Value.ToString();
            string carID = this.txtCarID.Text;
            string tag = this.txtTag.Text;

            this.dt.Rows.Add(new object[] { tag, carID, time_in, "", this.txtNote.Text, "" });

            staticClass.current_used_count++;
            this.refresh();
        }
        //收卡
        //可用数加1，已用数减一
        private void button3_Click(object sender, EventArgs e)
        {
            DataRow[] rows = this.dt.Select(string.Format("tag = '{0}'", this.txtTag.Text));
            if (rows.Length > 0)
            {
                dt.Rows.Remove(rows[0]);
            }

            staticClass.current_used_count--;

            this.refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig(this);
            frm.ShowDialog();
        }
        public void new_message(string tag)
        {
            deleControlInvoke dele = delegate(object oTag)
            {
                //this.txtTag.Text = oTag as string;
                this.new_tag(oTag as string);
            };
            this.Invoke(dele, tag);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //this.new_tag("111");
            reader_helper.start_loop_protocol();
            this.btnStart.Enabled = false;
        }
    }
}
