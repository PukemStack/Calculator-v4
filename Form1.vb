Public Class Main_Form
    ' Variables
    Dim texts As Double
    Dim textz As Double
    Dim operation As Int16
    Dim number As Boolean
    Dim op As String
    Dim result As Double

    Sub Clear()
        Screen.Text = "0"
        status.Text = ""
        number = True
        operation = 0
        point.Enabled = True
        texts = 0
        textz = 0
        op = ""
        Screen.SelectionFont = New Font("Segoe UI Semibold", 20)
        Screen.RightToLeft = RightToLeft.Yes
    End Sub

    Sub Disable()
        plus.Enabled = False
        subtract.Enabled = False
        muliti.Enabled = False
        dibv.Enabled = False
    End Sub

    Sub Enable()
        plus.Enabled = True
        subtract.Enabled = True
        muliti.Enabled = True
        dibv.Enabled = True
    End Sub

    ' Cast sender to Button, if it's not a Button then exit.
    Private Sub button_click(sender As Object, e As EventArgs)
        Dim btn As Button = TryCast(sender, Button)
        Dim btnText As String = btn.Text.Trim()
        Dim parsedNum As Integer

        ' Only handle clicks where the button text is a valid integer (number buttons).
        If Not Integer.TryParse(btnText, parsedNum) Then Exit Sub

        ' Append or replace the textbox content as appropriate.
        If Screen.Text = "0" Then
            Screen.Text = btnText
        Else
            Screen.Text &= btnText
        End If
    End Sub

    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        For Each c As Control In Controls
            If c.GetType() = GetType(Button) Then AddHandler c.Click, AddressOf button_click
        Next
    End Sub

    ' Consolidated operator handler for +, -, x, /
    Private Sub Operator_Click(sender As Object, e As EventArgs) Handles plus.Click, subtract.Click, muliti.Click, dibv.Click
        Dim btn As Button = TryCast(sender, Button)
        If btn Is Nothing Then Exit Sub

        op = btn.Text.Trim()
        texts = Screen.Text.Trim()
        status.Text = $"{texts} {op}"
        Screen.Text = "0"
        number = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Deleteoyt.Click
        If Screen.Text.Length > 1 Then
            Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1)
        ElseIf Screen.Text.Length = 1 Then
            Screen.Text = "0"
            Enable()
            point.Enabled = True
        ElseIf Screen.Text = "," Then
            Screen.Text = "0"
            Enable()
            point.Enabled = True
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Clear()
        Enable()
    End Sub

    Private Sub Equality_Click(sender As Object, e As EventArgs) Handles Equality.Click
        If number = False Then
            textz = Screen.Text.Trim()
            Select Case op
                Case "+"
                    result = texts + textz
                Case "–"
                    result = texts - textz
                Case "x"
                    result = texts * textz
                Case "÷"
                    If textz = 0 Then
                        MessageBox.Show("An error occurred while attempting a calculation. The application will now exit.", "", MessageBoxButtons.OK)
                        Application.Exit()
                    Else
                        result = texts / textz
                    End If
            End Select
            status.Text = ""
            Screen.Text = $"{result}"
        End If
    End Sub

    Private Sub Disability(parent As Control)
        For Each contrl As Control In parent.Controls
            If TypeOf contrl Is Button Then contrl.Enabled = False
        Next
    End Sub

    Private Sub point_Click(sender As Object, e As EventArgs) Handles point.Click
        Screen.RightToLeft = RightToLeft.No
        Screen.SelectionFont = New Font("Segoe UI", 9, FontStyle.Bold)
        Screen.Text = "There's a bug going on and I dont want anyone to see it."
        point.Enabled = False
        Disability(Me)
    End Sub

    Private Sub hyphen_Click(sender As Object, e As EventArgs) Handles hyphen.Click
        Ads.Show()  ' Shows another box
    End Sub
End Class
