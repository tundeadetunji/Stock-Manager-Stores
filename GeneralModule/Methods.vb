Imports System.Windows.Forms

Public Class Methods

#Region "Declarations"
	Public logo As String = My.Application.Info.DirectoryPath & "\logo.jpg"

#End Region

#Region "Help"
	Public Sub Help(app_ As String, dialog As Form)
		Select Case dialog.Name
			Case "UserAccess"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\LoggingIn.html")
				Catch
					'			MsgBox("Service is currently not available. Will be back soon.")
				End Try
				Exit Sub
			Case "EditCustomer"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Clients.html")
				Catch
				End Try
				Exit Sub
			Case "NewCustomer"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Clients.html")
				Catch
				End Try
				Exit Sub
			Case "EditItem"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Items.html")
				Catch
				End Try
				Exit Sub
			Case "NewItem"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Items.html")
				Catch
				End Try
				Exit Sub
			Case "NewSale"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Sales.html")
				Catch
				End Try
				Exit Sub
		End Select
		Select Case app_
			Case "Stock Manager Program Log"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\ProgramLog.html")
				Catch
				End Try
			Case "Stock Manager Main"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\LoggingIn.html")
				Catch
				End Try
			Case "Stock Manager Users"
				Try
					Process.Start(My.Application.Info.DirectoryPath & "\Users.html")
				Catch
				End Try
		End Select
	End Sub

#End Region

End Class
