Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class NewSale
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

#Region "Cart"

	Private Sub PrintReceipt_()

		If PrintReceipt.Checked = False Then GoTo 5

		Dim receipt_string As String = ""
		Dim total_ = 0

		img = Image.FromFile(m_.logo)
		Dim img_w As Single = img.Width
		Dim img_h As Single = img.Height
		If img_w > img_h Then   'landscape
            Dim k As Single = img_h / img_w
			Dim target_h As Single = k * 148
			rect.Width = 148
			rect.Height = target_h
			rect.X = (420 - 148) / 2
			rect.Y = 15
		ElseIf img_w < img_h Then    'portrait 
            Dim k As Single = img_w / img_h
			Dim target_w As Single = k * 111
			rect.Width = target_w
			rect.Height = 111
			rect.X = (420 - target_w) / 2
			rect.Y = 15
		Else    'square
            rect.Width = 111
			rect.Height = 111
			rect.X = (420 - 111) / 2
			rect.Y = 15
		End If
		'
		For r% = 1 To rect.Height / 15
			receipt_string &= vbCrLf
		Next

		receipt_string &= vbCrLf & vbCrLf
		receipt_string &= i.CompanyAddress
		receipt_string &= vbCrLf & "Phone: " & i.CompanyPhone
		receipt_string &= vbCrLf & "Email: " & i.CompanyEmail
		receipt_string &= vbCrLf & vbCrLf
		receipt_string &= "Receipt Number: " & ReceiptNumber.Text
		receipt_string &= vbCrLf & "Date: " & Now.ToShortDateString & "  Time: " & Now.ToShortTimeString
		receipt_string &= vbCrLf & "Sale by: " & username_
		receipt_string &= vbCrLf & vbCrLf

		Dim cart_currency_symbol As String = Mid(o.currency_symbol, 1, 3)
		receipt_string &= "#    ITEM                  PRICE (" & cart_currency_symbol
		If cart_currency_symbol.Length = 1 Then
			receipt_string &= ")   QTY     TOTAL (" & Mid(o.currency_symbol, 1, 3) & ")" & vbCrLf
		ElseIf cart_currency_symbol.Length = 2 Then
			receipt_string &= ")  QTY     TOTAL (" & Mid(o.currency_symbol, 1, 3) & ")" & vbCrLf
		ElseIf cart_currency_symbol.Length = 3 Then
			receipt_string &= ") QTY     TOTAL (" & Mid(o.currency_symbol, 1, 3) & ")" & vbCrLf
		End If

		CartBindingSource.MoveFirst()
		With Cart
			For c_% = 0 To .Rows.Count - 1
				receipt_string &= o.Spaces((Val(Mid(c_, 1, 4)) + 1), 4, False) & " " & o.Spaces(Mid(.Rows(c_).Cells(0).Value, 1, 21), 21) & " " & o.Spaces(Mid(FormatNumber(Val(.Rows(c_).Cells(2).Value), 2, TriState.False, TriState.False, TriState.False), 1, 11), 11) & " " & o.Spaces(Mid(FormatNumber(Val(.Rows(c_).Cells(1).Value), 2, TriState.False, TriState.False, TriState.False), 1, 7), 7) & " " & FormatNumber(Val(.Rows(c_).Cells(4).Value), 2, TriState.False, TriState.False, TriState.False) & vbCrLf
				total_ += FormatNumber(Val(.Rows(c_).Cells(4).Value), 2, TriState.False, TriState.False, TriState.False)
				CartBindingSource.MoveNext()
			Next
		End With
		receipt_string &= vbCrLf & "Total Amount Paid: " & o.currency_symbol & FormatNumber(Val(total_), 2, TriState.False, TriState.False, TriState.False)

		Me.ReceiptTableAdapter.Receipt(Me.ReceiptDataSet.Receipt)
		receipt_string &= vbCrLf & ThankYouL.Text
		receipt_string &= vbCrLf & vbCrLf & vbCrLf & AdditionalInfoL.Text


		FileIO.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Receipt.txt", receipt_string, False)
		Dim docName As String = "Receipt.txt"
		Dim docPath As String = My.Application.Info.DirectoryPath & "\"
		PrintDocument.DocumentName = docName
		Dim stream As New FileStream(docPath + docName, FileMode.Open)

		Dim reader As New StreamReader(stream)

		stringToPrint = reader.ReadToEnd()

		PrintDocument.Print()
		reader.Dispose()
		stream.Dispose()

