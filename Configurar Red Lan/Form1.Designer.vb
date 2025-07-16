<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnConfigurar1 = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.btnConfigurar2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConfigurar1
        '
        Me.btnConfigurar1.Location = New System.Drawing.Point(13, 13)
        Me.btnConfigurar1.Name = "btnConfigurar1"
        Me.btnConfigurar1.Size = New System.Drawing.Size(99, 23)
        Me.btnConfigurar1.TabIndex = 0
        Me.btnConfigurar1.Text = "Configurar PC1"
        Me.btnConfigurar1.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(12, 42)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(384, 409)
        Me.txtOutput.TabIndex = 1
        '
        'btnConfigurar2
        '
        Me.btnConfigurar2.Location = New System.Drawing.Point(118, 12)
        Me.btnConfigurar2.Name = "btnConfigurar2"
        Me.btnConfigurar2.Size = New System.Drawing.Size(99, 23)
        Me.btnConfigurar2.TabIndex = 2
        Me.btnConfigurar2.Text = "Configurar PC2"
        Me.btnConfigurar2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 468)
        Me.Controls.Add(Me.btnConfigurar2)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnConfigurar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Lan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfigurar1 As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents btnConfigurar2 As Button
End Class
