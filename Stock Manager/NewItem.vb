Imports System.Data.SqlClient
Public Class NewItem
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

	Private Sub LogItem(id_ As String)
		Try

			Dim stream As New IO.MemoryStream
			Dim photo_ As Image = Picture.BackgroundImage
			If photo_ IsNot Nothing Then
				photo_.Save(stream, Imaging.ImageFormat.Jpeg)
			End If

			Dim insert_log_query As String = "INSERT INTO [StockLog] (Category, Item, Unit, UnitCost, UnitPrice, QuantityBought, Discount, DiscountUnits, UseDiscount, Picture, RecordBy, RecordState, RecordDate, RecordTime, UnitProfit, TotalProfit, TotalCost, RecordMonth, RecordYear, ItemID, SessionID) VALUES (@Category, @Item, @Unit, @UnitCost, @UnitPrice, @QuantityBought, @Discount, @DiscountUnits, @UseDiscount, @Picture, @RecordBy, @RecordState, @RecordDate, @RecordTime, @UnitProfit, @TotalProfit, @TotalCost, @RecordMonth, @RecordYear, @ItemID, @SessionID)"
			Using insert_log_conn As New SqlConnection(sequel_connection_string)
				Using insert_log_comm As New SqlCommand()
					With insert_log_comm
						.Connection = insert_log_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_log_query
						.Parameters.AddWithValue("@Category", Categories.Text.Trim)
						.Parameters.AddWithValue("@Item", Item.Text.Trim)
						.Parameters.AddWithValue("@Unit", Unit.Text.Trim)
						.Parameters.AddWithValue("@UnitCost", UnitCost.Text.Trim)
						.Parameters.AddWithValue("@UnitPrice", UnitPrice.Text.Trim)
						.Parameters.AddWithValue("@QuantityBought", Val(QuantityBought.Text.Trim))
						.Parameters.AddWithValue("@Discount", Val(Discount.Text.Trim))
						.Parameters.AddWithValue("@DiscountUnits", Val(DiscountUnits.Text.Trim))
						.Parameters.AddWithValue("@UseDiscount", UseDiscount.Checked)
						.Parameters.AddWithValue("@Picture", stream.GetBuffer())
						.Parameters.AddWithValue("@RecordBy", username_)
						.Parameters.AddWithValue("@RecordState", "Addition")
						.Parameters.AddWithValue("@RecordDate", Now.ToShortDateString)
						.Parameters.AddWithValue("@RecordTime", Now.ToLongTimeString)
						.Parameters.AddWithValue("@UnitProfit", UnitProfit.Text.Trim)
						.Parameters.AddWithValue("@TotalProfit", 0)
						.Parameters.AddWithValue("@TotalCost", Val(QuantityBought.Text.Trim) * Val(UnitCost.Text.Trim))
						.Parameters.AddWithValue("@RecordMonth", Now.Month.ToString)
						.Parameters.AddWithValue("@RecordYear", Now.Year.ToString)
						.Parameters.AddWithValue("@ItemID", id_)
						.Parameters.AddWithValue("@SessionID", session_id)
					End With
					Try
						insert_log_conn.Open()
						insert_log_comm.ExecuteNonQuery()
					Catch ex As Exception
					Finally
						stream.Dispose()
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub
	Private Sub CommitItem(id_ As String)
		Try

			Dim stream As New IO.MemoryStream
			Dim photo_ As Image = Picture.BackgroundImage
			If photo_ IsNot Nothing Then
				photo_.Save(stream, Imaging.ImageFormat.Jpeg)
			End If

			Dim insert_query As String = "INSERT INTO [StockStock] (Category, Item, Unit, UnitCost, UnitPrice, QuantityBought, Discount, DiscountUnits, UseDiscount, Picture, RecordBy, RecordDate, RecordTime, UnitProfit, TotalProfit, ItemID, SessionID) VALUES (@Category, @Item, @Unit, @UnitCost, @UnitPrice, @QuantityBought, @Discount, @DiscountUnits, @UseDiscount, @Picture, @RecordBy, @RecordDate, @RecordTime, @UnitProfit, @TotalProfit, @ItemID, @SessionID)"
			Using insert_conn As New SqlConnection(sequel_connection_string)
				Using insert_comm As New SqlCommand()
					With insert_comm
						.Connection = insert_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_query
						.Parameters.AddWithValue("@Category", Categories.Text.Trim)
						.Parameters.AddWithValue("@Item", Item.Text.Trim)
						.Parameters.AddWithValue("@Unit", Unit.Text.Trim)
						.Parameters.AddWithValue("@UnitCost", UnitCost.Text.Trim)
						.Parameters.AddWithValue("@UnitPrice", UnitPrice.Text.Trim)
						.Parameters.AddWithValue("@QuantityBought", Val(QuantityBought.Text.Trim))
						.Parameters.AddWithValue("@Discount", Val(Discount.Text.Trim))
						.Parameters.AddWithValue("@DiscountUnits", Val(DiscountUnits.Text.Trim))
						.Parameters.AddWithValue("@UseDiscount", UseDiscount.Checked)
						.Parameters.AddWithValue("@Picture", stream.GetBuffer())
						.Parameters.AddWithValue("@RecordBy", username_)
						.Parameters.AddWithValue("@RecordDate", Now.ToShortDateString)
						.Parameters.AddWithValue("@RecordTime", Now.ToLongTimeString)
						.Parameters.AddWithValue("@UnitProfit", UnitProfit.Text.Trim)
						.Parameters.AddWithValue("@TotalProfit", Val(QuantityBought.Text.Trim) * Val(UnitProfit.Text.Trim))
						.Parameters.AddWithValue("@ItemID", id_)
						.Parameters.AddWithValue("@SessionID", session_id)
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
		Catch
		End Try
	End Sub

	Private Sub PlaceCriticalQuantity()
		CriticalQuantity.Text = (10 / 100) * Val(QuantityBought.Text.Trim)
	End Sub
	Private Sub GetUnitProfit()
		UnitProfit.Text = Val(UnitPrice.Text.Trim) - Val(UnitCost.Text.Trim)
		GetTotalProfit()
	End Sub

	Private Sub GetTotalProfit()
		TotalProfit.Text = Val(UnitProfit.Text) * Val(QuantityBought.Text) & "  (without discount)"
	End Sub

	Private Sub AddUnit(unit_ As String)
		Try
			Dim insert_unit_query As String = "INSERT INTO [StockDropdown] (Unit) VALUES (@Unit)"
			Using insert_unit_conn As New SqlConnection(sequel_connection_string)
				Using insert_unit_comm As New SqlCommand()
					With insert_unit_comm
						.Connection = insert_unit_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_unit_query
						.Parameters.AddWithValue("@Unit", unit_)
					End With
					Try
						insert_unit_conn.Open()
						insert_unit_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub
	Public Sub ClearFields()
		Categories.Text = ""
		Unit.Text = ""
		Item.Text = ""
		UnitCost.Text = ""
		UnitPrice.Text = ""
		UnitProfit.Text = "0"
		QuantityBought.Text = "0"
		CriticalQuantity.Text = "0"
		Discount.Text = "0"
		DiscountUnits.Text = "0"
		UseDiscount.Checked = False
		TotalProfit.Text = ""
		Picture.BackgroundImage = Image.FromFile(m_.logo)

	End Sub
