using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientDemo
{
    public partial class Form1 : Form
    {
        public struct HardParam
        {
            public int id;
            public string YID;
            public string Phone;
            public string CarID;
            public string Community;
            public DateTime StarTime;
            public DateTime EndTime;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HardParam hp = new HardParam();

                hp.YID = this.tbYID.Text;
                hp.Phone = this.tbPhone.Text;
                hp.CarID = this.tbCard.Text;
                hp.Community = this.tbCommunity.Text;
                hp.StarTime = DateTime.Now;

                this.toolStripStatusLabel1.Text = "正在提交...";
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                string message = hp.YID+','+hp.Phone+','+hp.CarID+','+hp.Community+','+hp.StarTime.ToString();

                Int32 port = int.Parse(this.textBox3.Text);
                string host = string.Empty;

                if (rbDns.Checked)
                    host = Dns.GetHostAddresses(tbDns.Text)[0].ToString();

                if (rbIP.Checked)
                    host = tbIP.Text;

                TcpClient client = new TcpClient(host, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
                this.toolStripStatusLabel1.Text = "提交成功!";
            }
            catch (ArgumentNullException ex)
            {
                //Console.WriteLine("ArgumentNullException: {0}", ex);
            }
            catch (SocketException ex)
            {
                this.toolStripStatusLabel1.Text = "提交失败!";
                //Console.WriteLine("SocketException: {0}", ex);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                this.tbDns.Enabled = true;
                this.tbIP.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                this.tbIP.Enabled = true;
                this.tbDns.Enabled = false;
            }
        }
    }
}
