' First, install NuGet package: Microsoft.Web.WebView2
Imports Microsoft.Web.WebView2.WinForms

Public Class Ads
    Private webView As WebView2

    ' Implement WebBrowser component (for .NET application, not Framework)
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        webView = New WebView2()
        webView.Dock = DockStyle.Fill
        Me.Controls.Add(webView)
        webView.Source = New Uri("https://apps.microsoft.com/detail/9WZDNCRDX2WN?hl=en-us")
    End Sub
End Class