Module ModuleBuild

	Sub FillCalendar()
		For Each i In EventB
			calendar.Add(New List(Of Action(Of Object)))
		Next
	End Sub

	Sub Build()
		For Each i$ In CodeDisc
			Dim iDecod As List(Of List(Of String)) = ReadCodeDisc(i)
			MsgBox(ArrToString(iDecod, vbCrLf & "next" & vbCrLf))
			For i2 = 0 To iDecod(0).Count - 1

			Next
		Next
	End Sub

	Sub BuildMsgBox(prompt As String)

	End Sub

End Module

Class ClassBuild
	Public Property Parent As ClassBuild
	Public Property Name As String
	Public Property Container As List(Of ClassBuild)
End Class