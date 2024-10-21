using FluentFTP;
using FluentFTP.GnuTLS;
using System.Diagnostics;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace PrintToBambu
{
    public partial class Form1 : Form
    {
        private MqttClient mqttClient;
        private string deviceId;

        public Form1()
        {
            InitializeComponent();
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            host.Text = "192.168.68.68";
            accessCode.Text = "e25bf7b6";
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Path.GetExtension(file).Equals(".gcode", StringComparison.OrdinalIgnoreCase))
                {
                    path.Text = file;
                }
            }
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            print();
        }

        void print()
        {
            uploadFile();
            sendMQTTPrintMessage();
        }

        bool RemoteCertificateValidationCallback(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        X509Certificate LocalCertificateSelectionCallback(object sender, string targetHost, X509CertificateCollection localCertificates, X509Certificate? remoteCertificate, string[] acceptableIssuers)
        {
            return null;
        }

        private void sendMQTTPrintMessage()
        {
            this.mqttClient = new MqttClient(host.Text, 8883, true, MqttSslProtocols.TLSv1_2, RemoteCertificateValidationCallback, null);
            var clientId = Guid.NewGuid().ToString();
            mqttClient.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            var result = mqttClient.Connect(clientId, "bblp", accessCode.Text);
            mqttClient.Subscribe(new string[] { "device/+/report" }, new byte[] { 2 });
        }

        private void Log(string message)
        {
            Debug.WriteLine(message);
            Invoke(new Action(() => {
                logTextBox.AppendText(message + "\r\n");
                ScrollToBottom(logTextBox);
            }));
        }

        private void LogInfo(string message)
        {
            Log(message);
        }

        private void LogError(string message)
        {
            Log(String.Format("ERROR: {0}", message));
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            LogInfo("Received MQTT message");
            var match = Regex.Match(e.Topic, "device/([^/]+)/report",RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                LogError(String.Format("Couldn't extract device id from topic '{0}'", e.Topic));
                mqttClient.Disconnect();
                return;
            }
            var deviceId = match.Groups[1].Value;
            LogInfo(String.Format("Device ID is {0}", deviceId));

            LogInfo("Publishing gcode_file request");
            var json = $$"""
            {
                "print": {
                    "sequence_id": "1",
                    "command": "gcode_file",
                    "param": "/mnt/sdcard/{{Path.GetFileName(path.Text)}}"
                }
            }
            """;
            var message = Encoding.UTF8.GetBytes(json);
            var topic = String.Format("device/{0}/request", deviceId);
            LogInfo(String.Format("Publishing to topic '{0}", topic));
            Log(json);
            mqttClient.Publish(topic, message, 0, false);

            LogInfo("Disconnect from MQTT broker");
            mqttClient.Disconnect();
        }

        void FtpLogCallback(FtpTraceLevel level, string message)
        {
            LogInfo(message);
        }

        private void uploadFile()
        {

            using (var client = new FtpClient(host.Text, "bblp", accessCode.Text))
            {
                client.Config.EncryptionMode = FtpEncryptionMode.Implicit;
                client.Config.SslProtocols = System.Security.Authentication.SslProtocols.Tls13;
                client.Config.ValidateAnyCertificate = true;
                client.Config.DataConnectionType = FtpDataConnectionType.AutoPassive;
                client.Config.CustomStream = typeof(GnuTlsStream);
                client.LegacyLogger = FtpLogCallback;
                try
                {
                    client.Connect();
                    var status = client.UploadFile(path.Text, Path.Combine("/", Path.GetFileName(path.Text)));
                    client.Disconnect();
                }
                catch (IOException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog.FileName;
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        internal static void ScrollToBottom(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
            richTextBox.SelectionStart = richTextBox.Text.Length;
        }
    }
}
