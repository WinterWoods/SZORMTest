using EntityInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SZORM;

namespace OracleTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (DB db = new DB())
                {
                    PersionInfo info = new PersionInfo();
                    info.Name = "张三";
                    info.Age = 18;
                    info.IsBegin = true;
                    //info.Score=98.5f;
                    info.Money = 521.55;
                    info.SumMoney = 156456.645897m;
                    info.Birthday = DateTime.Now;
                    info.Sex = PersonSex.Boy;
                    //info.Phote = File.ReadAllBytes("D:\\img018.jpg");
                    db.PersionInfo.Add(info);
                    db.Save();
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DB db = new DB())
            {
                var list = db.PersionInfo.Where(w => w.Name.Contains("张")).ToList();
                foreach(var model in list)
                {
                    File.WriteAllBytes("D:\\" + model.Name + ".jpg", model.Phote);
                }
                db.Save();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DB db = new DB())
            {
                var list = db.PersionInfo.Where(w => w.Name.Contains("张")).ToList();
                foreach (var model in list)
                {
                    model.Name = "张四";
                    db.PersionInfo.Edit(model);
                }
                db.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (DB db = new DB())
            {
                var list = db.PersionInfo.Where(w => w.Name.Contains("张")).ToList();
                foreach (var model in list)
                {
                    db.PersionInfo.Remove(model);
                }
                db.Save();
            }
        }
    }
}
