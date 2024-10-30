
Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.kill1 = New System.Windows.Forms.TextBox()
        Me.kill3 = New System.Windows.Forms.TextBox()
        Me.kill2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(29, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 49)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(29, 76)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 49)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Kill Processes"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'kill1
        '
        Me.kill1.Location = New System.Drawing.Point(317, 79)
        Me.kill1.Name = "kill1"
        Me.kill1.Size = New System.Drawing.Size(60, 20)
        Me.kill1.TabIndex = 3
        '
        'kill3
        '
        Me.kill3.Location = New System.Drawing.Point(317, 131)
        Me.kill3.Name = "kill3"
        Me.kill3.Size = New System.Drawing.Size(60, 20)
        Me.kill3.TabIndex = 4
        '
        'kill2
        '
        Me.kill2.Location = New System.Drawing.Point(317, 105)
        Me.kill2.Name = "kill2"
        Me.kill2.Size = New System.Drawing.Size(60, 20)
        Me.kill2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Kill pulsesvr"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Kill rpp4app"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Kill rpp4app"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(29, 131)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 49)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "TFTP rpp4bin File"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(29, 186)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(138, 49)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "reboot"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(29, 296)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(138, 49)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Kill Processes again"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(29, 351)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(138, 49)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "TFTP applicaton to RPP4"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(29, 241)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(138, 49)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Start Again"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(317, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Wait for board to reboot. Wait 5 seconds after LED starts blinking."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(177, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(322, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Enter the PS numbers for pulsesvr and rpp4app before proceeding."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(29, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 49)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Finish"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 277)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(322, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Enter the PS numbers for pulsesvr and rpp4app before proceeding."
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 496)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.kill2)
        Me.Controls.Add(Me.kill3)
        Me.Controls.Add(Me.kill1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Program Xilinx"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Public ProcID As Integer

    Private Sub start_telnet()
        kill1.Text = ""
        kill2.Text = ""
        kill3.Text = ""

        ProcID = Shell("C:\Local Data\Hyperterminal\hypertrm.exe", AppWinStyle.NormalFocus)

        SendKeys.Send("Telnet RPP4")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")
        Thread.Sleep(100)
        SendKeys.Send("{DOWN}")

        '   SendKeys.Send("192.168.16.139")
        Thread.Sleep(500)
        SendKeys.Send(ip_address)

        Thread.Sleep(500)
        SendKeys.Send("{TAB}")
        Thread.Sleep(100)
        SendKeys.Send("{TAB}")
        Thread.Sleep(100)
        SendKeys.Send("{TAB}")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)
        SendKeys.Send("root")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)
        SendKeys.SendWait("ps")
        Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.Green
        Call start_telnet()

    End Sub

   
 
    Private Sub kill_telnet()
        AppActivate(ProcID)
        SendKeys.SendWait("%{F4}")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
        SendKeys.Send("{RIGHT}")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents kill1 As System.Windows.Forms.TextBox
    Friend WithEvents kill3 As System.Windows.Forms.TextBox
    Friend WithEvents kill2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.Green
        Call kill_ps()
    End Sub
    Private Sub kill_ps()
        AppActivate(ProcID)
        If IsNumeric(kill1.Text) = True Then
            SendKeys.SendWait("kill " & kill1.Text)
            Thread.Sleep(100)
            SendKeys.Send("{ENTER}")
            Thread.Sleep(100)
        End If
        If IsNumeric(kill2.Text) = True Then
            SendKeys.SendWait("kill " & kill2.Text)
            Thread.Sleep(100)
            SendKeys.Send("{ENTER}")
            Thread.Sleep(100)
        End If
        If IsNumeric(kill3.Text) = True Then
            SendKeys.SendWait("kill " & kill3.Text)
            Thread.Sleep(100)
            SendKeys.Send("{ENTER}")
            Thread.Sleep(100)
        End If
        Thread.Sleep(500)
        SendKeys.SendWait("ps")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")

        kill1.Text = ""
        kill2.Text = ""
        kill3.Text = ""

    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.Green

        AppActivate(ProcID)

        SendKeys.Send("cd /")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(100)
        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4.bin")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(100)
        SendKeys.Send("/etc/config/update-fpga.sh")
        Thread.Sleep(100)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(100)


    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Button5.BackColor = Color.Green
        Call reboot_telnet()
    End Sub
    Private Sub reboot_telnet()
        AppActivate(ProcID)
        SendKeys.Send("reboot")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(5000)
        Call kill_telnet()

    End Sub
    Friend WithEvents Button6 As System.Windows.Forms.Button

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Button6.BackColor = Color.Green

        Call kill_ps()
    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Button7.BackColor = Color.Green

        AppActivate(ProcID)

        SendKeys.Send("cd /usr/bin")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(500)
        SendKeys.Send("tftp -g " & computer_ip_address & " -r pulsesvr")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(3000)
        SendKeys.Send("tftp -g " & computer_ip_address & " -r rpp4app")
        Thread.Sleep(1000)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(3000)
        SendKeys.Send("chmod 777 rpp4app")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)
        SendKeys.Send("chmod 777 pulsesvr")
        Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Thread.Sleep(200)

    End Sub
    Friend WithEvents Button8 As System.Windows.Forms.Button

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Button8.BackColor = Color.Green
        Call start_telnet()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Call reboot_telnet()
        Button2.BackColor = Color.Green
        Button2.Refresh()
        Thread.Sleep(1000)
        Me.Close()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label

 
    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MsgBox("Make sure TFTP program is opened.")
    End Sub
End Class
