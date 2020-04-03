using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;

namespace indexextract_cs {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string dev;
        string rel;
        string dl, rl;
        int Upcheck(string server) {
            try {
                DataSet c = new DataSet();
                c.ReadXml(server);
                rel = c.Tables[0].Rows[0].ItemArray[1].ToString();
                dev = c.Tables[0].Rows[0].ItemArray[2].ToString();
                rl = c.Tables[0].Rows[0].ItemArray[3].ToString();
                dl = c.Tables[0].Rows[0].ItemArray[4].ToString();
                Console.WriteLine(dev);
                Console.WriteLine(rel);
                Console.WriteLine(dl);
                Console.WriteLine(rl);
            } catch (Exception) {
                return 1;
            }
            return 0;
        }

        private struct ControlBool {
            public Control c;
            public bool b;

            public ControlBool(Control c, bool b) {
                this.c = c;
                this.b = b;
           }
        }
        private struct ControlStr {
            public Control c;
            public string s;

            public ControlStr(Control c, string s) {
                this.c = c;
                this.s = s;
            }
        }
        private void SetVisible(ControlBool cb) {
            cb.c.Visible = cb.b;
        }
        private delegate void ControlBoolD(ControlBool cb);
        private delegate void ControlStrD(ControlStr cs);
        private void ManageComponent(ControlBool cb) {
            if (cb.b)
                this.Controls.Add(cb.c);
            else
                this.Controls.Remove(cb.c);
        }
        private delegate void VoidDelegate();

        private void AsyncUpCheck() {
            string vvr;
            Upcheck("https://raw.githubusercontent.com/dhkim0800/indexextract/master/uc.xml");
            vvr = rel;
            if (this.Text.Contains("b"))
                vvr = dev;
            ControlBoolD svd = new ControlBoolD(SetVisible);
            try {
                if (vvr != Text) {
                    Invoke(svd, new ControlBool(Label13, true));
                    Invoke(svd, new ControlBool(Button7, true));
                } else {
                    Invoke(svd, new ControlBool(Label13, false));
                    Invoke(svd, new ControlBool(Button7, false));
                }
            } catch (Exception ex) when (ex is InvalidOperationException) {
                Application.Exit();
            }
        }

        private void Dotdotdot_Tick(object sender, EventArgs e) {
            if (Label3.Text.Length < 8) {
                Label3.Text += ".";
            } else {
                Label3.Text = "";
            }
        }

        private string appPath = "";

        private void Form1_Load(object sender, EventArgs e) {
            this.Show();

            if (System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName != "ko") {
                Button3.Visible = false;
                Button4.Visible = false;
            }
            int a = Screen.PrimaryScreen.Bounds.Width / 2;
            int b = Screen.PrimaryScreen.Bounds.Height / 2;
            this.Top = b - this.Height / 2;
            this.Left = a - this.Width / 2;
            OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.minecraft/assets/indexes";
            // 설정파일 처음 세팅
            appPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/indexextract";
            if (!FileSystem.FileExists(appPath + "/lang.set")) {
                FileSystem.CreateDirectory(appPath);
                FileSystem.WriteAllText(appPath + "/lang.set", "lang=EN_US", false);
            }
            //설정 파일 불러오기
            string se = FileSystem.ReadAllText(appPath + "/lang.set");
            string lang = "";
            try {
                lang = Strings.Split(se, "lang=")[1];
            } catch (IndexOutOfRangeException) {
                //todo button 3 click
            }
            if (lang == "EN_US") {
                Button3_Click(sender, e);
            } else if (lang == "KO_KR") {
                Button4_Click(sender, e);
            } else {
                FileSystem.DeleteFile(appPath + "/lang.set");
                Application.Restart();
            }
            this.MaximizeBox = false;

            Thread t = new Thread(AsyncUpCheck);
            t.Priority = ThreadPriority.Lowest;
            t.Start();

            if (lang == "ko") {
                Label4.Text = "대기";
            } else if (lang == "en") {
                Label4.Text = "Wait";
            }
        }

        private void Button4_Click(object sender, EventArgs e) {
            Label3.Visible = true;
            Label4.Font = new Font("맑은 고딕", 14.25f);
            Button5.Font = new Font("맑은 고딕", 18);
            Button2.Text = "찾아보기";
            Button1.Text = "시작";

            Button5.Text = "폴더 열기";
            lang = "ko";
            FileSystem.WriteAllText(appPath + "/lang.set", "lang=KO_KR", false);

            Label9.Text = "I/O 오류";
            Label9.Font = new Font("맑은 고딕", 8.5f, FontStyle.Regular);
            Label6.Text = "파일 중복";
            Label9.Font = new Font("맑은 고딕", 8, FontStyle.Regular);

            Label2.Font = new Font("맑은 고딕", 12, FontStyle.Regular);
            Label2.Text = "진행률: ";

            Label3.Visible = false;
            Label4.Text = "대기";

            Label13.Text = "업데이트가 존재합니다.";
            Button7.Text = "업데이트";
        }

        private void Button3_Click(object sender, EventArgs e) {
            Label3.Visible = true;
            Label4.Font = new Font("Segoe UI", 14.25f);
            Button5.Font = new Font("Segoe UI", 18);
            Button2.Text = "Browse";
            Button5.Text = "Open folder";
            Button1.Text = "Start";
            lang = "en";
            FileSystem.WriteAllText(appPath + "/lang.set", "lang=EN_US", false);

            Label9.Text = "I/O Error";
            Label9.Font = new Font("Segoe UI", 12.5f, FontStyle.Regular);
            Label6.Text = "Duplicated file";
            Label6.Font = new Font("Segoe UI", 10.3f, FontStyle.Regular);

            Label2.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            Label2.Text = "Progress: ";

            Label3.Visible = false;
            Label4.Text = "Wait";

            Label13.Text = "An update available.";
            Button7.Text = "Update";
        }

