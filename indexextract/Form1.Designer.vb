<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dotdotdot = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Tbtup = New System.Windows.Forms.Timer(Me.components)
        Me.Tbtdn = New System.Windows.Forms.Timer(Me.components)
        Me.infott = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 47)
        Me.TextBox1.MaxLength = 2147483647
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(560, 300)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.Location = New System.Drawing.Point(155, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Browse"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "json"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "json|*.json"
        Me.OpenFileDialog1.Title = "Select version json 버전 선택하기"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(341, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Status : "
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 357)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "English"
        Me.infott.SetToolTip(Me.Button3, "English : EN_US" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "영어 (English)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Most of them are international languages." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(대부분이" &
        " 알아듣는 국제 언어입니다.)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Language settings are saved as local files." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(언어 설정은 로컬 파일로 " &
        "저장됩니다.)")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Font = New System.Drawing.Font("궁서체", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button4.Location = New System.Drawing.Point(93, 357)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "한국어"
        Me.infott.SetToolTip(Me.Button4, "Korean : KO_KR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "한국어 (Korean)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It is not recommended for people in other countri" &
        "es!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(다른 나라 사람들에게는 권장하지 않습니다!)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Language settings are saved as local files." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(" &
        "언어 설정은 로컬 파일로 저장됩니다.)")
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("바탕", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button5.Location = New System.Drawing.Point(12, 273)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(466, 76)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Open"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 130)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "......"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label3.Visible = False
        '
        'Dotdotdot
        '
        Me.Dotdotdot.Enabled = True
        Me.Dotdotdot.Interval = 500
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(190, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(203, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Extracting"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label4.Visible = False
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("맑은 고딕", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button7.Location = New System.Drawing.Point(484, 273)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(88, 76)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "▼"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Tbtup
        '
        Me.Tbtup.Interval = 1
        '
        'Tbtdn
        '
        Me.Tbtdn.Interval = 1
        '
        'infott
        '
        Me.infott.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Segoe UI Emoji", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(449, 358)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(123, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Pause"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 388)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Index Extractor 2.40"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Dotdotdot As Timer
    Friend WithEvents Label4 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Tbtup As Timer
    Friend WithEvents Tbtdn As Timer
    Friend WithEvents infott As ToolTip
    Friend WithEvents Button6 As Button
End Class
