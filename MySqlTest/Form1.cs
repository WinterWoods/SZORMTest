using EntityInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZORM;

namespace MySqlTest
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
                    //info.Score=98.5f;
                    info.Money = 521.55;
                    info.SumMoney = 156456.645897m;
                    info.Birthday = DateTime.Now;
                    info.Sex = PersonSex.Boy;
                    info.Phote = File.ReadAllBytes("D:\\img018.jpg");
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
                foreach (var model in list)
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
                db.PersionInfo.LeftJoin(db.Org, (w, n) => w.Org_Key == n.Key&&n.Name.Contains("张三"));


                var list = db.PersionInfo.Where(w => w.Name.Contains("张")).ToList();

                foreach (var model in list)
                {
                    db.PersionInfo.Remove(model);
                }
                db.Save();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                SetText("开始");
                DateTime begin = DateTime.Now;
                for (int i = 0; i < 1000; i++)
                {
                    using (DB db = new DB())
                    {
                        PersionInfo info = new PersionInfo();
                        info.Name = "张三";
                        info.Age = 18;
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
                DateTime end = DateTime.Now;
                SetText((end - begin).Seconds.ToString());
            }));
        }
        private void SetText(string msg)
        {
            if (label1.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    label1.Text = msg;

                }));
            }
        }

        private void 线程测试2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                SetText1("开始");
                DateTime begin = DateTime.Now;
                using (DB db = new DB())
                {
                    for (int i = 0; i < 1000; i++)
                    {

                        PersionInfo info = new PersionInfo();
                        info.Name = "张三";
                        info.Age = 18;
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
                DateTime end = DateTime.Now;
                SetText1((end - begin).Seconds.ToString());
            }));
        }
        private void SetText1(string msg)
        {
            if (label2.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    label2.Text = msg;

                }));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                SetText3("开始");
                DateTime begin = DateTime.Now;

                for (int i = 0; i < 1000; i++)
                {
                    using (DB db = new DB())
                    {
                        db.PersionInfo.Where(w => w.Name.Contains("张")).Count();
                    }

                }
                DateTime end = DateTime.Now;
                SetText3((end - begin).Seconds.ToString());
            }));
        }
        private void SetText3(string msg)
        {
            if (label3.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    label3.Text = msg;

                }));
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                SetText4("开始");
                DateTime begin = DateTime.Now;
                using (DB db = new DB())
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        db.PersionInfo.Where(w => w.Name.Contains("张")).Count();
                    }

                }
                DateTime end = DateTime.Now;
                SetText4((end - begin).Seconds.ToString());
            }));
        }
        private void SetText4(string msg)
        {
            if (label4.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    label4.Text = msg;

                }));
            }
        }
    }
}
