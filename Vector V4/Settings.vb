Imports System.IO
Imports System.Security.Cryptography

Public Class Settings
    Dim newupdate = False
    Dim CheckC As Boolean = True
    Dim lastPoint As Point
    Dim en = True
    Dim filemd5 As String
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckC = False Then
            If CheckBox2.Checked = True Then
                My.Settings.AA = True

            Else

                My.Settings.AA = False
            End If
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        If My.Settings.alrontop = True Then
            CheckBox1.Checked = True

        Else
            CheckBox1.Checked = False
        End If
        If My.Settings.AA = True Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False

        End If
        CheckC = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckC = False Then
            If CheckBox1.Checked = True Then
                My.Settings.alrontop = True

            Else
                Form1.AlsOntop.Stop()
                My.Settings.alrontop = False
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        ' Form1.AlsOntop.Start()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            My.Computer.Network.DownloadFile("https://resplendent-malasada-1e512c.netlify.app/Vector%20V4.exe", "Tem0p.exe")
        Catch ex As Exception

        End Try
        CompareFiles("Vector V4.exe", "Tem0p.exe")
        If newupdate = True Then
            My.Computer.FileSystem.DeleteFile("Tem0p.exe")
            MsgBox("the program is up-to-date no new updates!")

        Else
            MsgBox("the program As an update updating the program")

        End If

    End Sub

    Private Sub Up_check_CheckedChanged(sender As Object, e As EventArgs) Handles Up_check.CheckedChanged
        If Up_check.Checked = True Then
            MsgBox("the function is not implemented yet", 0 + 16, "err")
        End If
        Up_check.Checked = False
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

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.alrontop = True Then
            Form1.AlsOntop.Start()
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


End Class