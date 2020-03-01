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
	Public rect As New Rectangle
	Public item_f_ As New Font("Courier New", 11, FontStyle.Bold)


#End Region

#Region "Connection"
	Public sequel_connection_string As String = "YOUR DATABASE CONNECTION STRING"
	Public Sub ConnectString()
		My.MySettings.Default("ConnectionString") = sequel_connection_string

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

End Module
