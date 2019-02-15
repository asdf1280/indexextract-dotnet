Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Public Class Form1
    Dim dev As String
    Dim rel As String
    Dim dl, rl As String
    Function Upcheck(server As String)
        Try
            Dim c As New DataSet
            c.ReadXml(server)
            rel = c.Tables(0).Rows(0).Item(1)
            dev = c.Tables(0).Rows(0).Item(2)
            rl = c.Tables(0).Rows(0).Item(3)
            dl = c.Tables(0).Rows(0).Item(4)
            Console.WriteLine(dev)
            Console.WriteLine(rel)
            Console.WriteLine(dl)
            Console.WriteLine(rl)
        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        '언어설정은 한국인만 받아요
        If Not System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag = "ko-KR" Then
            Button4.Visible = False
            Button3.Visible = False
        End If
        Dim a As Integer = Screen.PrimaryScreen.Bounds.Width / 2
        Dim b As Integer = Screen.PrimaryScreen.Bounds.Height / 2
        Me.Top = b - Me.Height / 2
        Me.Left = a - Me.Width / 2
        OpenFileDialog1.InitialDirectory = "c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes"
        '설정파일 처음 세팅
        If Not My.Computer.FileSystem.FileExists("c:\indexextract\lang.set") Then
            Try
                My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
            Catch ex As System.IO.DirectoryNotFoundException
                My.Computer.FileSystem.CreateDirectory("c:\indexextract")
                My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
            End Try
        End If
        '설정파일 로드
        '언어 설정파일
        Dim se As String
        se = My.Computer.FileSystem.ReadAllText("c:\indexextract\lang.set")
        Dim lang As String = ""
        'MsgBox(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) 앱데이터 폴더
        Try
            lang = Split(se, "lang=")(1)
        Catch ex As System.IndexOutOfRangeException
            Button3_Click(sender, e)
        End Try
        If lang = "EN_US" Then
            Button3_Click(sender, e)
        ElseIf lang = "KO_KR" Then
            Button4_Click(sender, e)
        Else
            My.Computer.FileSystem.DeleteFile("c:\indexextract\lang.set")
            Application.Restart()
        End If

        Me.MaximizeBox = False

        Dim t As New Thread(AddressOf AsyncUpCheck)
        t.Priority = ThreadPriority.Highest
        t.Start()

        If lang = "ko" Then
            Label4.Text = "대기"
        ElseIf lang = "en" Then
            Label4.Text = "Wait"
        End If
    End Sub
    'setvisible delegate
    Private Structure ControlBool
        Public c As Control
        Public b As Boolean

        Public Sub New(control As Control, bool As Boolean)
            c = control
            b = bool
        End Sub
    End Structure
    Private Structure ControlStr
        Public c As Control
        Public b As String

        Public Sub New(control As Control, bool As String)
            c = control
            b = bool
        End Sub
    End Structure
    Private Sub SetVisible(cb As ControlBool)
        cb.c.Visible = cb.b
    End Sub
    Private Delegate Sub ControlBoolD(cb As ControlBool)
    Private Delegate Sub ControlStrD(cb As ControlStr)

    Private Sub ManageComponent(cb As ControlBool)
        If cb.b Then
            Me.Controls.Add(cb.c)
        Else
            Me.Controls.Remove(cb.c)
        End If
    End Sub
    Private Sub AsyncUpCheck()
        Dim vvr As String
        Upcheck("https://raw.githubusercontent.com/dhkim0800/indexextract/master/uc.xml")
        vvr = rel
        If Me.Text.ToString.Contains("b") Then
            vvr = dev
        End If
        Dim svd As New ControlBoolD(AddressOf SetVisible)
        Try
            If Not vvr = Me.Text Then
                Me.Invoke(svd, New ControlBool(Label13, True))
                Me.Invoke(svd, New ControlBool(Button7, True))
            Else
                Me.Invoke(svd, New ControlBool(Label13, False))
                Me.Invoke(svd, New ControlBool(Button7, False))
            End If
        Catch ex As Exception When TypeOf ex Is InvalidOperationException
            Application.Exit()
        End Try
    End Sub

    Private Delegate Sub VoidDelegate()

    Public cancel As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If lang = "ko" Then
            OpenFileDialog1.Title = "파일 찾아보기"
            Form2.Label3.Text = "파일 선택 안함."
        ElseIf lang = "en" Then
            OpenFileDialog1.Title = "Browse File"
            Form2.Label3.Text = "No file selected."
        End If
        Form2.ShowDialog()
        If cancel Then
            Exit Sub
        End If
        Button1.Enabled = True
        Form2.ComboBox1.Text = ""
        Dim o As Integer
        o = UBound(Split(OpenFileDialog1.FileName, "\"))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label3.Visible = True
        Label4.Font = New Font("Segoe UI", 14.25)
        Button5.Font = New Font("Segoe UI", 18)
        Button2.Text = "Browse"
        Button5.Text = "Open folder"
        Button1.Text = "Start"
        lang = "en"
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
        '상태 표시 설정
        Label9.Text = "I/O Error"
        Label9.Font = New Font("Segoe UI", 12.5, FontStyle.Regular)
        Label6.Text = "Duplicated file"
        Label6.Font = New Font("Segoe UI", 10.3, FontStyle.Regular)

        Label2.Font = New Font("Segoe UI", 12, FontStyle.Regular)
        Label2.Text = "Progress: "

        Label3.Visible = False
        Label4.Text = "Wait"

        Label13.Text = "An update available."
        Button7.Text = "Update"
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label3.Visible = True
        Label4.Font = New Font("맑은 고딕", 14.25)
        Button5.Font = New Font("맑은 고딕", 18)
        Button2.Text = "찾아보기"
        Button1.Text = "시작"

        Button5.Text = "폴더 열기"
        lang = "ko"
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=KO_KR", False)
        '상태 표시 설정
        Label9.Text = "I/O 오류"
        Label9.Font = New Font("맑은 고딕", 8.5, FontStyle.Regular)
        Label6.Text = "파일 중복"
        Label9.Font = New Font("맑은 고딕", 8, FontStyle.Regular)

        Label2.Font = New Font("맑은 고딕", 12, FontStyle.Regular)
        Label2.Text = "진행률: "

        Label3.Visible = False
        Label4.Text = "대기"

        Label13.Text = "업데이트가 존재합니다."
        Button7.Text = "업데이트"
    End Sub
    Private Structure WorkData
        Public dataJson As String()
        Public targetPath As String
    End Structure
    Private workDataObj As WorkData = Nothing
    Private ad As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\.minecraft\"
    'Fields 2
    Dim ale As Integer = 0
    Dim abcd As Integer
    Public i As Integer
    Public index As Integer
    Public b As Integer
    Dim ncp As Integer
    Public lang As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lang = "ko" Then
            Label4.Text = "준비 중"
        ElseIf lang = "en" Then
            Label4.Text = "Prepearing"
        End If
        'If My.Computer.FileSystem.DirectoryExists("indexextract\" & Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)) Then
        '    Shell("cmd /c rd /Q /S " & Chr(34) & "indexextract\" & Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName) & Chr(34), AppWinStyle.Hide, True)
        'End If
        abcd = UBound(Split(OpenFileDialog1.FileName, "\"))
        Label7.Text = "0"
        Label8.Text = "0"
        ProgressBar1.Value = 0
        i = 0
        index = 3
        ale = 0
        ncp = 0
        Label4.Visible = True
        Label3.Visible = True
        Label1.Visible = True
        Button2.Enabled = False
        Button1.Enabled = False
        Button5.Enabled = False
        If lang = "ko" Then
            Label4.Text = "추출"
        ElseIf lang = "en" Then
            Label4.Text = "Processing"
        End If

        Dim fullt As String = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        b = UBound(Split(fullt, "hash")) - 1

        workDataObj = New WorkData With {
            .dataJson = Split(fullt, Chr(34)),
            .targetPath = ".\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0)
        }

        Dim t As New Thread(AddressOf WorkThread)
        t.Name = "Indexextract worker"
        t.Priority = ThreadPriority.Highest
        t.Start()
    End Sub
    Private Sub WorkThread()
        Dim vd As New VoidDelegate(AddressOf RefreshIndexTexts)
        Dim cd As New ControlStrD(AddressOf SetControlIntTxt)
        Do
            For t As Int16 = 1 To 50 Step 1
                i = i + 1
                Dim file As String
                Dim hash As String
                Try
                    file = workDataObj.dataJson(index)
                    hash = workDataObj.dataJson(index + 4)
                    index = index + 8
                Catch ex As System.IndexOutOfRangeException
                    Me.Invoke(vd)
                    Dim ed As New VoidDelegate(AddressOf WorkEnd)
                    Me.Invoke(ed)
                    Return
                End Try
                Dim sourceFile As String = ad & "assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash
                Dim targetFile As String = workDataObj.targetPath & "\" & file
                If My.Computer.FileSystem.FileExists(targetFile) Then
                    ale += 1
                    Me.Invoke(cd, New ControlStr(Label7, ale))
                    Continue For
                End If
                Try
                    My.Computer.FileSystem.CopyFile(sourceFile, targetFile, True)
                Catch ex As System.IO.FileNotFoundException
                    ncp += 1
                    Me.Invoke(cd, New ControlStr(Label8, ncp))
                End Try
            Next
            Me.Invoke(vd)
        Loop
    End Sub
    Private Sub RefreshIndexTexts()
        'Label10.Text = cmp
        Dim pc As Short = i * 100 / b
        ProgressBar1.Value = pc * 100
        Label1.Text = pc & "%"
    End Sub
    Private Sub SetControlIntTxt(cb As ControlStr)
        cb.c.Text = cb.b
    End Sub
    Private Sub WorkEnd()
        '작업 완료후 코드
        workDataObj = Nothing
        GC.Collect()

        '버튼 활성화
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Label3.Visible = False
        Label1.Visible = False
        ale = 0
        ncp = 0
        Label1.Text = ""
        If lang = "ko" Then
            Label4.Text = "대기"
        ElseIf lang = "en" Then
            Label4.Text = "Ready"
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Process.Start(Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0))
        Catch ex As Exception When TypeOf ex Is DirectoryNotFoundException Or TypeOf ex Is FileNotFoundException Or TypeOf ex Is Win32Exception
            Dim emsg As String = Nothing
            If lang = "ko" Then
                emsg = "폴더를 열 수 없습니다. 나중에 다시 시도하세요."
            ElseIf lang = "en" Then
                emsg = "Could not open folder. Please try again later."
            End If
            MsgBox(emsg, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub
    Private Sub Dotdotdot_Tick(sender As Object, e As EventArgs) Handles Dotdotdot.Tick
        If Label3.Text.Length < 8 Then
            Label3.Text &= "."
        Else
            Label3.Text = ""
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim vvr As String
        If Me.Text.Contains("e") Then
            vvr = rel
        ElseIf Me.Text.Contains("b") Then
            vvr = dev
        Else
            vvr = False
        End If
        If vvr = dev Then
            Process.Start(dl)
        ElseIf vvr = rel Then
            Process.Start(rl)
        End If
    End Sub
End Class