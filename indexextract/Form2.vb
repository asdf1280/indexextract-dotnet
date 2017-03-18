Imports System.ComponentModel
Imports Microsoft.Win32

Public Class Form2
    Private Function GetCurrentWallpaper() As String
        ' The current wallpaper path is stored in the registry at HKCU\Control Panel\Desktop\WallPaper
        Dim rkWallPaper As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", False)
        Dim WallpaperPath As String = rkWallPaper.GetValue("WallPaper").ToString()
        rkWallPaper.Close()
        ' Return the current wallpaper path
        Return WallpaperPath
    End Function
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(Screen.PrimaryScreen.Bounds.Width & " " & Screen.PrimaryScreen.Bounds.Height)
        Me.Top = Form1.Top + (Form1.Height / 3)
        Me.Left = Form1.Left + (Form1.Width / 4)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim a
        a = ColorDialog1.ShowDialog()
        If Not a = vbCancel Then
            Form1.BackColor = Color.Empty
            Form1.BackgroundImage = Nothing
            Form1.BackColor = ColorDialog1.Color
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a
        a = OpenFileDialog1.ShowDialog()
        If Not a = vbCancel Then
            Form1.BackColor = Color.Empty
            Form1.BackgroundImage = Nothing
            Form1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a
        If Form1.korean Then
            a = MsgBox("확실합니까?", vbYesNo, "배경 변경")
        Else
            a = MsgBox("Sure?", vbYesNo, "Change Background")
        End If
        If a = vbYes Then
            Form1.BackColor = Color.Empty
            Form1.BackgroundImage = Nothing
        End If
        If Form1.korean Then
            MsgBox("작업 완료.", vbInformation, "배경 변경")
        Else
            MsgBox("Task complete.", vbInformation, "Change Background")
        End If
        Me.Close()
        'GetCurrentWallpaper()
    End Sub
End Class