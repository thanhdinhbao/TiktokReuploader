using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.RegularExpressions;

namespace TiktokRender
{
    public partial class fMain : Form
    {
        public fMain()
        {
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public string path;

        #region ClassRespone

        public class Author
        {
            public string id { get; set; }
            public string unique_id { get; set; }
            public string nickname { get; set; }
            public string avatar { get; set; }
        }

        public class Data
        {
            public List<Video> videos { get; set; }
            public string cursor { get; set; }
            public bool hasMore { get; set; }
        }

        public class MusicInfo
        {
            public string id { get; set; }
            public string title { get; set; }
            public string play { get; set; }
            public string cover { get; set; }
            public string author { get; set; }
            public bool original { get; set; }
            public int duration { get; set; }
            public string album { get; set; }
        }

        public class Root
        {
            public int code { get; set; }
            public string msg { get; set; }
            public double processed_time { get; set; }
            public Data data { get; set; }
        }

        public class Video
        {
            public string video_id { get; set; }
            public string region { get; set; }
            public string title { get; set; }
            public string cover { get; set; }
            public string origin_cover { get; set; }
            public int duration { get; set; }
            public string play { get; set; }
            public string wmplay { get; set; }
            public int size { get; set; }
            public int wm_size { get; set; }
            public string music { get; set; }
            public MusicInfo music_info { get; set; }
            public int play_count { get; set; }
            public int digg_count { get; set; }
            public int comment_count { get; set; }
            public int share_count { get; set; }
            public int download_count { get; set; }
            public int create_time { get; set; }
            public Author author { get; set; }
            public int is_top { get; set; }
        }

        #endregion

        public class Root_Xbogus
        {
            [JsonProperty("X-Bogus")]
            public string XBogus { get; set; }
            public string param { get; set; }
        }

        #region DownloadVideo
        async void CallAPI(string cursor)
        {
            dtVideo.Rows.Clear();
            dtVideo.Refresh();
            string user_id = txtUsername.Text.Trim();
            string url = "https://www.tikwm.com/api/user/posts?unique_id=" + user_id + "&count=35&cursor=" + cursor;
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            var json = response.Content;
            Root parse_json = JsonConvert.DeserializeObject<Root>(json);

            int respone_code = parse_json.code;


            if (respone_code == 0)
            {
                bool hasMore = parse_json.data.hasMore;
                var currentDirectory = Directory.GetCurrentDirectory();
                string path_user = parse_json.data.videos[0].author.unique_id;
                path = currentDirectory + "\\" + path_user + "\\";

                try
                {
                    for (int i = 0; i < parse_json.data.videos.Count + 1; i++)
                    {

                        dtVideo.Rows.Add(false, parse_json.data.videos[i].video_id, parse_json.data.videos[i].title, parse_json.data.videos[i].duration + " s", (parse_json.data.videos[i].size / 1000 + " kB"), parse_json.data.videos[i].play);
                    }
                }
                catch (Exception)
                {

                }
                Thread.Sleep(1000);

                while (hasMore == true)
                {
                    Thread.Sleep(10000);
                    CallAPI(parse_json.data.cursor);
                    break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng thử lại sau 10s!");
            }


        }

        private void btnGetVideo_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập username!");
            }
            else
            {
                Thread thread = new Thread(() =>
                {
                    CallAPI("");
                });
                thread.Start();
            }
        }

        void DownloadVideo(string wmplay, string path)
        {
            var client = new WebClient();
            //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            //client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFile(wmplay, path);

        }

        //void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    this.BeginInvoke((MethodInvoker)delegate
        //    {
        //        double bytesIn = double.Parse(e.BytesReceived.ToString());
        //        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        //        double percentage = bytesIn / totalBytes * 100;
        //        label1.Text += "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
        //        textBox1.Text += "Percentage:" + percentage;
        //        progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        //    });
        //}
        //void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //    this.BeginInvoke((MethodInvoker)delegate
        //    {
        //        textBox1.Text += "Completed";
        //    });
        //}

        private void dtVideo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtVideo.Rows[e.RowIndex].Cells[0].Value = true;
            }

