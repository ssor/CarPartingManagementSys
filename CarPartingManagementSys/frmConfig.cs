using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using nsConfigDB;

namespace CarPartingManagementSys
{
    public partial class frmConfig : Form
    {
        frmCarParting last_form = null;
        public frmConfig(frmCarParting frm)
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbPortName.Items.AddRange(ports);

            this.Shown += new EventHandler(frmConfig_Shown);

            this.last_form = frm;
        }


        void frmConfig_Shown(object sender, EventArgs e)
        {
            this.numberCount.Value = staticClass.total_count;
            this.cmbPortName.Text = staticClass.comport_name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            //保存重新设置的总车位时，需要与当前已使用的量做比较
            //如果设置的新量小于当前使用量，就不能保存
            try
            {
                int new_count = (int)this.numberCount.Value;
                if (new_count < staticClass.current_used_count)
                {
                    MessageBox.Show("当前使用的车位数量已经超过设置的最大数量，请将车位数设置的更大些！");
                }
                else
                {
                    staticClass.total_count = new_count;
                    ConfigDB.saveConfig("total_count", staticClass.total_count);
                }

                staticClass.comport_name = this.cmbPortName.Text;
                nsConfigDB.ConfigDB.saveConfig("comport_name", staticClass.comport_name);

                this.Close();

                if (this.last_form != null)
                {
                    this.last_form.refresh();
                }
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
