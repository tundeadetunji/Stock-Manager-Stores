Imports System.Data.OleDb
Public Class ReceiptSetting
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

#Region "Other Functions"
	Private Sub EnableButtons(state_ As Boolean)
		For Each b_ As Control In Me.Controls
			If TypeOf b_ Is Button Then
				b_.Enabled = state_
			End If
		Next
	End Sub

#End Region
	Private Sub ReceiptSetting_Activated(sender As Object, e As EventArgs) Handles Me.Activated

	End Sub

	Private Sub ReceiptSetting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

	End Sub

	Private Sub ReceiptSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'first thing
		ConnectString()

		'language
		MarkLanguage()

		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)

		'dialog
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, False, True, o.theme(), Feedback, TimeTimer, TimeLabel)

		'begin
		GetValues(sender, e)

	End Sub

	Public Sub GetValues(sender As Object, e As EventArgs)
		Try
			Me.ReceiptTableAdapter.Receipt(Me.ReceiptDataSet.Receipt)
		Catch
		End Try
		ThankYouL_TextChanged(sender, e)
		AdditionalInfoL_TextChanged(sender, e)
	End Sub

	Private Sub ThankYouL_TextChanged(sender As Object, e As EventArgs) Handles ThankYouL.TextChanged
		ThankYou.Text = ThankYouL.Text
	End Sub

	Private Sub AdditionalInfoL_TextChanged(sender As Object, e As EventArgs) Handles AdditionalInfoL.TextChanged
		AdditionalInfo.Text = AdditionalInfoL.Text
	End Sub

	Private Sub DefaultButton_Click(sender As Object, e As EventArgs) Handles DefaultButton.Click

		If f.Feedback("Really load defaults?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

		ThankYou.Text = "Thank You, Please Call Again!"
		AdditionalInfo.Text = ""

	End Sub

	Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
		If f.Feedback("Reset fields?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

		GetValues(sender, e)

	End Sub

	Private Sub CommitButton_Click(sender As Object, e As EventArgs) Handles CommitButton.Click

		If f.Feedback("Commit changes?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

		Try
			DefaultButton.Enabled = False
			ResetButton.Enabled = False
			CommitButton.Enabled = False

			Dim insert_cart_query As String = "UPDATE [Receipt] SET ThankYouText=@ThankYouText, InfoMessage=@InfoMessage WHERE (RecordSerial=1)"
			Using insert_cart_conn As New OleDbConnection(cart_connection_string)
				Using insert_cart_comm As New OleDbCommand()
					With insert_cart_comm
						.Connection = insert_cart_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_cart_query
						.Parameters.AddWithValue("@ThankYouText", ThankYou.Text.Trim)
						.Parameters.AddWithValue("@InfoMessage", AdditionalInfo.Text.Trim)
					End With
					Try
						insert_cart_conn.Open()
						insert_cart_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using

			'log
			LogEvent("Receipt Setting", "Receipt setting updated.")

			f.Feedback("Changes successfully saved.", "Database update successful.")

		Catch ex As Exception

		Finally
			DefaultButton.Enabled = True
			ResetButton.Enabled = True
			CommitButton.Enabled = True
			Me.Close()
		End Try
	End Sub
End Class