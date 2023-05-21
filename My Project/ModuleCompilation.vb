Module ModuleBuild

	Sub Build()
		For Each i In AllE.Values
			i.Clear()
		Next
		For Each i In AllEA.Values
			i.Clear()
		Next
		For Each i$ In CodeDisc
			Dim iDecod As List(Of List(Of String)) = ReadCodeDisc(i)
			Dim eName$ = ""
			For i2 = 0 To iDecod(0).Count - 1
				If iDecod(0)(i2) <> "" Then
					Dim name$ = ""
					Dim args = ""
					For i3 = iDecod(0)(i2).Length - 1 To 0 Step -1
						If iDecod(0)(i2)(i3) = "." Then
							Exit For
						Else
							name = name.Insert(0, iDecod(0)(i2)(i3))
						End If
					Next
					If Not name.Contains("TextBox") Then
						name = GetBlockClassTypeFromName(name)
					End If
					If iDecod(1).Count > i2 Then
						If iDecod(1)(i2).Length > 0 Then
							For i3 = iDecod(1)(i2).Length - 1 To 0 Step -1
								If iDecod(1)(i2)(i3) = "." Then
									Exit For
								Else
									args = args.Insert(0, iDecod(1)(i2)(i3))
								End If
							Next
						End If
					End If
					If i2 = 0 Then
						For i3 = 0 To iDecod(0)(i2).Length - 1
							If IsNumeric(iDecod(0)(i2)(i3)) OrElse iDecod(0)(i2)(i3) = "." Then
								Exit For
							Else
								eName += iDecod(0)(i2)(i3)
							End If
						Next
					End If
					eName = eName.Replace("-", "")
					name = name.Replace("-", "")
					'MsgBox(name & " name" & vbCrLf & eName & " ename" & vbCrLf & i2 & " i2")
					If name <> eName Then
						DistributorManger(name, eName, args)
					End If
				End If
			Next
		Next
	End Sub

	Sub DistributorManger(pfName As String, eventName As String, args As Object)
		If pfName <> "" Then
			If pfName.Contains("TextBox") Then
				Dim nI As Integer
				For i = pfName.Length - 1 To 0 Step -1
					If IsNumeric(pfName(i)) And Not IsNumeric(pfName(i - 1)) Then
						nI = i
						Exit For
					End If
				Next
				pfName = pfName.Insert(nI, "_")
				AllEA(eventName)(AllEA(eventName).Count - 1) = TextBoxContent(FindTextBoxContentIndex(pfName))(1)
				MsgBox(ArrToString(TextBoxContent(FindTextBoxContentIndex(pfName))) & vbCrLf & pfName)
			Else
				AllE(eventName).Add(AllPF(pfName))
				AllEA(eventName).Add(args)
			End If
		End If
	End Sub

	Sub BuildMsgBox(prompt As String)
		MsgBox(prompt)
	End Sub

	Sub AllPFFiller()
		AllPF.Add("MsgBox", AddressOf BuildMsgBox)
	End Sub
End Module

Class ClassBuild
	Public Property Parent As ClassBuild
	Public Property Name As String
	Public Property Container As List(Of ClassBuild)
End Class