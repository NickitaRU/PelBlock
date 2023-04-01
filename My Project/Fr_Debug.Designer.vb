<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Debug
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Lst = New System.Windows.Forms.ListBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lst
        '
        Me.Lst.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Lst.FormattingEnabled = True
        Me.Lst.HorizontalScrollbar = True
        Me.Lst.ItemHeight = 24
        Me.Lst.Location = New System.Drawing.Point(0, 110)
        Me.Lst.Name = "Lst"
        Me.Lst.Size = New System.Drawing.Size(800, 340)
        Me.Lst.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"isMouseDown", "isVisualised", "StartPoint", "isBlockChosingShow", "Blocks", "BC", "GBBC", "MaxEvent", "GBBCh", "EventB", "EventT", "OutputB", "OutputT", "Conteiner", "BlockContent", "BlockParants", "viscont", "visblock", "VisConts", "VisGB", "Block", "CodDisc"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 56)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(776, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Обновить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Fr_Debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Lst)
        Me.Name = "Fr_Debug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Fr_Debug"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lst As ListBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
End Class
