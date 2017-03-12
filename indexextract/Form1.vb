Public Class Form1
    Dim fullt As String
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
            fullt = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            b = UBound(Split(fullt, "hash"))
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Text = "Browse"
        Button1.Text = "Start"
        Label1.Text = "Status : ready"
        korean = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
        Label1.Text = "현재 : 준비"
        korean = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error GoTo b
        Dim abcd As Integer
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
            TextBox1.Text = "완료됨 : 프로그램 폴더\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
        Else
            TextBox1.Text = "Finished : This EXE dir\indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\..."
        End If

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
End Class
