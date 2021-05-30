Imports CefSharp.WinForms
Imports CefSharp
Imports System.Net
Imports System.IO

Public Class Main

    Private WithEvents browser As ChromiumWebBrowser
    Dim Version As String = "2.3"

    Public Sub New()
        InitializeComponent()

        Dim settings As New CefSettings()
        CefSharp.Cef.Initialize(settings)

        browser = New ChromiumWebBrowser("") With {
            .Dock = DockStyle.Fill
        }
        PanelWeb.Controls.Add(browser)

    End Sub
    Sub ChkUpdt()
        'Verifie MAJ au démarrage
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/s2o826cydnm0j5z/webbrowser_version.txt?dl=0")
            If Version = LastUpdt Then
            ElseIf LastUpdt = "0" Then

            Else
                Label3.Visible = True
                Label6.Visible = True
                LinkLabel1.Visible = True
                If Label7.Text = "1" Then
                    Dim UpdateBoxFR As New MsgBoxResult
                    UpdateBoxFR = MsgBox("Une nouvelle version du logiciel est disponible !" & vbNewLine & "Voulez-vous la télécharger maintenant ?", vbYesNo + vbQuestion, "Mise à jour disponible")
                    If UpdateBoxFR = vbYes Then
                        Download.ShowDialog()
                    ElseIf UpdateBoxFR = vbNo Then

                    End If
                ElseIf Label7.Text = "2" Then
                    Dim UpdateBoxEN As New MsgBoxResult
                    UpdateBoxEN = MsgBox("A new update is available !" & vbNewLine & "Do you want to download it now ?", vbYesNo + vbQuestion, "Update available")
                    If UpdateBoxEN = vbYes Then
                        Download.ShowDialog()
                    ElseIf UpdateBoxEN = vbNo Then

                    End If
                Else

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub language()
        Try
            Dim langopenfile As New OpenFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Evans Web Browser\"
            langopenfile.FileName = AppDataFolder & "lang.ini"
            Dim lang As New StreamReader(langopenfile.FileName)
            Label7.Text = lang.ReadLine
            If Label7.Text = "1" Then
                FichierToolStripMenuItem.Text = "&Fichier"
                FichierToolStripMenuItem1.Text = "&Navigateur"
                FenêtreToolStripMenuItem.Text = "F&enêtre"
                AProposToolStripMenuItem.Text = "À &propos"
                OuvrirToolStripMenuItem.Text = "&Ouvrir"
                FermerToolStripMenuItem.Text = "&Quitter"
                PrécedentToolStripMenuItem.Text = "&Précédent"
                ActualiserToolStripMenuItem.Text = "&Actualiser"
                OutilsDeDToolStripMenuItem.Text = "&Outils de développement"
                AfficherAuPremierPlanToolStripMenuItem.Text = "&Afficher au premier plan"
                OpacitéToolStripMenuItem.Text = "&Opacité"
                ÀProposToolStripMenuItem.Text = "À propos de &Evans Web Browser"
                Label5.Text = "Ouvrir"
                Button3.Text = "Fermer"
                Button2.Text = "Ouvrir"
                Label3.Text = "/!\ Une nouvelle version est diponible !"
                LinkLabel1.Text = "Cliquez ici"
                Label6.Text = ", pour l'installer"
                LangueToolStripMenuItem.Text = "&Langue"
                ÀProposDeChromiumToolStripMenuItem.Text = "À propos de &Chromium Embedded Framework"

                lang.Close()
            ElseIf Label7.Text = "2" Then
                FichierToolStripMenuItem.Text = "&File"
                FichierToolStripMenuItem1.Text = "&Browser"
                FenêtreToolStripMenuItem.Text = "&Window"
                AProposToolStripMenuItem.Text = "&About"
                OuvrirToolStripMenuItem.Text = "&Open"
                FermerToolStripMenuItem.Text = "&Exit"
                PrécedentToolStripMenuItem.Text = "&Back"
                SuivantToolStripMenuItem.Text = "&Forward"
                ActualiserToolStripMenuItem.Text = "&Refresh"
                OutilsDeDToolStripMenuItem.Text = "&Development tools"
                AfficherAuPremierPlanToolStripMenuItem.Text = "&Show in the foreground"
                OpacitéToolStripMenuItem.Text = "&Opacity"
                ÀProposToolStripMenuItem.Text = "About &Evans Web Browser"
                Label5.Text = "Open"
                Button3.Text = "Close"
                Button2.Text = "Open"
                Label3.Text = "/!\ A new update is available !"
                LinkLabel1.Text = "Click here"
                Label6.Text = ", to install it"
                LangueToolStripMenuItem.Text = "&Language"
                ÀProposDeChromiumToolStripMenuItem.Text = "About &Chromium Embedded Framework"

                lang.Close()
            ElseIf Label7.Text = "0" Then
                lang.Close()
                Process.Start("language.exe")
                End
            Else
                MsgBox("lang.ini : Incorrect value", vbCritical)
            End If
        Catch ex As Exception
            Dim langsavefile As New SaveFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Evans Web Browser\"
            langsavefile.FileName = AppDataFolder & "lang.ini"
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim langsave As New StreamWriter(langsavefile.FileName)
            langsave.Write(Label8.Text)
            langsave.Close()
            Process.Start("language.exe")
            End
        End Try
    End Sub
    Sub DevMode()
        Try
            Dim devmodeopenfile As New OpenFileDialog
            Dim devmodelabel As New Label
            devmodeopenfile.FileName = "DevMode.ini"
            Dim DM As New StreamReader(devmodeopenfile.FileName)
            devmodelabel.Text = DM.ReadLine
            If devmodelabel.Text = "1" Then
                Label7.Visible = True
                ToolStripSeparator4.Visible = True
                DevModeToolStripMenuItem.Visible = True
                Me.Text = "Evans Web Browser (DevMode activé)"
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ÀProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÀProposToolStripMenuItem.Click
        If Panel2.Visible = True Then
            Panel2.Hide()
            Panel1.Show()
        Else
            Panel1.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Hide()
    End Sub

    Private Sub FermerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerToolStripMenuItem.Click
        End
    End Sub

    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        If Panel2.Visible = True Then
        Else
            TextBox1.Text = ""
            TextBox1.Text = browser.Address
            AcceptButton = Button2
            Panel2.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            If Label7.Text = 1 Then
                MsgBox("Vous devez entrer une URL !", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Please enter URL in the text box !", MsgBoxStyle.Exclamation)
            End If

        Else
            browser.Load(TextBox1.Text)
            Panel2.Hide()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Hide()
    End Sub

    Private Sub AfficherAuPremierPlanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherAuPremierPlanToolStripMenuItem.Click
        If AfficherAuPremierPlanToolStripMenuItem.Checked = False Then
            AfficherAuPremierPlanToolStripMenuItem.Checked = True
            TopMost = True
        ElseIf AfficherAuPremierPlanToolStripMenuItem.Checked = True Then
            AfficherAuPremierPlanToolStripMenuItem.Checked = False
            TopMost = False
        End If
    End Sub

    Private Sub PrécedentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrécedentToolStripMenuItem.Click
        browser.Back
    End Sub

    Private Sub SuivantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuivantToolStripMenuItem.Click
        browser.Forward
    End Sub

    Private Sub ActualiserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualiserToolStripMenuItem.Click
        browser.Reload
    End Sub

    Private Sub OutilsDeDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutilsDeDToolStripMenuItem.Click
        browser.ShowDevTools
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        language()
        DevMode()
        ChkUpdt()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Label7.Text = "1" Then
            LinkLabelFR()
        ElseIf Label7.Text = "2" Then
            LinkLabelEN()
        Else

        End If
    End Sub
    Sub LinkLabelFR()
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/s2o826cydnm0j5z/webbrowser_version.txt?dl=0")
            Dim UpdateBox As New MsgBoxResult
            UpdateBox = MsgBox("Une nouvelle version du logiciel est disponible !" & vbNewLine & "Voulez-vous la télécharger maintenant ?", vbYesNo + vbQuestion, "Mise à jour disponible")
            If UpdateBox = vbYes Then
                Download.ShowDialog()
            ElseIf UpdateBox = vbNo Then

            End If
        Catch ex As Exception
            MsgBox("An error has occured!" & vbNewLine & "Please try again later!", vbCritical)
        End Try
    End Sub
    Sub LinkLabelEN()
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/s2o826cydnm0j5z/webbrowser_version.txt?dl=0")
            Dim UpdateBox As New MsgBoxResult
            UpdateBox = MsgBox("A new update is available !" & vbNewLine & "Do you want to download it now ?", vbYesNo + vbQuestion, "Update available")
            If UpdateBox = vbYes Then
                Download.ShowDialog()
            ElseIf UpdateBox = vbNo Then

            End If
        Catch ex As Exception
            MsgBox("An error has occured!" & vbNewLine & "Please try again later!", vbCritical)
        End Try
    End Sub


    Private Sub AfficherNuméroVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherNuméroVersionToolStripMenuItem.Click
        MsgBox(Version)
    End Sub

    Private Sub AfficherMessageMAJToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherMessageMAJToolStripMenuItem.Click
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/s2o826cydnm0j5z/webbrowser_version.txt?dl=0")
            Dim UpdateBox As New MsgBoxResult
            UpdateBox = MsgBox("Une nouvelle version du logiciel est disponible !" & vbNewLine & "Voulez-vous la télécharger maintenant ?", vbYesNo + vbQuestion, "Mise à jour disponible")
            If UpdateBox = vbYes Then
                Download.ShowDialog()
            ElseIf UpdateBox = vbNo Then

            End If
        Catch ex As Exception
            MsgBox("An error has occured!" & vbNewLine & "Please try again later!", vbCritical)
        End Try
    End Sub

    Private Sub SélecteurDeFenêtresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SélecteurDeFenêtresToolStripMenuItem.Click
        FormSelect.Show()
    End Sub

    Private Sub LangueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LangueToolStripMenuItem.Click
        Process.Start("language.exe")
        End
    End Sub

    Private Sub ÀProposDeChromiumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÀProposDeChromiumToolStripMenuItem.Click
        browser.Load("chrome://version/")
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ToolStripMenuItem2.Checked = True
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.1
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = True
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.2
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = True
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.3
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = True
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.4
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = True
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.5
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = True
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.6
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = True
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.7
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = True
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.8
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = True
        ToolStripMenuItem11.Checked = False
        Me.Opacity = 0.9
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = True
        Me.Opacity = 1
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Panel1.Hide()

    End Sub
End Class
