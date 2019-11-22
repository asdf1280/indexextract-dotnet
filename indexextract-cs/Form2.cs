using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;

namespace indexextract_cs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string[] sp = { "legacy.json", "1.7.10.json", "1.8.json", "1.9.json", "1.9-aprilfools.json", "1.10.json", "1.11.json", "1.12.json", "1.13.json", "1.13.1.json", "1.14.json", "1.14-af.json", "1.15.json", "pre-1.6.json" };
        public void Fds()
        {
            ComboBox1.Items.Clear();
            foreach (string foundFile in FileSystem.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\assets\\indexes"))
            {
                string[] its = Strings.Split(foundFile, "\\");
                string it = its[its.Length - 1];
                if (Array.IndexOf(sp, it) != -1)
                    ComboBox1.Items.Add(it);
            }
        }
        private OpenFileDialog OpenFileDialog;
        internal void SafeShow(OpenFileDialog openFileDialog)
        {
            OpenFileDialog = openFileDialog;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var fi = OpenFileDialog.ShowDialog();
            if (fi == DialogResult.Cancel)
                return;
            else if (fi == DialogResult.OK)
            {
                int lastIdx;
                string[] fns = Strings.Split(OpenFileDialog.FileName, "\\");
                lastIdx = fns.Length - 1;
                if (Array.IndexOf(sp, fns[lastIdx]) == -1)
                {
                    DialogResult? ad = null;
                    Console.Beep();
                    if (lang == "ko")
                    {
                        ad = MessageBox.Show("지정된 파일만 열 수 있습니다.\n허가된 파일 목록을 확인하려면 '확인'을 클릭하십시오.", "Indexextract", MessageBoxButtons.OKCancel);
                    }
                    else if (lang == "en")
                    {
                        ad = MessageBox.Show("Incompatible version. Press OK to see list of compatible versions.", "Indexextract", MessageBoxButtons.OKCancel);
                    }
                    if (ad == DialogResult.OK)
                    {
                        Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84");
                    }
                }
                else
                    Label3.Text = OpenFileDialog.FileName;
            }
        }
        public string lang;
        private void Form2_Load(object sender, EventArgs e)
        {
            lang = Form1.GetLanguage();
            ComboBox1.Items.Clear();
            int a = Screen.PrimaryScreen.Bounds.Width / 2;
            int b = Screen.PrimaryScreen.Bounds.Height / 2;
            this.Top = b - this.Height / 2;
            this.Left = a - this.Width / 2;
            Fds();
            if (lang == "ko")
            {
                Text = "찾아보기";
                Button1.Text = "파일에서 찾아보기";
                GroupBox1.Text = "파일 찾아보기";
                GroupBox2.Text = "목록에서 선택";
                Button2.Text = "목록 새로고침";
                GroupBox4.Text = "선택됨";
                Button4.Text = "취소";
                Button3.Text = "확인";
                if (Label3.Text == "No file selected")
                    Label3.Text = "파일 선택 안함";
            }
            else if (lang == "en")
            {
                Text = "Browse";
                Button1.Text = "Browse file";
                GroupBox1.Text = "Browse file";
                GroupBox2.Text = "Indexes list";
                Button2.Text = "Reload list";
                GroupBox4.Text = "Selected : ";
                Button4.Text = "Cancel";
                Button3.Text = "Confirm";
                if (Label3.Text == "파일 선택 안함")
                    Label3.Text = "No file selected";
            }
        }

        private static BrowserResult result = new BrowserResult();
        internal static BrowserResult GetResult()
        {
            return result;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Label3.Text == "No file selected" || Label3.Text == "파일 선택 안함")
            {
                if (lang == "ko")
                    MessageBox.Show("파일을 선택하지 않았습니다.", "Indexextract", MessageBoxButtons.OK);
                else if (lang == "en")
                    MessageBox.Show("You didn't select any file.", "Indexextract", MessageBoxButtons.OK);
                return;
            }
            result = new BrowserResult(false, Label3.Text);
            Close();
            Dispose();
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string fn = ComboBox1.Text;
            if (Array.IndexOf(sp, fn) == -1)
            {
                DialogResult? ad = null;
                Console.Beep();
                if (lang == "ko")
                {
                    ad = MessageBox.Show("지정된 파일만 열 수 있습니다.\n허가된 파일 목록을 확인하려면 '확인'을 클릭하십시오.", "Indexextract", MessageBoxButtons.OKCancel);
                }
                else if (lang == "en")
                {
                    ad = MessageBox.Show("Incompatible version. Press OK to see list of compatible versions.", "Indexextract", MessageBoxButtons.OKCancel);
                }
                if (ad == DialogResult.OK)
                {
                    Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84");
                }
            }
            else
                Label3.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\assets\\indexes\\" + fn;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Label3.Text = "No file selected";
            result = new BrowserResult(true, "");
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Label3_TextChanged(object sender, EventArgs e)
        {
            if (Label3.Text.Contains("/"))
            {
                Label3.Text = Label3.Text.Replace("/", "\\");
            }
            int lastIdx;
            string[] fns = Strings.Split(Label3.Text, "\\");
            lastIdx = fns.Length - 1;
            //            if (!sp.Contains(fns[lastIdx])) {
            if (!FileSystem.FileExists(Label3.Text) || Array.IndexOf(sp, fns[lastIdx]) == -1)
            {
                Button3.Enabled = false;
            }
            else
            {
                Button3.Enabled = true;
            }
        }
    }
}