        private static string lang;
        public static string GetLanguage() {
            return lang;
        }
        private static void SetLanguage(string newlang) {
            lang = newlang;
        }

        private WorkData WorkDataObj;
        private string ad = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\";
        private int ale;
        private int abcd;
        private int i;
        private int index;
        private int b;
        private int ncp;

        private void Button1_Click(object sender, EventArgs e) {
            if (lang == "ko")
                Label4.Text = "준비 중";
            else if (lang == "en")
                Label4.Text = "Preparing";

            BrowserResult br = new BrowserResult();
            try {
                br = Form2.GetResult();
            } catch (NullReferenceException) {
                MessageBox.Show("ERR_FILE_NOT_SELECTED", "Indexextract", MessageBoxButtons.OK);
                return;
            }
            abcd = Strings.Split(br.file, "\\").Length - 1;
            Label7.Text = "0";
            Label8.Text = "0";
            ProgressBar1.Value = 0;
            i = 0;
            index = 3;
            ale = 0;
            ncp = 0;
            Label4.Visible = true;
            Label3.Visible = true;
            Label1.Visible = true;
            Button2.Enabled = false;
            Button1.Enabled = false;
            Button5.Enabled = false;
            if (lang == "ko")
                Label4.Text = "작업 중";
            else if (lang == "en")
                Label4.Text = "Working";

            string fullt = FileSystem.ReadAllText(br.file);
            b = Strings.Split(fullt, "hash").Length - 1;
            WorkDataObj = new WorkData() {
                dataJson = Strings.Split(fullt, "\""),
                targetPath = $"{Application.StartupPath}\\indexextract\\{Strings.Split(Strings.Split(br.file, "\\")[abcd], ".json")[0]}"
            };

            Thread t = new Thread(WorkThread);
            t.Name = "Indexextract worker";
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }
        private void WorkThread() {
            VoidDelegate vd = new VoidDelegate(RefreshIndexTexts);
            ControlStrD cd = new ControlStrD(SetControlIntTxt);
            while (true) {
                for (int t = 1; t <= 50; t++) {
                    i++;
                    string file;
                    string hash;
                    try {
                        file = WorkDataObj.dataJson[index];
                        hash = WorkDataObj.dataJson[index + 4];
                        index += 8;
                    } catch (IndexOutOfRangeException) {
                        Invoke(vd);
                        VoidDelegate ed = new VoidDelegate(WorkEnd);
                        Invoke(ed);
                        return;
                    }
                    string sourceFile = ad + "assets\\objects\\" + Strings.Left(hash, 2) + "\\" + hash;
                    string targetFile = WorkDataObj.targetPath + "\\" + file;
                    if (FileSystem.FileExists(targetFile)) {
                        ale++;
                        Invoke(cd, new ControlStr(Label7, ale.ToString()));
                        continue;
                    }
                    try {
                        FileSystem.CopyFile(sourceFile, targetFile);
                    } catch (FileNotFoundException) {
                        ncp++;
                        Invoke(cd, new ControlStr(Label8, ncp.ToString()));
                    }
                }
                Invoke(vd);
            }
        }
        private void RefreshIndexTexts() {
            int pc = 0;
            if (b != 0) pc = i * 100 / b;
            ProgressBar1.Value = pc * 100;
            Label1.Text = pc + "%";
        }
        private void SetControlIntTxt(ControlStr cb) {
            cb.c.Text = cb.s;
        }

        private void WorkEnd() {
            //작업 완료후 코드
            //WorkDataObj = new WorkData(); 사용 금지!

            //버튼 활성화
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Label3.Visible = false;
            Label1.Visible = false;
            ale = 0;
            ncp = 0;
            Label1.Text = "";
            if (lang == "ko")
                Label4.Text = "대기 중";
            else if (lang == "en")
                Label4.Text = "Ready";

        }

        private void Button2_Click(object sender, EventArgs e) {
            Form2 f2 = new Form2();
            if (lang == "ko") {
                OpenFileDialog1.Title = "파일 찾아보기";
                f2.Label3.Text = "파일 선택 안함.";
            } else if (lang == "en") {
                OpenFileDialog1.Title = "Browse file";
                f2.Label3.Text = "No file selected";
            }
            f2.SafeShow(OpenFileDialog1);
            f2.ShowDialog();
            Console.WriteLine("closed");
            if (Form2.GetResult().cancel) {
                Console.WriteLine("canceled");
                return;
            }

            Console.WriteLine("enabled");
            Button1.Enabled = true;
            f2.ComboBox1.Text = "";
        }

        private void Button5_Click(object sender, EventArgs e) {
            try {
                Console.WriteLine(WorkDataObj.targetPath);
                Process.Start(WorkDataObj.targetPath);
            } catch (Exception ex) when (ex is DirectoryNotFoundException || ex is FileNotFoundException || ex is Win32Exception) {
                string emsg = "";
                if (lang == "ko")
                    emsg = "폴더를 열 수 없습니다. 나중에 다시 시도하세요.";
                else if (lang == "en")
                    emsg = "Could not open folder. Please try again later.";
                MessageBox.Show(emsg, "Indexextract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
