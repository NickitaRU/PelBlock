Public Class builded_project
	Private Sub builded_project_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For i = 0 To OnStartC.Count - 1
			OnStartC(i)(OnStartCArgs(i))
		Next
	End Sub

	Private Sub builded_project_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
		For i = 0 To OnStopC.Count - 1
			OnStopC(i)(OnStopCArgs(i))
		Next
	End Sub
End Class