5:
		Dim spent__ = 0
		CartBindingSource.MoveFirst()
		With Cart
			For c__% = 0 To .Rows.Count - 1
				spent__ += Val(Cart_Gross.Text)
				CartBindingSource.MoveNext()
			Next
		End With
		UpdateClient(spent__)

	End Sub

	Private Sub CommitSale()
		CartBindingSource.MoveFirst()
		For ic As Integer = 0 To Cart.Rows.Count - 1
			Try
				Dim insert_sale_query As String = "INSERT INTO [StockSales] (ClientID, Item, UnitPrice, QuantityBought, Discount, UseDiscount, TotalCost, RecordDate, RecordTime, RecordMonth, RecordYear, RecordBy, UnitProfit, TotalProfit, ItemID, SessionID, ReceiptNumber, ItemRecordSerial, Gross) VALUES (@ClientID, @Item, @UnitPrice, @QuantityBought, @Discount, @UseDiscount, @TotalCost, @RecordDate, @RecordTime, @RecordMonth, @RecordYear, @RecordBy, @UnitProfit, @TotalProfit, @ItemID, @SessionID, @ReceiptNumber, @ItemRecordSerial, @Gross)"
				Using insert_sale_conn As New SqlConnection(sequel_connection_string)
					Using insert_sale_comm As New SqlCommand()
						With insert_sale_comm
							.Connection = insert_sale_conn
							.CommandTimeout = 0
							.CommandType = CommandType.Text
							.CommandText = insert_sale_query
							.Parameters.AddWithValue("@ClientID", Main.selected_client.Text)
							.Parameters.AddWithValue("@Item", Cart_Item.Text.Trim)
							.Parameters.AddWithValue("@UnitPrice", Cart_UnitPrice.Text.Trim)
							.Parameters.AddWithValue("@QuantityBought", Val(Cart_Quantity_Bought.Text.Trim))
							.Parameters.AddWithValue("@Discount", Val(Cart_Discount.Text.Trim))
							.Parameters.AddWithValue("@UseDiscount", Cart_UseDiscount.Checked)
							.Parameters.AddWithValue("@TotalCost", Cart_TotalCost.Text)
							.Parameters.AddWithValue("@RecordDate", Now.ToShortDateString)
							.Parameters.AddWithValue("@RecordTime", Now.ToLongTimeString)
							.Parameters.AddWithValue("@RecordMonth", Now.Month.ToString)
							.Parameters.AddWithValue("@RecordYear", Now.Year.ToString)
							.Parameters.AddWithValue("@RecordBy", username_)
							.Parameters.AddWithValue("@UnitProfit", Val(Cart_UnitProfit.Text.Trim))
							.Parameters.AddWithValue("@TotalProfit", Val(Cart_Gross.Text) - Val(Cart_TotalCost.Text))
							.Parameters.AddWithValue("@ItemID", Cart_ItemID.Text.Trim)
							.Parameters.AddWithValue("@SessionID", session_id)
							.Parameters.AddWithValue("@ReceiptNumber", ReceiptNumber.Text)
							.Parameters.AddWithValue("@ItemRecordSerial", Cart_ItemRecordSerial.Text)
							.Parameters.AddWithValue("@Gross", Val(Cart_Gross.Text))
						End With
						Try
							insert_sale_conn.Open()
							insert_sale_comm.ExecuteNonQuery()
						Catch ex As Exception
						End Try
					End Using
				End Using
			Catch
			End Try
			CartBindingSource.MoveNext()
		Next

		LogItems()

	End Sub

	Private Sub UpdateClient(spent_)

		Dim update_client_query As String = "UPDATE [StockClients] SET Spent=@Spent WHERE (RecordSerial=@RecordSerial)"
		Using update_client_conn As New SqlConnection(sequel_connection_string)
			Using update_client_comm As New SqlCommand()
				With update_client_comm
					.Connection = update_client_conn
					.CommandTimeout = 0
					.CommandType = CommandType.Text
					.CommandText = update_client_query
					.Parameters.AddWithValue("@Spent", Val(Main.ClientSpent.Text) + spent_)
					.Parameters.AddWithValue("@RecordSerial", Main.ClientRecordSerial.Text)
				End With
				Try
					update_client_conn.Open()
					update_client_comm.ExecuteNonQuery()
				Catch ex As Exception
				End Try
			End Using
		End Using

		CommitSale()


	End Sub

	Private Sub LogItems()
		CartBindingSource.MoveFirst()
		With Cart
			For l As Integer = 0 To .Rows.Count - 1
				Try
					Dim stream As New IO.MemoryStream
					Dim photo_ As Image = Cart_Picture.BackgroundImage
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
								.Parameters.AddWithValue("@Category", CartCategory.Text.Trim)
								.Parameters.AddWithValue("@Item", Cart_Item.Text.Trim)
								.Parameters.AddWithValue("@Unit", CartUnit.Text.Trim)
								.Parameters.AddWithValue("@UnitCost", Cart_UnitCost.Text.Trim)
								.Parameters.AddWithValue("@UnitPrice", Cart_UnitPrice.Text.Trim)
								.Parameters.AddWithValue("@QuantityBought", Val(Cart_Quantity_Bought.Text.Trim))
								.Parameters.AddWithValue("@Discount", Val(Cart_Discount.Text.Trim))
								.Parameters.AddWithValue("@DiscountUnits", Val(Cart_DiscountUnits.Text.Trim))
								.Parameters.AddWithValue("@UseDiscount", Cart_UseDiscount.Checked)
								.Parameters.AddWithValue("@Picture", stream.GetBuffer())
								.Parameters.AddWithValue("@RecordBy", username_)
								.Parameters.AddWithValue("@RecordState", "Sale")
								.Parameters.AddWithValue("@RecordDate", Now.ToShortDateString)
								.Parameters.AddWithValue("@RecordTime", Now.ToLongTimeString)
								.Parameters.AddWithValue("@UnitProfit", Cart_UnitProfit.Text.Trim)
								.Parameters.AddWithValue("@TotalProfit", Val(Cart_Gross.Text) - Val(Cart_TotalCost.Text))
								.Parameters.AddWithValue("@TotalCost", Val(Cart_TotalCost.Text.Trim))
								.Parameters.AddWithValue("@RecordMonth", Now.Month.ToString)
								.Parameters.AddWithValue("@RecordYear", Now.Year.ToString)
								.Parameters.AddWithValue("@ItemID", Cart_ItemID.Text)
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
				CartBindingSource.MoveNext()
			Next
		End With

		LogEvent("Sale", "Sale was recorded", "", Main.selected_client.Text, "")
		Me.Close()
	End Sub

	Private Sub CartValues()
		Try
			Me.CartTableAdapter.WhereReceiptNumber(Me.CartDataSet.Cart, ReceiptNumber.Text)
			Me.CartBindingSource.MoveLast()
		Catch
		End Try
	End Sub
	Private Sub RemoveItem(record_serial)
		Try
			Dim delete_item_query As String = "DELETE FROM [Cart] WHERE (RecordSerial=@RecordSerial)"
			Using delete_item_conn As New OleDbConnection(cart_connection_string)
				Using delete_item_comm As New OleDbCommand()
					With delete_item_comm
						.Connection = delete_item_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = delete_item_query
						.Parameters.AddWithValue("@RecordSerial", record_serial)
					End With
					Try
						delete_item_conn.Open()
						delete_item_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try

		CartValues()
	End Sub

	Private Sub RemoveItems()
		Try
			Dim delete_cart_query As String = "DELETE FROM [Cart] WHERE (ReceiptNumber=@ReceiptNumber)"
			Using delete_cart_conn As New OleDbConnection(cart_connection_string)
				Using delete_cart_comm As New OleDbCommand()
					With delete_cart_comm
						.Connection = delete_cart_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = delete_cart_query
						.Parameters.AddWithValue("@ReceiptNumber", ReceiptNumber.Text)
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

		CartValues()
	End Sub

	Private Sub UpdateItem(quantity_bought, gross_, total_cost)
		Try
			Dim update_cart_query As String = "UPDATE [Cart] SET QuantityBought=@QuantityBought, Gross=@Gross, TotalCost=@TotalCost WHERE (ItemID=@ItemID AND ReceiptNumber=@ReceiptNumber)"
			Using update_cart_conn As New OleDbConnection(cart_connection_string)
				Using update_cart_comm As New OleDbCommand()
					With update_cart_comm
						.Connection = update_cart_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = update_cart_query
						.Parameters.AddWithValue("@QuantityBought", quantity_bought)
						.Parameters.AddWithValue("@Gross", gross_)
						.Parameters.AddWithValue("@TotalCost", total_cost)
						.Parameters.AddWithValue("@ItemID", ItemItemID.Text)
						.Parameters.AddWithValue("@ReceiptNumber", ReceiptNumber.Text)
					End With
					Try
						update_cart_conn.Open()
						update_cart_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try

		CartValues()
	End Sub
	Private Sub AddItem(gross_)
		Try

			Dim stream As New IO.MemoryStream
			Dim photo_ As Image = ItemPicture.BackgroundImage
			If photo_ IsNot Nothing Then
				photo_.Save(stream, Imaging.ImageFormat.Jpeg)
			End If

			Dim insert_cart_query As String = "INSERT INTO [Cart] (UnitPrice, QuantityBought, Discount, UseDiscount, ItemID, ReceiptNumber, ItemRecordSerial, Gross, Item, TotalCost, DiscountUnits, UnitCost, Picture, Category, Unit) VALUES (@UnitPrice, @QuantityBought, @Discount, @UseDiscount, @ItemID, @ReceiptNumber, @ItemRecordSerial, @Gross, @Item, @TotalCost, @DiscountUnits, @UnitCost, @Picture, @Category, @Unit)"
			Using insert_cart_conn As New OleDbConnection(cart_connection_string)
				Using insert_cart_comm As New OleDbCommand()
					With insert_cart_comm
						.Connection = insert_cart_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = insert_cart_query
						.Parameters.AddWithValue("@UnitPrice", ItemUnitPrice.Text.Trim)
						.Parameters.AddWithValue("@QuantityBought", Val(ItemQuantityBought.Text.Trim))
						.Parameters.AddWithValue("@Discount", Val(ItemDiscount.Text.Trim))
						.Parameters.AddWithValue("@UseDiscount", ItemUseDiscount.Checked)
						.Parameters.AddWithValue("@ItemID", ItemItemID.Text.Trim)
						.Parameters.AddWithValue("@ReceiptNumber", ReceiptNumber.Text)
						.Parameters.AddWithValue("@ItemRecordSerial", ItemRecordSerial.Text)
						.Parameters.AddWithValue("@Gross", gross_)
						.Parameters.AddWithValue("@Item", ItemName.Text.Trim)
						.Parameters.AddWithValue("@TotalCost", Val(ItemUnitCost.Text) * Val(ItemQuantityBought.Text))
						.Parameters.AddWithValue("@DiscountUnits", Val(ItemDiscountUnits.Text.Trim))
						.Parameters.AddWithValue("@UnitCost", Val(ItemUnitCost.Text.Trim))
						.Parameters.AddWithValue("@Picture", stream.GetBuffer)
						.Parameters.AddWithValue("@Category", Val(ItemCategories.Text.Trim))
						.Parameters.AddWithValue("@Unit", Val(ItemUnit.Text.Trim))
					End With
					Try
						insert_cart_conn.Open()
						insert_cart_comm.ExecuteNonQuery()
					Catch ex As Exception
					Finally
						stream.Dispose()
					End Try
				End Using
			End Using
		Catch
		End Try

		CartValues()
	End Sub

