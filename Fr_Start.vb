Public Class Fr_Start
	Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

	End Sub

	Private Sub RB_LightTheme_CheckedChanged(sender As Object, e As EventArgs) Handles RB_LightTheme.CheckedChanged
		Fr_Code.BackColor = Color.White
		Fr_Code.ForeColor = Color.Black
		Fr_Code.Button1.BackColor = Color.White
		Me.BackColor = Color.White
		Me.ForeColor = Color.Black
		ThemeBackColor = Color.White
		ThemeForeColor = Color.Black
		For Each i In TextBoxContent
			i(0).Backcolor = Color.White
			i(0).ForeColor = Color.Black
		Next
	End Sub

	Private Sub RB_BlackTheme_CheckedChanged(sender As Object, e As EventArgs) Handles RB_BlackTheme.CheckedChanged, PictureBox1.Click, Label3.Click
		Fr_Code.BackColor = Color.Black
		Fr_Code.ForeColor = Color.White
		Fr_Code.Button1.BackColor = Color.Black
		Me.BackColor = Color.Black
		Me.ForeColor = Color.White
		ThemeBackColor = Color.Black
		ThemeForeColor = Color.White
		For Each i In TextBoxContent
			i(0).Backcolor = Color.Black
			i(0).ForeColor = Color.White
		Next
		GBBC = 0
		GBBCh.Clear()
		If Blocks.Count = 0 Then
			Blocks.Add(New List(Of String))
			Blocks.Add(New List(Of String))
		End If
		For i = 0 To Blocks(1).Count - 1
			Blocks(1)(i) = 0
		Next
		PersonalConteiner.Clear()
	End Sub

	Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, Label3.Click
		Fr_Code.Show()
		Me.Hide()
	End Sub
End Class