            dtVideo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnDownVideo_Click(object sender, EventArgs e)
        {
            int rowindex = dtVideo.CurrentCell.RowIndex;
            string url = dtVideo.Rows[rowindex].Cells[5].Value.ToString();
            string id = dtVideo.Rows[rowindex].Cells[1].Value.ToString();
            string path_to_save = path + id + ".mp4";
            bool check = (bool)dtVideo.Rows[rowindex].Cells[0].Value;

            if (!File.Exists(path_to_save))
            {
                if (check == true)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    DownloadVideo(url, path_to_save);

                    MessageBox.Show("Down video thành công");
                }
                else
                {
                    MessageBox.Show("Chọn video để tải!!");
                }
            }
            else
            {
                MessageBox.Show("Đã tải video!");
            }

        }

        private void dtVideo_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = dtVideo.CurrentCell.RowIndex;
            dtVideo.Rows[rowindex].Cells[0].Value = false;

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            //string videoFile = @"D:\vs\TiktokRender\TiktokRender\bin\Debug\net6.0-windows\thanhdinhbao\7198939748382067995.mp4 ";
            //string outputFile = @"D:\vs\TiktokRender\TiktokRender\bin\Debug\net6.0-windows\thanhdinhbao\final.avi";


            string path = @"D:\vs\TiktokRender\TiktokRender\bin\Debug\net6.0-windows\thanhdinhbao\test.mp4";
            string outputpath = @"D:\vs\TiktokRender\TiktokRender\bin\Debug\net6.0-windows\thanhdinhbao\final.mp4";
            string fileargs = String.Format("-i {0} -ss 00:01:00 -codec copy -t 60 {1}", path, outputpath);



            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"D:\vs\TiktokRender\TiktokRender\bin\Debug\net6.0-windows\ffmpeg.exe";
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();


            p.WaitForExit();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string pattern_channel = @"[A-Za-z]+://([A-Za-z]+(\.[A-Za-z]+)+)/@[A-Za-z]+";
            string pattern_video = @"[A-Za-z]+://([A-Za-z]+(\.[A-Za-z]+)+)/@([A-Za-z0-9]+(/[A-Za-z0-9]+)+)";
            //string pattern = @"[A-Za-z0-9]+://([A-Za-z]+(\.[A-Za-z]+)+)/[A-Za-z0-9]+/";

            Regex rg = new Regex(pattern_channel);
            string sharelink = textBox1.Text;
            //Match matched = rg.Match(sharelink);
            Match matched = rg.Match(sharelink);
            if (matched.Success)
            {
                MessageBox.Show("Channel link");
            }
            else
            {
                MessageBox.Show("Video link");
            }


        }

        void Generate_msToken()
        {
            string ran_string = "";
            Random ran = new Random();

        }

        async void Post_XBogus(string original_video, string id)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://tiktok.iculture.cc/X-Bogus", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "acw_tc=2760826716781531833418589e07e7428eee6a29190264da94cbedf0cbd2c6");

            string head = "{\"url\":";
            string tail = ",\"user_agent\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36\"}";

            var raw_body = head + original_video + tail;

            request.AddStringBody(raw_body, DataFormat.Json);

            RestResponse response = await client.ExecuteAsync(request);
            var json = response.Content;
            Root_Xbogus parsed_json = JsonConvert.DeserializeObject<Root_Xbogus>(json);
            string xbogus_link = parsed_json.param;


            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string pattern_video = @"[A-Za-z]+://([A-Za-z0-9]+(\.[A-Za-z0-9]+)+)/[A-Za-z0-9]+/";
            Regex reg = new Regex(pattern_video);
            Match rs = reg.Match(textBox1.Text);
            string v_link = rs.Value;

            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.38 (KHTML, like Gecko) Version/11.0 Mobile/15A372 Safari/604.1",
            };
            var client = new RestClient(options);
            var request = new RestRequest(v_link, Method.Get);
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("Cookie", "__ac_nonce=06405b6f1001c6f5b3beb");
            RestResponse response = await client.ExecuteAsync(request);
            Uri fullUrl = response.ResponseUri;

            //Regex to specify id video from share video links
            string regex_id = @"\d+";
            Regex rg = new Regex(regex_id);
            Match matched = rg.Match(fullUrl.ToString());
            string id = matched.Value;
            MessageBox.Show(id);

            string sq = @"""";
            string original_video = sq + "https://www.douyin.com/aweme/v1/web/aweme/detail/?aweme_id=" + id + "&aid=1128&version_name=23.5.0&device_platform=android&os_version=2333" + sq;

            Post_XBogus(original_video, id);

        }


    }
}