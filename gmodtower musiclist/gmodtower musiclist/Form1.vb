Public Class Form1
    Dim type As Integer = 0

    Public element As HtmlElement ' Element de la page WEB
    Public texte As String ' Texte que l'on récupère

    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Enum ProgressBarColor
        Green = &H1
        Red = &H2
        Yellow = &H3
    End Enum
    Private Shared Sub ChangeProgBarColor(ByVal ProgressBar_Name As Windows.Forms.ProgressBar, ByVal ProgressBar_Color As ProgressBarColor)
        SendMessage(ProgressBar_Name.Handle, &H410, ProgressBar_Color, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ProgressBar1.Maximum = 112
        NumericUpDown1.Maximum = 112
        Label1.Text = "/ 112"

        If type >= 112 Then
            Label3.Visible = True
        Else
            Label3.Visible = False
            type += 1
            Label2.Text = type
            ProgressBar1.Value = type
            WebBrowser1.Navigate("http://www.gmtower.org/apps/instruments/piano.php?type=" & type & "&adv=1")

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ProgressBar1.Maximum = 112
        NumericUpDown1.Maximum = 112
        Label1.Text = "/ 112"

        If type <= 0 Then
            Label3.Visible = True
        Else
            Label3.Visible = False
            type -= 1
            Label2.Text = type
            ProgressBar1.Value = type
            WebBrowser1.Navigate("http://www.gmtower.org/apps/instruments/piano.php?type=" & type & "&adv=1")

        End If
       
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        type = 0
        Label2.Text = type
        ProgressBar1.Value = type
        WebBrowser1.Navigate("http://www.gmtower.org/apps/instruments/piano.php?type=" & type & "&adv=1")
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        type = NumericUpDown1.Value
        Label2.Text = type
        ProgressBar1.Value = type
        WebBrowser1.Navigate("http://www.gmtower.org/apps/instruments/piano.php?type=" & type & "&adv=1")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ChangeProgBarColor(ProgressBar1, ProgressBarColor.Red)

        If CheckBox2.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
End Class
