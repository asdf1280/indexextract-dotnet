Public Class Form1
    Dim fullt As String
    Dim abcd As Integer
    Public i As Integer
    Public a As Integer = 3
    Public hash As String
    Public b As Integer
    Public file As String
    Public korean As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        i = 0
        a = 3
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = "c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            Button5.Visible = False
            b = UBound(Split(fullt, "hash"))
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Text = "Browse"
        Button5.Text = "Open"
        Button1.Text = "Start"
        Label1.Text = "Status : ready"
        korean = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
        Button5.Text = "폴더 열기"
        Label1.Text = "현재 : 준비"
        korean = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error GoTo b

        abcd = UBound(Split(OpenFileDialog1.FileName, "\"))

        i = i + 1
        If korean Then
            Label1.Text = "현재 : " & i & "/" & b + 1
        Else
            Label1.Text = "Status : " & i & "/" & b + 1
        End If

        file = Split(fullt, Chr(34))(a)
        hash = Split(fullt, Chr(34))(a + 4)
        'MsgBox(hash & " " & file)

        My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file, True)
        If korean Then
            'TextBox1.Text = TextBox1.Text & vbCrLf & "파일 복사됨:" & file
            TextBox1.Text = TextBox1.Text & vbCrLf & "File copy:" & file
        Else
            TextBox1.Text = TextBox1.Text & vbCrLf & "File copy:" & file
        End If


        '마지막으로 스크롤
        TextBox1.SelectionStart = TextBox1.TextLength

        TextBox1.ScrollToCaret()


        a = a + 8
        Exit Sub
b:
        If korean Then
            TextBox1.Text = "완료됨 : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
        Else
            TextBox1.Text = "Finished : " & Application.StartupPath & "\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\..."
        End If
        Button5.Visible = True

        Timer1.Enabled = False
        Button1.Enabled = False
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
End Class
