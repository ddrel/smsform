<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmuserlist
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtguser = New System.Windows.Forms.DataGridView()
        Me.colSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colmobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colemail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collatitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collongitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collocation_key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BDS = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.btnsend = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dtguser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtguser)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnrefresh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnsend)
        Me.SplitContainer1.Size = New System.Drawing.Size(682, 318)
        Me.SplitContainer1.SplitterDistance = 286
        Me.SplitContainer1.TabIndex = 0
        '
        'dtguser
        '
        Me.dtguser.AllowUserToAddRows = False
        Me.dtguser.AllowUserToDeleteRows = False
        Me.dtguser.AllowUserToResizeColumns = False
        Me.dtguser.AllowUserToResizeRows = False
        Me.dtguser.AutoGenerateColumns = False
        Me.dtguser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtguser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelected, Me.colname, Me.colmobile, Me.colemail, Me.collocation, Me.collatitude, Me.collongitude, Me.collocation_key})
        Me.dtguser.DataSource = Me.BDS
        Me.dtguser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtguser.Location = New System.Drawing.Point(0, 0)
        Me.dtguser.Name = "dtguser"
        Me.dtguser.RowHeadersVisible = False
        Me.dtguser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtguser.Size = New System.Drawing.Size(682, 286)
        Me.dtguser.TabIndex = 1
        '
        'colSelected
        '
        Me.colSelected.HeaderText = ""
        Me.colSelected.Name = "colSelected"
        Me.colSelected.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSelected.Visible = False
        Me.colSelected.Width = 20
        '
        'colname
        '
        Me.colname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colname.DataPropertyName = "name"
        Me.colname.HeaderText = "Name"
        Me.colname.Name = "colname"
        Me.colname.ReadOnly = True
        Me.colname.Width = 150
        '
        'colmobile
        '
        Me.colmobile.DataPropertyName = "mobile"
        Me.colmobile.HeaderText = "Mobile"
        Me.colmobile.Name = "colmobile"
        Me.colmobile.Width = 85
        '
        'colemail
        '
        Me.colemail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colemail.DataPropertyName = "email"
        Me.colemail.HeaderText = "Email"
        Me.colemail.Name = "colemail"
        Me.colemail.ReadOnly = True
        Me.colemail.Width = 120
        '
        'collocation
        '
        Me.collocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.collocation.DataPropertyName = "location"
        Me.collocation.HeaderText = "Location"
        Me.collocation.Name = "collocation"
        '
        'collatitude
        '
        Me.collatitude.DataPropertyName = "lat"
        Me.collatitude.HeaderText = "Latitude"
        Me.collatitude.Name = "collatitude"
        Me.collatitude.Width = 60
        '
        'collongitude
        '
        Me.collongitude.DataPropertyName = "lng"
        Me.collongitude.HeaderText = "Longitude"
        Me.collongitude.Name = "collongitude"
        Me.collongitude.Width = 60
        '
        'collocation_key
        '
        Me.collocation_key.DataPropertyName = "location_key"
        Me.collocation_key.HeaderText = "location_key"
        Me.collocation_key.Name = "collocation_key"
        Me.collocation_key.Visible = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.Location = New System.Drawing.Point(6, 3)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(76, 23)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnsend
        '
        Me.btnsend.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnsend.Location = New System.Drawing.Point(568, 2)
        Me.btnsend.Name = "btnsend"
        Me.btnsend.Size = New System.Drawing.Size(106, 23)
        Me.btnsend.TabIndex = 0
        Me.btnsend.Text = "Send Notification"
        Me.btnsend.UseVisualStyleBackColor = True
        '
        'frmuserlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 318)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmuserlist"
        Me.Text = "User subscribe"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dtguser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtguser As System.Windows.Forms.DataGridView
    Friend WithEvents btnsend As System.Windows.Forms.Button
    Friend WithEvents BDS As System.Windows.Forms.BindingSource
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents colSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colmobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colemail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collatitude As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collongitude As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collocation_key As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
