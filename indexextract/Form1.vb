Public Class Form1
    Dim fullt As String
    Dim abcd As Integer
    Public i As Integer
    Public a As Integer = 3
    Public hash As String
    Public b As Integer
    Public file As String
    Dim cmp As Integer
    Dim ncp As Integer
    Public korean As Boolean = False
    Dim mopen As Boolean
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
        If Not My.Computer.FileSystem.DirectoryExists("c:\indexextract") Then
            My.Computer.FileSystem.CreateDirectory("c:\indexextract")
        End If
        If Not My.Computer.FileSystem.FileExists("c:\indexextract\lang.set") Then
            My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False, System.Text.Encoding.UTF7)
        End If

        '설정파일 로드
        '언어 설정파일
        Dim se As String
        se = My.Computer.FileSystem.ReadAllText("c:\indexextract\lang.set", System.Text.Encoding.UTF7)
        Dim lang As String
        lang = Split(se, "lang=")(1)
        If lang = "EN_US" Then
            Button3_Click(sender, e)
        ElseIf lang = "KO_KR" Then
            Button4_Click(sender, e)
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
            Dim fn As String = Split(OpenFileDialog1.FileName, "\")(abcd)
            If Not fn = "1.11.json" And Not fn = "1.10.json" And Not fn = "1.9.json" And Not fn = "1.8.json" And Not fn = "1.7.10.json" And Not fn = "legacy.json" And Not fn = "1.12.json" Then
                Dim aaaa
                If korean Then
                    Console.Beep()
                    aaaa = MsgBox("지정된 파일만 열 수 있습니다." & vbCrLf & "허가된 파일 목록을 확인하려면 확인을 클릭하십시오.", vbOKCancel, "IndexExtract")
                Else
                    Console.Beep()
                    aaaa = MsgBox("Only you can open (Version).json / legacy.json. Click ok to open accepted filename list.", vbOKCancel, "IndexExtract")
                End If
                If aaaa = vbOK Then
                    Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84")
                End If
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
        TextBox1.Font = New Font("Segoe UI", 9)
        Label4.Font = New Font("Segoe UI", 14.25)
        Label2.Font = New Font("Segoe UI", 9)
        Button5.Font = New Font("Segoe UI", 18)
        Button7.Font = New Font("Segoe UI", 36)
        Button2.Text = "Browse"
        Button5.Text = "Open"
        Button1.Text = "Start"
        Label1.Text = "Status : ready"
        Button6.Text = "Change Background"
        Form2.Button3.Text = "Reset"
        Button6.Left = 422
        Button6.Width = 150
        Form2.OpenFileDialog1.Title = "Browse Picture"
        korean = False
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=EN_US", False, System.Text.Encoding.UTF7)
        '툴팁 설정
        infott.SetToolTip(Label2, "Time")
        infott.SetToolTip(Button2, "100% free!! Use it right now!")

        '마무리 작업
        Form1_SizeChanged(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Font = New Font("맑은 고딕", 9)
        Label4.Font = New Font("맑은 고딕", 14.25)
        Label2.Font = New Font("궁서", 9)
        Button5.Font = New Font("바탕", 18)
        Button7.Font = New Font("맑은 고딕", 36)
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
        Button5.Text = "폴더 열기"
        Label1.Text = "현재 : 준비"
        Button6.Text = "배경 변경"
        Form2.Button3.Text = "초기화"
        Button6.Left = 497
        Button6.Width = 75
        Form2.OpenFileDialog1.Title = "사진 찾아보기"
        korean = True
        My.Computer.FileSystem.WriteAllText("c:\indexextract\lang.set", "lang=KO_KR", False, System.Text.Encoding.UTF7)
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
    Dim tim As Boolean = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        tim = korean
        If korean Then
            Label2.Text = "현재 시간 : " & Now

            If TextBox1.Text = "" Or TextBox1.Text = "Click Browse" Then
                TextBox1.Text = "찾아보기 를 클릭하십시오."
            End If
        Else
            Label2.Text = "Now : " & Now

            If TextBox1.Text = "" Or TextBox1.Text = "찾아보기 를 클릭하십시오." Then
                TextBox1.Text = "Click Browse"
            End If
        End If
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button3.Top = Me.Size.Height - 74
        Button4.Top = Me.Size.Height - 74
        Label2.Top = Me.Size.Height - 69
        TextBox1.Height = Me.Height - 131
        TextBox1.Width = Me.Width - 40
        If korean Then
            Button6.Left = Me.Width - 103
            Button6.Top = Me.Height - 74
        Else
            Button6.Left = Me.Width - 178
            Button6.Top = Me.Height - 74
        End If
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Public modd As Boolean = True
    Public modc As Boolean = False
    Public dd As Short = Int(Rnd() * 5) + 1
    Public ddd As Short = Int(Rnd() * 5) + 1
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        '600 1500 431 1000
        If modd Then
            Me.Width = Me.Width + dd
        Else
            Me.Width = Me.Width - dd
        End If
        If modc Then
            Me.Height = Me.Height + ddd
        Else
            Me.Height = Me.Height - ddd
        End If
        If Me.Width < 600 Then
            dd = Int(Rnd() * 50) + 1
            modd = True
        ElseIf Me.Width > 1300 Then
            dd = Int(Rnd() * 50) + 1
            modd = False
        End If
        If Me.Height < 431 Then
            ddd = Int(Rnd() * 50) + 1
            modc = True
        ElseIf Me.Height > 800 Then
            ddd = Int(Rnd() * 50) + 1
            modc = False
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Timer3.Enabled = True
    End Sub
    Dim moa As Boolean

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick


        If moa Then
            Me.Left = Me.Left + dimu
            Me.Top = Me.Top + dimu
            moa = False
        Else
            Me.Left = Me.Left - dimu
            Me.Top = Me.Top - dimu
            moa = True
        End If
    End Sub
    Dim dimu As Short
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        dimu = Int(Rnd() * 80) + 1
        Timer4.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Process.Start(Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form2.Top = Me.Top
        Form2.Left = Me.Left
        If korean Then
            Form2.Label1.Text = "적용할 방법을 선택하십시오."
            Form2.Button1.Text = "단색"
            Form2.Button2.Text = "사진"
        Else
            Form2.Label1.Text = "Select Background Type."
            Form2.Button1.Text = "Color"
            Form2.Button2.Text = "Picture"
        End If
        Form2.ShowDialog()
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
        'Button5.Visible = False
        'Button7.Visible = True
        tbtdn.Enabled = True
        mopen = False
    End Sub

    Private Sub tbtup_Tick(sender As Object, e As EventArgs) Handles tbtup.Tick
        Button5.Visible = True
        Button7.Visible = True
        If Not Button5.Top = Me.Height - 160 Then
            Button5.Top = Button5.Top - 1
            Button7.Top = Button7.Top - 1
        Else
            tbtup.Enabled = False
        End If
    End Sub

    Private Sub tbtdn_Tick(sender As Object, e As EventArgs) Handles tbtdn.Tick
        If Not Button5.Top = Me.Height + 8 Then
            Button5.Top = Button5.Top + 1
            Button7.Top = Button7.Top + 1
        Else
            tbtdn.Enabled = False
            Button5.Visible = False
            Button7.Visible = False
        End If
    End Sub
End Class
