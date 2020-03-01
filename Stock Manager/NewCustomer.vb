Imports System.Data.SqlClient
Public Class NewCustomer
#Region "Declarations"
#End Region

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
	Public Sub ClearFields()
		Gender.Text = ""
		Customer.Text = ""
		Email.Text = ""
		Phone.Text = ""
		City.Text = ""
		Picture.BackgroundImage = Image.FromFile(m_.logo)

	End Sub
#End Region

#Region "Form"
	Private Sub NewCustomer_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, CommitButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, True, True, o.theme(), Feedback, TimeTimer, TimeLabel)
	End Sub

	Private Sub NewCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'first thing
		ConnectString()

		'language
		MarkLanguage()

		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)

		'dialog
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, CommitButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, True, True, o.theme(), Feedback, TimeTimer, TimeLabel)

		'begin
		GetValues()
		ClearFields()

	End Sub

	Public Sub GetValues()
		Try
			With Gender
				.DataSource = Me.GenderDataSet.StockDropdown
				.DisplayMember = Me.GenderDataSet.StockDropdown.GenderColumn.ColumnName.ToString
				Me.GenderTableAdapter.DistinctGender(Me.GenderDataSet.StockDropdown)
				.SelectedIndex = -1
			End With

			Picture.BackgroundImage = Image.FromFile(m_.logo)
		Catch
		End Try
	End Sub

	Private Sub Gender_TextChanged(sender As Object, e As EventArgs) Handles Gender.TextChanged, Customer.TextChanged, City.TextChanged
		o.ToTitleCase(sender)
	End Sub

	Private Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
		o.ConvertTextToLowerCase(sender)
	End Sub

	Private Sub Gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gender.SelectedIndexChanged
		o.FocusMe(sender, Customer)
	End Sub


	Private Sub BrowseForPicture_Click(sender As Object, e As EventArgs) Handles BrowseForPicture.Click
		Try
			Picture.BackgroundImage = Image.FromFile(o.GetFile("picture", ""))
		Catch ex As Exception
		End Try
	End Sub
	Private Sub ClearPicture_Click(sender As Object, e As EventArgs) Handles ClearPicture.Click
		Picture.BackgroundImage = Image.FromFile(m_.logo)
	End Sub

	Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
		If f.Feedback("Pressing OK will clear all fields.", "", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

		ClearFields()

	End Sub

	Private Sub CommitButton_Click(sender As Object, e As EventArgs) Handles CommitButton.Click

		If Customer.Text.Trim.ToLower = "regular customer" Then
			f.Feedback("Please enter another name. That name is reserved.", "")
			Customer.Focus()
			Exit Sub
		End If
		If Customer.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the name.", "")
			Customer.Focus()
			Exit Sub
		End If


		If Me.EmailTableAdapter.Count_FullName_Email(Customer.Text.Trim, Email.Text.Trim) > 0 Then
			If f.Feedback("Customer with that name and with that email already exists. Do you want to proceed?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
		End If
		If Me.PhoneTableAdapter.Count_FullName_Phone(Customer.Text.Trim, Phone.Text.Trim) > 0 Then
			If f.Feedback("Customer with that name and with that phone number already exists. Do you want to proceed?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
		End If


		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanWorkOnClient(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot create record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		'create record
		If f.Feedback("Press OK to create record...", "", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

		If Picture.BackgroundImage Is Nothing Then
			Picture.BackgroundImage = Image.FromFile(m_.logo)
		End If

		Dim clientID As String = "C-" & o.NewID.ToUpper

		Try
			CommitButton.Enabled = False
			ResetButton.Enabled = False

			Dim stream As New IO.MemoryStream
			Dim photo_ As Image = Picture.BackgroundImage
			If photo_ IsNot Nothing Then
				photo_.Save(stream, Imaging.ImageFormat.Jpeg)
			End If

			Dim insert_query As String = "INSERT INTO [StockClients] (Gender, CustomerID, FullName, Email, Phone, Birthday, City, Picture, SessionID, Spent) VALUES (@Gender, @CustomerID, @FullName, @Email, @Phone, @Birthday, @City, @Picture, @SessionID, @Spent)"
			Using insert_conn As New SqlConnection(sequel_connection_string)
				Using insert_comm As New SqlCommand()
					With insert_comm
						.Connection = insert_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_query
						.Parameters.AddWithValue("@Gender", Gender.Text.Trim)
						.Parameters.AddWithValue("@CustomerID", clientID)
						.Parameters.AddWithValue("@FullName", Customer.Text.Trim)
						.Parameters.AddWithValue("@Email", Email.Text.Trim)
						.Parameters.AddWithValue("@Phone", Phone.Text.Trim)
						.Parameters.AddWithValue("@Birthday", Birthday.Value.ToShortDateString)
						.Parameters.AddWithValue("@City", City.Text.Trim)
						.Parameters.AddWithValue("@Picture", stream.GetBuffer())
						.Parameters.AddWithValue("@SessionID", session_id)
						.Parameters.AddWithValue("@Spent", 0)
					End With
					Try
						insert_conn.Open()
						insert_comm.ExecuteNonQuery()
					Catch ex As Exception
					Finally
						stream.Dispose()
					End Try
				End Using
			End Using

			'log
			LogEvent("New Client", "Client record created", "", clientID)

			'exit
			f.Feedback("Client record successfully created.", "Database update successful.")
			'/
			'			DefaultAction(Me.Name)
			ClearFields()

		Catch ex As Exception
			f.Feedback("An error occured while processing the request. Please verify that the record was created or updated.", "Error. Database update inaccessible.")
		Finally
			CommitButton.Enabled = True
			ResetButton.Enabled = True
		End Try

	End Sub

	Private Sub NewCustomer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Main.ClientsValues()
	End Sub
#End Region
End Class