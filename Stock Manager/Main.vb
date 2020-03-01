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

#Region "Clients"
	Public Sub ClientsStat_(term As String)
		Dim n_ As Integer = ClientsGrid.Rows.Count
		Dim spent_ = 0
		With ClientsGrid
			For cg As Integer = 0 To .Rows.Count - 1
				spent_ += .Rows(cg).Cells(8).Value
			Next
		End With
		Select Case term.ToLower
			Case "id"
				ClientsStat.Text = "Have received " & o.currency_symbol & spent_ & " from " & ClientsLoadThis.Text.Trim & " so far"
			Case "name"
				ClientsStat.Text = "Have received " & o.currency_symbol & spent_ & " from " & ClientsLoadThis.Text.Trim & " so far"
			Case "city"
				ClientsStat.Text = n_ & " record(s) matching selected city"
			Case "email"
				ClientsStat.Text = n_ & " record(s) matching selected email"
			Case "session id"
				ClientsStat.Text = n_ & " record(s) modified during selected session"
			Case "phone"
				ClientsStat.Text = n_ & " record(s) matching selected phone number"
		End Select
	End Sub

	Public Sub ClientsValues()
		Try
			Me.ClientsTableAdapter.WhereCustomerID(Me.ClientsDataSet.StockClients, "Regular Customer")

			With ClientsLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			ClientsLocateBy.Text = ""

			ClientsStat.Text = "Total of " & ClientsTableAdapter.Count_ & " registered customer(s).   To begin, pick a task or locate a record."
		Catch
		End Try
	End Sub

	Private Sub ClientsLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClientsLocateBy.SelectedIndexChanged
		Try
			With ClientsLoadThis
				.DataSource = Me.ClientsLoadThisDataSet.StockClients
				Select Case ClientsLocateBy.Text.Trim.ToLower
					Case "customer id"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.CustomerIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCustomerID(Me.ClientsLoadThisDataSet.StockClients)
					Case "full name"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.FullNameColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctFullName(Me.ClientsLoadThisDataSet.StockClients)
					Case "city"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.CityColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctCity(Me.ClientsLoadThisDataSet.StockClients)
					Case "email"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.EmailColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctEmail(Me.ClientsLoadThisDataSet.StockClients)
					Case "session id of last modification"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.SessionIDColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctSessionID(Me.ClientsLoadThisDataSet.StockClients)
					Case "phone number"
						.DisplayMember = Me.ClientsLoadThisDataSet.StockClients.PhoneColumn.ColumnName.ToString
						Me.ClientsLoadThisTableAdapter.DistinctPhone(Me.ClientsLoadThisDataSet.StockClients)
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
				Case "customer id"
					Me.ClientsTableAdapter.WhereCustomerID(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("id")
				Case "full name"
					Me.ClientsTableAdapter.WhereFullName(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("name")
				Case "city"
					Me.ClientsTableAdapter.WhereCity(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("city")
				Case "email"
					Me.ClientsTableAdapter.WhereEmail(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("email")
				Case "session id of last modification"
					Me.ClientsTableAdapter.WhereSessionID(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("session id")
				Case "phone number"
					Me.ClientsTableAdapter.WherePhone(Me.ClientsDataSet.StockClients, ClientsLoadThis.Text.Trim)
					ClientsStat_("phone")
			End Select

			Me.ClientsBindingSource.MoveLast()

		Catch
		End Try
	End Sub

	Private Sub ClientsReset_Click(sender As Object, e As EventArgs) Handles ClientsReset.Click
		ClientsValues()
	End Sub

#End Region

#Region "Items"
	Public Sub ItemsValues()
		Try
			Me.ItemsTableAdapter.Null(Me.ItemsDataSet.StockStock)

			With ItemsLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			ItemsLocateBy.Text = ""

			ItemsStat.Text = "Total of " & ItemsTableAdapter.Count_ & " item(s).   To begin, pick a task or locate a record."
		Catch
		End Try
	End Sub

	Private Sub ItemsStat_(term As String)
		Dim n_ As Integer = ItemsGrid.Rows.Count
		Dim c_ As Boolean
		If ItemsLoadThis.Text.Trim.ToLower = "true" Then
			c_ = True
		Else
			c_ = False
		End If
		Select Case term.ToLower
			Case "item"
				ItemsStat.Text = n_ & " record(s) matching selected item name"
			Case "category"
				ItemsStat.Text = n_ & " record(s) matching selected category"
			Case "unit"
				ItemsStat.Text = n_ & " record(s) matching selected unit"
			Case "quantity level"
				ItemsStat.Text = n_ & " record(s) matching selected level"
			Case "item id"
				ItemsStat.Text = n_ & " record(s) matching selected item id"
			Case "use discount"
				Select Case c_
					Case True
						ItemsStat.Text = n_ & " item(s) set with discount"
					Case False
						ItemsStat.Text = n_ & " item(s) set without discount"
				End Select
			Case "recordby"
				ItemsStat.Text = n_ & " record(s) matching selected username"
			Case "session id"
				ItemsStat.Text = n_ & " record(s) modified during selected session"
		End Select
	End Sub
	Private Sub ItemsLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemsLocateBy.SelectedIndexChanged
		Try
			With ItemsLoadThis
				.DataSource = Me.ItemsLoadThisDataSet.StockStock
				Select Case ItemsLocateBy.Text.Trim.ToLower
					Case "item"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.ItemColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctItem(Me.ItemsLoadThisDataSet.StockStock)
					Case "category"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.CategoryColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctCategory(Me.ItemsLoadThisDataSet.StockStock)
					Case "unit"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.UnitColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctUnit(Me.ItemsLoadThisDataSet.StockStock)
					Case "quantity level"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.QuantityLevelColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctQuantityLevel(Me.ItemsLoadThisDataSet.StockStock)
					Case "item id"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.ItemIDColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctItemID(Me.ItemsLoadThisDataSet.StockStock)
					Case "use discount"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.UseDiscountColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctUseDiscount(Me.ItemsLoadThisDataSet.StockStock)
					Case "quantity last bought by"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.RecordByColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctRecordBy(Me.ItemsLoadThisDataSet.StockStock)
					Case "session id of last modification"
						.DisplayMember = Me.ItemsLoadThisDataSet.StockStock.SessionIDColumn.ColumnName.ToString
						Me.ItemsLoadThisTableAdapter.DistinctSessionID(Me.ItemsLoadThisDataSet.StockStock)
				End Select
				.SelectedIndex = -1
				.Focus()
			End With
		Catch
		End Try
	End Sub

	Private Sub ItemsLoadThis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemsLoadThis.SelectedIndexChanged
		Try
			Select Case ItemsLocateBy.Text.Trim.ToLower
				Case "item"
					Me.ItemsTableAdapter.WhereItem(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("item")
				Case "category"
					Me.ItemsTableAdapter.WhereCategory(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("category")
				Case "unit"
					Me.ItemsTableAdapter.WhereUnit(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("unit")
				Case "quantity level"
					Me.ItemsTableAdapter.WhereQuantityLevel(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("quantity level")
				Case "item id"
					Me.ItemsTableAdapter.WhereItemID(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("item id")
				Case "use discount"
					Me.ItemsTableAdapter.WhereUseDiscount(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("use discount")
				Case "quantity last bought by"
					Me.ItemsTableAdapter.WhereRecordBy(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("recordby")
				Case "session id of last modification"
					Me.ItemsTableAdapter.WhereSessionID(Me.ItemsDataSet.StockStock, ItemsLoadThis.Text.Trim)
					ItemsStat_("session id")
			End Select

			Me.ItemsBindingSource.MoveLast()

		Catch
		End Try
	End Sub

	Private Sub ItemsReset_Click(sender As Object, e As EventArgs) Handles ItemsReset.Click
		ItemsValues()
	End Sub

#End Region

#Region "Log"

	Public Sub LogValues()
		Try
			Me.StockLogTableAdapter.Null(Me.StockLogDataSet.StockLog)

			With LogLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			LogLocateBy.Text = ""

			LogStat.Text = "Total of " & StockLogTableAdapter.Count_ & " record(s).   To begin, locate a record."
		Catch
		End Try
	End Sub
	Private Sub LogStat_(term As String)
		Dim n__ As Integer = LogGrid.Rows.Count
		Dim c__ As Boolean
		If LogLoadThis.Text.Trim.ToLower = "true" Then
			c__ = True
		Else
			c__ = False
		End If
		Dim add_ = 0, sale_ = 0, qty_bought_ = 0, qty_sold_ = 0, qty_ = 0
		With LogGrid
			For il As Integer = 0 To .Rows.Count - 1
				If .Rows(il).Cells(9).Value.ToString.ToLower = "addition" Then
					add_ += .Rows(il).Cells(10).Value
					qty_bought_ += .Rows(il).Cells(8).Value
				Else
					sale_ += .Rows(il).Cells(11).Value
					qty_sold_ += .Rows(il).Cells(8).Value
				End If
			Next
		End With
		qty_ = qty_sold_ - qty_bought_
		Try
			Select Case term.ToLower
				Case "item id"
					LogStat.Text = o.currency_symbol & add_ & " has been spent on " & LogLoadThis.Text.Trim & " so far;  "
					LogStat.Text &= o.currency_symbol & sale_ & " has been made on " & LogLoadThis.Text.Trim & " so far"
					LogStat.Text &= vbCrLf & qty_ & " units available"
				Case "name"
					LogStat.Text = o.currency_symbol & add_ & " has been spent on " & LogLoadThis.Text.Trim & " so far;  "
					LogStat.Text &= o.currency_symbol & sale_ & " has been made on " & LogLoadThis.Text.Trim & " so far"
					LogStat.Text &= vbCrLf & qty_ & " units available"
				Case "category"
					LogStat.Text = n__ & " record(s) matching selected category"
				Case "unit"
					LogStat.Text = n__ & " record(s) matching selected unit"
				'				Case "quantity level"
				'					LogStat.Text = n__ & " record(s) matching selected level"
				Case "use discount"
					Select Case c__
						Case True
							LogStat.Text = n__ & " record(s) with discount"
						Case False
							LogStat.Text = n__ & " record(s) without discount"
					End Select
				Case "record state"
					LogStat.Text = n__ & " record(s) matching selected record state"
				Case "record date"
					LogStat.Text = n__ & " record(s) matching selected date"
				Case "record by"
					LogStat.Text = n__ & " record(s) matching selected username"
				Case "session id"
					LogStat.Text = n__ & " record(s) matching selected session id"
			End Select
		Catch
		End Try

	End Sub

	Private Sub LogReset_Click(sender As Object, e As EventArgs) Handles LogReset.Click
		LogValues()
	End Sub

	Private Sub LogLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LogLocateBy.SelectedIndexChanged
		Try
			With LogLoadThis
				.DataSource = Me.LogLoadThisDataSet.StockLog
				Select Case LogLocateBy.Text.Trim.ToLower
					Case "item id"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.ItemIDColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctItemID(Me.LogLoadThisDataSet.StockLog)
					Case "item"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.ItemColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctItem(Me.LogLoadThisDataSet.StockLog)
					Case "category"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.CategoryColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctCategory(Me.LogLoadThisDataSet.StockLog)
					Case "unit"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.UnitColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctUnit(Me.LogLoadThisDataSet.StockLog)
					Case "quantity level"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.QuantityLevelColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctQuantityLevel(Me.LogLoadThisDataSet.StockLog)
					Case "use discount"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.UseDiscountColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctUseDiscount(Me.LogLoadThisDataSet.StockLog)
					Case "record state"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.RecordStateColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctRecordState(Me.LogLoadThisDataSet.StockLog)
					Case "record date"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.RecordDateColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctRecordDate(Me.LogLoadThisDataSet.StockLog)
					Case "record by"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.RecordByColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctRecordBy(Me.LogLoadThisDataSet.StockLog)
					Case "session id"
						.DisplayMember = Me.LogLoadThisDataSet.StockLog.SessionIDColumn.ColumnName.ToString
						Me.LogLoadThisTableAdapter.DistinctSessionID(Me.LogLoadThisDataSet.StockLog)
				End Select
				.SelectedIndex = -1
				.Focus()
			End With
		Catch
		End Try
	End Sub

	Private Sub LogLoadThis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LogLoadThis.SelectedIndexChanged
		Try
			Select Case LogLocateBy.Text.Trim.ToLower
				Case "item id"
					Me.StockLogTableAdapter.WhereItemID(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("item id")
				Case "item"
					Me.StockLogTableAdapter.WhereItem(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("name")
				Case "category"
					Me.StockLogTableAdapter.WhereCategory(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("category")
				Case "unit"
					Me.StockLogTableAdapter.WhereUnit(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("unit")
				Case "quantity level"
					Me.StockLogTableAdapter.WhereQuantityLevel(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("quantity level")
				Case "use discount"
					Me.StockLogTableAdapter.WhereUseDiscount(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("use discount")
				Case "record state"
					Me.StockLogTableAdapter.WhereRecordState(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("record state")
				Case "record date"
					Me.StockLogTableAdapter.WhereRecordDate(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("record date")
				Case "record by"
					Me.StockLogTableAdapter.WhereRecordBy(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("record by")
				Case "session id"
					Me.StockLogTableAdapter.WhereSessionID(Me.StockLogDataSet.StockLog, LogLoadThis.Text.Trim)
					LogStat_("session id")
			End Select

			Me.StockLogBindingSource.MoveLast()

		Catch
		End Try
	End Sub

#End Region

#Region "Sales"
	Public Sub SalesValues()
		Try
			Me.StockSalesTableAdapter.Null(Me.StockSalesDataSet.StockSales)

			With SalesLoadThis
				.DataSource = Nothing
				.Items.Clear()
				.SelectedIndex = -1
				.Text = ""
			End With

			SalesLocateBy.Text = ""

			Me.StockSalesCountTableAdapter.WhereRecordMonthRecordYear(Me.StockSalesCountDataSet.StockSales, Now.Month.ToString, Now.Year.ToString)
			Me.StockSalesCountBindingSource.MoveFirst()
			Dim quantity_bought_this_month = 0, gross_this_month = 0
			With StockSalesCountGrid
				For ss_ As Integer = 0 To .Rows.Count - 1
					quantity_bought_this_month += .Rows(ss_).Cells(0).Value
					gross_this_month += .Rows(ss_).Cells(1).Value
				Next
			End With
			Me.StockSalesCountTableAdapter.WhereRecordDate(Me.StockSalesCountDataSet.StockSales, Now.ToShortDateString.ToString)
			Me.StockSalesCountBindingSource.MoveFirst()
			Dim quantity_bought_today = 0, gross_today = 0
			With StockSalesCountGrid
				For ss__ As Integer = 0 To .Rows.Count - 1
					quantity_bought_today += .Rows(ss__).Cells(0).Value
					gross_today += .Rows(ss__).Cells(1).Value
				Next
			End With
			SalesStat.Text = quantity_bought_today & " unit(s) of items have been sold today;  "
			SalesStat.Text &= o.currency_symbol & gross_today & " has been recorded today"
			SalesStat.Text &= vbCrLf & quantity_bought_this_month & " unit(s) of items have been sold this month;  "
			SalesStat.Text &= vbCrLf & o.currency_symbol & gross_this_month & " has been recorded this month"
			SalesStat.Text &= vbCrLf & "To begin, locate a record."
		Catch
		End Try
	End Sub

	Public Sub SalesStat_(term As String)

		Dim n__s As Integer = SalesGrid.Rows.Count
		Dim c__s As Boolean
		If SalesLoadThis.Text.Trim.ToLower = "true" Then
			c__s = True
		Else
			c__s = False
		End If
		Dim sale__ = 0, gross__ = 0
		With SalesGrid
			For i_ As Integer = 0 To .Rows.Count - 1
				sale__ += .Rows(i_).Cells(13).Value
				gross__ += .Rows(i_).Cells(2).Value
			Next
		End With
		Try
			Select Case term
				Case "WhereReceiptNumber"
					SalesStat.Text = o.currency_symbol & sale__ & " was made from " & SalesLoadThis.Text.Trim
				Case "WhereClientID"
					SalesStat.Text = o.currency_symbol & gross__ & " has been spent by " & SalesLoadThis.Text.Trim
				Case "WhereItemID"
					SalesStat.Text = n__s & " record(s) matching selected item id"
				Case "WhereItem"
					SalesStat.Text = n__s & " record(s) matching selected item name"
				Case "WhereRecordDate"
					SalesStat.Text = n__s & " record(s) matching selected date"
				Case "WhereRecordBy"
					SalesStat.Text = n__s & " record(s) matching selected username"
				Case "WhereUseDiscount"
					Select Case c__s
						Case True
							SalesStat.Text = n__s & " record(s) with discount"
						Case False
							SalesStat.Text = n__s & " record(s) without discount"
					End Select
				Case "WhereSessionID"
					SalesStat.Text = o.currency_symbol & sale__ & " was made during selected session"
			End Select
		Catch
		End Try




	End Sub

	Private Sub SalesLocateBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SalesLocateBy.SelectedIndexChanged
		Try
			With SalesLoadThis
				.DataSource = Me.SalesLoadThisDataSet.StockSales
				Select Case SalesLocateBy.Text.Trim.ToLower
					Case "receipt number"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.ReceiptNumberColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctReceiptNumber(Me.SalesLoadThisDataSet.StockSales)
					Case "client id"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.ClientIDColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctClientID(Me.SalesLoadThisDataSet.StockSales)
					Case "item id"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.ItemIDColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctItemID(Me.SalesLoadThisDataSet.StockSales)
					Case "item"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.ItemColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctItem(Me.SalesLoadThisDataSet.StockSales)
					Case "record date"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.RecordDateColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctRecordDate(Me.SalesLoadThisDataSet.StockSales)
					Case "sale by"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.RecordByColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctRecordBy(Me.SalesLoadThisDataSet.StockSales)
					Case "use discount"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.UseDiscountColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctUseDiscount(Me.SalesLoadThisDataSet.StockSales)
					Case "session id"
						.DisplayMember = Me.SalesLoadThisDataSet.StockSales.SessionIDColumn.ColumnName.ToString
						Me.SalesLoadThisTableAdapter.DistinctSessionID(Me.SalesLoadThisDataSet.StockSales)
				End Select
				.SelectedIndex = -1
				.Focus()
			End With
		Catch
		End Try
	End Sub

	Private Sub SalesLoadThis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SalesLoadThis.SelectedIndexChanged
		Try
			Select Case SalesLocateBy.Text.Trim.ToLower
				Case "receipt number"
					Me.StockSalesTableAdapter.WhereReceiptNumber(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereReceiptNumber")
				Case "client id"
					Me.StockSalesTableAdapter.WhereClientID(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereClientID")
				Case "item id"
					Me.StockSalesTableAdapter.WhereItemID(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereItemID")
				Case "item"
					Me.StockSalesTableAdapter.WhereItem(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereItem")
				Case "record date"
					Me.StockSalesTableAdapter.WhereRecordDate(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereRecordDate")
				Case "sale by"
					Me.StockSalesTableAdapter.WhereRecordBy(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereRecordBy")
				Case "use discount"
					Me.StockSalesTableAdapter.WhereUseDiscount(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereUseDiscount")
				Case "session id"
					Me.StockSalesTableAdapter.WhereSessionID(Me.StockSalesDataSet.StockSales, SalesLoadThis.Text.Trim)
					SalesStat_("WhereSessionID")
			End Select

			Me.StockSalesBindingSource.MoveLast()

		Catch
		End Try
	End Sub

	Private Sub SalesReset_Click(sender As Object, e As EventArgs) Handles SalesReset.Click
		SalesValues()
	End Sub

#End Region

#Region "Other Functions"
	Private Sub PlaceView(p_ As Panel)
		For Each c As Control In Me.Controls
			If TypeOf c Is Panel Then
				c.Visible = False
			End If
		Next

		With HiddenPanel
			.Visible = True
			.Width = 2
			.Height = 2
			.Left = DialogTitle.Left + 2
			.Top = DialogTitle.Top + 2
			.SendToBack()
		End With

		NewStockToolStripMenuItem.Enabled = False
		UpdateCustomerToolStripMenuItem.Enabled = False
		NewSaleToolStripMenuItem.Enabled = False
		LoadView(p_)
	End Sub

	Private Sub LoadView(p As Panel)
		With p
			.Top = TopLine.Top + TopLine.Height + 14
			.Left = 14
			.Size = New Size(915, 404)
			.Location = New Point(14, 63)
		End With

		DialogTitle.Tag = "x"

		If p.Name = "CustomersPanel" Then
			UpdateCustomerToolStripMenuItem.Enabled = True
			NewSaleToolStripMenuItem.Enabled = True
			DialogTitle.Text = "Customers - Stock Manager"
			o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, True, True, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False)
		End If

		If p.Name = "ItemsPanel" Then
			NewStockToolStripMenuItem.Enabled = True
			DialogTitle.Text = "All Items - Stock Manager"
			o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, True, True, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False)
		End If

		If p.Name = "LogPanel" Then
			DialogTitle.Text = "Log - Stock Manager"
			o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, True, True, False, True, o.theme(), Feedback, TimeTimer, TimeLabel, False)
		End If

		If p.Name = "SalesPanel" Then

		End If

		p.Visible = True

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
		PlaceView(ItemsPanel)
		ItemsValues()

	End Sub

	Public Sub GetValues()
		'clients grid
		With ClientsGrid
			.Columns.Item(0).HeaderText = "Record Serial"
			.Columns.Item(1).HeaderText = "Customer ID"
			.Columns.Item(2).HeaderText = "Full Name"
			.Columns.Item(3).HeaderText = "Gender"
			.Columns.Item(4).HeaderText = "Email"
			.Columns.Item(5).HeaderText = "Phone Number"
			.Columns.Item(6).HeaderText = "Birthday"
			.Columns.Item(7).HeaderText = "City"
			.Columns.Item(8).HeaderText = "Have Spent So Far (" & o.currency_symbol & ")"
			.Columns.Item(9).HeaderText = "Session ID Of Last Modification"
		End With

		'clients dropdown
		With ClientsLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Customer ID")
				.Add("Full Name")
				.Add("City")
				.Add("Email")
				.Add("Session ID Of Last Modification")
				.Add("Phone Number")
			End With
		End With

		'items grid
		With ItemsGrid
			.Columns.Item(0).HeaderText = "Record Serial"
			.Columns.Item(1).HeaderText = "Item"
			.Columns.Item(2).HeaderText = "Category"
			.Columns.Item(3).HeaderText = "Unit"
			.Columns.Item(4).HeaderText = "Unit Price (" & o.currency_symbol & ")"
			.Columns.Item(5).HeaderText = "Item ID"
			.Columns.Item(6).HeaderText = "Discount (%)"
			.Columns.Item(7).HeaderText = "Apply Discount To (Units And Over)"
			.Columns.Item(8).HeaderText = "Use Discount"
			.Columns.Item(9).HeaderText = "Quantity Last Bought"
			.Columns.Item(10).HeaderText = "Quantity Last Bought By"
			.Columns.Item(11).HeaderText = "Session ID Of Last Modification"
		End With

		'items dropdown
		With ItemsLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Item")
				.Add("Category")
				.Add("Unit")
				.Add("Item ID")
				.Add("Use Discount")
				.Add("Quantity Last Bought By")
				.Add("Session ID Of Last Modification")
			End With
		End With

		'log grid
		With LogGrid
			.Columns.Item(0).HeaderText = "Record Serial"
			.Columns.Item(1).HeaderText = "Item ID"
			.Columns.Item(2).HeaderText = "Item"
			.Columns.Item(3).HeaderText = "Category"
			.Columns.Item(4).HeaderText = "Unit"
			.Columns.Item(5).HeaderText = "Unit Cost (" & o.currency_symbol & ")"
			.Columns.Item(6).HeaderText = "Unit Price (" & o.currency_symbol & ")"
			.Columns.Item(7).HeaderText = "Unit Profit Without Discount (" & o.currency_symbol & ")"
			.Columns.Item(8).HeaderText = "Quantity Bought"
			.Columns.Item(9).HeaderText = "Record State"
			.Columns.Item(10).HeaderText = "Total Cost (" & o.currency_symbol & ")"
			.Columns.Item(11).HeaderText = "Total Profit (" & o.currency_symbol & ")"
			.Columns.Item(12).HeaderText = "Discount (%)"
			.Columns.Item(13).HeaderText = "Apply Discount To (Units And Over)"
			.Columns.Item(14).HeaderText = "Use Discount"
			.Columns.Item(15).HeaderText = "Record Date"
			.Columns.Item(16).HeaderText = "Record Time"
			.Columns.Item(17).HeaderText = "Record By"
			.Columns.Item(18).HeaderText = "Session ID"
		End With

		'log dropdown
		With LogLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Item ID")
				.Add("Item")
				.Add("Category")
				.Add("Unit")
				.Add("Record State")
				.Add("Use Discount")
				.Add("Record Date")
				.Add("Record By")
				.Add("Session ID")
			End With
		End With

		'sales grid
		With SalesGrid
			.Columns.Item(0).HeaderText = "Record Serial"
			.Columns.Item(1).HeaderText = "Receipt Number"
			.Columns.Item(2).HeaderText = "Gross (" & o.currency_symbol & ")"
			.Columns.Item(3).HeaderText = "Client ID"
			.Columns.Item(4).HeaderText = "Item ID"
			.Columns.Item(5).HeaderText = "Item"
			.Columns.Item(6).HeaderText = "Record Date"
			.Columns.Item(7).HeaderText = "Record Time"
			.Columns.Item(8).HeaderText = "Sale By"
			.Columns.Item(9).HeaderText = "Unit Price (" & o.currency_symbol & ")"
			.Columns.Item(10).HeaderText = "Quantity Bought"
			.Columns.Item(11).HeaderText = "Discount (%)"
			.Columns.Item(12).HeaderText = "Use Discount"
			.Columns.Item(13).HeaderText = "Total Profit (" & o.currency_symbol & ")"
			.Columns.Item(14).HeaderText = "Session ID"
		End With

		'sales dropdown
		With SalesLocateBy
			.Sorted = True
			With .Items
				.Clear()
				.Add("Receipt Number")
				.Add("Client ID")
				.Add("Item ID")
				.Add("Item")
				.Add("Record Date")
				.Add("Sale By")
				.Add("Use Discount")
				.Add("Session ID")
			End With
		End With

	End Sub

	Private Sub NewCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCustomerToolStripMenuItem.Click
		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanWorkOnClient(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot create record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If
		NewCustomer.ShowDialog()
	End Sub

	Private Sub UpdateCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateCustomerToolStripMenuItem.Click
		If ClientsGrid.Rows.Count < 1 Or selected_client.Text.Length < 1 Then Exit Sub
		If ClientRecordSerial.Text.ToString = "1" Then Exit Sub

		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanWorkOnClient(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot update record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		With EditCustomer
			.CustomerValue.Text = ClientCustomer.Text
			.GenderValue.Text = ClientGender.Text
			.EmailValue.Text = ClientEmail.Text
			.PhoneValue.Text = ClientPhone.Text
			.BirthdayValue.Text = ClientBirthday.Text
			.CityValue.Text = ClientCity.Text
			.PictureValue.BackgroundImage = Picture.BackgroundImage
			.selected_client.Text = selected_client.Text
			.record_serial.Text = ClientRecordSerial.Text
			.ShowDialog()
		End With
	End Sub

	Private Sub NewItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewItemToolStripMenuItem.Click
		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanRecordStock(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot create record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If
		NewItem.ShowDialog()
	End Sub

	Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click
		PlaceView(CustomersPanel)
		ClientsValues()
	End Sub

	Private Sub AllItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllItemsToolStripMenuItem.Click
		PlaceView(ItemsPanel)
		ItemsValues()
	End Sub

	Private Sub NewStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStockToolStripMenuItem.Click
		If ItemsGrid.Rows.Count < 1 Then Exit Sub
		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanRecordStock(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot add stock.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If
		With EditItem
			.ItemsCategories.Text = ItemsCategories.Text
			.ItemsUnit.Text = ItemsUnit.Text
			.ItemsItem.Text = ItemsItem.Text
			.ItemsUnitCost.Text = ItemsUnitCost.Text
			.ItemsUnitPrice.Text = ItemsUnitPrice.Text
			.ItemsQuantity.Text = ItemsQuantity.Text
			.ItemsDiscount.Text = ItemsDiscount.Text
			.ItemsDiscountUnits.Text = ItemsDiscountUnits.Text
			.ItemsUseDiscount.Checked = ItemsUseDiscount.Checked
			.ItemsPicture.BackgroundImage = ItemPicture.BackgroundImage
			.selected_item.Text = selected_item.Text
			.ItemsRecordSerial.Text = ItemsRecordSerial.Text
			.ShowDialog()
		End With
	End Sub

	Private Sub ItemsFlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsFlowToolStripMenuItem.Click
		PlaceView(LogPanel)
		LogValues()
	End Sub

	Private Sub NewSaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewSaleToolStripMenuItem.Click
		If ClientsGrid.Rows.Count < 1 Or selected_client.Text.Length < 1 Then Exit Sub
		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanRecordSale(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot record sale.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If
		With NewSale
			.selected_client.Text = selected_client.Text
			.ShowDialog()
		End With
	End Sub

	Private Sub AllSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllSalesToolStripMenuItem.Click
		PlaceView(SalesPanel)
		salesValues()
	End Sub

	Private Sub PrintersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintersToolStripMenuItem.Click
		Try
			Process.Start("control", "/name Microsoft.AddHardware")
		Catch
		End Try
	End Sub

	Private Sub ReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiptToolStripMenuItem.Click
		If Me.StockUsersTableAdapter.IsAdmin(username_) < 1 Then
			f.Feedback(username_ & " cannot change setting.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		ReceiptSetting.ShowDialog()
	End Sub
End Class
