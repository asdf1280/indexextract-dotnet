Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error GoTo b
        Dim a As Integer = 3
        Dim hash As String
        Dim file As String
a:
        file = Split(TextBox1.Text, Chr(34))(a)
        hash = Split(TextBox1.Text, Chr(34))(a + 4)
        My.Computer.FileSystem.CopyFile("c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\objects\" & Microsoft.VisualBasic.Left(hash, 2) & "\" & hash, "indexextract\" & file, True)
        a = a + 8
        GoTo a
b:
        MsgBox("Saved as indexextract   indexextract 에 저장되었습니다.", vbInformation)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = "c:\users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
    End Sub
End Class
