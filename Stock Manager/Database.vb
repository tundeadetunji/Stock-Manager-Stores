Imports System.Data.SqlClient
Module Database
#Region "Declarations"

	Public o As New General_Module.FormatWindow
	Public f As New Feedback.Feedback
	Public m_ As New GeneralModule.Methods
	Public i As New GeneralModule.Information

	Public username_ As String
	Public session_id As String

	Public img As Image
	Public rect As New System.Drawing.Rectangle
	Public item_f_ As New Font("Courier New", 9, GraphicsUnit.Point)

	Public report_sheet_file As String = My.Application.Info.DirectoryPath & "\My_Admin_Report_Sheet.txt"
	Public stringToPrint As String
	Private on_record_assessment As String = My.Application.Info.DirectoryPath & "\Settings_On_Record.txt"
	Private on_record_student_memo As String = My.Application.Info.DirectoryPath & "\Settings_On_Promote.txt"
	Private on_record_user_memo As String = My.Application.Info.DirectoryPath & "\Settings_On_Add.txt"

	Private on_record_assessment_file As String = My.Application.Info.DirectoryPath & "\Settings_On_Record_File.txt"    'score
	Private on_record_student_memo_file As String = My.Application.Info.DirectoryPath & "\Settings_On_Promote_File.txt" 'promote
	Private on_record_user_memo_file As String = My.Application.Info.DirectoryPath & "\Settings_On_Add_File.txt"        'achievement/award/remark


#End Region

#Region "Connection"
	Public sequel_connection_string As String = "YOUR_DATABASE_CONNECTION_STRING_HERE"
	Public cart_file As String = My.Application.Info.DirectoryPath & "\67658385.mdb" 'your local file, for temporary database actions
	Public cart_connection_string As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & cart_file & ";Persist Security Info=True" 'REPLACE THIS WITH YOUR_FINAL_LOCAL_DATABASE_CONNECTION_STRING_
	Public Sub ConnectString()
		My.MySettings.Default("ConnectionString") = sequel_connection_string
		My.MySettings.Default("CartConnectionString") = cart_connection_string

	End Sub

#End Region


#Region "Log"
	Public Sub LogEvent(ByVal log_title As String, ByVal log_memo As String, Optional user_id__ As String = "", Optional client_id__ As String = "", Optional item_id__ As String = "", Optional log_trigger As String = "User")

		Dim log_query As String = "INSERT INTO StockProgramLog (LogTitle, LogDate, LogTime, LogTrigger, TriggerUsername, LogMemo, UserID, ClientID, ItemID, SessionID, LogIP) VALUES (@LogTitle, @LogDate, @LogTime, @LogTrigger, @TriggerUsername, @LogMemo, @UserID, @ClientID, @ItemID, @SessionID, @LogIP)"

		Using log_conn As New SqlConnection(sequel_connection_string)
			Using log_comm As New SqlCommand()
				With log_comm
					.Connection = log_conn
					.CommandTimeout = 0
					.CommandType = CommandType.Text
					.CommandText = log_query
					.Parameters.AddWithValue("@LogTitle", log_title)
					.Parameters.AddWithValue("@LogDate", Now.ToShortDateString)
					.Parameters.AddWithValue("@LogTime", Now.ToLongTimeString)
					.Parameters.AddWithValue("@LogTrigger", log_trigger)
					.Parameters.AddWithValue("@TriggerUsername", username_)
					.Parameters.AddWithValue("@LogMemo", log_memo)
					.Parameters.AddWithValue("@UserID", user_id__)
					.Parameters.AddWithValue("@ClientID", client_id__)
					.Parameters.AddWithValue("@ItemID", item_id__)
					.Parameters.AddWithValue("@SessionID", session_id)
					.Parameters.AddWithValue("@LogIP", o.IP())
				End With
				Try
					log_conn.Open()
					log_comm.ExecuteNonQuery()
				Catch ex As Exception
				Finally
				End Try
			End Using
		End Using
	End Sub

