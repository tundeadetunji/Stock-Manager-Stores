Imports System.Data.SqlClient
Public Class EditItem
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

	Private Sub LogItem()
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
						.Parameters.AddWithValue("@ItemID", selected_item.Text)
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
	Private Sub CommitItem()
		Try

			Dim stream As New IO.MemoryStream
			Dim photo_ As Image = Picture.BackgroundImage
			If photo_ IsNot Nothing Then
				photo_.Save(stream, Imaging.ImageFormat.Jpeg)
			End If

			Dim insert_query As String = "UPDATE [StockStock] SET  UnitCost=@UnitCost, UnitPrice=@UnitPrice, QuantityBought=@QuantityBought, Discount=@Discount, DiscountUnits=@DiscountUnits, UseDiscount=@UseDiscount, Picture=@Picture, RecordBy=@RecordBy, RecordDate=@RecordDate, RecordTime=@RecordTime, UnitProfit=@UnitProfit, TotalProfit=@TotalProfit, SessionID=@SessionID WHERE (RecordSerial=@RecordSerial)"
			Using insert_conn As New SqlConnection(sequel_connection_string)
				Using insert_comm As New SqlCommand()
					With insert_comm
						.Connection = insert_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_query
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
						.Parameters.AddWithValue("@SessionID", session_id)
						.Parameters.AddWithValue("@RecordSerial", ItemsRecordSerial.Text)
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

	Private Sub PlaceNewQuantity()
		NewQuantity.Text = Val(Quantity.Text) + Val(QuantityBought.Text.Trim)
	End Sub

	Private Sub PlaceCriticalQuantity()
		CriticalQuantity.Text = (10 / 100) * Val(NewQuantity.Text.Trim)
	End Sub
	Private Sub GetUnitProfit()
		UnitProfit.Text = Val(UnitPrice.Text.Trim) - Val(UnitCost.Text.Trim)
		GetTotalProfit()
	End Sub

	Private Sub GetTotalProfit()
		TotalProfit.Text = Val(UnitProfit.Text) * Val(NewQuantity.Text) & "  (without discount)"
	End Sub

	Public Sub ClearFields()
		Categories.Text = ItemsCategories.Text
		Unit.Text = ItemsUnit.Text
		Item.Text = ItemsItem.Text
		UnitCost.Text = ItemsUnitCost.Text
		UnitPrice.Text = ItemsUnitPrice.Text
		'		UnitProfit.Text = "0"
		QuantityBought.Text = ""
		Quantity.Text = ItemsQuantity.Text
		NewQuantity.Text = "0"
		'		CriticalQuantity.Text = ItemsCriticalQuantity.Text
		Discount.Text = ItemsDiscount.Text
		DiscountUnits.Text = ItemsDiscountUnits.Text
		UseDiscount.Checked = ItemsUseDiscount.Checked
		'		TotalProfit.Text = ""
		Picture.BackgroundImage = ItemsPicture.BackgroundImage

	End Sub
#End Region
	Private Sub EditItem_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, CommitButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, True, True, o.theme(), Feedback, TimeTimer, TimeLabel)
	End Sub

	Private Sub EditItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Main.ItemsValues()
	End Sub

	Private Sub EditItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'first thing
		ConnectString()

		'language
		MarkLanguage()

		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)


		'dialog
		DialogTitle.Text = "Update " & selected_item.Text & " - Stock Manager"
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, CommitButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, True, True, o.theme(), Feedback, TimeTimer, TimeLabel)

		'begin
		GetValues()
		ClearFields()
	End Sub

	Public Sub GetValues()

	End Sub

	Private Sub BrowseForPicture_Click(sender As Object, e As EventArgs) Handles BrowseForPicture.Click
		Try
			Picture.BackgroundImage = Image.FromFile(o.GetFile("picture", ""))
		Catch ex As Exception
		End Try
	End Sub
	Private Sub ClearPicture_Click(sender As Object, e As EventArgs) Handles ClearPicture.Click
		Picture.BackgroundImage = ItemsPicture.BackgroundImage
	End Sub

	Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
		If f.Feedback("Pressing OK will clear all fields.", "", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
		ClearFields()
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
	Private Sub NewQuantity_TextChanged(sender As Object, e As EventArgs) Handles NewQuantity.TextChanged
	End Sub

	Private Sub UnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UnitCost.KeyPress, UnitPrice.KeyPress, QuantityBought.KeyPress, CriticalQuantity.KeyPress, Discount.KeyPress, DiscountUnits.KeyPress
		o.AllowDigitOnly(e)
	End Sub

	Private Sub CommitButton_Click(sender As Object, e As EventArgs) Handles CommitButton.Click
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
		If Val(QuantityBought.Text.Trim) = 0 Then
			f.Feedback("Please enter the quantity.", "")
			QuantityBought.Focus()
			Exit Sub
		End If

		If UseDiscount.Checked = True Then
			If Val(Discount.Text.Trim) < 0 Or Val(Discount.Text.Trim) > 100 Then
				f.Feedback("Please enter the discount.", "")
				Discount.Focus()
				Exit Sub
			End If
		End If

		'create record
		If f.Feedback("Press OK to update record...", "", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

		If Picture.BackgroundImage Is Nothing Then
			Picture.BackgroundImage = Image.FromFile(m_.logo)
		End If

		Try
			CommitButton.Enabled = False
			ResetButton.Enabled = False

			'commit
			CommitItem()
			LogItem()

			'log
			LogEvent("New Stock", "Units added to Item", "", "", selected_item.Text)

			'exit
			f.Feedback("Item " & selected_item.Text & " successfully updated.", "Database update successful.")
			'/
			'			DefaultAction(Me.Name)
			Me.Close()

		Catch ex As Exception
			f.Feedback("An error occured while processing the request. Please verify that the record was created or updated.", "Error. Database update inaccessible.")
		Finally
			CommitButton.Enabled = True
			ResetButton.Enabled = True
		End Try
	End Sub

	Private Sub Categories_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Categories.KeyPress, Item.KeyPress, Unit.KeyPress
		o.AllowNothing(e)
	End Sub

End Class