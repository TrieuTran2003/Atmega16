using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;
using static System.Windows.Forms.LinkLabel;
namespace Giaodien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] pause = { "1200", "2400", "4800", "9600", "14400", "19200" };
        string[] time = { "0,5s", "1s", "1,5s", "2s", "2,5s", "3s", "3.5s", "4s", "4,5s", "5s" };
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lisnamecom = SerialPort.GetPortNames();
            comboBox2.Items.AddRange(pause);
            comboBox1.Items.AddRange(lisnamecom);


            GraphPane mypanne = zedGraphControl1.GraphPane;
            mypanne.Title.Text = "Biểu đồ nhiệt độ";
            mypanne.YAxis.Title.Text = "Nhiệt độ ";
            mypanne.XAxis.Title.Text = "Thời gian ";

            RollingPointPairList list1 = new RollingPointPairList(600000);

            LineItem duongline1 = mypanne.AddCurve("Nhiet do", list1, Color.Red, SymbolType.Circle);

            mypanne.XAxis.Scale.Min = 0;
            mypanne.XAxis.Scale.Max = 100;
            mypanne.XAxis.Scale.MinorStep = 1;
            mypanne.XAxis.Scale.MajorStep = 5;

            mypanne.YAxis.Scale.Min = 0;
            mypanne.YAxis.Scale.Max = 100;
            mypanne.YAxis.Scale.MinorStep = 1;
            mypanne.YAxis.Scale.MajorStep = 5;

            zedGraphControl1.AxisChange();
        }
        int tong = 0;

        public void draw(double line1)
        {
            LineItem duongline1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (duongline1 == null)
            {
                return;
            }
            IPointListEdit list1 = duongline1.Points as IPointListEdit;
            if (list1 == null)
            {
                return;
            }

            list1.Add(tong, line1);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            tong += 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn cổng COM", "Thông báo");
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tốc độ Baudrate", "Thông báo");
            }
            if (Port1.IsOpen == true)
            {
                Port1.Close();
                button1.Text = "Kết nối";
            }
            else if (Port1.IsOpen == false)
            {
                Port1.PortName = comboBox1.Text;
                Port1.BaudRate = int.Parse(comboBox2.Text);
                Port1.Open();
                button1.Text = "Ngắt kết nối";
            }
        }

        bool tb1 = true;
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (tb1 == true)
                {
                    Port1.Write("1");
                    button2.Text = "Off";
                    tb1 = false;
                }
                else
                {

                    Port1.Write("a");
                    button2.Text = "On";
                    tb1 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb2 = true;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb2 == true)
                {
                    Port1.Write("2");
                    button3.Text = "Off";
                    tb2 = false;
                }
                else
                {

                    Port1.Write("b");
                    button3.Text = "On";
                    tb2 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb3 = true;
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb3 == true)
                {
                    Port1.Write("3");
                    button4.Text = "Off";
                    tb3 = false;
                }
                else
                {

                    Port1.Write("c");
                    button4.Text = "On";
                    tb3 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb4 = true;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb4 == true)
                {
                    Port1.Write("4");
                    button5.Text = "Off";
                    tb4 = false;
                }
                else
                {

                    Port1.Write("d");
                    button5.Text = "On";
                    tb4 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb5 = true;
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb5 == true)
                {
                    Port1.Write("5");
                    button6.Text = "Off";
                    tb5 = false;
                }
                else
                {

                    Port1.Write("e");
                    button6.Text = "On";
                    tb5 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb6 = true;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb6 == true)
                {
                    Port1.Write("6");
                    button7.Text = "Off";
                    tb6 = false;
                }
                else
                {

                    Port1.Write("f");
                    button7.Text = "On";
                    tb6 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb7 = true;
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb7 == true)
                {
                    Port1.Write("7");
                    button8.Text = "Off";
                    tb7 = false;
                }
                else
                {

                    Port1.Write("g");
                    button8.Text = "On";
                    tb7 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool tb8 = true;
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb8 == true)
                {
                    Port1.Write("8");
                    button9.Text = "Off";
                    tb8 = false;
                }
                else
                {

                    Port1.Write("h");
                    button9.Text = "On";
                    tb8 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string data = "";
        private void Port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = Port1.ReadLine();
            data = data.Trim();
            if (data.Length > 0)
            {
                if (int.TryParse(data, out int result))
                {

                    Invoke(new MethodInvoker(() => listBox1.Items.Add(data)));
                    Invoke(new MethodInvoker(() => draw(Convert.ToDouble(data))));
                }

                else
                {
                    string kitu = data.Substring(0, 2);
                    Invoke(new MethodInvoker(() => listBox3.Items.Add(kitu)));

                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button11_Click(object sender, EventArgs e)
        {
            if(comboBox4.Text == "0,5s")
            {
                Port1.Write("z");
            }
            if (comboBox4.Text == "1s")
            {
                Port1.Write("x");
            }
            if (comboBox4.Text == "1,5s")
            {
                Port1.Write("v");
            }
            if (comboBox4.Text == "2s")
            {
                Port1.Write("n");
            }
            if (comboBox4.Text == "2,5s")
            {
                Port1.Write("m");
            }
            if (comboBox4.Text == "3s")
            {
                Port1.Write("r");
            }
            if (comboBox4.Text == "3,5s")
            {
                Port1.Write("t");
            }
            if (comboBox4.Text == "4s")
            {
                Port1.Write("u");
            }
            if (comboBox4.Text == "4,5s")
            {
                Port1.Write("j");
            }
            if (comboBox4.Text == "5s")
            {
                Port1.Write("k");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }     
    
}


