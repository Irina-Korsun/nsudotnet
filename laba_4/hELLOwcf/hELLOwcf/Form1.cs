using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace hELLOwcf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "READY";
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Uri address = new Uri("http://localhost:4000/IContract");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, endpoint);
            IContract channel = factory.CreateChannel();
       
            byte[] response = channel.Say("hello");
            //Console.WriteLine(response);
            // Console.ReadKey();
            using (Image image = Image.FromStream(new MemoryStream(response)))
            {
                image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
            }
        }
    }
}
