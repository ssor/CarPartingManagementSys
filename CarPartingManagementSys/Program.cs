using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarPartingManagementSys
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initialPara();

            Application.Run(new frmCarParting());
        }

        public static void initialPara()
        {
            object o1 = nsConfigDB.ConfigDB.getConfig("total_count");
            if (o1 != null)
            {
                staticClass.total_count = int.Parse(o1 as string);
            }
            object o2 = nsConfigDB.ConfigDB.getConfig("comport_name");
            if (o2 != null)
            {
                staticClass.comport_name = o2 as string;
            }
        }
    }
}
