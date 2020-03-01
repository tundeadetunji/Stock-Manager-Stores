Imports System.Data.OleDb
Public Class UserAccess


#Region "Help"

	Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
		m_.Help(My.Application.Info.AssemblyName, Me)
	End Sub

	Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles HelpButton.Click
		Help_Click(sender, e)
	End Sub

#End Region

#Region "Feedback"
	Private Sub VoiceOnly_Click(sender As Object, e As EventArgs) Handles VoiceOnly.Click
		Dim u As ToolStripMenuItem = sender
		Select Case u.Checked
			Case False
				u.Checked = True
				If MessagePromptWithVoice.Checked = True Then
					f.SaveAccompanyPromptWithVoiceFeedback(False)
					MessagePromptWithVoice.Checked = False
				End If
				If MessagePromptOnly.Checked = True Then
					f.SaveUsePrompt(False)
					MessagePromptOnly.Checked = False
				End If
			Case True
				If MessagePromptWithVoice.Checked = False And MessagePromptOnly.Checked = False Then
					u.Checked = True
				ElseIf MessagePromptWithVoice.Checked = True Or MessagePromptOnly.Checked = True Then
					u.Checked = False
				End If
		End Select
		f.MarkUseVoiceFeedback(u.Checked, sender)

	End Sub

	Private Sub MessagePromptWithVoice_Click(sender As Object, e As EventArgs) Handles MessagePromptWithVoice.Click
		Dim ampwvf As ToolStripMenuItem = sender
		Select Case ampwvf.Checked
			Case False
				ampwvf.Checked = True
				If VoiceOnly.Checked = True Then
					f.SaveUseVoiceFeedback(False)
					VoiceOnly.Checked = False
				End If
				If MessagePromptOnly.Checked = True Then
					f.SaveUsePrompt(False)
					MessagePromptOnly.Checked = False
				End If
			Case True
				If VoiceOnly.Checked = False And MessagePromptOnly.Checked = False Then
					ampwvf.Checked = True
				ElseIf VoiceOnly.Checked = True Or MessagePromptOnly.Checked = True Then
					ampwvf.Checked = False
				End If
		End Select
		f.MarkAccompanyPromptWithVoiceFeedback(ampwvf.Checked, sender)

	End Sub

	Private Sub MessagePromptOnly_Click(sender As Object, e As EventArgs) Handles MessagePromptOnly.Click
		Dim mp As ToolStripMenuItem = sender
		Select Case mp.Checked
			Case False
				mp.Checked = True
				If VoiceOnly.Checked = True Then
					f.SaveUseVoiceFeedback(False)
					VoiceOnly.Checked = False
				End If
				If MessagePromptWithVoice.Checked = True Then
					f.SaveAccompanyPromptWithVoiceFeedback(False)
					MessagePromptWithVoice.Checked = False
				End If
			Case True
				If VoiceOnly.Checked = False And MessagePromptWithVoice.Checked = False Then
					mp.Checked = True
				ElseIf VoiceOnly.Checked = True Or MessagePromptWithVoice.Checked = True Then
					mp.Checked = False
				End If
		End Select
		f.MarkUsePrompt(mp.Checked, sender)

	End Sub
#End Region

#Region "Language"
	Private Sub MarkLanguage()
		Select Case l.selected_language.ToString.ToLower
			Case "english"
				l.MarkLanguage(EnglishLanguage, EnglishLanguage, FrenchLanguage, ThaiLanguage, YorubaLanguage)
			Case "french"
				l.MarkLanguage(FrenchLanguage, EnglishLanguage, FrenchLanguage, ThaiLanguage, YorubaLanguage)
			Case "thai"
				l.MarkLanguage(ThaiLanguage, EnglishLanguage, FrenchLanguage, ThaiLanguage, YorubaLanguage)
			Case "yoruba"
				l.MarkLanguage(YorubaLanguage, EnglishLanguage, FrenchLanguage, ThaiLanguage, YorubaLanguage)
		End Select
	End Sub

#End Region

#Region "Standard"
	Public Sub HideItems()
		With MenuStrip
			.Top = Login.Top - 1
			.Left = 1
			.Visible = True
		End With
	End Sub

	Private Sub ClearCart()
		Try
			Dim delete_cart_query As String = "DELETE FROM [Cart]"
			Using delete_cart_conn As New OleDbConnection(cart_connection_string)
				Using delete_cart_comm As New OleDbCommand()
					With delete_cart_comm
						.Connection = delete_cart_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = delete_cart_query
					End With
					Try
						delete_cart_conn.Open()
						delete_cart_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try

	End Sub
#End Region

	Private Sub UserAccess_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, Login, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False, True) : HideItems()
	End Sub

	Private Sub UserAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'language
		MarkLanguage()

		'voice feedback - accompany, voice only, prompt only
		f.InitialMarkVoiceFeedback(MessagePromptOnly, MessagePromptWithVoice, VoiceOnly)
		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)

		'dialog
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, Login, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False, True) : HideItems()
		'first thing
		ConnectString()

		'begin
		GetValues()

	End Sub

	Public Sub GetValues()
		'empty cart
		If Me.CartTableAdapter.Count_ > 0 Then
			ClearCart()
		End If

	End Sub

	Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
		'connect to server through database

		'if username and password match, and is enabled, then...
		If Me.StockUsersTableAdapter.Count_Username_UserPassword_IsEnabled(Username.Text, Password.Text, True) < 1 Then
			f.Feedback("Your username and password do not match, or is inaccessible. Please contact your admin.", "Login Denied. Credential is not accessible.")
			Exit Sub
		End If

		'create a session_id
		session_id = o.NewID()
		username_ = Username.Text

		'log
		LogEvent("Main Login", "User logged in")

		'login (close this window and open main)
		If VoiceOnly.Checked = True Or MessagePromptWithVoice.Checked = True Then
			f.Feedback("", "Welcome")
		End If

		Main.Show()
		Me.Close()

	End Sub

	Private Sub Username_TextChanged(sender As Object, e As EventArgs) Handles Username.TextChanged
		o.SetUsernameTextChange(sender, "Username")
	End Sub

	Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
		o.SetPasswordChange(sender, "Password")
	End Sub

End Class