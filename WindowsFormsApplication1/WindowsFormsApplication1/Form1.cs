using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //private Boolean Timer = false;
        private int Seconds = 39;
        private int MilliSeconds = 43;
        public Form1()
        {
            
            InitializeComponent();
            //CheckFile();
          
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FileTimer_Elapsed(object sender, EventArgs arg)
        {
            string filePath = @"./BombData.txt";
            String line = "";
            string[] words;
          
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        // Read the stream to a string, and write the string to the console.
                        line = sr.ReadToEnd();
                        //Console.WriteLine(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }


                words = line.Split('"');

                foreach (string s in words)
                {
                    if (s.Equals("planted"))
                    {
                        MilliTimer.Enabled = true; 
                        panel1.BackColor = Color.Orange;
                        label1.Text = "Planted";
                    break;
                     }
                   else if (s.Equals("freezetime"))
                    {
                    Seconds = 39;
                    MilliSeconds = 43;
                    MilliTimer.Enabled = false;
                    panel1.BackColor = Color.Green;
                    label1.Text = "Safe";
                    
                    break;
                    }
                    else if (s.Equals("defused"))
                   {
                    MilliTimer.Enabled = false;
                    panel1.BackColor = Color.Orange;
                    label1.Text = "Planted";
                    break;
                    }   
            }
               // System.Threading.Thread.Sleep(200);
        }

        public void TimerDisplay(object sender, EventArgs arg)
        {
            MilliSeconds--;
            if (MilliSeconds == 0)
            {
                Seconds--;
                MilliSeconds = 65;
            }
                

            if (Seconds <= 10 && Seconds > 5)
            {
                panel1.BackColor = Color.Yellow;
                label1.Text = "Run!!!";
            }
            else if (Seconds <= 5 && Seconds > 0)
            {
                panel1.BackColor = Color.Red;
                label1.Text = "Run!!!";
            }

            if (Seconds == 0)
            {
                MilliTimer.Enabled = false;
                panel1.BackColor = Color.Green;
                label1.Text = "Safe";
                Seconds = 39;
                MilliSeconds = 63;
    }

            label2.Text = Seconds.ToString();
            
            Application.DoEvents();
            label4.Text = MilliSeconds.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            //Console.WriteLine(Seconds);
        }
    }
}
