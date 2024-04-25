using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpIP_Client
{
    public partial class Form1 : Form
    {
        private TcpClient m_client;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Create Tcp client.
                int nPort = 13000;
                m_client = new TcpClient("127.0.0.1", nPort);
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException:{0}", a);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException:{0}", ex);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(txtData.Text); // Convert string to byte array.
            try
            {
                NetworkStream stream = m_client.GetStream();
                stream.Write(btData, 0, btData.Length); // Write data to server.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Write Exception:{0}", ex);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            m_client.Close();
        }
    }
}
