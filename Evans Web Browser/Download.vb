﻿Imports System.Net

Public Class Download
    Dim WithEvents Download As WebClient
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Download = New WebClient
            Dim DLink As String = Download.DownloadString("https://dl.dropboxusercontent.com/s/lvg53aa4kuzgcc9/webbrowser_url.txt?dl=0")
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Download.DownloadFileAsync(New Uri(DLink), (SaveFileDialog1.FileName))
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Une erreur s'est produite lors du téléchargement", vbCritical)
            End
        End Try

    End Sub
    Private Sub Download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Try
            If ProgressBar1.Value = 100 Then
                System.Threading.Thread.Sleep(500)
                Process.Start(SaveFileDialog1.FileName)
                End
            End If
        Catch ex As Exception
            MsgBox("Une erreur s'est produite lors de l'exécution du programme", vbCritical)
        End Try
    End Sub
End Class