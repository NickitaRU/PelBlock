Module ModulePelBlock_Subs_Functions

	Function GetFamalyNameFromName(name$) As String
		Dim classtype$ = GetClassTypeFromName(name)
		For Each i$ In Blocks(0)
			If i = classtype Then
				For i2 = 0 To FamilyNamePos.Count - 1 Step 2
					If i2 < FamilyNamePos.Count - 1 AndAlso Blocks(0).IndexOf(i) >= FamilyNamePos(i2) And Blocks(0).IndexOf(i) <= FamilyNamePos(i2 + 1) Then
						Return FamilyName(i2)
						Exit Function
					End If
				Next
			End If
		Next
		Return ""
	End Function

	Sub CountPesonalCont(obj As Control)
		Dim ObjFamilyName As String = GetFamalyNameFromName(obj.Name)
		Dim ObjC As List(Of List(Of String))
		ObjC = AllC(ObjFamilyName)
		If ObjC IsNot Nothing Then
			For Each i In BlockParants
				For Each i2 In ObjC
					For Each i3 In i2
						If GetClassTypeFromName(i.Name) = i3 Then
							PersonalConteiner.Add(New List(Of Object) From {
													i,
													i.Location + New Size(-20, -20),
													i.Location + i.Size + New Size(20, 20)})
						End If
					Next
				Next
			Next
		End If
	End Sub

	Sub RemoveBlock(AC As Control)
		Dim i = Fr_Code.GB_Blocks.Controls.IndexOf(AC)
		Fr_Code.GB_Blocks.Controls.Remove(AC)
		GBBCh.Remove(GBBCh(GBBCh.Count() - 1))
		Blocks(1)(i) -= 1
		DeleteBlockPropertes(AC)
		If Not AC.Controls(AC.Controls.Count - 1).Name.Contains("TextBox") Then
			BlockContent.RemoveAt(BlockParants.IndexOf(AC))
			BlockParants.Remove(AC)
			BlockContent.RemoveAt(BlockParants.IndexOf(AC.Controls(AC.Controls.Count - 1)))
			BlockParants.RemoveAt(BlockParants.IndexOf(AC.Controls(AC.Controls.Count - 1)))
		End If
	End Sub

	Function GetClassTypeFromName(name$) As String
		If ReadName(name).Count = 3 Then
			Return ReadName(name)(1)
			Exit Function
		Else
			For Each i$ In ReadName(name)
				If Block(0).Contains(i) Then
					Return i
					Exit Function
				End If
			Next
		End If
		Return ""
	End Function

	Function FindBlockClassTypeIndex(name$) As Integer
		For Each i$ In Blocks(0)
			If i = name Then
				Return Blocks(0).IndexOf(i)
				Exit Function
			End If
		Next
		Return -1
	End Function

	'Code description manipulations
	Sub AddCodeDisc(name$, contname$)
		Dim list$
		Dim ContI%
		Dim FGC%
		Dim objL$
		Dim contCDI%
		For Each i In CodeDisc
			If i.Contains(contname) Then
				list = i
				contCDI = CodeDisc.IndexOf(i)
				Exit For
			End If
		Next
		For Each i In CodeDisc
			If i.Contains(name) Then
				objL = i
				CodeDisc.Remove(i)
				Exit For
			End If
		Next
		ContI = list.IndexOf(contname)
		For i = ContI To list.Length - 1
			If list(i) = "{" Then
				FGC += 1
			ElseIf list(i) = "}" Then
				FGC -= 1
				If FGC = 0 Then
					list = list.Insert(i, objL & ",")
				End If
			End If
		Next
		CodeDisc(contCDI) = list
	End Sub

	'End Code description manipulations

	'Logical Functions
	Public Function isBI(obj As GroupBox) As Boolean 'is block inserted 
		Return IIf(obj.Parent IsNot Fr_Code.GB_WF, True, False)
	End Function

	'End Logical Functions

	'Block propertes manipulations
	Sub AddBlockProperties(obj As Control)
		If FindBlockPropertes(obj.Name) Is Nothing Then
			Block(0).Add(obj)
			Block(1).Add(obj.Name)
			Block(2).Add(obj.Parent)
			Block(3).Add(obj.Size)
			Block(4).Add(obj.Location)
			Block(5).Add(New Point(IIf(
			obj.Parent IsNot MakeFamilyTree(obj.Parent).Last,
			CountLeft(obj.Parent),
			0),
							   IIf(
			obj.Parent IsNot MakeFamilyTree(obj.Parent).Last,
			CountTop(obj.Parent),
			0)))
		End If
	End Sub

	Function FindBlockPropertes(name As String) As List(Of Object)
		Dim i% = Block(1).IndexOf(name)
		If i = -1 Then
			Return Nothing
		Else
			Dim preres As New List(Of Object) From {
			Block(0)(i),
			Block(1)(i),
			Block(2)(i),
			Block(3)(i),
			Block(4)(i),
			Block(5)(i)
		}
			Return preres
		End If
	End Function

	Sub DeleteBlockPropertes(name As String)
		Dim i% = Block(1).IndexOf(name)
		Block(0).RemoveAt(i)
		Block(1).RemoveAt(i)
		Block(2).RemoveAt(i)
		Block(3).RemoveAt(i)
		Block(4).RemoveAt(i)
		Block(5).RemoveAt(i)
	End Sub

	Sub DeleteBlockPropertes(cont As GroupBox)
		For Each i$ In ReadBlockContent(cont)
			Dim eName$ = ""
			For i2 = i.Length - 1 To 0 Step -1
				If i(i2) = "." Then
					Exit For
				Else
					eName = eName.Insert(0, i(i2))
				End If
			Next
			Dim i3% = Block(1).IndexOf(eName)
			Block(0).RemoveAt(i3)
			Block(1).RemoveAt(i3)
			Block(2).RemoveAt(i3)
			Block(3).RemoveAt(i3)
			Block(4).RemoveAt(i3)
			Block(5).RemoveAt(i3)

		Next
	End Sub

	Sub RecountBlockProperties(name As String)
		Dim BlockI% = Block(1).IndexOf(name)
		Dim obj As Control = Block(0)(BlockI)
		Block(3)(BlockI) = obj.Size
		Block(4)(BlockI) = obj.Location
		Block(5)(BlockI) = (New Point(IIf(
		obj.Parent IsNot MakeFamilyTree(obj.Parent).Last,
		CountLeft(obj.Parent),
		0),
						   IIf(
		obj.Parent IsNot MakeFamilyTree(obj.Parent).Last,
		CountTop(obj.Parent),
		0)))
	End Sub

	'End Block propertes manipulations

	'Array To String

	Function ArrToString(lst As List(Of Control), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i As Control In lst
			preres += i.Name + sep
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of Integer), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i$ In lst
			preres += i + sep
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of String), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i$ In lst
			preres += i + sep
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of GroupBox), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i As GroupBox In lst
			preres += i.Name + sep
		Next
		Return preres
	End Function

	Function ArrToString(lst As ArrayList, Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i In lst
			If i.ToString.Contains("Forms") Then
				preres += i.name + sep
			Else
				preres += i.ToString + sep
			End If
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of List(Of String)), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i As List(Of String) In lst
			For Each i2$ In i
				preres += i2 & sep
			Next
			preres += vbCrLf
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of Object), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i In lst
			If i.ToString.Contains("Forms") Then
				preres += i.name + sep
			Else
				preres += i.ToString + sep
			End If
		Next
		Return preres
	End Function

	Function ArrToString(lst As List(Of List(Of Object)), Optional sep As String = ", ") As String
		Dim preres$ = ""
		For Each i As List(Of Object) In lst
			For Each i2 In i
				If i2.ToString.Contains("Forms") Then
					preres += i2.name + sep
				Else
					preres += i2.ToString + sep
				End If
			Next
			preres += vbCrLf
		Next
		Return preres
	End Function

	'End Array to String

	'Reading

	Function ReadCodeDisc(contname$) As List(Of List(Of String))
		Dim list$
		Dim preres As New List(Of List(Of String)) From {
			New List(Of String),
			New List(Of String)
		}
		For Each i In CodeDisc
			If i.Contains(contname) Then
				list = i
				Exit For
			End If
		Next

		Dim depth%
		Dim name$ = ""
		Dim isArgb As Boolean
		Dim ArgbDepth%
		Dim wordbase$ = ""
		For i = 0 To list.Length - 1
			If list(i) = "{" Then
				preres(0).Add(name)
				Select Case name
					Case "OnStart", "OnStop"
						preres(1).Add("")
				End Select
				depth += 1
				wordbase = name & "."
				name = wordbase
			ElseIf list(i) = "}" Then
				If name <> "" Then
					preres(0).Add(name)
					Select Case name
						Case "OnStart", "OnStop"
							preres(1).Add("")
					End Select
				End If
				depth -= 1
				For i2 = 0 To wordbase.LastIndexOf(".")
					wordbase = wordbase.Remove(i2, 1)
					wordbase = wordbase.Insert(i2, " ")
				Next
				wordbase = wordbase.Replace(" ", "")
				name = wordbase
			ElseIf list(i) = "," Then
				If name <> "" Then
					preres(0).Add(name)
					Select Case name
						Case "OnStart", "OnStop"
							preres(1).Add("")
					End Select
				End If
				name = wordbase
			ElseIf list(i) = "," And isArgb Then
				preres(1).Add(name)
			ElseIf list(i) = "(" Then
				preres(0).Add(name)
				If isArgb Then
					preres(1).Add(name)
				End If
				isArgb = True
				ArgbDepth += 1
				wordbase = name & "."
				name = wordbase
			ElseIf list(i) = ")" Then
				preres(1).Add(name)
				ArgbDepth -= 1
				If ArgbDepth = 0 Then
					isArgb = False
				End If
				For i2 = 0 To wordbase.LastIndexOf(".")
					wordbase = wordbase.Remove(i2, 1)
					wordbase = wordbase.Insert(i2, " ")
				Next
				wordbase = wordbase.Replace(" ", "")
				name = wordbase
			Else
				name += list(i)
			End If
		Next

		Return preres
	End Function

	Function ReadName(tar As String) As List(Of String)
		Dim preres As New List(Of String)
		Dim ct$ = ""
		For i = 0 To tar.Length - 1
			If tar(i) = "_" Then
				preres.Add(ct)
				ct = ""
			Else
				ct += tar(i)
			End If
		Next
		preres.Add(ct)
		Return preres
	End Function

	Function ReadBlockContent(cont As Control) As List(Of String)
		Dim preres As New List(Of String)
		Dim word$ = ""
		Dim list$, wordc%, deep%
		Dim wordbase$ = ""
		Dim IsWordBaseNeeded As Boolean = False
		Dim IsFGC As Boolean = False

		list = BlockContent(BlockParants.IndexOf(cont))
		For i = 1 To list.Length - 2
			Dim letter As Char = list(i)
			If letter = "," And word <> "" And word <> wordbase Then
				preres.Add("")
				wordc += 1
				preres(wordc - 1) = word
				word = wordbase

			ElseIf letter = "," And IsWordBaseNeeded And word <> "" And word <> wordbase Then
				preres.Add("")
				wordc += 1
				If IsFGC Then
					preres(wordc - 1) = "cont." & word
				Else
					preres(wordc - 1) = word
				End If
				word = wordbase

			ElseIf letter = "}" And IsWordBaseNeeded Then
				deep -= 1
				If deep = 0 Then
					IsWordBaseNeeded = False
				End If

				For i2% = wordbase.Length - 1 To 0 Step -1
					If wordbase(i2) = "." Then
						Exit For
					End If
					wordbase = wordbase.Remove(i2)
				Next

			ElseIf letter = "{" And word <> "" And word <> wordbase Then
				IsWordBaseNeeded = True
				wordbase = word & "."
				deep += 1
				IsFGC = True
				preres.Add("cont." & word)
				wordc += 1
				word = wordbase
			ElseIf letter = "," Then

			Else
				word += letter
			End If
		Next

		Return preres
	End Function

	'End Reading

	'Block content manipulations


	Sub AddBlockContent(cont As GroupBox, type As String, obj As Control, Optional cont2 As Control = Nothing)
		AddBlockProperties(obj)
		Dim FT As List(Of GroupBox) = MakeFamilyTree(cont)
		If Not FT.Contains(cont) Then
			FT.Add(cont)
		End If
		For Each i In FT
			Dim list$
			Dim contindex% = 0

			list = BlockContent(BlockParants.IndexOf(i))

			If cont2 IsNot Nothing Then
				contindex = list.LastIndexOf(cont2.Name)
			End If
			If FT.Count > 1 And cont2 Is Nothing And list.Contains(cont.Name) Then
				contindex = list.LastIndexOf(cont.Name)
			End If

			If type Is "Block" Then
				Dim startindex%
				startindex = list.IndexOf("}", contindex)
				list = list.Insert(startindex, obj.Name & ",")
				BlockContent(BlockParants.IndexOf(i)) = list

			ElseIf type Is "GB" Then
				Dim listObj$
				Dim startindex%
				startindex = list.IndexOf("}", contindex)
				listObj = BlockContent(BlockParants.IndexOf(obj))
				list = list.Insert(startindex, obj.Name & listObj & ",")
				BlockContent(BlockParants.IndexOf(i)) = list
			End If
		Next
	End Sub

	Sub RemoveBlockContent(cont As Control, obj As Control)
		Dim FT As List(Of GroupBox) = MakeFamilyTree(cont)
		FT.Add(cont)
		For Each i2 In FT
			Dim list$ = BlockContent(BlockParants.IndexOf(i2))
			Dim contcontent As List(Of String) = ReadBlockContent(i2)
			Dim objIndex% = list.IndexOf(obj.Name)
			Dim isCont = False
			Dim leng = list.Length
			Dim Deep% = 0
			For i = objIndex To leng - 1
				If i = -1 Then
					Exit For
				End If
				If list(i) = "{" Then
					isCont = True
					list = list.Remove(i, 1)
					list = list.Insert(i, " ")
					Deep += 1
				ElseIf i + 1 = list.Length Then
					Exit For
				ElseIf list(i) = "}" And list(i + 1) = "," And Deep = 0 Then
					Exit For
				ElseIf list(i) = "," And Not isCont Then
					Exit For
				Else
					If list(i) = "}" Then
						Deep -= 1
					End If
					list = list.Remove(i, 1)
					list = list.Insert(i, " ")
				End If
			Next
			list = list.Replace(" ", "")
			BlockContent(BlockParants.IndexOf(i2)) = list
		Next
	End Sub

	'End Block content manipulations

	Function LastInnerPos(cont As GroupBox) As Point
		Dim preres As Point
		For Each i As Control In cont.Controls
			preres = New Point(IIf(preres.Y < i.Top + i.Height, i.Top + i.Height, preres.Y), IIf(preres.X < i.Left + i.Width, i.Left + i.Width, preres.X))
		Next
		Return preres
	End Function

	Function MakeFamilyTree(obj As GroupBox) As List(Of GroupBox)
		Dim preres As New List(Of GroupBox)
		Dim parent As GroupBox = obj.Parent

		While parent IsNot Fr_Code.GB_WF And parent IsNot Fr_Code.GB_Blocks
			preres.Add(parent)
			parent = parent.Parent
		End While
		If preres.Count = 0 Then
			preres.Add(obj)
		End If
		Return preres
	End Function

	Function FindParent(objName$) As GroupBox
		Dim preres As GroupBox
		Dim list$
		Dim pName$ = ""
		Dim si%
		For Each i2 In BlockContent
			If i2.Contains(objName) Then
				list = i2
				Exit For
			End If
		Next

		si = objName.LastIndexOf(objName)

		For i = si - 1 To 0 Step -1
			If list(i) = "." Then
				Exit For
			Else
				pName += list(i)
			End If
		Next

		For Each i As GroupBox In BlockParants
			If i.Name = pName Then
				preres = i
				Exit For
			End If
		Next


		Return preres
	End Function

	Function CountLeft(obj As GroupBox) As Integer
		Dim preres As Integer = 15
		Dim FT As List(Of GroupBox) = MakeFamilyTree(obj)
		For Each i In FT
			If i Is FT.Last Then

			Else
				preres += i.Left
			End If
		Next
		Return preres
	End Function

	Function CountTop(obj As GroupBox) As Integer
		Dim preres As Integer = 20
		Dim FT As List(Of GroupBox) = MakeFamilyTree(obj)
		For Each i In FT
			If i Is FT.Last Then

			Else
				preres += i.Top
			End If
		Next
		Return preres
	End Function

	Function CountMaxSize(cont As GroupBox) As Size
		Dim preres As Size, maxW% = cont.Width, maxH% = cont.Height
		Dim BP As List(Of Object)
		For Each i$ In ReadBlockContent(cont)
			Dim EName$ = ""
			If i.Contains("cont") Then
			Else
				For i2 = i.Length - 1 To 0 Step -1
					If i(i2) = "." Then
						Exit For
					Else
						EName = EName.Insert(0, i(i2))
					End If
				Next
				If EName = "" Then
					Exit For
				End If
				BP = FindBlockPropertes(EName)
				maxW = IIf(maxW < BP(3).Width + BP(4).X + BP(5).X, BP(3).Width + BP(4).X + BP(5).X, maxW)
				maxH = IIf(maxH < BP(3).Height + BP(4).Y + BP(5).Y, BP(3).Height + BP(4).Y + BP(5).Y, maxH)
			End If
		Next
		preres = New Size(maxW, maxH)
		Return preres
	End Function

	Sub BlockReSize(cont As Control)
		Console.WriteLine(ArrToString(BlockContent, vbCrLf))
		Dim contDecod As List(Of String) = ReadBlockContent(cont)
		Dim LastCont As Control = cont
		Dim tb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_TopHorizontal", False)(0)
		Dim bb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_BottomHorizontal", False)(0)
		Dim lb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_LeftHorizontal", False)(0)
		Dim inr As GroupBox = cont.Controls.Find("GB_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_innerBlocks", False)(0)

		For Each i$ In contDecod
			If i.Contains("cont") Then
				Dim LastContName$ = ""
				For i2 = i.Length - 1 To 0 Step -1
					If i(i2) = "." Then
						Exit For
					End If
					LastContName = LastContName.Insert(0, i(i2))
				Next
				LastCont = FindBlockPropertes(LastContName)(0)
				LastCont.Size = CountMaxSize(LastCont)
				Console.WriteLine(CountMaxSize(LastCont).ToString & " " & LastCont.Name)
			End If
		Next
		cont.Size = CountMaxSize(cont)
		lb.Height = cont.Height
		tb.Width = cont.Width
		bb.Width = cont.Width
		bb.Top = cont.Height - bb.Height
		inr.Size = New Size(cont.Width - 15, cont.Height - 30)
	End Sub

	Sub DisVisualize(cont As GroupBox)
		If VisConts.Count <> 0 And isVisualised Then
			Dim tb As Label = cont.Parent.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Parent.Name)(1) & "_" & ReadName(cont.Parent.Name)(2) & "_TopHorizontal", False)(0)
			Dim bb As Label = cont.Parent.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Parent.Name)(1) & "_" & ReadName(cont.Parent.Name)(2) & "_BottomHorizontal", False)(0)
			Dim lb As Label = cont.Parent.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Parent.Name)(1) & "_" & ReadName(cont.Parent.Name)(2) & "_LeftHorizontal", False)(0)
			Dim inr As GroupBox = cont.Parent.Controls.Find("GB_" & "FromGB_" & ReadName(cont.Parent.Name)(1) & "_" & ReadName(cont.Parent.Name)(2) & "_innerBlocks", False)(0)
			cont.Controls.Remove(VisConts(0))
			isVisualised = False
			DeleteBlockPropertes(VisConts(0))
			RemoveBlockContent(cont, VisConts(0))
			For Each i As Control In VisConts
				BlockContent.RemoveAt(BlockParants.IndexOf(i))
				BlockParants.Remove(i)
			Next
			VisConts.Clear()
			cont.Parent.Size = cont.Parent.Size - VisGB.Size
			lb.Height = cont.Parent.Height
			tb.Width = cont.Parent.Width
			bb.Width = cont.Parent.Width
			bb.Top = cont.Parent.Height - bb.Height
			inr.Size = New Size(cont.Parent.Width - 15, cont.Parent.Height - 30)
			visblock = Nothing
			VisGB = Nothing
			Console.WriteLine("DisVisualized")
			BlockReSize(cont.Parent)
		End If
	End Sub

	Sub Visualize(cont As Control, obj As Control) 'GG
		If Not isVisualised Then
			viscont = cont
			visblock = obj
			Dim innerO As Control
			Dim objDecod As List(Of String) = ReadBlockContent(obj)


			innerO = obj.Controls(obj.Controls.Count - 1)

			cont.Controls.Add(New GroupBox With {
												.Name = "Visual_GB",
												.BackColor = Color.Transparent,
												.Location = New Point(LastInnerPos(cont).X, LastInnerPos(cont).Y + 5),
												.Width = obj.Width,
												.Height = obj.Height
												})

			VisGB = cont.Controls.Find("Visual_GB", False)(0)
			BlockParants.Add(VisGB)
			BlockContent.Add("{}")
			AddBlockContent(cont, "GB", VisGB)
			VisConts.Add(VisGB)

			For Each i$ In objDecod
				Dim objECloneName$ = ""

				For i2% = i.Length - 1 To 0 Step -1
					If i(i2) = "." Then
						Exit For
					Else
						objECloneName = objECloneName.Insert(0, i(i2))
					End If
				Next
				If i Is "" Then
					Exit For
				End If
				Dim objEClone As Control = obj.Controls.Find(objECloneName, False)(0)
				If i.Contains("cont") Then
					VisGB.Controls.Add(New GroupBox With {
												.Name = "Visual_GB_" & objEClone.Name,
												.BackColor = Color.Transparent,
												.Location = objEClone.Location,
												.Width = objEClone.Width,
												.Height = objEClone.Height
												})
					VisGB = VisGB.Controls.Find("Visual_GB_" & objEClone.Name, False)(0)
					BlockParants.Add(VisGB)
					BlockContent.Add("{}")
					VisConts.Add(VisGB)
				ElseIf i.Contains("Lbl") Then
					Dim objECloneLbl As Label = obj.Controls.Find(objECloneName, False)(0)
					Dim parentindex%
					Dim parent$ = ""
					Dim VisParent As Control = VisGB

					If i.Contains(".") Then
						For i2 = i.Length - 1 To 0
							If i(i2) = "." Then
								parentindex = i2 + 1
								Exit For
							End If
						Next
						For i2 = parentindex To 0 Step -1
							If i(i2) = "." Then
								Exit For
							Else
								parent = parent.Insert(0, i(i2))
							End If
						Next
						For Each i2 As Control In VisConts
							If i2.Name = "Visual_GB_" & parent Then
								VisParent = i2
								VisGB = i2
								Exit For
							End If
						Next
					End If


					VisParent.Controls.Add(New Label With {
													.Name = "Visual_Lbl_" & objEClone.Name,
													.BackColor = Color.FromArgb(140, 140, 140),
													.Location = objEClone.Location,
													.Width = objEClone.Width,
													.Height = objEClone.Height,
													.Text = objEClone.Text,
													.ForeColor = Color.White,
													.Font = objEClone.Font,
													.TextAlign = objECloneLbl.TextAlign})

					AddBlockContent(VisParent, "Block", VisParent.Controls.Find("Visual_Lbl_" & objEClone.Name, False)(0))
				End If
			Next

			BlockReSize(cont.Parent)
			isVisualised = True
		End If
	End Sub

	Sub InsertBlock(cont As GroupBox, block As GroupBox)
		RemoveHandler block.MouseDown, AddressOf Fr_Code.Move_MouseDown
		RemoveHandler block.MouseUp, AddressOf Fr_Code.Move_MouseUP
		RemoveHandler block.MouseMove, AddressOf Fr_Code.Move_MouseMove
		RemoveHandler block.LocationChanged, AddressOf Fr_Code.Move_OTLocationChanged
		block.Location = LastInnerPos(cont)
		cont.Controls.Add(block)
		AddBlockContent(cont, "GB", block)
		AddCodeDisc(ReadName(block.Name)(1), ReadName(cont.Name)(2))
		RecountBlockProperties(block.Name)
		BlockReSize(cont.Parent)
	End Sub

	Sub LaunchCode()
		Build()
		builded_project.Show()
	End Sub

End Module