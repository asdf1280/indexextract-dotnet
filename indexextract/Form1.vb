Public Class Form1
    Dim dev As String
    Dim rel As String
    Dim dl, rl As String
    Function Upcheck(server As String)
        Try
            Dim c As New DataSet
            c.ReadXml(server)
            dev = c.Tables(0).Rows(0).Item(1)
            rel = c.Tables(0).Rows(0).Item(2)
            dl = c.Tables(0).Rows(0).Item(3)
            rl = c.Tables(0).Rows(0).Item(4)
        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function




    Dim ale As Integer = 0
    Public fullt As String
    Dim abcd As Integer
    Public i As Integer
    Public a As Integer
    Public hash As String
    Public b As Integer
    Public file As String
    Dim cmp As Integer
    Dim ncp As Integer
    Public korean As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        abcd = UBound(Split(OpenFileDialog1.FileName, "\"))
        Button5.Enabled = True
        Label7.Text = "0"
        Label8.Text = "0"
        Label10.Text = "0"
        i = 0
        a = 3
        cmp = 0
        ale = 0
        ncp = 0
        Label4.Visible = True
        Label3.Visible = True
        Button2.Enabled = False
        Button1.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists("ieup.exe") Then
            My.Computer.FileSystem.DeleteFile("ieup.exe")
        End If

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


        Dim vvr As String
        Upcheck("https://raw.githubusercontent.com/dhkim0800/indexextract/master/uc.xml")
        vvr = rel
        If Me.Text.ToString.Contains("...") Then
            vvr = dev
        End If
        If Not vvr = Me.Text Then
            Label13.Visible = True
            Button7.Visible = True
        End If

        Me.MaximizeBox = False

        If korean Then
            Label4.Text = "대기"
        Else
            Label4.Text = "Ready"
        End If


    End Sub
    Public cancel As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If korean Then
            OpenFileDialog1.Title = "파일 찾아보기"
        Else
            OpenFileDialog1.Title = "Browse File"
        End If
        Form2.ShowDialog()
        If cancel Then
            Exit Sub
        End If
        Button1.Enabled = True
        fullt = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        b = UBound(Split(fullt, "hash")) - 1
        Form2.ComboBox1.Text = ""
        If korean Then
            Form2.Label3.Text = "파일 선택 안함."
        Else
            Form2.Label3.Text = "No file."
        End If
        Dim o As Integer
        o = UBound(Split(OpenFileDialog1.FileName, "\"))
        If My.Computer.FileSystem.DirectoryExists("indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(o), ".json")(0)) Then
            Dim y
            If korean Then
                y = MsgBox("추출하려고 하는 내용이 이미 존재하는것 같습니다." & "게임 업데이트로 인해서 내용이 변경될 수도 있습니다." & "삭제하고 진행하시겠습니까? (권장)", vbYesNo, "IndexExtract")
            Else
                y = MsgBox("Some extract results are already exists." & "When Minecraft is updated, these files may change." & "Do you want to delete and extract it again? (Recommended)", vbYesNo, "IndexExtract")
            End If
            If y = vbYes Then
                My.Computer.FileSystem.DeleteDirectory("indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(o), ".json")(0), FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label4.Text = "Change language"
        Label3.Visible = True
        Label4.Font = New Font("Segoe UI", 14.25)
        Button5.Font = New Font("Segoe UI", 18)
        Button2.Text = "Browse"
        Button5.Text = "Open folder"
        Button1.Text = "Start"
        korean = False
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
        '상태 표시 설정
        Label9.Text = "No file"
        Label6.Text = "Already exists"
        Label11.Text = "Success"

        Label3.Visible = False
        Label4.Text = "Ready"

        Label13.Text = "An update available."
        Button7.Text = "Update"
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label4.Text = "언어 변경"
        Label3.Visible = True
        Label4.Font = New Font("맑은 고딕", 14.25)
        Button5.Font = New Font("맑은 고딕", 18)
        Button2.Text = "찾아보기"
        Button1.Text = "시작"

        Button5.Text = "폴더 열기"
        korean = True
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=KO_KR", False)
        '상태 표시 설정
        Label9.Text = "파일 없음"
        Label6.Text = "이미 추출"
        Label11.Text = "성공"

        Label3.Visible = False
        Label4.Text = "대기"

        Label13.Text = "업데이트 사용 가능"
        Button7.Text = "업데이트"
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i = i + 1
        Try
            file = Split(fullt, Chr(34))(a)
            hash = Split(fullt, Chr(34))(a + 4)
            a = a + 8
        Catch ex As System.IndexOutOfRangeException
            GoTo b
        End Try
        If My.Computer.FileSystem.FileExists("indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file) Then
            ale = ale + 1
            Label7.Text = ale
            cmp = cmp - 1
        End If
        Try
            My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file, True)
        Catch ex As System.IO.FileNotFoundException
            ncp = ncp + 1
            Label8.Text = ncp
            cmp = cmp - 1
        End Try
        cmp = cmp + 1
        Label10.Text = cmp
        If korean Then
            Label4.Text = "추출 : " & vbCrLf & Int(i / b * 100) & "%"
        Else
            Label4.Text = "Extract : " & vbCrLf & Int(i / b * 100) & "%"
        End If
        Exit Sub
b:
        '작업 완료후 코드
        '버튼 활성화
        Button3.Enabled = True
        Button4.Enabled = True
        Label3.Visible = False
        Timer1.Enabled = False
        Button1.Enabled = False
        ale = 0
        cmp = 0
        ncp = 0
        If korean Then
            Label4.Text = "대기"
        Else
            Label4.Text = "Ready"
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Process.Start(Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0))
    End Sub
    Private Sub Dotdotdot_Tick(sender As Object, e As EventArgs) Handles Dotdotdot.Tick
        Select Case Label3.Text
            Case "........"
                Label3.Text = ""
            Case ""
                Label3.Text = "."
            Case "."
                Label3.Text = ".."
            Case ".."
                Label3.Text = "..."
            Case "..."
                Label3.Text = "...."
            Case "...."
                Label3.Text = "....."
            Case "....."
                Label3.Text = "......"
            Case "......"
                Label3.Text = "......."
            Case "......."
                Label3.Text = "........"
            Case "........"
                Label3.Text = "........."
        End Select
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim vvr As String
        If Replace(Me.Text, "...", "") = Me.Text Then
            vvr = rel
        Else
            vvr = dev
        End If
        If My.Computer.Network.Ping("cdn.userapps.net") Then
            My.Computer.Network.DownloadFile("http://cdn.userapps.net/indexextract/update/ieup.exe", "ieup.exe")
            If vvr = dev Then
                My.Computer.FileSystem.WriteAllText("ieu.txt", "http://cdn.userapps.net/indexextract/update/dev/indexextract.exe", False)
                My.Computer.FileSystem.WriteAllText("iel.txt", Application.ExecutablePath, False)
            ElseIf vvr = rel Then
                My.Computer.FileSystem.WriteAllText("ieu.txt", "http://cdn.userapps.net/indexextract/update/rel/indexextract.exe", False)
                My.Computer.FileSystem.WriteAllText("iel.txt", Application.ExecutablePath, False)
            End If
            My.Computer.FileSystem.WriteAllText("iee.txt", IO.Path.GetFileName(Application.ExecutablePath), False)
            Process.Start("ieup.exe")
        Else
            If vvr = dev Then
                Process.Start(dl)
            ElseIf vvr = rel Then
                Process.Start(rl)
            End If
        End If
    End Sub
End Class