#End Region
	Private Sub NewItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, CommitButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, True, True, o.theme(), Feedback, TimeTimer, TimeLabel)
	End Sub

	Private Sub NewItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Main.ItemsValues
	End Sub

	Private Sub NewItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
			With Categories
				.DataSource = Me.CategoriesDataSet.StockStock
				.DisplayMember = Me.CategoriesDataSet.StockStock.CategoryColumn.ColumnName.ToString
				Me.CategoriesTableAdapter.DistinctCategory(Me.CategoriesDataSet.StockStock)
				.SelectedIndex = -1
			End With
		Catch
		End Try

		Try
			With Unit
				.DataSource = Me.UnitDataSet.StockDropdown
				.DisplayMember = Me.UnitDataSet.StockDropdown.UnitColumn.ColumnName.ToString
				Me.UnitTableAdapter.DistinctUnit(Me.UnitDataSet.StockDropdown)
				.SelectedIndex = -1
			End With
		Catch
		End Try


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

	Private Sub Categories_TextChanged(sender As Object, e As EventArgs) Handles Categories.TextChanged, Unit.TextChanged, Item.TextChanged
		o.ToTitleCase(sender)
	End Sub

	Private Sub UnitCost_TextChanged(sender As Object, e As EventArgs) Handles UnitCost.TextChanged
		GetUnitProfit()
	End Sub
	Private Sub UnitPrice_TextChanged(sender As Object, e As EventArgs) Handles UnitPrice.TextChanged
		GetUnitProfit()
	End Sub
	Private Sub QuantityBought_TextChanged(sender As Object, e As EventArgs) Handles QuantityBought.TextChanged
		GetTotalProfit()
	End Sub

	Private Sub UnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UnitCost.KeyPress, UnitPrice.KeyPress, QuantityBought.KeyPress, CriticalQuantity.KeyPress, Discount.KeyPress, DiscountUnits.KeyPress
		o.AllowDigitOnly(e)
	End Sub

	Private Sub CommitButton_Click(sender As Object, e As EventArgs) Handles CommitButton.Click

		If Categories.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the category.", "")
			Categories.Focus()
			Exit Sub
		End If
		If Unit.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the unit.", "")
			Unit.Focus()
			Exit Sub
		End If
		If Item.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the name.", "")
			Item.Focus()
			Exit Sub
		End If
		If UnitCost.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the cost.", "")
			UnitCost.Focus()
			Exit Sub
		End If
		If UnitPrice.Text.Trim.Length < 1 Then
			f.Feedback("Please enter the price.", "")
			UnitPrice.Focus()
			Exit Sub
		End If

		If UseDiscount.Checked = True Then
			If Val(Discount.Text.Trim) < 0 Or Val(Discount.Text.Trim) > 100 Then
				f.Feedback("Please enter the discount.", "")
				Discount.Focus()
				Exit Sub
			End If
		End If

		If Me.StockTableAdapter.Count_Item_Unit_Category(Item.Text.Trim, Unit.Text.Trim, Categories.Text.Trim) > 0 Then
			f.Feedback("That item already exists.", "")
			Exit Sub
		End If

		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanRecordStock(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot create record.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		'create record
		If f.Feedback("Press OK to create record...", "", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

		'add unit to database if new one was entered
		If Me.UnitTableAdapter.Count_Unit(Unit.Text.Trim) < 1 Then
			AddUnit(Unit.Text.Trim)
		End If

		If Picture.BackgroundImage Is Nothing Then
			Picture.BackgroundImage = Image.FromFile(m_.logo)
		End If

		Dim itemID As String = "ITEM-" & o.NewID.ToUpper

		Try
			CommitButton.Enabled = False
			ResetButton.Enabled = False

			'commit
			CommitItem(itemID)
			LogItem(itemID)

			'log
			LogEvent("New Item", "Item record created", "", "", itemID)

			'exit
			f.Feedback("Item " & itemID & " successfully created.", "Database update successful.")
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

End Class