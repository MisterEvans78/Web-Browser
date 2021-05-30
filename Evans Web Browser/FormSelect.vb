Public Class FormSelect
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ListBox1.SelectedItem = "Form1" Then
                Main.Show()
            ElseIf ListBox1.SelectedItem = "Form2" Then
                Download.Show()
            ElseIf ListBox1.SelectedItem = "Form3" Then
                Options.Show()
            ElseIf ListBox1.SelectedItem = "Form4" Then
                Me.Show()
            End If
        Catch ex As Exception
            MsgBox("Impossible d'ouvrir la fenêtre", vbCritical)
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "Form1" Then
            Label1.Text = "Fenêtre principale"
        ElseIf ListBox1.SelectedItem = "Form2" Then
            Label1.Text = "Fenêtre Téléchargement MAJ"
        ElseIf ListBox1.SelectedItem = "Form3" Then
            Label1.Text = "Fenêtre Choisir la langue"
        ElseIf ListBox1.SelectedItem = "Form4" Then
            Label1.Text = "La fenêtre actuel"
        End If
    End Sub
End Class