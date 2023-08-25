using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeteaseNameGenerator
{
    public partial class Form1 : Form
    {
        private string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            string hostName = Dns.GetHostName();
            SendInfo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HWIDGenerator generator = new HWIDGenerator();
            string hwid = generator.GetHWID();
            string ipAddress = new WebClient().DownloadString("https://api.ipify.org");
            MessageBox.Show("你的机器标识码（hwid）为:" + hwid + "\nIP地址为" + ipAddress,"hwid");
        }
        static async Task SendInfo()
        {
            HWIDGenerator generator = new HWIDGenerator();
            string hwid = generator.GetHWID();
            string ipAddress = new WebClient().DownloadString("https://api.ipify.org");

            string url = $"https://words.xiaojiang233.top/user.php?hwid={hwid}&ip={ipAddress}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int position1 = 1;
            int position2 = 2;
            int position3 = 3;

            string word1 = await GetWord(position1);
            string word2 = await GetWord(position2);
            string word3 = await GetWord(position3);

            string result = word1 + word2 + word3;

            textBox1.Text += Environment.NewLine + result;
        }
        static async Task<string> GetWord(int position)
        {
            string url = $"https://words.xiaojiang233.top/get_word.php?position={position}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return (await response.Content.ReadAsStringAsync()).Trim();
                }
                else
                {
                    return "词语获取失败";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            string word1 = GetRandomWordFromEmbeddedResource("1.txt");
            string word2 = GetRandomWordFromEmbeddedResource("2.txt");
            string word3 = GetRandomWordFromEmbeddedResource("3.txt");

            string result = word1 + word2 + word3;

            textBox1.Text += Environment.NewLine + result;





        }
        private string GetRandomWordFromEmbeddedResource(string resourceName)
        {
            Random random = new Random();

            string[] words = ReadEmbeddedResource(resourceName).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int randomIndex = random.Next(0, words.Length);
            return words[randomIndex];
        }
        private string ReadEmbeddedResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string fullResourceName = assembly.GetName().Name + "." + resourceName;

            using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }



    }

}
