using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;

namespace CarPartingManagementSys
{
    public enum HFRFID_PROTOCOL
    {
        TAG_1443A,TAG_1443B,TAG_15693,TAG_ALL
    }
    public interface IListener
    {
        void new_message(string tag);
    }
    public class HFTag
    {
        public string tag_type;
        public string tag_epc;
        public HFTag(string type, string epc)
        {
            this.tag_type = type;
            this.tag_epc = epc;
        }
    }
    public interface IHFListener
    {
        void new_HFTag(HFTag ht);

    }

    /// <summary>
    /// 该类只负责在有信息输入的情况下，对信息进行解析，并生成通知
    /// </summary>
    public class HFReaderHelper
    {
        public IListener Listener = null;
        public IHFListener HFListener = null;
        public SerialPort serial_port = null;
        StringBuilder buffer = new StringBuilder();
        Timer _timer = new Timer();

        //三种协议
        public string 设置15693协议 = "010C00030410002101000000";
        public string 设置14443A协议 = "010c00030410002101090000";
        public string 设置14443B协议 = "010C000304100021010C0000";
        //public static string 设置TAGIT协议 = "010C00030410002101130000";
        public string 读取15693协议标签 = "010B000304142401000000";
        public string 读取14443A协议标签 = "0109000304A0010000";
        public string 读取14443B协议标签 = "0109000304B0040000";
        //public static string 读取TAGIT协议标签 = "010B000304340050000000";

        public bool b_support_15693 = true;// 1
        public bool b_support_1443A = true;// 2
        public bool b_support_1443B = true;// 3

        int current_protocol_index = 0;
        public HFReaderHelper()
        {

        }
        public void set_protocol_support(HFRFID_PROTOCOL protocol, bool bSupport)
        {
            switch (protocol)
            { 
                case HFRFID_PROTOCOL.TAG_1443A:
                    this.b_support_1443A = bSupport;
                    break;
                case HFRFID_PROTOCOL.TAG_1443B:
                    this.b_support_1443B = bSupport;
                    break;
                case HFRFID_PROTOCOL.TAG_15693:
                    this.b_support_15693 = bSupport;
                    break;
                case HFRFID_PROTOCOL.TAG_ALL:
                    this.b_support_1443A = bSupport;
                    this.b_support_15693 = bSupport;
                    this.b_support_1443B = bSupport;
                    break;
            }
        }
        /// <summary>
        /// 开始启动协议轮询，只轮询支持的协议
        /// </summary>
        public void start_loop_protocol()
        {
            current_protocol_index = 0;
            _timer.Interval = 800;
            _timer.Tick -= _timer_Tick;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;
        }
        public void stop_loop_protocol()
        {
            _timer.Enabled = false;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            //this.loop_protocol_index();
            string[] cmd = this.get_protocol_command_string();
            if (cmd != null && this.serial_port != null)
            {
                if (this.serial_port.IsOpen == false)
                {
                    try
                    {
                        this.serial_port.Open();
                    }
                    catch (System.Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        return;
                    }
                }
                this.serial_port.Write(cmd[0]);
                System.Threading.Thread.Sleep(60);
                this.serial_port.Write(cmd[1]);

            }
        }
        string[] get_protocol_command_string()
        {
            string[] cmd = null;
            bool flag = false;
            while (!flag)
            {
                loop_protocol_index();
                switch (current_protocol_index)
                {
                    case 1:
                        if (this.b_support_15693 == true)
                        {
                            cmd = new string[2] { this.设置15693协议, this.读取15693协议标签 };
                            flag = true;
                        }
                        break;
                    case 2:
                        if (this.b_support_1443A == true)
                        {
                            cmd = new string[2] { this.设置14443A协议, this.读取14443A协议标签 };
                            flag = true;
                        }
                        break;
                    case 3:
                        if (this.b_support_1443B == true)
                        {
                            cmd = new string[2] { this.设置14443B协议, this.读取14443B协议标签 };
                            flag = true;
                        }
                        break;
                    case -1:
                        flag = true;
                        break;
                }
            }
            return cmd;
        }
        //获取代表当前要使用的协议的索引
        void loop_protocol_index()
        {
            current_protocol_index++;
            if (current_protocol_index > 3)
            {
                current_protocol_index = 0;
            }
        }
        void raise_new_message(string type, string tag)
        {
            Debug.WriteLine(string.Format("type -> {0}  tag -> {1}", type, tag));
            if (this.Listener != null)
            {
                this.Listener.new_message(tag);
            }
            if (this.HFListener != null)
            {
                this.HFListener.new_HFTag(new HFTag(type, tag));
            }
        }
        public void protocal_parse(string data)
        {
            string strPro = string.Empty;
            buffer.Append(data);

            //解析返回的数据
            // 首先确定已经接收到的数据中含有指示命令和标签UID
            string currentData = buffer.ToString();
            Debug.WriteLine(
    string.Format("protocal_parse  -> current buffer = {0}"
    , currentData));
            //处理1443A协议
            strPro = "14443A协议";
            //未读取到
            MatchCollection mc = Regex.Matches(currentData, @"0109000304A0010000[\r\n]+14443A REQA.[\r\n]+\(\)");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"0109000304A0010000[\r\n]+14443A REQA.[\r\n\(\w+\)]+\[(?<tag>\w+)\]");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.raise_new_message(strPro, tag);
                }
                buffer.Replace(m.Value, "");
            }
            strPro = "14443B协议";
            mc = Regex.Matches(currentData, @"0109000304B0040000[\r\n]+14443B REQB.([\r\n]+\[\]){16}");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"0109000304B0040000[\r\n]+14443B REQB.[\r\n]+\[(?<tag>\w+)\]([\r\n]+\[\]){15}");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.raise_new_message(strPro, tag);
                }
                buffer.Replace(m.Value, "");
            }
            strPro = "15693协议";
            mc = Regex.Matches(currentData, @"010B000304142401000000[\r\n]+ISO 15693 Inventory request.[\r\n]+\[,\w+\]");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010B000304142401000000[\r\n]+ISO 15693 Inventory request.[\r\n]+\[(?<tag>\w+),\w+\]");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.raise_new_message(strPro, tag);
                }
                buffer.Replace(m.Value, "");
            }

            //清楚无用信息，放置内存过大
            mc = Regex.Matches(currentData, @"010C00030410002101000000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010C00030410002101090000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010C000304100021010C0000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            buffer.Replace("\r\n\r\n", "");
        }
    }
}
