Public Class Fr_Debug
	Dim Tmr As New Timer With {
								.Interval = 1000,
								.Enabled = True}
	Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, Button1.Click
        Lst.Items.Clear()
        Select Case ComboBox1.SelectedIndex
            Case 0
                Lst.Items.Add(isMouseDown)
            Case 1
                Lst.Items.Add(isVisualised)
            Case 2
                Lst.Items.Add(StartPoint.ToString)
            Case 3
                Lst.Items.Add(isBlockChosingShow)
            Case 4
                Lst.Items.Add(ArrToString(Blocks))
            Case 5
                Lst.Items.Add(BC)
            Case 6
                Lst.Items.Add(GBBC)
            Case 7
                Lst.Items.Add(ArrToString(MaxEvent))
            Case 8
                Lst.Items.Add(ArrToString(GBBCh))
            Case 9
                Lst.Items.Add(ArrToString(EventB))
            Case 10
                Lst.Items.Add(ArrToString(EventT))
            Case 11
                Lst.Items.Add(ArrToString(OutputB))
            Case 12
                Lst.Items.Add(ArrToString(OutputT))
            Case 13
                Lst.Items.Add(ArrToString(Conteiner))
            Case 14
                For Each i In BlockContent
                    Lst.Items.Add(i)
                Next
            Case 15
                Lst.Items.Add(ArrToString(BlockParants))
            Case 16
				If viscont IsNot Nothing Then
					Lst.Items.Add(viscont.Name)
				End If
			Case 17
				If visblock IsNot Nothing Then
					Lst.Items.Add(visblock.Name)
				End If
			Case 18
                Lst.Items.Add(ArrToString(VisConts))
			Case 19
				If VisGB IsNot Nothing Then
					Lst.Items.Add(VisGB.Name)
				End If
			Case 20
                For Each i$ In Block(1)
                    Lst.Items.Add(ArrToString(FindBlockPropertes(i)))
                Next
            Case 21
				For Each i In CodeDisc
					Lst.Items.Add(i)
				Next
			Case 22
				For Each i In TextBoxPr
					Lst.Items.Add(ArrToString(i))
				Next
		End Select
    End Sub

    Private Sub Lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lst.SelectedIndexChanged

    End Sub

	Private Sub Fr_Debug_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		AddHandler Tmr.Tick, AddressOf ComboBox1_SelectedIndexChanged
		ComboBox1.Items.Add("TextBox_Pr")
	End Sub

	Private Sub Fr_Debug_Close(sender As Object, e As EventArgs) Handles Me.Closing
		Tmr.Stop()
	End Sub
End Class