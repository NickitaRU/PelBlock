<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Fr_Code
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Code))
        Me.GB_WF = New System.Windows.Forms.GroupBox()
        Me.GB_BF = New System.Windows.Forms.GroupBox()
        Me.GB_Blocks = New System.Windows.Forms.GroupBox()
        Me.Btn_Text = New System.Windows.Forms.PictureBox()
        Me.Btn_Output = New System.Windows.Forms.PictureBox()
        Me.Btn_Actions = New System.Windows.Forms.PictureBox()
        Me.GB_BF.SuspendLayout()
        CType(Me.Btn_Text, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Btn_Output, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Btn_Actions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GB_WF
        '
        Me.GB_WF.Dock = System.Windows.Forms.DockStyle.Right
        Me.GB_WF.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GB_WF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GB_WF.Location = New System.Drawing.Point(221, 0)
        Me.GB_WF.Name = "GB_WF"
        Me.GB_WF.Size = New System.Drawing.Size(1063, 919)
        Me.GB_WF.TabIndex = 1
        Me.GB_WF.TabStop = False
        '
        'GB_BF
        '
        Me.GB_BF.Controls.Add(Me.Btn_Text)
        Me.GB_BF.Controls.Add(Me.Btn_Output)
        Me.GB_BF.Controls.Add(Me.Btn_Actions)
        Me.GB_BF.Controls.Add(Me.GB_Blocks)
        Me.GB_BF.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_BF.Location = New System.Drawing.Point(0, 0)
        Me.GB_BF.Name = "GB_BF"
        Me.GB_BF.Size = New System.Drawing.Size(534, 919)
        Me.GB_BF.TabIndex = 2
        Me.GB_BF.TabStop = False
        '
        'GB_Blocks
        '
        Me.GB_Blocks.Dock = System.Windows.Forms.DockStyle.Right
        Me.GB_Blocks.Location = New System.Drawing.Point(240, 16)
        Me.GB_Blocks.Name = "GB_Blocks"
        Me.GB_Blocks.Size = New System.Drawing.Size(291, 900)
        Me.GB_Blocks.TabIndex = 1
        Me.GB_Blocks.TabStop = False
        '
        'Btn_Text
        '
        Me.Btn_Text.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_Text.Image = Global.PelBlock.My.Resources.Resources.Text
        Me.Btn_Text.Location = New System.Drawing.Point(3, 206)
        Me.Btn_Text.Name = "Btn_Text"
        Me.Btn_Text.Size = New System.Drawing.Size(237, 95)
        Me.Btn_Text.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Btn_Text.TabIndex = 4
        Me.Btn_Text.TabStop = False
        '
        'Btn_Output
        '
        Me.Btn_Output.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_Output.Image = Global.PelBlock.My.Resources.Resources.Outputs
        Me.Btn_Output.Location = New System.Drawing.Point(3, 111)
        Me.Btn_Output.Name = "Btn_Output"
        Me.Btn_Output.Size = New System.Drawing.Size(237, 95)
        Me.Btn_Output.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Btn_Output.TabIndex = 3
        Me.Btn_Output.TabStop = False
        '
        'Btn_Actions
        '
        Me.Btn_Actions.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_Actions.Image = Global.PelBlock.My.Resources.Resources.Events
        Me.Btn_Actions.Location = New System.Drawing.Point(3, 16)
        Me.Btn_Actions.Name = "Btn_Actions"
        Me.Btn_Actions.Size = New System.Drawing.Size(237, 95)
        Me.Btn_Actions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Btn_Actions.TabIndex = 0
        Me.Btn_Actions.TabStop = False
        '
        'Fr_Code
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 919)
        Me.Controls.Add(Me.GB_BF)
        Me.Controls.Add(Me.GB_WF)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Fr_Code"
        Me.Text = "Коструктор. Код"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GB_BF.ResumeLayout(False)
        CType(Me.Btn_Text, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Btn_Output, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Btn_Actions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GB_WF As GroupBox
    Friend WithEvents GB_BF As GroupBox
    Friend WithEvents GB_Blocks As GroupBox
    Friend WithEvents Btn_Actions As PictureBox
    Friend WithEvents Btn_Output As PictureBox
    Friend WithEvents Btn_Text As PictureBox
End Class
