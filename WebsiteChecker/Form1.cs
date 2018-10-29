using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteChecker
{
    public partial class Form1 : Form
    {
        public string[] URLs = new string[]
        {
            "http://www.google.de",
            "http://www.zeit.de",
            "http://www.youtube.de",
            "http://www.cnn.com",
            "http://www.wetter.de",
            "http://www.facebook.de",
            "http://www.netflix.de",
        };


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxUrls.Items.Clear();
            for (int i = 0; i < URLs.Length; i++)
            {
                string url = URLs[i];
                listBoxUrls.Items.Add(url + " ... wird gerade geprüft...");
                PrüfeSeiteUndAktualisiereListBoxAsync(url, i);
            }
        }

        private async Task PrüfeSeiteUndAktualisiereListBoxAsync(string url, int index)
        {

            long zeitdauer;
            string resultString = string.Empty;
            try
            {
                zeitdauer = await GetLoadingTimeForUrlAsync(url);
                resultString = url + $" wurde geladen in {zeitdauer} Millisekunden";
            }
            catch (Exception)
            {
                resultString = url + " konnte nicht geladen werden!";
            }

            listBoxUrls.Items[index] = resultString;
        }

        private async Task<long> GetLoadingTimeForUrlAsync(string url)
        { 
            Stopwatch watch = new Stopwatch();
            watch.Start();
            HttpClient client = new HttpClient();
            await client.GetStringAsync(url);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
