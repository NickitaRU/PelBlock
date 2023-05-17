Public Class Fr_Code

	Public Sub Move_MouseMove(sender As Object, e As MouseEventArgs)
		If isMouseDown Then 'если кнопка мыши удерживается
			'вычисляем новые координаты элемента управления
			sender.Left += (e.X - StartPoint.X)
			sender.Top += (e.Y - StartPoint.Y)
		End If
	End Sub

	Public Sub Move_MouseUP(sender As Object, e As MouseEventArgs)
		isMouseDown = False
		sender.Cursor = Cursors.Default 'восстанавливаем вид курсора
		If isVisualised Then
			DisVisualize(viscont)
			InsertBlock(viscont, sender)
		End If
		PersonalConteiner.Clear()
	End Sub

	Private Sub Label1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		''если большая часть элемента управления выходит за границу формы, возвращаем его в центр
		'Dim w2 As Integer = Convert.ToInt32(Label1.Width / 2)
		'Dim h2 As Integer = Convert.ToInt32(Label1.Height / 2)
		'If Label1.Top < -h2 Or Label1.Left < -w2 Or Label1.Top > GB_WF.ClientSize.Height - h2 Or Label1.Left > GB_WF.ClientSize.Width - w2 Then
		'    Label1.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2)
		'    isMouseDown = False
		'    Label1.Cursor = Cursors.Default
		'End If
	End Sub

	Private Sub Label1_Click(sender As Object, e As EventArgs)
		'Dim ActiveControl As Control
		'GB_WF.Controls.Add(New Label With {
		'                            .Location = New Point(200, 250),
		'                            .Name = "Label" & BC,
		'                            .AutoSize = False,
		'                            .Size = Label1.Size,
		'                            .BackColor = Label1.BackColor
		'                            })
		'BC += 1
		'Blocks(0, 2) = (GB_WF.Controls.Find("Label" & BC - 1, False)(0))
		'ActiveControl = Blocks(0, 2)
		'AddHandler ActiveControl.MouseMove, AddressOf Move_MouseMove
		'AddHandler ActiveControl.MouseUp, AddressOf Move_MouseUP
		'AddHandler ActiveControl.MouseDown, AddressOf Move_MouseDown
		'AddHandler ActiveControl.LocationChanged, AddressOf Move_LocationChanged
	End Sub

	Private Sub Move_LocationChanged(sender As Object, e As EventArgs)
		'если большая часть элемента управления выходит за границу формы, возвращаем его в центр
		Dim w2 As Integer = Convert.ToInt32(sender.Width / 2)
		Dim h2 As Integer = Convert.ToInt32(sender.Height / 2)
		If sender.Top < -h2 Or sender.Left < -w2 Or sender.Top > GB_WF.ClientSize.Height - h2 Or sender.Left > GB_WF.ClientSize.Width - w2 Then
			sender.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2)
			isMouseDown = False
			sender.Cursor = Cursors.Default
		End If
	End Sub

	'GG

	Sub Move_OTLocationChanged(sender As Object, e As EventArgs)
		'если большая часть элемента управления выходит за границу формы, возвращаем его в центр
		Dim w2 As Integer = Convert.ToInt32(sender.Width / 2)
		Dim h2 As Integer = Convert.ToInt32(sender.Height / 2)
		If sender.Top < -h2 Or sender.Left < -w2 Or sender.Top > GB_WF.ClientSize.Height - h2 Or sender.Left > GB_WF.ClientSize.Width - w2 Then
			sender.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2)
			isMouseDown = False
			sender.Cursor = Cursors.Default
		End If

		For Each i As List(Of Object) In PersonalConteiner
			Dim ysl1 As Boolean = i(1).X < sender.Left And sender.Left < i(2).X
			Dim ysl2 As Boolean = i(1).Y < sender.Top And sender.Top < i(2).Y
			Dim AC As Control = i(0).Controls(i(0).Controls.Count - 1)
			If ysl1 And ysl2 And Not isBI(sender) Then
				Visualize(AC, sender)
				Exit For
			Else
				DisVisualize(AC)
			End If
		Next
	End Sub


	Private Sub GB_BF_Enter(sender As Object, e As EventArgs) Handles GB_BF.Enter
		'GB Blocks Field
	End Sub

	Private Sub GB_WF_Enter(sender As Object, e As EventArgs) Handles GB_WF.Enter
		'GB Working field
	End Sub



	Private Sub CreateActionBlock(sender As Control, e As EventArgs)
		Dim snp As New ArrayList 'sender name properts
		Dim AC As Control, blockname$ = ""
		Dim blockindex%
		blockindex = EventB.IndexOf(ReadName(sender.Name)(2))
		If blockindex = -1 Then
			For i = 3 To sender.Name.Length - 1
				If IsNumeric(sender.Name(i + 1)) Then
					Exit For
				ElseIf sender.Name(i) = "_" Then
				Else
					blockname += sender.Name(i)
				End If
			Next
			blockindex = EventB.IndexOf(blockname)
		End If

		If Blocks(1)(blockindex) = MaxEvent(blockindex) + 1 Then
			Exit Sub
		End If

		Dim w2 As Integer = Convert.ToInt32(sender.Width / 2)
		Dim h2 As Integer = Convert.ToInt32(sender.Height / 2)
		GB_WF.Controls.Add(New GroupBox With {
										.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2),
										.Name = "GB_" & Blocks(0)(blockindex) & "_" & Blocks(1)(blockindex),
										.AutoSize = False,
										.AutoSizeMode = AutoSizeMode.GrowOnly,
										.Font = New Font(FontFamily.GenericSansSerif, 14)
										})

		GBWFB.Add(GB_WF.Controls.Find("GB_" & Blocks(0)(blockindex) & "_" & Blocks(1)(blockindex), False)(0))
		Conteiner.Add(GBWFB(GBWFB.Count - 1))
		AC = GBWFB(GBWFB.Count - 1)
		BlockParants.Add(AC)
		BlockContent.Add("{}")
		CodeDisc.Add(Blocks(0)(blockindex) & Blocks(1)(blockindex) & "{}")
		FillEventBGB(AC, blockindex)
		AddHandler AC.MouseDown, AddressOf Move_MouseDown
		AddHandler AC.MouseUp, AddressOf Move_MouseUP
		AddHandler AC.MouseMove, AddressOf Move_MouseMove
		AddHandler AC.LocationChanged, AddressOf Move_LocationChanged
		Blocks(1)(blockindex) += 1
	End Sub

	Sub FillBlocks()
		Dim nls As New List(Of String)
		Dim nls2 As New List(Of String)
		FamilyNamePos.Add(0)
		FamilyName.Add("Event")
		For Each i$ In EventB
			nls.Add(i)
			nls2.Add(0)
			MaxEvent.Add(1)
		Next
		FamilyNamePos.Add(nls.Count - 1)
		FamilyName.Add("Event")
		FamilyNamePos.Add(nls.Count)
		FamilyName.Add("Output")
		For Each i$ In OutputB
			nls.Add(i)
			nls2.Add(0)
		Next
		FamilyNamePos.Add(nls.Count - 1)
		FamilyName.Add("Output")
		FamilyNamePos.Add(nls.Count)
		FamilyName.Add("Text")
		For Each i$ In TextB
			nls.Add(i)
			nls2.Add(0)
		Next
		FamilyNamePos.Add(nls.Count - 1)
		FamilyName.Add("Text")
		Blocks.Add(nls)
		Blocks.Add(nls2)
	End Sub

	Private Sub Fr_Code_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If Not wasShown Then
			'Fr_Stage.Show()
			'Fr_Debug.Show()
			FillBlocks()
			Block.Add(New List(Of Object)) 'link
			Block.Add(New List(Of Object)) 'name
			Block.Add(New List(Of Object)) 'parent
			Block.Add(New List(Of Object)) 'Size
			Block.Add(New List(Of Object)) 'pos in container
			Block.Add(New List(Of Object)) 'pos in main cointainer
			AllC.Add("Output", OutPutC)
			AllC.Add("Text", TextC)
			AllC.Add("Event", Nothing)
			AllE.Add("OnStart", OnStartC)
			AllEA.Add("OnStart", OnStartCArgs)
			AllE.Add("OnStop", OnStopC)
			AllEA.Add("OnStop", OnStopCArgs)
			AllPFFiller()
			wasShown = True
		End If
		GB_WF.Width = Me.Width - GB_BF.Width
		AddHandler GB_WF.MouseUp, AddressOf Move_MouseUP
	End Sub

	Private Sub CreateOutputBlock(sender As Control, e As EventArgs)
		Dim snp As New ArrayList 'sender name properts
		Dim AC As Control, blockname$ = ""
		Dim blockindex%
		For Each i$ In ReadName(sender.Name)
			blockindex = OutputB.IndexOf(i)
			If blockindex <> -1 Then
				blockindex += EventB.Count
				Exit For
			End If
		Next
		If blockindex = EventB.Count - 1 Then
			For i = 3 To sender.Name.Length - 1
				If IsNumeric(sender.Name(i + 1)) Then
					Exit For
				ElseIf sender.Name(i) = "_" Then
				Else
					blockname += sender.Name(i)
				End If
			Next
			blockindex = OutputB.IndexOf(blockname) + EventB.Count
		End If

		Dim w2 As Integer = Convert.ToInt32(sender.Width / 2)
		Dim h2 As Integer = Convert.ToInt32(sender.Height / 2)
		GB_WF.Controls.Add(New GroupBox With {
										.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2),
										.Name = "GB_" & Blocks(0)(blockindex) & "_" & Blocks(1)(blockindex),
										.AutoSize = False,
										.AutoSizeMode = AutoSizeMode.GrowOnly,
										.Font = New Font(FontFamily.GenericSansSerif, 14)
										})

		GBWFB.Add(GB_WF.Controls.Find("GB_" & Blocks(0)(blockindex) & "_" & Blocks(1)(blockindex), False)(0))
		AC = GBWFB(GBWFB.Count - 1)
		BlockParants.Add(AC)
		BlockContent.Add("{}")
		CodeDisc.Add(Blocks(0)(blockindex) & Blocks(1)(blockindex) & "()")
		FillOutputBGB(AC, blockindex - EventB.Count)
		AddHandler AC.MouseDown, AddressOf Move_MouseDown
		AddHandler AC.MouseUp, AddressOf Move_MouseUP
		AddHandler AC.MouseMove, AddressOf Move_MouseMove
		AddHandler AC.LocationChanged, AddressOf Move_OTLocationChanged
		Blocks(1)(blockindex) += 1
	End Sub

	Private Sub BtnOutput_Click(sender As Object, e As EventArgs) Handles Btn_Output.Click
		Dim ActiveConrol As Control, ForC% = EventB.Count

		If GB_Blocks.Controls.Count = 0 Then
			For Each i$ In OutputB
				GB_Blocks.Controls.Add(New GroupBox With {
										.Location = New Point(0, GBBC * 110 + 7),
										.Name = "GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC),
										.AutoSize = False,
										.Font = New Font(FontFamily.GenericSansSerif, 14)
										})


				GBBC += 1
				GBBCh.Add(GB_Blocks.Controls.Find("GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC), False)(0))
				ActiveConrol = GBBCh(GBBC - 1)
				AddHandler ActiveConrol.Click, AddressOf CreateOutputBlock
				BlockParants.Add(ActiveConrol)
				BlockContent.Add("{}")
				FillOutputBGB(ActiveConrol, ForC - EventB.Count, True)
				Blocks(1)(ForC) += 1
				ForC += 1
			Next
		Else
			For i% = 0 To GBBCh.Count() - 1
				Dim AC As Control = GBBCh(GBBCh.Count() - 1)
				RemoveBlock(AC)
			Next
			GBBC = 0
		End If
	End Sub

	Sub FillOutputBGB(GB As Control, indexET%, Optional isExample As Boolean = False)
		Dim bc As Color = Color.FromArgb(255, 164, 32)
		Dim fc As Color = Color.FromArgb(135, 85, 70)
		Dim indexB% = indexET + EventB.Count
		GB.Controls.Add(New Label With {
									 .AutoSize = False,
									 .Name = "Lbl_" & "FromGB_" & Blocks(0)(indexB) & "_" & Blocks(1)(indexB) & "_TopHorizontal",
									 .Size = New Size(GB.Width, 30),
									 .Location = New Point(0, 0),
									 .Text = OutputT(indexET),
									 .TextAlign = ContentAlignment.MiddleRight,
									 .BackColor = bc,
									 .ForeColor = fc,
									 .Font = New Font(FontFamily.GenericSansSerif, 10),
									 .Enabled = False
									 })

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New Label With {
										.AutoSize = False,
										.Name = "Lbl_" & "FromGB_" & Blocks(0)(indexB) & "_" & Blocks(1)(indexB) & "_BottomHorizontal",
										.Size = New Size(GB.Width, 15),
										.Location = New Point(0, GB.Height - 15),
										.BackColor = bc,
									 .Enabled = False
										})

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New Label With {
										.AutoSize = False,
										.Name = "Lbl_" & "FromGB_" & Blocks(0)(indexB) & "_" & Blocks(1)(indexB) & "_LeftHorizontal",
										.Size = New Size(15, GB.Height - 1),
										.Location = New Point(0, 0),
										.BackColor = bc,
										.Enabled = False
										})

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New GroupBox With {
										.AutoSize = False,
										.Name = "GB_" & "FromGB_" & Blocks(0)(indexB) & "_" & Blocks(1)(indexB) & "_innerBlocks",
										.Size = New Size(GB.Width - 15, GB.Height - 30),
										.Location = New Point(16, 16)
										  })

		BlockParants.Add(GB.Controls(GB.Controls.Count - 1))
		BlockContent.Add("{}")
		AddBlockContent(GB, "GB", GB.Controls(GB.Controls.Count - 1))

		If isExample Then
			For Each i As Control In GB.Controls
				AddHandler i.Click, AddressOf CreateOutputBlock
			Next
		End If
	End Sub

	Sub FillEventBGB(GB As Control, indexET%, Optional isExample As Boolean = False)
		Dim bc As Color = Color.FromArgb(120, 215, 124)
		Dim fc As Color = Color.FromArgb(64, 93, 83)
		GB.Controls.Add(New Label With {
								 .AutoSize = False,
								 .Name = "Lbl_" & "FromGB_" & Blocks(0)(indexET) & "_" & Blocks(1)(indexET) & "_TopHorizontal",
								 .Size = New Size(GB.Width, 30),
								 .Location = New Point(0, 0),
								 .Text = EventT(indexET),
								 .TextAlign = ContentAlignment.MiddleRight,
								 .BackColor = bc,
								 .ForeColor = fc,
								 .Font = New Font(FontFamily.GenericSansSerif, 10),
								 .Enabled = False
								 })

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New Label With {
										.AutoSize = False,
										.Name = "Lbl_" & "FromGB_" & Blocks(0)(indexET) & "_" & Blocks(1)(indexET) & "_BottomHorizontal",
										.Size = New Size(GB.Width, 15),
										.Location = New Point(0, GB.Height - 15),
										.BackColor = bc,
								 .Enabled = False
										})

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New Label With {
										.AutoSize = False,
										.Name = "Lbl_" & "FromGB_" & Blocks(0)(indexET) & "_" & Blocks(1)(indexET) & "_LeftHorizontal",
										.Size = New Size(15, GB.Height - 1),
										.Location = New Point(0, 0),
										.BackColor = bc,
										.Enabled = False
										})

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New GroupBox With {
										.AutoSize = True,
										.Name = "GB_" & "FromGB_" & Blocks(0)(indexET) & "_" & Blocks(1)(indexET) & "_innerBlocks",
										.Size = New Size(GB.Width - 15, GB.Height - 15),
										.Location = New Point(16, 16)
										  })

		BlockParants.Add(GB.Controls(GB.Controls.Count - 1))
		BlockContent.Add("{}")
		AddBlockContent(GB, "GB", GB.Controls(GB.Controls.Count - 1))

		If isExample Then
			For Each i As Control In GB.Controls
				AddHandler i.Click, AddressOf CreateActionBlock
			Next
		End If
	End Sub

	Private Sub Btn_Actions_Click(sender As Object, e As EventArgs) Handles Btn_Actions.Click
		Dim ActiveConrol As Control, ForC% = 0

		If GB_Blocks.Controls.Count = 0 Then
			For Each i$ In EventB
				GB_Blocks.Controls.Add(New GroupBox With {
										.Location = New Point(0, GBBC * 110 + 7),
										.Name = "GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC),
										.AutoSize = False,
										.AutoSizeMode = AutoSizeMode.GrowOnly,
										.Font = New Font(FontFamily.GenericSansSerif, 14)
										})


				GBBC += 1
				GBBCh.Add(GB_Blocks.Controls.Find("GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC), False)(0))
				ActiveConrol = GBBCh(GBBC - 1)
				AddHandler ActiveConrol.Click, AddressOf CreateActionBlock
				BlockParants.Add(ActiveConrol)
				BlockContent.Add("{}")
				FillEventBGB(ActiveConrol, ForC, True)
				Blocks(1)(ForC) += 1
				ForC += 1
			Next
		Else
			For i% = 0 To GBBCh.Count() - 1
				Dim AC As Control = GBBCh(GBBCh.Count() - 1)
				RemoveBlock(AC)
			Next
			GBBC = 0
		End If
	End Sub

	Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
		'    If Not IsNumeric(TextBox1.Text) Then
		'        Dim txt = CStr(TextBox1.Text)
		'        Dim Res$ = ""
		'        For i = 0 To txt.Length - 1
		'            If IsNumeric(txt(i)) Then
		'                Res += txt(i)
		'            End If
		'        Next
		'        TextBox1.Text = Res
		'    End If
	End Sub

	Public Sub Move_MouseDown(sender As Object, e As MouseEventArgs)
		If e.Button = MouseButtons.Left Then 'если нажата левая кнопка мыши
			isMouseDown = True
			StartPoint = e.Location 'запоминаем текущую позицию элемента управления
			sender.Cursor = Cursors.SizeAll 'меняем вид указателя мыши над элементом управления
			CountPesonalCont(sender)
		End If
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs)
	End Sub

	Private Sub Fr_Code_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
		If e.KeyChar = "s" OrElse e.KeyChar = "ы" Then
			LaunchCode()
		End If
	End Sub

	Sub FillTextBGB(GB As Control, name$, Optional isExample As Boolean = False)
		Dim bc As Color = Color.FromArgb(240, 248, 255)
		Dim fc As Color = Color.FromArgb(64, 93, 83)

		GB.Controls.Add(New Label With {
								 .AutoSize = False,
								 .Name = "Lbl_" & "FromGB_" & name & "_" & Blocks(1)(FindBlockClassTypeIndex(name)) & "_TopHorizontal",
								 .Size = New Size(GB.Width, 30),
								 .Location = New Point(0, 0),
								 .Text = TextT(TextB.IndexOf(name)),
								 .TextAlign = ContentAlignment.MiddleRight,
								 .BackColor = bc,
								 .ForeColor = fc,
								 .Font = New Font(FontFamily.GenericSansSerif, 10),
								 .Enabled = False
								 })

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		GB.Controls.Add(New TextBox With {
									.Name = "Txt_FromGB_" & name & "_" & Blocks(1)(FindBlockClassTypeIndex(name)) & "_innerTxt",
									.Location = New Point(0, 30),
									.Multiline = True,
									.Size = GB.Size - New Size(0, 30),
									.Enabled = Not isExample,
									.BackColor = ThemeBackColor,
									.ForeColor = ThemeForeColor
									})

		AddBlockContent(GB, "Block", GB.Controls(GB.Controls.Count - 1))

		If isExample Then
			For Each i As Control In GB.Controls
				AddHandler i.Click, AddressOf CreateTextBlock
			Next
		Else
			CreateTextBoxPr(GB.Controls(GB.Controls.Count - 1))
			AddHandler GB.Controls(GB.Controls.Count - 1).TextChanged, AddressOf TextBlock_TextChaged
		End If
	End Sub

	Sub TextBlock_TextChaged(sender As Object, e As EventArgs)
		RecountTextBoxPr(sender)
	End Sub

	Sub CreateTextBlock(sender As Object, e As EventArgs) Handles Btn_Text.Click
		If sender Is Btn_Text Then
			Dim ForC%
			If GB_Blocks.Controls.Count = 0 Then
				For Each i$ In TextB
					ForC = FindBlockClassTypeIndex(i)
					Dim ActiveConrol As Control
					GB_Blocks.Controls.Add(New GroupBox With {
											.Location = New Point(0, GBBC * 110 + 7),
											.Name = "GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC),
											.AutoSize = False,
											.AutoSizeMode = AutoSizeMode.GrowOnly,
											.Font = New Font(FontFamily.GenericSansSerif, 14)
											})


					GBBC += 1
					GBBCh.Add(GB_Blocks.Controls.Find("GB_" & Blocks(0)(ForC) & "_" & Blocks(1)(ForC), False)(0))
					ActiveConrol = GBBCh(GBBC - 1)
					AddHandler ActiveConrol.Click, AddressOf CreateTextBlock
					BlockParants.Add(ActiveConrol)
					BlockContent.Add("{}")
					FillTextBGB(ActiveConrol, Blocks(0)(ForC), True)
					Blocks(1)(ForC) += 1
				Next
			Else
				For i% = 0 To GBBCh.Count() - 1
					Dim AC As Control = GBBCh(GBBCh.Count() - 1)
					RemoveBlock(AC)
				Next
				GBBC = 0
			End If
		Else
			Dim AC As Control
			Dim ForC$
			ForC = GetClassTypeFromName(sender.Name)
			Dim w2 As Integer = Convert.ToInt32(sender.Width / 2)
			Dim h2 As Integer = Convert.ToInt32(sender.Height / 2)
			GB_WF.Controls.Add(New GroupBox With {
										.Location = New Point(Convert.ToInt32(GB_WF.ClientSize.Width / 2) - w2, Convert.ToInt32(GB_WF.ClientSize.Height / 2) - h2),
										.Name = "GB_" & ForC & "_" & Blocks(1)(FindBlockClassTypeIndex(ForC)),
										.AutoSize = False,
										.AutoSizeMode = AutoSizeMode.GrowOnly,
										.Font = New Font(FontFamily.GenericSansSerif, 14)
										})


			GBBC += 1
			GBWFB.Add(GB_WF.Controls.Find("GB_" & ForC & "_" & Blocks(1)(FindBlockClassTypeIndex(ForC)), False)(0))
			AC = GBWFB(GBWFB.Count - 1)
			CodeDisc.Add(Blocks(0)(FindBlockClassTypeIndex(ForC)) & Blocks(1)(FindBlockClassTypeIndex(ForC)) & "()")
			BlockContent.Add("{}")
			BlockParants.Add(AC)
			AddHandler AC.MouseDown, AddressOf Move_MouseDown
			AddHandler AC.MouseUp, AddressOf Move_MouseUP
			AddHandler AC.MouseMove, AddressOf Move_MouseMove
			AddHandler AC.LocationChanged, AddressOf Move_OTLocationChanged
			FillTextBGB(AC, ForC)
			Blocks(1)(FindBlockClassTypeIndex(ForC)) += 1
		End If
	End Sub

	Private Sub Button1_Click_1(sender As Object, e As EventArgs)
		LaunchCode()
	End Sub

	Private Sub Fr_Code_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		Fr_Start.Show()
	End Sub

	Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
		LaunchCode()
	End Sub

	Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
		Me.Close()
	End Sub
End Class