#End Region

#Region "Settings"
	Public Function OnNewAssessment() As String
		Try
			Dim on_new_assessment_ As String = ""
			on_new_assessment_ = My.Computer.FileSystem.ReadAllText(on_record_assessment).Trim
			If on_new_assessment_.Length < 1 Then on_new_assessment_ = "do_nothing"
			Return on_new_assessment_
		Catch
		End Try
	End Function

	Public Function OnNewAssessmentFile() As String
		Try
			Return My.Computer.FileSystem.ReadAllText(on_record_assessment_file).Trim
		Catch
		End Try
	End Function

	Public Function OnEditUserMemo() As String
		Try
			Dim on_edit_user_memo_ As String = ""
			on_edit_user_memo_ = My.Computer.FileSystem.ReadAllText(on_record_user_memo).Trim
			If on_edit_user_memo_.Length < 1 Then on_edit_user_memo_ = "do_nothing"
			Return on_edit_user_memo_
		Catch
		End Try
	End Function

	Public Function OnEditUserMemoFile() As String
		Try
			Return My.Computer.FileSystem.ReadAllText(on_record_user_memo_file).Trim
		Catch
		End Try
	End Function

	Public Function OnEditStudentMemo() As String
		Try
			Dim on_edit_student_memo_ As String = ""
			on_edit_student_memo_ = My.Computer.FileSystem.ReadAllText(on_record_student_memo).Trim
			If on_edit_student_memo_.Length < 1 Then on_edit_student_memo_ = "do_nothing"
			Return on_edit_student_memo_
		Catch
		End Try
	End Function

	Public Function OnEditStudentMemoFile() As String
		Try
			Return My.Computer.FileSystem.ReadAllText(on_record_student_memo_file).Trim
		Catch
		End Try
	End Function

	Public Sub saveSettings(on_new_assessment_action_ As String, on_new_assessment_file_ As String, on_edit_student_memo_action_ As String, on_edit_student_memo_file_ As String, on_edit_user_memo_action_ As String, on_edit_user_memo_file_ As String)
		Try
			My.Computer.FileSystem.WriteAllText(on_record_assessment, on_new_assessment_action_, False)
			My.Computer.FileSystem.WriteAllText(on_record_assessment_file, on_new_assessment_file_, False)

			My.Computer.FileSystem.WriteAllText(on_record_student_memo, on_edit_student_memo_action_, False)
			My.Computer.FileSystem.WriteAllText(on_record_student_memo_file, on_edit_student_memo_file_, False)

			My.Computer.FileSystem.WriteAllText(on_record_user_memo, on_edit_user_memo_action_, False)
			My.Computer.FileSystem.WriteAllText(on_record_user_memo_file, on_edit_user_memo_file_, False)
		Catch
		End Try
	End Sub


#End Region

#Region "Default Action"
	Public Sub DefaultAction(dialog_or_panel As String)
		Try
			Select Case dialog_or_panel.ToLower
				Case "score"
					o.DefaultAction(OnNewAssessment(), OnNewAssessmentFile())
				Case "promote"
					o.DefaultAction(OnEditStudentMemo(), OnEditStudentMemoFile())
				Case "achievement"
					o.DefaultAction(OnEditUserMemo(), OnEditUserMemoFile())
			End Select
		Catch
		End Try
	End Sub
#End Region

#Region "Stock Manager"
	Public Function Gross__(quantity_bought As VariantType, discount_units As VariantType, unit_price As VariantType, discount As VariantType, use_discount As Boolean)
		If use_discount Then
			discount /= 100
			Dim discounted_value = unit_price * discount
			Dim discounted_price = unit_price - discounted_value
			Dim amount_from_discount_units = discounted_price * discount_units
			Dim amount_from_units = unit_price * (quantity_bought - discount_units)
			Return amount_from_discount_units + amount_from_units
		ElseIf use_discount = False Then
			Return quantity_bought * unit_price
		End If

	End Function

#End Region
End Module
