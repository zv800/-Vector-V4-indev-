Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports WeAreDevs_API
Imports System.IO
Imports System.Net
Imports System.Reflection

Public Class Form1
    Dim newupdate = False
    Dim lastPoint As Point
    Dim Api As New ExploitAPI
    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.alrontop = True
        Try
            My.Computer.Network.DownloadFile("https://resplendent-malasada-1e512c.netlify.app/Vector%20V4.exe", "Tem0p.exe")
        Catch ex As Exception

        End Try
        CompareFiles("Vector V4.exe", "Tem0p.exe")
        If newupdate = True Then
            My.Computer.FileSystem.DeleteFile("Tem0p.exe")

        Else
            My.Computer.FileSystem.DeleteFile("Tem0p.exe")
            MsgBox("Update detected Consider downloading the new update.", 0 + 64, "UPDATE")

        End If


        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua
        Try
            ListBox1.Items.Clear()
            Functions.PopulateListBox(ListBox1, "./Scripts", "*.txt")
            Functions.PopulateListBox(ListBox1, "./Scripts", "*.lua")
        Catch ex As Exception
            AlsOntop.Stop()

            MsgBox("Some important files seem to be missing some features may not work as intended", 0 + 16, "ERROR")

            AlsOntop.Start()
        End Try
        fade_in()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AlsOntop.Stop()
        MsgBox("this Exploit was made by ZV800 if you have any questions you can contact me at denverv1000@gmail.com", 0 + 64, "")
        AlsOntop.Start()
    End Sub

    Private Sub SaveAu_Tick(sender As Object, e As EventArgs) Handles SaveAu.Tick

        s_bw.RunWorkerAsync()
    End Sub

    Private Sub Save_bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub s_bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles s_bw.DoWork


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Inj_btn.Click
        If Api.isAPIAttached = False Then

            Dim p() As Process


            p = Process.GetProcessesByName("RobloxPlayerBeta")
            If p.Count > 0 Then
                Api.LaunchExploit()
                Inj_btn.Enabled = False
            Else
                AlsOntop.Stop()
                MsgBox("Vector did not detect a instance of Roblox open. Please try again once you have joined a game", 0 + 16, "ERROR")
                AlsOntop.Start()
            End If
        End If
    End Sub

    Private Sub CheckForInj_Tick(sender As Object, e As EventArgs) Handles CheckForInj.Tick
        If Api.isAPIAttached = True Then
            Inj_btn.Enabled = False
        Else
            CheckForInj1.Start()
            Inj_btn.Enabled = True
        End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Api.isAPIAttached = True Then
            Api.SendLuaScript(FastColoredTextBox1.Text)
        Else
            AlsOntop.Stop()
            MsgBox("Looks like vector is not injected. please inject the exploit", 0 + 16, "ERROR")

            AlsOntop.Start()
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        OpenFileDialog1.Title = "Please select a lua file"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "lua Files|*.lua"
        AlsOntop.Stop()
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AlsOntop.Start()
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            FastColoredTextBox1.Text = fileReader
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SaveFileDialog1.Filter = "LUA Files (*.lua*)|*.lua"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
         Then
            My.Computer.FileSystem.WriteAllText _
            (SaveFileDialog1.FileName, FastColoredTextBox1.Text, True)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FastColoredTextBox1.Text = ""
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        FastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{ListBox1.SelectedItem}")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ListBox1.Items.Clear()
        Functions.PopulateListBox(ListBox1, "./Scripts", "*.txt")
        Functions.PopulateListBox(ListBox1, "./Scripts", "*.lua")
    End Sub

    Private Sub CheckForInj1_Tick(sender As Object, e As EventArgs) Handles CheckForInj1.Tick
        If Api.isAPIAttached = True Then
            CheckForInj1.Stop()
            Dim wb As WebClient = New WebClient()
            Dim Script As String = wb.DownloadString("https://pastebin.com/raw/sgZhDRuw")
            Api.SendLuaScript(Script)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

    End Sub

    Private Sub AA_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub AA_Tick_1(sender As Object, e As EventArgs) Handles AA.Tick
        If Api.isAPIAttached = False Then

            Dim p() As Process


            p = Process.GetProcessesByName("RobloxPlayerBeta")
            If p.Count > 0 Then
                If My.Settings.AA = True Then
                    Api.LaunchExploit()
                    Inj_btn.Enabled = False
                End If
            Else

            End If
        End If
    End Sub

    Private Sub AlsOntop_Tick(sender As Object, e As EventArgs) Handles AlsOntop.Tick
        If My.Settings.alrontop = True Then
            Try


                Me.TopMost = True


            Catch ex As Exception

            End Try
        Else
            AlsOntop.Stop()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AlsOntop.Stop()
        Settings.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AlsOntop.Stop()
        Scripthub.ShowDialog()
    End Sub

    Private Sub offAlrontopbuggic_Tick(sender As Object, e As EventArgs) Handles offAlrontopbuggic.Tick
        If My.Settings.alrontop = False Then
            AlsOntop.Stop()
        End If
    End Sub

    Public Function CompareFiles(ByVal file1FullPath As String, ByVal file2FullPath As String) As Boolean

        If Not File.Exists(file1FullPath) Or Not File.Exists(file2FullPath) Then
            'One or both of the files does not exist.
            newupdate = False
        End If

        If file1FullPath = file2FullPath Then
            ' fileFullPath1 and fileFullPath2 points to the same file...
            newupdate = True
        End If

        Try
            Dim file1Hash As String = hashFile(file1FullPath)
            Dim file2Hash As String = hashFile(file2FullPath)

            If file1Hash = file2Hash Then
                newupdate = True
            Else
                newupdate = False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function hashFile(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash() As Byte = md5.ComputeHash(reader)
                Return System.Text.Encoding.Unicode.GetString(hash)
            End Using
        End Using
    End Function

    Public Sub fade_in()
        For FadeIn = 0.0 To 1.1 Step 0.1
            Me.Opacity = FadeIn
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub


    'Fade out:
    Public Sub fade_out()
        For FadeOut = 90 To 10 Step -10
            Me.Opacity = FadeOut / 100
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fade_out()
    End Sub
End Class
