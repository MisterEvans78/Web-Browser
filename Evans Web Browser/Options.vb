Imports System.IO

Public Class Options
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim langsavefiledialog As New SaveFileDialog
        Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Evans Web Browser\"
        langsavefiledialog.FileName = AppDataFolder & "lang.ini"
        Dim langwriter As New StreamWriter(langsavefiledialog.FileName)
        If ComboBox1.Text = "Français" Then
            Try
                langwriter.Write("1")
                langwriter.Close()
                Main.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop", vbCritical)
                End
            End Try

        ElseIf ComboBox1.Text = "English" Then
            Try
                langwriter.Write("2")
                langwriter.Close()
                Main.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop", vbCritical)
                End
            End Try
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please choose a language", vbExclamation, "Select language")
            langwriter.Close()
        End If
    End Sub
End Class