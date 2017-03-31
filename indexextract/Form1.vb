Public Class Form1
    Dim fullt As String
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
        If korean Then
            Label4.Text = "추출중"
        Else
            Label4.Text = "Extracting"
        End If
        TextBox1.Text = ""
        i = 0
        a = 3
        cmp = 0
        ncp = 0
        Label4.Visible = True
        Label3.Visible = True
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            MsgBox("Unknown lang. Remove c:\indexextract The settings will be reset and it will work.")
            End
        End If
        Form1_SizeChanged(sender, e)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If korean Then
            OpenFileDialog1.Title = "인덱스 찾아보기"
        Else
            OpenFileDialog1.Title = "Select Index JSON"
        End If
        Dim fi = OpenFileDialog1.ShowDialog
        On Error Resume Next
        If fi = DialogResult.Cancel Then
            If korean Then

                TextBox1.Text = "사용자가 취소했습니다.
다시 찾아보기를 클릭하십시오."
            Else
                TextBox1.Text = "User canceled."
            End If
        ElseIf fi = DialogResult.OK Then
            Dim abcd As Integer
            abcd = UBound(Split(OpenFileDialog1.FileName, "\"))
            fullt = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            If Split(OpenFileDialog1.FileName, "\")(abcd) = "legacy.json" Then
                fullt = Split(fullt, Chr(34) & "virtual" & Chr(34) & ": true,")(1)
            End If
            '허가된 파일 이름인지 확인
            Dim fn As String = Split(OpenFileDialog1.FileName, "\")(abcd)
            Dim sp As String = "legacy.json   1.7.10.json   1.8.json   1.9.json   1.10.json   1.11.json   1.12.json"
            If Replace(sp, fn, "") = sp Then
                Dim aaaa
                If korean Then
                    Console.Beep()
                    aaaa = MsgBox("지정된 파일만 열 수 있습니다." & vbCrLf & "허가된 파일 목록을 확인하려면 '확인'을 클릭하십시오.", vbOKCancel, "IndexExtract")
                Else
                    Console.Beep()
                    aaaa = MsgBox("Only you can open (Version).json / legacy.json. Click 'OK' to open accepted filename list.", vbOKCancel, "IndexExtract")
                End If
                If aaaa = vbOK Then
                    Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84")
                End If
                Exit Sub
            End If
            TextBox1.ScrollBars = ScrollBars.None
            If mopen Then
                mopen = False
                tbtdn.Enabled = True
            End If
            b = UBound(Split(fullt, "hash"))
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox1.Text = "찾아보기 버튼을 클릭하십시오." Then
            TextBox1.Text = "Click 'Browse' button."
        End If
        TextBox1.Font = New Font("Segoe UI", 9)
        Label4.Font = New Font("Segoe UI", 14.25)
        Label2.Font = New Font("Segoe UI", 9)
        Button5.Font = New Font("Segoe UI", 18)
        Button7.Font = New Font("Segoe UI", 36)
        Button2.Text = "Browse"
        Button5.Text = "Open"
        Button1.Text = "Start"
        Label1.Text = "Status : ready"
        korean = False
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False)
        '툴팁 설정
        infott.SetToolTip(Label2, "Time")
        infott.SetToolTip(Button2, "100% free!! Use it right now!")

        '마무리 작업
        Form1_SizeChanged(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox1.Text = "Click 'Browse' button." Then
            TextBox1.Text = "찾아보기 버튼을 클릭하십시오."
        End If
        TextBox1.Font = New Font("맑은 고딕", 9)
        Label4.Font = New Font("맑은 고딕", 14.25)
        Label2.Font = New Font("맑은 고딕", 9)
        Button5.Font = New Font("바탕", 18)
        Button7.Font = New Font("맑은 고딕", 36)
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
        Button5.Text = "폴더 열기"
        Label1.Text = "현재 : 준비"
        korean = True
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=KO_KR", False)
        '툴팁 설정
        infott.SetToolTip(Label2, "현재 시간")
        infott.SetToolTip(Button2, "100% 무료입니다!! 지금 바로 추출해보세요!")

        '마무리 작업
        Form1_SizeChanged(sender, e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        abcd = UBound(Split(OpenFileDialog1.FileName, "\"))
        'On Error GoTo b
        i = i + 1
        If korean Then
            Label1.Text = "현재 : " & i & "/" & b
        Else
            Label1.Text = "Status : " & i & "/" & b
        End If
        Try
            file = Split(fullt, Chr(34))(a)
            hash = Split(fullt, Chr(34))(a + 4)
        Catch ex As System.IndexOutOfRangeException
            GoTo b
        End Try
        Try
            My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file, True)
        Catch ex As System.IO.FileNotFoundException
            ncp = ncp + 1
            If korean Then
                'TextBox1.Text = TextBox1.Text & vbCrLf & "파일 없음,건너뜀:" & file
                TextBox1.Text = TextBox1.Text & vbCrLf & "No file, skip:" & file
            Else
                TextBox1.Text = TextBox1.Text & vbCrLf & "No file, skip:" & file
            End If
        End Try
        cmp = cmp + 1
        If korean Then
            'TextBox1.Text = TextBox1.Text & vbCrLf & "파일 복사됨:" & file
            TextBox1.Text = TextBox1.Text & vbCrLf & "File copy:" & file
        Else
            TextBox1.Text = TextBox1.Text & vbCrLf & "File copy:" & file
        End If

        'TextBox1.Text = Microsoft.VisualBasic.Right(TextBox1.Text, 1300)
        '마지막으로 스크롤
        TextBox1.SelectionStart = Len(TextBox1.Text)
        TextBox1.ScrollToCaret()


        a = a + 8

        'MsgBox(hash & " " & file)

        Exit Sub
b:
        Label3.Visible = False
        Label4.Visible = False
        Dim iii As Integer
        For iii = 0 To 5
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        If korean Then
            TextBox1.Text = TextBox1.Text & vbCrLf & "완료됨 : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
            TextBox1.Text = TextBox1.Text & vbCrLf & "성공 : " & cmp & " 실패(파일 없음) : " & ncp & " 총 작업량 : " & cmp + ncp
        Else
            TextBox1.Text = TextBox1.Text & vbCrLf & "Finished : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\..."
            TextBox1.Text = TextBox1.Text & vbCrLf & "Complete : " & cmp & " Fail (No File) : " & ncp & " Total : " & cmp + ncp
        End If
        For iii = 0 To 5
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        Button5.Top = Me.Height + 8
        Button7.Top = Me.Height + 8
        mopen = True
        Button5.Visible = True
        Button7.Visible = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        tbtup.Enabled = True
        Timer1.Enabled = False
        Button1.Enabled = False
        TextBox1.SelectionStart = Len(TextBox1.Text)
        TextBox1.ScrollToCaret()
        If korean Then
            Label1.Text = "현재 : 준비"
        Else
            Label1.Text = "Status : ready"
        End If
        Exit Sub
    End Sub
    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button3.Top = Me.Size.Height - 74
        Button4.Top = Me.Size.Height - 74
        Label2.Top = Me.Size.Height - 69
        TextBox1.Height = Me.Height - 131
        TextBox1.Width = Me.Width - 40
        Label4.Top = ((Me.Height / 2) - Label4.Height / 2) - Label3.Height / 5
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
    Private Sub dotdotdot_Tick(sender As Object, e As EventArgs) Handles dotdotdot.Tick
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
        tbtdn.Enabled = True
        mopen = False
    End Sub

    Private Sub tbtup_Tick(sender As Object, e As EventArgs) Handles tbtup.Tick
        'tbtup : 폴더 열기 버튼 올라옴
        Button5.Visible = True
        Button7.Visible = True
        If Not Button5.Top <= Me.Height - 160 Then
            Button5.Top = Button5.Top - 4
            Button7.Top = Button7.Top - 4
        Else
            tbtup.Enabled = False
        End If
    End Sub

    Private Sub tbtdn_Tick(sender As Object, e As EventArgs) Handles tbtdn.Tick
        'tbtdn : 폴더 열기 버튼 내려옴
        If Not Button5.Top >= Me.Height + 8 Then
            Button5.Top = Button5.Top + 4
            Button7.Top = Button7.Top + 4
        Else
            tbtdn.Enabled = False
            Button5.Visible = False
            Button7.Visible = False
        End If
    End Sub
End Class
