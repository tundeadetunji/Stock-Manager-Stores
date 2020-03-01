Public Class Main

#Region "Log Out"
	Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click

		session_id = ""
		username_ = ""

		UserAccess.Show()
		Me.Close()

	End Sub

#End Region

#Region "Links"
	Private Sub LinksMain_Click(sender As Object, e As EventArgs) Handles LinksMain.Click
		Try
			Process.Start(My.Application.Info.DirectoryPath & "\Stock Manager Main.exe")
		Catch ex As Exception
		End Try
	End Sub

	Private Sub LinksProgramLog_Click(sender As Object, e As EventArgs) Handles LinksProgramLog.Click
		Try
			Process.Start(My.Application.Info.DirectoryPath & "\Stock Manager Program Log.exe")
		Catch ex As Exception
		End Try
	End Sub

	Private Sub LinksUsers_Click(sender As Object, e As EventArgs) Handles LinksUsers.Click
		Try
			Process.Start(My.Application.Info.DirectoryPath & "\Stock Manager Users.exe")
		Catch ex As Exception
		End Try
	End Sub

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

	Public Sub UsersStat_(term As String)
		Dim n_ As Integer = ClientsGrid.Rows.Count
		Dim c_ As Boolean
		If ClientsLoadThis.Text.Trim.ToLower = "true" Then
			c_ = True
		Else
			c_ = False
		End If
		Select Case term.ToLower
			Case "username"
				ClientsStat.Text = n_ & " record(s) matching selected username"
			Case "name"
				ClientsStat.Text = n_ & " record(s) matching selected full name"
			Case "city"
				ClientsStat.Text = n_ & " record(s) matching selected city"
			Case "email"
				ClientsStat.Text = n_ & " record(s) matching selected email"
			Case "session id"
				ClientsStat.Text = n_ & " record(s) modified during selected session"
			Case "phone"
				ClientsStat.Text = n_ & " record(s) matching selected phone number"
			Case "stock"
				Select Case c_
					Case True
						ClientsStat.Text = n_ & " user(s) can record stock"
					Case False
						ClientsStat.Text = n_ & " user(s) cannot record stock"
				End Select
			Case "sale"
				Select Case c_
					Case True
						ClientsStat.Text = n_ & " user(s) can record sale"
					Case False
						ClientsStat.Text = n_ & " user(s) cannot record sale"
				End Select
			Case "user"
				Select Case c_
					Case True
						ClientsStat.Text = n_ & " user(s) can work on user"
					Case False
						ClientsStat.Text = n_ & " user(s) cannot work on user"
				End Select
			Case "client"
				Select Case c_
					Case True
						ClientsStat.Text = n_ & " user(s) can work on customer record"
					Case False
						ClientsStat.Text = n_ & " user(s) cannot work on customer record"
				End Select
			Case "enabled"
				Select Case c_
					Case True
						ClientsStat.Text = n_ & " user(s) enabled"
					Case False
						ClientsStat.Text = n_ & " user(s) not enabled"
				End Select
		End Select
	End Sub

	Public Sub ClearFields()
		Try
			Me.UsersTableAdapter.Null(Me.UsersDataSet.StockUsers)

			With ClientsLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			ClientsLocateBy.Text = ""

			ClientsStat.Text = "Total of " & UsersTableAdapter.Count_ & " user(s).   To begin, pick a task or locate a record."
		Catch
		End Try

	End Sub
