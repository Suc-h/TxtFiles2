using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;

namespace knihy
{
    public partial class Knihy : Form
    {
        public Knihy()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string finder = textBox1.Text;
            bool prvni = true;
            
            StreamReader ctenar = new StreamReader("knihy.txt", Encoding.GetEncoding("UTF-8")); //VS 2022 nešelo dát windows 1250 ani 1252
            StreamWriter zapisovac1 = new StreamWriter("text.txt", true, Encoding.GetEncoding("UTF-8"));
            StreamWriter zapisovac2 = new StreamWriter("text2.txt", true, Encoding.GetEncoding("UTF-8"));

            while (!ctenar.EndOfStream)
            {
                string row = ctenar.ReadLine();
                if (row != "")
                {
                    listBox1.Items.Add(row);
                    string[] split = row.Split(';');
                    if (split[1] == finder && prvni)
                    {
                        label1.Text = row;
                        prvni = false;
                    }
                    if (Convert.ToInt32(split[4]) > 1950)
                    {
                        zapisovac1.WriteLine(row);
                    }
                    else
                    {
                        zapisovac2.WriteLine(row);
                    }
                }
            }
           
            ctenar.Close();
            zapisovac1.Close();
            zapisovac2.Close();
            label2.Text = "Jsem hotov!";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("text.txt", String.Empty);
            File.WriteAllText("text2.txt", String.Empty);
            label1.Text = "";
            label2.Text = "";
            textBox1.Text = "";
            listBox1.Items.Clear();
        }
    }
}