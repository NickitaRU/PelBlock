Public Class builded_project
	Private Sub builded_project_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For Each i As Action(Of Object) In OnStartC
			i(OnStartCArgs(OnStartC.IndexOf(i)))
		Next
	End Sub
End Class