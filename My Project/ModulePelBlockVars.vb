Public Module ModulePelBlockVars
	Public isMouseDown As Boolean = False 'признак удерживания кнопки мыши
	Public isVisualised As Boolean = False
	Public StartPoint As Point 'начальная позиция элемента управления\
	Public isBlockChosingShow As Boolean
	Public Blocks As New List(Of List(Of String)), BC%, GBBC% 'BC - block counter, GBBC - GB Blocks Counter
	Public MaxEvent As New List(Of Integer)
	Public GBBCh As New ArrayList, GBWFB As New ArrayList ' BBBCh - GB Blocks Choosing; GBWFB - GB_WF Blocks
	Public EventB As New List(Of String) From {"OnStart", "OnStop"}
	Public EventT As New ArrayList From {"При запуске программы", "При выключении програмы"}
	Public OutputB As New List(Of String) From {"MsgBox"}
	Public OutputT As New ArrayList From {"Вызвать окно вывода"}
	Public OutPutC As New List(Of List(Of String)) From {EventB}
	Public TextB As New List(Of String) From {"TextBox"}
	Public TextT As New List(Of String) From {"Текст"}
	Public TextC As New List(Of List(Of String)) From {OutputB}
	Public FamilyNamePos As New List(Of Integer)
	Public FamilyName As New List(Of String)
	Public PersonalConteiner As New List(Of List(Of Object))
	Public AllC As New Dictionary(Of String, Object)
	Public Conteiner As New ArrayList
	Public BlockContent As New List(Of String)
	Public BlockParants As New List(Of GroupBox) '
	Public viscont, visblock As GroupBox
	Public VisConts As New List(Of Control)
	Public VisGB As Control
	Public Block As New List(Of List(Of Object))
	Public CodeDisc As New List(Of String)
	Public OnStartC As New List(Of Action(Of Object))
	Public OnStopC As New List(Of Action(Of Object))
	Public OnStartCArgs As New List(Of Object)
	Public OnStopCArgs As New List(Of Object)
End Module