#End Region
	Private Sub Main_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, True, True, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False)
	End Sub

	Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'first thing
		ConnectString()

		'language
		MarkLanguage()

		'voice feedback - accompany, voice only, prompt only
		f.InitialMarkVoiceFeedback(MessagePromptOnly, MessagePromptWithVoice, VoiceOnly)
		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)


		'dialog
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, True, True, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False)

		'begin
		GetValues()
		ClearFields()

	End Sub

	Public Sub GetValues()
		'grid
		With ClientsGrid
			.Columns.Item(0).HeaderText = "Record Serial"
			.Columns.Item(1).HeaderText = "Gender"
			.Columns.Item(2).HeaderText = "Full Name"
			.Columns.Item(3).HeaderText = "Email"
			.Columns.Item(4).HeaderText = "Phone Number"
			.Columns.Item(5).HeaderText = "Birthday"
			.Columns.Item(6).HeaderText = "City"
			.Columns.Item(7).HeaderText = "Can Record Stock"
			.Columns.Item(8).HeaderText = "Can Record Sale"
			.Columns.Item(9).HeaderText = "Can Work On User"
			.Columns.Item(10).HeaderText = "Can Work On Client"
			.Columns.Item(11).HeaderText = "Is Enabled"
			.Columns.Item(12).HeaderText = "Username"
			.Columns.Item(13).HeaderText = "Session ID Of Last Modification"
		End With

		'dropdown
		With ClientsLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Username")
				.Add("Full Name")
				.Add("City")
				.Add("Email")
				.Add("Session ID Of Last Modification")
				.Add("Phone Number")
				.Add("Can Record Stock")
				.Add("Can Record Sale")
				.Add("Can Work On User")
				.Add("Can Work On Client")
				.Add("Is Enabled")
			End With
		End With

	End Sub

	Private Sub UpdateUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateUserToolStripMenuItem.Click
		If ClientsGrid.Rows.Count < 1 Or selected_user.Text.Length < 1 Then Exit Sub
		If selected_user.Text.ToLower = "admin" Then Exit Sub
		If Me.UsersTableAdapter.Count_Username_CanWorkOnUser_IsEnabled(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot update record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		With EditUser
			.UserUser.Text = UserUser.Text
			.UserGender.Text = UserGender.Text
			.UserEmail.Text = UserEmail.Text
			.UserPhone.Text = UserPhone.Text
			.UserBirthday.Text = UserBirthday.Text
			.UserCity.Text = UserCity.Text
			.UserUsername.Text = UserUsername.Text
			.UserPassword.Text = UserPassword.Text
			.UserCanRecordItem.Checked = UserCanRecordItem.Checked
			.UserCanRecordSale.Checked = UserCanRecordSale.Checked
			.UserCanWorkOnUser.Checked = UserCanWorkOnUser.Checked
			.UserCanWorkOnClient.Checked = UserCanWorkOnClient.Checked
			.UserIsEnabled.Checked = UserIsEnabled.Checked
			.UserPicture.BackgroundImage = Picture.BackgroundImage
			.UserRecordSerial.Text = UserRecordSerial.Text
			.ShowDialog()
		End With

	End Sub

	Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
		If Me.UsersTableAdapter.Count_Username_CanWorkOnUser_IsEnabled(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot create record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If
		NewUser.ShowDialog()
	End Sub

	Private Sub ClientsReset_Click(sender As Object, e As EventArgs) Handles ClientsReset.Click
		ClearFields()
	End Sub

	Private Sub ClientsLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClientsLocateBy.SelectedIndexChanged
		Try
			With ClientsLoadThis
				.DataSource = Me.ClientsLoadThisDataSet.StockUsers
				Select Case ClientsLocateBy.Text.Trim.ToLower
					Case "username"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.UsernameColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctUsername(Me.ClientsLoadThisDataSet.StockUsers)
					Case "full name"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.FullNameColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctFullName(Me.ClientsLoadThisDataSet.StockUsers)
					Case "city"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.CityColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCity(Me.ClientsLoadThisDataSet.StockUsers)
					Case "email"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.EmailColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctEmail(Me.ClientsLoadThisDataSet.StockUsers)
					Case "session id of last modification"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.SessionIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctSessionID(Me.ClientsLoadThisDataSet.StockUsers)
					Case "phone number"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.PhoneColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctPhone(Me.ClientsLoadThisDataSet.StockUsers)
					Case "can record stock"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.CanRecordStockColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCanRecordStock(Me.ClientsLoadThisDataSet.StockUsers)
					Case "can record sale"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.CanRecordSaleColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCanRecordSale(Me.ClientsLoadThisDataSet.StockUsers)
					Case "can work on user"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.CanWorkOnUserColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCanWorkOnUser(Me.ClientsLoadThisDataSet.StockUsers)
					Case "can work on client"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.CanWorkOnClientColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCanWorkOnClient(Me.ClientsLoadThisDataSet.StockUsers)
					Case "is enabled"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockUsers.IsEnabledColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctIsEnabled(Me.ClientsLoadThisDataSet.StockUsers)
				End Select
				.SelectedIndex = -1
				.Focus()
			End With
		Catch
		End Try

	End Sub

	Private Sub ClientsLoadThis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClientsLoadThis.SelectedIndexChanged
		Try
			Select Case ClientsLocateBy.Text.Trim.ToLower
				Case "username"
					Me.UsersTableAdapter.WhereUsername(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("username")
				Case "full name"
					Me.UsersTableAdapter.WhereFullName(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("name")
				Case "city"
					Me.UsersTableAdapter.WhereCity(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("city")
				Case "email"
					Me.UsersTableAdapter.WhereEmail(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("email")
				Case "session id of last modification"
					Me.UsersTableAdapter.WhereSessionID(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("session id")
				Case "phone number"
					Me.UsersTableAdapter.WherePhone(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("phone")
				Case "can record stock"
					Me.UsersTableAdapter.WhereCanRecordStock(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("stock")
				Case "can record sale"
					Me.UsersTableAdapter.WhereCanRecordSale(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("sale")
				Case "can work on user"
					Me.UsersTableAdapter.WhereCanWorkOnUser(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("user")
				Case "can work on client"
					Me.UsersTableAdapter.WhereCanWorkOnClient(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("client")
				Case "is enabled"
					Me.UsersTableAdapter.WhereIsEnabled(Me.UsersDataSet.StockUsers, ClientsLoadThis.Text.Trim)
					UsersStat_("enabled")
			End Select

			Me.UsersBindingSource.MoveLast()
		Catch
		End Try

	End Sub

	Private Sub EnglishLanguage_Click(sender As Object, e As EventArgs) Handles EnglishLanguage.Click

	End Sub
End Class