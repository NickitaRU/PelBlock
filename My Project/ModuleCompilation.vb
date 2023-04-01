Module ModuleBuild

	Sub Build()
		For Each i$ In CodeDisc
			Dim iDecod As List(Of List(Of String)) = ReadCodeDisc(i)
			For i2 = 0 To iDecod(0).Count - 1
				If iDecod(0)(i2) <> "" Then
					Dim name$ = ""
					Dim args = ""
					Dim eName$ = ""
					For i3 = iDecod(0)(i2).Length - 1 To 0 Step -1
						If iDecod(0)(i2)(i3) = "." Then
							Exit For
						Else
							name = name.Insert(0, iDecod(0)(i2)(i3))
						End If
					Next
					If iDecod(1)(i2).Length > 0 Then
						For i3 = iDecod(1)(i2).Length - 1 To 0 Step -1
							If iDecod(1)(i2)(i3) = "." Then
								Exit For
							Else
								args = args.Insert(0, iDecod(1)(i2)(i3))
							End If
						Next
					End If
					For i3 = 0 To iDecod(0)(i2).Length - 1
						If iDecod(0)(i2)(i3) = "." Then
							Exit For
						Else
							eName += iDecod(0)(i2)(i3)
						End If
					Next
					Select Case name
						Case "MsgBox"
							Select Case eName
								Case "OnStart"
									OnStartC.Add(AddressOf BuildMsgBox)
									OnStartCArgs.Add(args)
								Case "OnStop"
									OnStopC.Add(AddressOf BuildMsgBox)
									OnStopCArgs.Add(args)
							End Select
					End Select
				End If
			Next
		Next
	End Sub

	Sub BuildMsgBox(prompt As String)
		MsgBox(prompt)
	End Sub

End Module

Class ClassBuild
	Public Property Parent As ClassBuild
	Public Property Name As String
	Public Property Container As List(Of ClassBuild)
End Class