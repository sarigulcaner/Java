using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SimpleClientWordProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Clear text data on GUI
            richTxtLongFile.Text = "";
            richTxtShortFile.Text = "";

            // Create address query
            var query = urlTextBox.Text;
            if (!String.IsNullOrEmpty(Path.Text))
            {
                query += "?path=" + Path.Text;
            }
            var client = new RestClient(query);
            // insantiate request
            // Send request
            var json = client.MakeRequest();
            if (json.Contains("Exception"))
                return;
            // get json data and deserialize
            FileWrapper JsonDe = (FileWrapper)JsonConvert.DeserializeObject(json, typeof(FileWrapper));

            // Business requirement generate output text for long files
            if (JsonDe.longfiles != null && JsonDe.longfiles.Count > 0)
            {
                int direcToryNo = 1;
                FileInfo info = new FileInfo(JsonDe.longfiles[0].getLocation());
                var parent = info.Directory.Parent;
                richTxtLongFile.Text += "<" + parent.FullName + ">";
                var parentLonglast = "";
                foreach (var longfile in JsonDe.longfiles)
                {
                    var lastLocation = new FileInfo(longfile.getLocation()).Directory.Parent;
                    parent = info.Directory.Parent;

                    richTxtLongFile.Text += Environment.NewLine;
                    parentLonglast = lastLocation.Name;
                    if (parentLonglast != parent.FullName)
                    {
                        direcToryNo++;
                    }
                    for (int i = 0; i < direcToryNo; i++)
                    {
                        richTxtLongFile.Text += '\t';
                    }
                    richTxtLongFile.Text += " <" + longfile.getName() + ">" + "<" + longfile.getwordcount() +">";
                    foreach (var word in longfile.mostusedwords)
                    {
                        richTxtLongFile.Text += "<" + word.word + " " + word.count + ">";
                    }

                }
            }
            // Business requirement generate output text for short files

            if (JsonDe.shortfiles != null && JsonDe.shortfiles.Count > 0)
            {
               var directoryNo = 1;
               var info = new FileInfo(JsonDe.shortfiles[0].getLocation());
               var parent = info.Directory.Parent;
                richTxtShortFile.Text += "<" + parent.FullName + ">";
                var parentShortlast = "";

                foreach (var shortFile in JsonDe.shortfiles)
                {
                    var lastLocation = new FileInfo(shortFile.getLocation()).Directory.Parent;
                    parent = info.Directory.Parent;

                    richTxtShortFile.Text += Environment.NewLine;
                    parentShortlast = lastLocation.Name;
                    if (parentShortlast != parent.FullName)
                    {
                        directoryNo++;
                    }
                    for (int i = 0; i < directoryNo; i++)
                    {
                        richTxtShortFile.Text += '\t';
                    }
                    richTxtShortFile.Text += "<" + shortFile.getName() + ">" + "<" + shortFile.getwordcount() + ">";
                    foreach (var word in shortFile.mostusedwords)
                    {
                        richTxtShortFile.Text += "<" + word.word + " " + word.count + ">";
                    }

                }
            }
            
        }
    }
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
        }


        public string MakeRequest()
        {
            return MakeRequest("");
        }

        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }

    }
}
