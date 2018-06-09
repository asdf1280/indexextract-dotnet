Imports System.ComponentModel

Public Class Form2
    Dim cfm As Boolean = False
    Public sp As String = "legacy.json   1.7.10.json   1.8.json   1.9.json 1.9-aprilfools.json   1.10.json   1.11.json   1.12.json   1.13.json"
    Public sz As String = ""
    Public Function Fds()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
          "c:\Users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes")
            Dim it As String
            it = Split(foundFile, "\")(UBound(Split(foundFile, "\")))
            If Replace(sp, it, "") = sp Then
                Continue For
            End If
            ComboBox1.Items.Add(Split(foundFile, "\")(UBound(Split(foundFile, "\"))))
        Next
        Return 1
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt As String
        Dim fi = Form1.OpenFileDialog1.ShowDialog
        On Error Resume Next
        If fi = DialogResult.Cancel Then
            Exit Sub
        ElseIf fi = DialogResult.OK Then
            Dim abcd As Integer
            abcd = UBound(Split(Form1.OpenFileDialog1.FileName, "\"))
            txt = My.Computer.FileSystem.ReadAllText(Form1.OpenFileDialog1.FileName)
            If Split(Form1.OpenFileDialog1.FileName, "\")(abcd) = "legacy.json" Then
                txt = Split(txt, Chr(34) & "virtual" & Chr(34) & ": true,")(1)
            End If
            '허가된 파일 이름인지 확인
            Dim fn As String = Split(Form1.OpenFileDialog1.FileName, "\")(abcd)

            If Replace(sp, fn, "") = sp Then
                Dim aaaa As MsgBoxResult
                If Form1.lang = "ko" Then
                    Console.Beep()
                    aaaa = MsgBox("지정된 파일만 열 수 있습니다." & vbCrLf & "허가된 파일 목록을 확인하려면 '확인'을 클릭하십시오.", vbOKCancel, "IndexExtract")
                ElseIf Form1.lang = "en" Then
                    Console.Beep()
                    aaaa = MsgBox("Only you can open (Version).json / legacy.json. Click 'OK' to open accepted filename list.", vbOKCancel, "IndexExtract")
                End If
                If aaaa = vbOK Then
                    Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84")
                End If
            End If
            Label3.Text = Form1.OpenFileDialog1.FileName
        End If
    End Sub
    Public lang As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lang = Form1.lang
        'MsgBox(korean)
        ComboBox1.Items.Clear()
        Form1.cancel = False
        Dim a As Integer = Screen.PrimaryScreen.Bounds.Width / 2
        Dim b As Integer = Screen.PrimaryScreen.Bounds.Height / 2
        Me.Top = b - Me.Height / 2
        Me.Left = a - Me.Width / 2
        Fds()
        If lang = "ko" Then
            Me.Text = "찾아보기"
            Button1.Text = "파일에서 찾아보기"
            GroupBox1.Text = "파일 찾아보기"
            GroupBox2.Text = "목록에서 선택"
            Button2.Text = "목록 새로고침"
            GroupBox4.Text = "선택됨"
            Button4.Text = "취소"
            Button3.Text = "확인"
            If Label3.Text = "No file." Then
                Label3.Text = "파일 선택 안함."
            End If
        ElseIf lang = "en" Then
            Me.Text = "Browse"
            Button1.Text = "Browse file"
            GroupBox1.Text = "Browse file"
            GroupBox2.Text = "Indexes list"
            Button2.Text = "Reload list"
            GroupBox4.Text = "Selected : "
            Button4.Text = "Cancel"
            Button3.Text = "Confirm"
            If Label3.Text = "파일 선택 안함." Then
                Label3.Text = "No file."
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label3.Text = "No file." Or Label3.Text = "파일 선택 안함." Then
            If lang = "ko" Then
                MsgBox("파일을 선택하지 않았습니다.")
            ElseIf lang = "en" Then
                MsgBox("No file.")
            End If
            Exit Sub
        End If
        cfm = True
        Form1.cancel = False
        Form1.OpenFileDialog1.FileName = Label3.Text
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fds()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim fn As String = ComboBox1.Text

        If Replace(sp, fn, "") = sp Then
            Dim aaaa As MsgBoxResult
            If Form1.lang = "ko" Then
                Console.Beep()
                aaaa = MsgBox("지정된 파일만 열 수 있습니다." & vbCrLf & "허가된 파일 목록을 확인하려면 '확인'을 클릭하십시오.", vbOKCancel, "IndexExtract")
            ElseIf Form1.lang = "en" Then
                Console.Beep()
                aaaa = MsgBox("Only you can open (Version).json / legacy.json. Click 'OK' to open accepted filename list.", vbOKCancel, "IndexExtract")
            End If
            If aaaa = vbOK Then
                Process.Start("https://github.com/dhkim0800/indexextract/wiki/%EC%82%AC%EC%9A%A9-%EA%B0%80%EB%8A%A5%ED%95%9C-%EB%B2%84%EC%A0%84")
            End If
        End If
        Label3.Text = "c:\Users\" & Split(My.User.Name, "\")(1) & "\appdata\roaming\.minecraft\assets\indexes\" & fn
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label3.Text = "No file."
        Form1.cancel = True
        Me.Close()
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not cfm Then
            Form1.cancel = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs)

    End Sub
End Class