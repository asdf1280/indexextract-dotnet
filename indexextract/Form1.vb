Public Class Form1
    Public i As Integer
    Public a As Integer = 3
    Public hash As String
    Public b As Integer
    Public file As String
    Public korean As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        i = 0
        a = 3
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = "c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        On Error Resume Next
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        b = UBound(Split(TextBox1.Text, "hash"))
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Text = "Browse"
        Button1.Text = "Start"
        korean = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button2.Text = "찾아보기"
        Button1.Text = "시작"
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

        file = Split(TextBox1.Text, Chr(34))(a)
        hash = Split(TextBox1.Text, Chr(34))(a + 4)
        'MsgBox(hash & " " & file)

        My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\" & file, True)
        a = a + 8
        Exit Sub
b:
        If korean Then

            TextBox1.Text = "완료됨 indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\... 에 저장되었습니다."
        Else
            TextBox1.Text = "Finished : indexextract\" & Split(Split(OpenFileDialog1.FileName, "\")(abcd), ".json")(0) & "\..."
        End If

        Timer1.Enabled = False
        Button1.Enabled = False
        Exit Sub
    End Sub
End Class
