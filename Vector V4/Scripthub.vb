Imports WeAreDevs_API
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Imports System.Net
Imports System.Reflection

Public Class Scripthub
    Dim lastPoint As Point
    Dim api As ExploitAPI = New ExploitAPI
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged ''loadstring(game:HttpGet("https://raw.githubusercontent.com/RegularVynixu/Vynixius/main/Doors/Script.lua"))()
        Try
            If ListBox1.SelectedItem.ToString = "DarkDex" Then
                RichTextBox1.Text = "Dex Explorer, a well-liked exploit tool that some players use to control and investigate the game's code, is one such cheat tool. Dex Explorer is frequently included in the ""CoreGui"" or ""PlayerGui"". bild367×522 49 KB. Dex Explorer allows users to view and edit game objects, players, and even scripts in real-time"
            ElseIf ListBox1.SelectedItem.ToString = "Unnamed ESP" Then
                RichTextBox1.Text = "Extrasensory perception, often read incorrectly as ""Extrasensory precision"" (ESP) in video games displays contextual information such as the health, name, equipment, position and/or orientation of other participants as navigation/directional markers, which would normally be hidden from game players."
            ElseIf ListBox1.SelectedItem.ToString = "Remote Spy" Then
                RichTextBox1.Text = ""
            ElseIf ListBox1.SelectedItem.ToString = "Doors Script" Then
                RichTextBox1.Text = "A Cheat GUI for the game DOORS"
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If api.isAPIAttached = True Then
            If ListBox1.SelectedItem.ToString = "DarkDex" Then
                Dim fileReader As String
                fileReader = My.Computer.FileSystem.ReadAllText("Scripts\Dex Explorer V2.txt") 'loadstring(game:HttpGet("https://pastebin.com/raw/bCghX33W", true))()
                api.SendLuaScript(fileReader)
            ElseIf ListBox1.SelectedItem.ToString = "Unnamed ESP" Then 'url loadstring(game:HttpGet('https://raw.githubusercontent.com/ic3w0lf22/Unnamed-ESP/master/UnnamedESP.lua'))()
                api.SendLuaScript("loadstring(game:HttpGet('https://raw.githubusercontent.com/ic3w0lf22/Unnamed-ESP/master/UnnamedESP.lua'))()")

            ElseIf ListBox1.SelectedItem.ToString = "Remote Spy" Then
                api.SendLuaScript("loadstring(game:HttpGet(""https: //pastebin.com/raw/bCghX33W"", true))()")
            ElseIf ListBox1.SelectedItem.ToString = "Doors Script" Then
                api.SendLuaScript("loadstring(game:HttpGet(""https://raw.githubusercontent.com/RegularVynixu/Vynixius/main/Doors/Script.lua""))()")
            End If
        Else
            MsgBox("Looks like vector is not injected. please inject the exploit", 0 + 16, "ERROR")
        End If


    End Sub

    Private Sub Scripthub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Scripthub_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Form1.Button5.Enabled = True
        Form1.AlsOntop.Start()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        lastPoint = New Point(e.X, e.Y)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Me.Left += e.X - lastPoint.X
            Me.Top += e.Y - lastPoint.Y
        End If
    End Sub
End Class