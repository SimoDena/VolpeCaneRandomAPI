using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolpeCaneRandomAPI
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("appliication/json"));

        }

        private async void btmVolpe_Click(object sender, EventArgs e)
        {
            string url = "https://randomfox.ca/floof/";

            HttpResponseMessage risposta = await client.GetAsync(url);

            if (risposta.IsSuccessStatusCode)
            {
                ImmagineVolpe immagine = await risposta.Content.ReadAsAsync<ImmagineVolpe>();
                pictureBox1.ImageLocation = immagine.Image;
            }
            else
            {
                pictureBox1.ImageLocation = "https://upload.wikimedia.org/wikipedia/commons/f/f0/Error.svg";
            }
        }

        private async void btnCane_Click(object sender, EventArgs e)
        {
            string url = "https://random.dog/woof.json";

            HttpResponseMessage risposta = await client.GetAsync(url);

            if (risposta.IsSuccessStatusCode)
            {
                ImmagineCane immagine = await risposta.Content.ReadAsAsync<ImmagineCane>();
                pictureBox1.ImageLocation = immagine.Url;
            }
            else
            {
                pictureBox1.ImageLocation = "https://upload.wikimedia.org/wikipedia/commons/f/f0/Error.svg";
            }
        }
    }
}
