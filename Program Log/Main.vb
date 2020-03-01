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
			Case "title"
				ClientsStat.Text = n_ & " record(s) matching selected title"
			Case "date"
				ClientsStat.Text = n_ & " record(s) matching selected date"
			Case "triggerusername"
				ClientsStat.Text = n_ & " record(s) matching selected username"
			Case "memo"
				ClientsStat.Text = LogDetails.Text
			Case "userid"
				ClientsStat.Text = n_ & " record(s) matching selected user"
			Case "clientid"
				ClientsStat.Text = n_ & " record(s) matching selected customer"
			Case "itemid"
				ClientsStat.Text = n_ & " record(s) matching selected item"
			Case "sessionid"
				ClientsStat.Text = n_ & " record(s) matching selected session id"
			Case "logip"
				ClientsStat.Text = n_ & " record(s) matching selected ip address"
		End Select
	End Sub

	Public Sub ClearFields()
		Try
			Me.LogTableAdapter.Null(Me.LogDataSet.StockProgramLog)

			With ClientsLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			ClientsLocateBy.Text = ""

			ClientsStat.Text = "Total of " & LogTableAdapter.Count_ & " record(s).   To begin, locate a record."
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
			.Columns.Item(1).HeaderText = "Title"
			.Columns.Item(2).HeaderText = "Date"
			.Columns.Item(3).HeaderText = "Time"
			.Columns.Item(4).HeaderText = "Username"
			.Columns.Item(5).HeaderText = "Details"
			.Columns.Item(6).HeaderText = "Concerned Username"
			.Columns.Item(7).HeaderText = "Concerned Customer"
			.Columns.Item(8).HeaderText = "Concerned Item"
			.Columns.Item(9).HeaderText = "Session ID"
			.Columns.Item(10).HeaderText = "IP Address"
		End With

		'dropdown
		With ClientsLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Title")
				.Add("Date")
				.Add("Username")
				.Add("Details")
				.Add("Concerned Username")
				.Add("Concerned Customer")
				.Add("Concerned Item")
				.Add("Session ID")
				.Add("IP Address")
			End With
		End With

	End Sub


	Private Sub ClientsReset_Click(sender As Object, e As EventArgs) Handles ClientsReset.Click
		ClearFields()
	End Sub

	Private Sub ClientsLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClientsLocateBy.SelectedIndexChanged
		Try
			With ClientsLoadThis
				.DataSource = Me.ClientsLoadThisDataSet.StockProgramLog
				Select Case ClientsLocateBy.Text.Trim.ToLower
					Case "title"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.LogTitleColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctLogTitle(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "date"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.LogDateColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctLogDate(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "username"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.TriggerUsernameColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctTriggerUsername(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "details"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.LogMemoColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctLogMemo(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "concerned username"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.UserIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctUserID(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "concerned customer"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.ClientIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctClientID(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "concerned item"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.ItemIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctItemID(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "session id"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.SessionIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.Distinctsessionid(Me.ClientsLoadThisDataSet.StockProgramLog)
					Case "ip address"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockProgramLog.LogIPColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctLogIP(Me.ClientsLoadThisDataSet.StockProgramLog)
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
				Case "title"
					Me.LogTableAdapter.WhereLogTitle(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("title")
				Case "date"
					Me.LogTableAdapter.WhereLogDate(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("date")
				Case "username"
					Me.LogTableAdapter.WhereTriggerUsername(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("triggerusername")
				Case "details"
					Me.LogTableAdapter.WhereLogMemo(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("memo")
				Case "concerned username"
					Me.LogTableAdapter.WhereUserID(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("userid")
				Case "concerned customer"
					Me.LogTableAdapter.WhereClientID(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("clientid")
				Case "concerned item"
					Me.LogTableAdapter.WhereItemID(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("itemid")
				Case "session id"
					Me.LogTableAdapter.WhereSessionID(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("sessionid")
				Case "ip address"
					Me.LogTableAdapter.WhereLogIP(Me.LogDataSet.StockProgramLog, ClientsLoadThis.Text.Trim)
					UsersStat_("logip")
			End Select

			Me.LogBindingSource.MoveLast()
		Catch
		End Try

	End Sub


End Class