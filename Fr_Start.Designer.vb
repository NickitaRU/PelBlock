<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Start
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RB_BlackTheme = New System.Windows.Forms.RadioButton()
        Me.RB_LightTheme = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Блочный программист"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(637, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Тема:"
        '
        'RB_BlackTheme
        '
        Me.RB_BlackTheme.AutoSize = True
        Me.RB_BlackTheme.Location = New System.Drawing.Point(641, 63)
        Me.RB_BlackTheme.Name = "RB_BlackTheme"
        Me.RB_BlackTheme.Size = New System.Drawing.Size(64, 17)
        Me.RB_BlackTheme.TabIndex = 2
        Me.RB_BlackTheme.TabStop = True
        Me.RB_BlackTheme.Text = "Тёмная"
        Me.RB_BlackTheme.UseVisualStyleBackColor = True
        '
        'RB_LightTheme
        '
        Me.RB_LightTheme.AutoSize = True
        Me.RB_LightTheme.Location = New System.Drawing.Point(641, 86)
        Me.RB_LightTheme.Name = "RB_LightTheme"
        Me.RB_LightTheme.Size = New System.Drawing.Size(67, 17)
        Me.RB_LightTheme.TabIndex = 3
        Me.RB_LightTheme.TabStop = True
        Me.RB_LightTheme.Text = "Светлая"
        Me.RB_LightTheme.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PelBlock.My.Resources.Resources.projects
        Me.PictureBox1.Location = New System.Drawing.Point(23, 123)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 105)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(129, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 31)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Проекты"
        '
        'Fr_Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RB_LightTheme)
        Me.Controls.Add(Me.RB_BlackTheme)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Fr_Start"
        Me.Text = "Fr_Start"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents RB_BlackTheme As RadioButton
    Friend WithEvents RB_LightTheme As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
End Class
