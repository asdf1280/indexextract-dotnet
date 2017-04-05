Public Class Form1
    Dim ale As Integer = 0
    Public fullt As String
    Dim abcd As Integer
    Public i As Integer
    Public a As Integer ' = 3
    Public hash As String
    Public b As Integer
    Public file As String
    Dim cmp As Integer
    Dim ncp As Integer
    Public korean, mopen As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Visible = False
        If korean Then
            Label4.Text = "추출중"
        Else
            Label4.Text = "Extracting"
        End If
        TextBox1.Text = ""
        i = 0
        a = 3
        cmp = 0
        ale = 0
        ncp = 0
        Label4.Visible = True
        Label3.Visible = True
        Button6.Visible = True
        Button2.Enabled = False
        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '언어설정은 한국인만 받아요
        If Not System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag = "ko-KR" Then
            Button4.Visible = False
            Button3.Visible = False
        End If
        Dim a As Integer = Screen.PrimaryScreen.Bounds.Width / 2
        Dim b As Integer = Screen.PrimaryScreen.Bounds.Height / 2
        Me.Top = b - Me.Height / 2
        Me.Left = a - Me.Width / 2
        'MsgBox(Me.BackgroundImage)
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
        Form1_SizeChanged(sender, e)
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
        If korean Then
            TextBox1.Text = OpenFileDialog1.FileName & " 파일을 불러왔습니다."
        Else
            TextBox1.Text = "Successfully loaded " & OpenFileDialog1.FileName
        End If
        If mopen Then
            mopen = False
            Tbtdn.Enabled = True
        End If
        b = UBound(Split(fullt, "hash"))
        Form2.Label3.Text = ""
        Form2.ComboBox1.Text = ""
        Form2.ComboBox1.SelectedItem = ""
        If korean Then
            Form2.Label3.Text = "파일 선택 안함."
        Else
            Form2.Label3.Text = "No file."
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox1.Text = "'찾아보기' 버튼을 클릭하십시오." Then
            TextBox1.Text = "Click 'Browse' button."
        End If
        TextBox1.Font = New Font("Segoe UI", 9)
        Label4.Font = New Font("Segoe UI", 14.25)
        Button5.Font = New Font("Segoe UI", 18)
        Button7.Font = New Font("Segoe UI", 36)
        Button2.Text = "Browse"
        Button5.Text = "Open"
        Button1.Text = "Start"
        Label1.Text = "Status : ready"
        korean = False
        Button6.Text = "Pause"
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
        '툴팁 설정
        infott.SetToolTip(Button2, "100% free!! Use it right now!")

        '마무리 작업
        Form1_SizeChanged(sender, e)
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox1.Text = "Click 'Browse' button." Then
            TextBox1.Text = "'찾아보기' 버튼을 클릭하십시오."
        End If
        TextBox1.Font = New Font("맑은 고딕", 9)
        Label4.Font = New Font("맑은 고딕", 14.25)
        Button5.Font = New Font("바탕", 18)
        Button7.Font = New Font("맑은 고딕", 36)
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
        Button5.Text = "폴더 열기"
        Label1.Text = "상태 : 준비"
        korean = True
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=KO_KR", False)
        Button6.Text = "일시 정지"
        '툴팁 설정
        infott.SetToolTip(Button2, "100% 무료입니다!! 지금 바로 추출해보세요!")

        '마무리 작업
        Form1_SizeChanged(sender, e)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        abcd = UBound(Split(OpenFileDialog1.FileName, "\"))
        i = i + 1
        If korean Then
            Label1.Text = "상태 : " & i & "/" & b & "(" & Int(i / b * 100) & "%" & ")"
        Else
            Label1.Text = "Status : " & i & "/" & b & "(" & Int(i / b * 100) & "%" & ")"
        End If
        Try
            file = Split(fullt, Chr(34))(a)
            a = a + 4
            hash = Split(fullt, Chr(34))(a)
            a = a + 4
        Catch ex As System.IndexOutOfRangeException
            GoTo b
        End Try
        If My.Computer.FileSystem.FileExists("indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file) Then
            ale = ale + 1
            GoTo aale
        End If
        Try
            My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file, True)
        Catch ex As System.IO.FileNotFoundException
            ncp = ncp + 1
            GoTo aale
        End Try
        cmp = cmp + 1
aale:
        If korean Then
            TextBox1.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & "작업하고 있습니다. 현재 작업량 : " & Int(i / b * 100) & "%"
        Else
            TextBox1.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Processing. Status : " & Int(i / b * 100) & "%"
        End If
        Exit Sub
b:
        '작업 완료후 코드
        TextBox1.Visible = True
        '버튼 활성화
        Button2.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        TextBox1.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
        Label3.Visible = False
        Label4.Visible = False
        Dim iii As Integer
        For iii = 0 To 5
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        If korean Then
            TextBox1.Text = TextBox1.Text & vbCrLf & "완료 : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
            TextBox1.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & "추출됨 : " & cmp & " | 오류(파일 없음) : " & ncp & " | 안내(이미 존재) : " & ale & " | 작업량 : " & cmp + ncp + ale
            If ale > 0 Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[경고]이미 존재하는 파일이 몇 개 있어서 건너뛰었습니다." & vbCrLf & "두 파일간에 차이점이 있을 수 있으니, 기존 폴더를 삭제하고 다시 작업하는 것을 권장합니다.(폴더 열기를 사용하십시오.)"
            End If
            If ncp > 0 Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[경고]마인크래프트 폴더상에 찾을 수 없는 파일들이 몇몇 있어서 건너뛰었습니다." & vbCrLf & "해당 버전의 마인크래프트를 실행한 뒤 다시 작업하는 것을 권장합니다."
            End If
            If Not cmp + ncp + ale = cmp Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[안내]모든 파일이 완벽하게 추출되지 않았습니다. 위 내용을 참고하세요."
            End If
        Else
            TextBox1.Text = TextBox1.Text & vbCrLf & "Complete : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
            TextBox1.Text = vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Extracted : " & cmp & " | Errored(No file) : " & ncp & " | Info(Already exists) : " & ale & " | Total : " & cmp + ncp + ale
            If ale > 0 Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[WARNING]Some files was already exists and I skipped them." & vbCrLf & "They may have a different, and we recommend to remove old directory and run this tool again.(Use 'Open' button.)"
            End If
            If ncp > 0 Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[WARNING]Some files does not exist in Minecraft directory. I skipped them." & vbCrLf & "It is recommend that you execute the corresponding version of the Minecraft and then run this tool again."
            End If
            If Not cmp + ncp + ale = cmp Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "[INFO]Some files were not extracted fully. Please refer to the above."
            End If
        End If
        TextBox1.SelectionStart = Len(TextBox1.Text)
        TextBox1.ScrollToCaret()
        For iii = 0 To 5
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        Button5.Visible = True
        Button7.Visible = True
        Button6.Visible = False
        Button5.Top = Me.Height + 8
        Button7.Top = Me.Height + 8
        mopen = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        Tbtup.Enabled = True
        Timer1.Enabled = False
        Button1.Enabled = False
        If korean Then
            Label1.Text = "상태 : 준비"
        Else
            Label1.Text = "Status : ready"
        End If
        TextBox1.SelectionStart = Len(TextBox1.Text)
        TextBox1.ScrollToCaret()
        Exit Sub
    End Sub
    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button3.Top = Me.Size.Height - 74
        Button4.Top = Me.Size.Height - 74
        Button6.Left = Me.Width - 151
        Button6.Top = Me.Height - 74
        TextBox1.Height = Me.Height - 131
        TextBox1.Width = Me.Width - 40
        Label4.Top = (Me.Height / 2) - Label4.Height / 2
        Label4.Left = (Me.Width / 2) - Label4.Width / 2
        Label3.Top = (Me.Height / 2) - Label3.Height / 2
        Label3.Left = (Me.Width / 2) - Label3.Width / 2

        'Button5.Left = Me.Width - 588
        Button5.Top = Me.Height - 160
        Button5.Width = Me.Width - 134

        'Button7 폴더 열기 메뉴 닫기버튼
        Button7.Top = Me.Height - 160
        Button7.Left = Me.Width - 116
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '폴더 열기
        Process.Start(Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0))
    End Sub
    Private Sub Dotdotdot_Tick(sender As Object, e As EventArgs) Handles Dotdotdot.Tick
        Select Case Label3.Text
            Case "......."
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
        End Select
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Tbtdn.Enabled = True
        mopen = False
    End Sub

    Private Sub Tbtup_Tick(sender As Object, e As EventArgs) Handles Tbtup.Tick
        'tbtup : 폴더 열기 버튼 올라옴
        Button5.Visible = True
        Button7.Visible = True
        If Not Button5.Top <= Me.Height - 160 Then
            Button5.Top = Button5.Top - 4
            Button7.Top = Button7.Top - 4
        Else
            Tbtup.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Pause" Or Button6.Text = "일시 정지" Then
            If korean Then
                Button6.Text = "계속"
            Else
                Button6.Text = "Resume"
            End If
            Dotdotdot.Enabled = False
            Label3.Text = "......."
            Timer1.Enabled = False
        ElseIf Button6.Text = "Resume" Or Button6.Text = "계속" Then
            If korean Then
                Button6.Text = "일시 정지"
            Else
                Button6.Text = "Pasue"
            End If
            Dotdotdot.Enabled = True
            Timer1.Enabled = True
        End If
    End Sub
    Public cntt As Integer = 0
    Public acntt As Boolean = False
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If acntt Then
            MsgBox("Language option already enabled for '" & System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag & "' User", vbInformation)
            Exit Sub
        End If
        If cntt = 10 Then
            MsgBox("Language option enabled for '" & System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag & "' User", vbCritical)
            Button3.Visible = True
            Button4.Visible = True
            acntt = True
        Else
            cntt = cntt + 1
        End If
    End Sub

    Private Sub Tbtdn_Tick(sender As Object, e As EventArgs) Handles Tbtdn.Tick
        'tbtdn : 폴더 열기 버튼 내려옴
        If Not Button5.Top >= Me.Height + 8 Then
            Button5.Top = Button5.Top + 4
            Button7.Top = Button7.Top + 4
        Else
            Tbtdn.Enabled = False
            Button5.Visible = False
            Button7.Visible = False
        End If
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        'MsgBox(korean)
    End Sub
End Class
