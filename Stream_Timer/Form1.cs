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

namespace Stream_Timer
{
    public partial class Form1 : Form
    {
        string filename = Directory.GetCurrentDirectory() + "/Stream_timer.txt";
        string times;
        string texts;

        int h;
        int m;
        int s;
        public Form1()
        {
            InitializeComponent();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохраниние файла";
            //sfd.DefaultExt = ".txt";
            sfd.Filter = "txt files (*.txt)|*.txt";
            sfd.FileName = "Stream_timer";
            sfd.AddExtension = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                toolStripTextBox1.Text = filename;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            times = maskedTextBox1.Text;
            texts = textBox1.Text;
            DateTime time = DateTime.Parse(times);
            h = Convert.ToInt32(time.Hour);
            m = Convert.ToInt32(time.Minute);
            s = Convert.ToInt32(time.Second);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            DateTime time = DateTime.Parse(times);
            DateTime localTime = DateTime.Now;


            s--;
            if (s < 1)
            {
                s = 59;
                m--;
            }
            if (m < 1)
            {
                m = 59;
                h--;
            }
            if (h < 0)
            {
                if (filename != "")
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw1 = new StreamWriter(filename);

                    sw1.WriteLine(textBox2.Text);

                    // sw.WriteLine("From the StreamWriter class");
                    //Close the file
                    sw1.Close();
                }
                timer1.Stop();
            }
            else
            {


                Console.WriteLine("Difference between {0} and {1} time: {2} : {3} hours",
                                  time.ToString(),
                                  localTime.ToString(),
                                  (time - localTime).Hours,
                                  (time - localTime).Minutes);

                if (filename != "")
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(filename);

                    sw.WriteLine(textBox1.Text + " " + h + ":" + m + ":" + s);

                    // sw.WriteLine("From the StreamWriter class");
                    //Close the file
                    sw.Close();
                }
            }
            label3.Text = "Осталось " + h + ":" + m + ":" + s;

            timer1.Start();
      }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = filename;
        }
    }
}