#End Region
	Private Sub NewSale_Activated(sender As Object, e As EventArgs) Handles Me.Activated
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, False, True, o.theme(), Feedback, TimeTimer, TimeLabel)
	End Sub

	Private Sub NewSale_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

	End Sub

	Private Sub NewSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		ConnectString()

		'language
		MarkLanguage()

		'theme
		o.MarkTheme(o.theme, ClassicTheme, LavenderTheme, NightTheme, RoseTheme, StandardTheme)

		'dialog
		ReceiptNumber.Text = "R-" & o.NewID.ToUpper
		DialogTitle.Text = ReceiptNumber.Text & " charged to " & Main.selected_client.Text
		o.FormatMe(Me, LeftBorder, RightBorder, TopBorder, BottomBorder, TopLine, BottomLine, DialogTitle, SystemCloseButton, MinimizeButton, CloseButton, HelpButton, MenuStrip, SystemCloseButton, SystemCloseButton, False, False, False, True, o.theme(), Feedback, TimeTimer, TimeLabel)

		'begin
		GetValues()
	End Sub

	Public Sub GetValues()
		'
		Try
			With ItemItemID
				.DataSource = Me.ItemIDDataSet.StockStock
				.DisplayMember = Me.ItemIDDataSet.StockStock.ItemIDColumn.ColumnName.ToString
				Me.ItemIDTableAdapter.DistinctItemID(Me.ItemIDDataSet.StockStock)
				.SelectedIndex = -1
			End With
		Catch
		End Try

		With psd
			.PageSettings.Margins.Left = 15.6
			.PageSettings.Margins.Top = 15.6
			.PageSettings.Margins.Right = 15.6
			.PageSettings.Margins.Bottom = 15.6
			.Document = PrintDocument
		End With


		'cart grid
		With Cart
			.Columns.Item(0).HeaderText = "Item"
			.Columns.Item(1).HeaderText = "Quantity Bought"
			.Columns.Item(2).HeaderText = "Unit Price"
			.Columns.Item(3).HeaderText = "Discount"
			.Columns.Item(4).HeaderText = "Gross"
			.Columns.Item(5).HeaderText = "Use Discount"
		End With

		Me.UpdateCartTableAdapter.Null(Me.UpdateCartDataSet.Cart)

	End Sub

	Private Sub ItemID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemItemID.SelectedIndexChanged
		Try
			Me.StockTableAdapter.WhereItemID(Me.StockDataSet.StockStock, ItemItemID.Text.Trim)
		Catch
		End Try
		ItemQuantityBought.Text = ""
		ItemQuantityBought.Focus()

	End Sub

	Private Sub QuantityBought_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ItemQuantityBought.KeyPress, NewQuantity.KeyPress
		o.AllowDigitOnly(e)
	End Sub

	Private Sub AddToReceipt_Click(sender As Object, e As EventArgs) Handles AddToReceipt.Click
		If Val(ItemQuantityBought.Text.Trim) = 0 Or ItemItemID.Text.Length < 1 Or Me.ItemIDTableAdapter.Count_ItemID(ItemItemID.Text.Trim) < 1 Then Exit Sub
		Me.UpdateCartTableAdapter.Null(Me.UpdateCartDataSet.Cart) '/

		EnableButtons(False)

		Dim gross_ = o.Gross(Val(ItemQuantityBought.Text), Val(ItemDiscountUnits.Text), Val(ItemUnitPrice.Text), Val(ItemDiscount.Text), ItemUseDiscount.Checked)
		Select Case Me.CartTableAdapter.Count_ItemID_ReceiptNumber(ItemItemID.Text.Trim, ReceiptNumber.Text)
			Case > 0
				f.Feedback("Please change the quantity instead. The item is already in the cart.", "")
			Case < 1
				AddItem(gross_)
		End Select

		EnableButtons(True)
	End Sub

	Private Sub ItemQuantityBought_TextChanged(sender As Object, e As EventArgs) Handles ItemQuantityBought.TextChanged
		'total cost
		ItemTotalCost.Text = Val(ItemQuantityBought.Text.Trim) * ItemUnitCost.Text
	End Sub

	Private Sub ChangeQuantity_Click(sender As Object, e As EventArgs) Handles ChangeQuantity.Click
		If Cart.Rows.Count < 1 Then Exit Sub

		If Val(NewQuantity.Text.Trim) = 0 Then
			f.Feedback("Please enter the quantity you want to change to.", "")
			o.FocusMe(NewQuantity, NewQuantity)
			Exit Sub
		End If

		Dim b As Button = sender
		Select Case b.Text.ToLower
			Case "change quantity"
				Cart.Enabled = False
				b.Text = "Commit New Quantity"
				EnableButtons(False)
				NewQuantity.ReadOnly = False
				b.Enabled = True
				o.FocusMe(NewQuantity, NewQuantity)
			Case "commit new quantity"
				If f.Feedback("Really change quantity?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
					Me.UpdateCartTableAdapter.WhereReceiptNumber(Me.UpdateCartDataSet.Cart, ReceiptNumber.Text)
					NewQuantity.Text = Update_Cart_QuantityBought.Text
					NewQuantity.ReadOnly = True
					b.Text = "Change Quantity"
					Cart.Enabled = True
					EnableButtons(True)
				Else
					Dim gross_ = o.Gross(Val(NewQuantity.Text), Val(Cart_DiscountUnits.Text), Val(Cart_UnitPrice.Text), Val(Cart_Discount.Text), ItemUseDiscount.Checked)
					UpdateItem(Val(NewQuantity.Text), gross_, Val(NewQuantity.Text.Trim) * Cart_UnitCost.Text)
					NewQuantity.ReadOnly = True
					b.Text = "Change Quantity"
					Cart.Enabled = True
					EnableButtons(True)
				End If

		End Select

	End Sub

	Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
		If Cart.Rows.Count < 1 Then Exit Sub

		If f.Feedback("Really remove item?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
		EnableButtons(False)
		RemoveItem(Cart_RecordSerial.Text)
		EnableButtons(True)
	End Sub

	Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
		If Cart.Rows.Count < 1 Then Exit Sub

		If f.Feedback("Really remove all items?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
		EnableButtons(False)
		RemoveItems()
		EnableButtons(True)
	End Sub

	Private Sub CommitButton_Click(sender As Object, e As EventArgs) Handles CommitButton.Click
		If Cart.Rows.Count < 1 Then Exit Sub
		If Me.StockUsersTableAdapter.Count_Username_IsEnabled_CanRecordSale(username_, True, True) < 1 Then
			f.Feedback(username_ & " cannot record sale.", "Operation invalid. Credential is not accessible.")
			Exit Sub
		End If

		If f.Feedback("Close the receipt?", "", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

		EnableButtons(False)
		PrintReceipt_()
		Try
		Catch
		End Try
	End Sub


	Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
		Try
            '
            e.Graphics.DrawImage(img, rect)
			'
			Dim charactersOnPage As Integer = 0
			Dim linesPerPage As Integer = 0

			e.Graphics.MeasureString(stringToPrint, item_f_, e.MarginBounds.Size,
				StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

			e.Graphics.DrawString(stringToPrint, item_f_, Brushes.Black,
				e.MarginBounds, StringFormat.GenericTypographic)

			stringToPrint = stringToPrint.Substring(charactersOnPage)

			e.HasMorePages = stringToPrint.Length > 0
		Catch ex As Exception

		End Try

	End Sub

End Class