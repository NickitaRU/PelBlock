Module ModulePelBlock_Subs_Functions
    'Block propertes manipulations
    Sub AddBlockPorperties(obj As Control)
        Block(0).Add(obj)
        Block(1).Add(obj.Name)
        Block(2).Add(obj.Parent)
        Block(3).Add(obj.Size)
        Block(4).Add(obj.Location)
        Block(5).Add(New Point(IIf(
            obj.Parent IsNot Fr_Code.GB_Blocks And obj.Parent IsNot Fr_Code.GB_WF,
            CountLeft(obj.Parent),
            0), IIf(obj.Parent IsNot Fr_Code.GB_Blocks And obj.Parent IsNot Fr_Code.GB_WF,
            CountTop(obj.Parent), 0)))
    End Sub

    Function FindBlockPropertes(name As String) As List(Of Object)
        Dim i% = Block(1).IndexOf(name)
        Dim preres As New List(Of Object) From {
            Block(0)(i),
            Block(1)(i),
            Block(2)(i),
            Block(3)(i),
            Block(4)(i),
            Block(5)(i)
        }
        Return preres
    End Function

    'End Block propertes manipulations

    'Reading

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
        For Each i$ In lst
            preres += i + sep
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

    Sub AddBlockContent(cont As GroupBox, type As String, obj As Control, Optional cont2 As Control = Nothing)
        AddBlockPorperties(obj)
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

    Function LastInnerPos(cont As Control) As Point
        Dim preres As Point
        Dim AC As Control
        If cont.Controls.Count = 0 Then
            AC = New Control(top:=0, height:=0, width:=0, left:=0, text:="")
        Else
            AC = cont.Controls(cont.Controls.Count - 1)
        End If
        preres = New Point(0, AC.Top + AC.Height + 2)
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

    Function FindParent(cont As Control, objName$) As GroupBox
        Dim preres As GroupBox = cont
        Dim contDecod As List(Of String) = ReadBlockContent(cont)
        For Each i$ In contDecod
            Dim PName$ = ""
            If i.Contains("cont") Then
                If preres.Controls.Find(objName, False).Count = 1 Then
                    Exit For
                End If
                For i2 = 5 To i.Length - 1
                    If i(i2) = "." Then
                        preres = preres.Controls.Find(PName, False)(0)
                    Else
                        PName += i(i2)
                    End If
                Next
                If preres.Name <> PName Then
                    preres = preres.Controls.Find(PName, False)(0)
                End If
            End If
        Next
        Return preres
    End Function

    Function CountLeft(obj As GroupBox) As Integer
        Dim preres As Integer = 15
        Dim FT As List(Of GroupBox) = MakeFamilyTree(obj)
        For Each i In FT
            preres += i.Left
        Next
        Return preres
    End Function

    Function CountTop(obj As GroupBox) As Integer
        Dim preres As Integer = 20
        Dim FT As List(Of GroupBox) = MakeFamilyTree(obj)
        For Each i In FT
            preres += i.Top
        Next
        Return preres
    End Function

    Function CountMaxSize(cont As GroupBox) As Size
        Dim preres As Size, maxW% = cont.Width, maxH% = cont.Height
        Dim parent As Control = cont
        Dim El As Control
        Dim FT As List(Of GroupBox) = MakeFamilyTree(cont)
        MsgBox(ArrToString(ReadBlockContent(cont), vbCrLf))
        For Each i$ In ReadBlockContent(cont)
            Dim EName$ = "", EParentName$ = ""
            If i.Contains("cont") Then


            Else
                For i2 = i.Length - 1 To 0 Step -1
                    If i(i2) = "." Then
                        Exit For
                    Else
                        EName = EName.Insert(0, i(i2))
                    End If
                Next
            End If
            If EName = "" Then
                Exit For
            End If
            El = parent.Controls.Find(EName, False)(0)
            maxW += IIf(maxW < El.Width + El.Left + IIf(El.Parent IsNot FT(0), CountLeft(El.Parent), 0), El.Width + El.Left + IIf(El.Parent IsNot FT(0), CountLeft(El.Parent), 0) - maxW, 0)
            maxH += IIf(maxH < El.Height + El.Top + IIf(El.Parent IsNot FT(0), CountTop(El.Parent), 0), El.Height + El.Top + IIf(El.Parent IsNot FT(0), CountTop(El.Parent), 0) - maxH, 0)
        Next
        preres = New Size(maxW, maxH)
        Return preres
    End Function

    Sub BlockReSize(cont As Control)
        Dim contDecod As List(Of String) = ReadBlockContent(cont)
        Dim LastCont As Control = cont
        Dim tb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_TopHorizontal", False)(0)
        Dim bb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_BottomHorizontal", False)(0)
        Dim lb As Label = cont.Controls.Find("Lbl_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_LeftHorizontal", False)(0)
        Dim inr As GroupBox = cont.Controls.Find("GB_" & "FromGB_" & ReadName(cont.Name)(1) & "_" & ReadName(cont.Name)(2) & "_innerBlocks", False)(0)

        MsgBox(cont.Name & vbCrLf & ArrToString(contDecod, vbCrLf))

        For Each i$ In contDecod
            If i.Contains("cont") Then
                Dim LastContName$ = ""
                For i2 = i.Length - 1 To 0 Step -1
                    If i(i2) = "." Then
                        Exit For
                    End If
                    LastContName = LastContName.Insert(0, i(i2))
                Next
                LastCont = LastCont.Controls.Find(LastContName, False)(0)
                LastCont.Size = CountMaxSize(LastCont)
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
        cont.Controls.Remove(VisGB)
        isVisualised = False
        RemoveBlockContent(cont, VisGB)
        MsgBox(BlockContent(BlockParants.IndexOf(cont.Parent)))
    End Sub

    Sub Visualize(cont As Control, obj As Control) 'GG
        If Not isVisualised Then
            MsgBox(cont.Name)
            viscont = cont
            visblock = obj
            Dim innerO As Control
            Dim objDecod As List(Of String) = ReadBlockContent(obj)


            innerO = obj.Controls(obj.Controls.Count - 1)

            cont.Controls.Add(New GroupBox With {
                                                .Name = "Visual_GB",
                                                .BackColor = Color.Transparent,
                                                .Location = LastInnerPos(cont),
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
                                                    .Height = objEClone.Height})

                    AddBlockContent(VisParent, "Block", VisParent.Controls.Find("Visual_Lbl_" & objEClone.Name, False)(0))
                End If
            Next

            MsgBox(ArrToString(BlockContent, vbCrLf))
            BlockReSize(cont.Parent)
            isVisualised = True
        End If
    End Sub

    Sub InsertBlock(cont As GroupBox, block As GroupBox)
        cont.Controls.Add(block)
        BlockReSize(cont.Parent)
    End Sub

    Sub LaunchCode()
        MsgBox("Пока не готово")
    End Sub

End Module