Public Module ModulePelBlockVars
    Public isMouseDown As Boolean = False 'признак удерживания кнопки мыши
    Public isVisualised As Boolean = False
    Public StartPoint As Point 'начальная позиция элемента управления\
    Public isBlockChosingShow As Boolean
    Public Blocks As New List(Of List(Of String)), BC%, GBBC, MaxEvent(100, 1) 'BC - block counter, GBBC - GB Blocks Counter
    Public GBBCh As New ArrayList, GBWFB As New ArrayList ' BBBCh - GB Blocks Choosing; GBWFB - GB_WF Blocks
    Public EventB As New ArrayList From {"OnStart", "OnStop"}
    Public EventT As New ArrayList From {"При запуске программы", "При выключении програмы"}
    Public OutputB As New ArrayList From {"MsgBox"}
    Public OutputT As New ArrayList From {"Вызвать окно вывода"}
    Public Conteiner As New ArrayList
    Public ConteinerP()
    Public BlockContent As New List(Of String)
    Public BlockParants As New List(Of GroupBox) '
    Public viscont, visblock As GroupBox
    Public VisConts As New List(Of Control)
    Public VisGB As Control
End Module
