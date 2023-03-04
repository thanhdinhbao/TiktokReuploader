using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using System.Net;

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
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFile(wmplay, path);

        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                label1.Text += "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                textBox1.Text += "Percentage:" + percentage;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                textBox1.Text += "Completed";
            });
        }

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
    }
}