using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        String textString;
        String textString2;
        ArrayList list = new ArrayList();
        ArrayList newlist = new ArrayList();


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textString = textBox1.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textChanger(textString);
            textString2 = null;
            list.Clear();
            newlist.Clear();


        }
        private void textChanger(String str)
        {
            var listStr = new List<String>();
            ArrayList listNum = new ArrayList();
            str = str + ' ' + ' ';
            int startind = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] == ' ')
                {
                    String strin = str.Substring(startind, i - 1 - startind);
                    list.Add(strin);
                    startind = i;
                }
                if (char.IsLetter(str[i - 1]) && (char.IsDigit(str[i]) || str[i] == '.'))
                {
                    String strin = str.Substring(startind, i - startind);
                    list.Add(strin);
                    startind = i;
                }
                if ((char.IsDigit(str[i - 1]) || str[i - 1] == '.') && char.IsLetter(str[i]))
                {
                    String strin = str.Substring(startind, i - startind);
                    list.Add(strin);
                    startind = i;
                }


            }
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    float num = float.Parse(list[i].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    listNum.Add(num.ToString());
                }
                catch
                {
                    listStr.Add(list[i].ToString());
                }

            }
            var sortedlistStr = listStr.OrderBy(x => x.Length).Reverse().ToList<string>();
            var sortedListDig = listNum.Cast<string>().OrderBy(item => float.Parse(item)).Reverse();
            var sortedListDigStr = sortedListDig.Cast<string>().ToList();
            int j = 0;
            int k = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (sortedlistStr.Contains(list[i]))
                {
                    newlist.Add(sortedlistStr[j] + ";");

                    j++;
                }
                if (sortedListDigStr.Contains(list[i]))
                {
                    newlist.Add(sortedListDigStr[k] + ";");

                    k++;
                }

            }
            label3.Text = String.Concat(newlist.ToArray());

        }
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.WriteLine("   {0}", obj + ";");
            Console.WriteLine();
        }




        MediaPlayer mediaPlayer = new MediaPlayer();
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            mediaPlayer.Open(new Uri(@"C:\sample-15s.wav"));
            //Thread myThread = new Thread(play_music);
            //myThread.Start();
        }
        private static void play_music()
        {
         MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\sample-15s.wav"));
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\sample-15s.wav");


        }
        private void button3_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mediaPlayer.Play();
        }
    }
}
