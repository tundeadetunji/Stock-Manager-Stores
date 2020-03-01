<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
		Me.LinksProgramLog = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpCode = New System.Windows.Forms.MenuStrip()
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.Help = New System.Windows.Forms.ToolStripMenuItem()
		Me.TimeTimer = New System.Windows.Forms.Timer()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.YorubaLanguage = New System.Windows.Forms.ToolStripMenuItem()
		Me.ThaiLanguage = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
		Me.FrenchLanguage = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
		Me.EnglishLanguage = New System.Windows.Forms.ToolStripMenuItem()
		Me.LanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
		Me.LinksUsers = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.TimeLabel = New System.Windows.Forms.Label()
		Me.MinimizeButton = New System.Windows.Forms.Label()
		Me.SystemCloseButton = New System.Windows.Forms.Button()
		Me.DialogTitle = New System.Windows.Forms.Label()
		Me.Feedback = New System.Windows.Forms.TextBox()
		Me.CloseButton = New System.Windows.Forms.Label()
		Me.MenuStrip = New System.Windows.Forms.MenuStrip()
		Me.TasksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ThemeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ClassicTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
		Me.LavenderTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
		Me.NightTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
		Me.RoseTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
		Me.StandardTheme = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ApplicationFeedbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.MessagePromptOnly = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
		Me.MessagePromptWithVoice = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
		Me.VoiceOnly = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
		Me.AdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.LinksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.LinksMain = New System.Windows.Forms.ToolStripMenuItem()
		Me.PicturePath = New System.Windows.Forms.TextBox()
		Me.ClientsStat = New System.Windows.Forms.TextBox()
		Me.ClientsLocateBy = New System.Windows.Forms.ComboBox()
		Me.LocateByLabel = New System.Windows.Forms.Label()
		Me.ClientsLoadThis = New System.Windows.Forms.ComboBox()
		Me.ClientsReset = New System.Windows.Forms.Button()
		Me.LoadThisLabel = New System.Windows.Forms.Label()
		Me.ClientsGrid = New System.Windows.Forms.DataGridView()
		Me.RecordSerialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TriggerUsernameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogMemoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.UserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ClientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.SessionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogIPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.LogBindingSource = New System.Windows.Forms.BindingSource()
		Me.LogDataSet = New Program_Log.LogDataSet()
		Me.LogDetails = New System.Windows.Forms.TextBox()
		Me.LogTableAdapter = New Program_Log.LogDataSetTableAdapters.StockProgramLogTableAdapter()
		Me.StockLogTableAdapter = New Program_Log.LogDataSetTableAdapters.StockLogTableAdapter()
		Me.ClientsLoadThisDataSet = New Program_Log.LogDataSet()
		Me.ClientsLoadThisTableAdapter = New Program_Log.LogDataSetTableAdapters.StockProgramLogTableAdapter()
		Me.PictureBox6 = New System.Windows.Forms.PictureBox()
		Me.PictureBox5 = New System.Windows.Forms.PictureBox()
		Me.PictureBox4 = New System.Windows.Forms.PictureBox()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.PictureBox7 = New System.Windows.Forms.PictureBox()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.HelpButton = New System.Windows.Forms.PictureBox()
		Me.TopLine = New System.Windows.Forms.PictureBox()
		Me.BottomBorder = New System.Windows.Forms.PictureBox()
		Me.RightBorder = New System.Windows.Forms.PictureBox()
		Me.LeftBorder = New System.Windows.Forms.PictureBox()
		Me.TopBorder = New System.Windows.Forms.PictureBox()
		Me.BottomLine = New System.Windows.Forms.PictureBox()
		Me.HelpCode.SuspendLayout()
		Me.MenuStrip.SuspendLayout()
		CType(Me.ClientsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.LogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.LogDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ClientsLoadThisDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.HelpButton, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TopLine, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RightBorder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BottomLine, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'LinksProgramLog
		'
		Me.LinksProgramLog.Image = Global.Program_Log.My.Resources.Resources.camera
		Me.LinksProgramLog.Name = "LinksProgramLog"
		Me.LinksProgramLog.Size = New System.Drawing.Size(169, 24)
		Me.LinksProgramLog.Text = "Program Log"
		Me.LinksProgramLog.Visible = False
		'
		'HelpCode
		'
		Me.HelpCode.Dock = System.Windows.Forms.DockStyle.None
		Me.HelpCode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem})
		Me.HelpCode.Location = New System.Drawing.Point(1375, 422)
		Me.HelpCode.Name = "HelpCode"
		Me.HelpCode.Size = New System.Drawing.Size(52, 24)
		Me.HelpCode.TabIndex = 14882
		Me.HelpCode.Text = "MenuStrip1"
		'
		'HelpToolStripMenuItem
		'
		Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Help})
		Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
		Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.HelpToolStripMenuItem.Text = "Help"
		'
		'Help
		'
		Me.Help.Name = "Help"
		Me.Help.ShortcutKeys = System.Windows.Forms.Keys.F1
		Me.Help.Size = New System.Drawing.Size(118, 22)
		Me.Help.Text = "Help"
		'
		'TimeTimer
		'
		Me.TimeTimer.Enabled = True
		Me.TimeTimer.Interval = 1000
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(1133, 301)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(21, 20)
		Me.Label3.TabIndex = 14872
		Me.Label3.Text = "X"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Heavy", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(1073, 286)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(18, 21)
		Me.Label2.TabIndex = 14870
		Me.Label2.Text = "_"
		'
		'Button1
		'
		Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button1.Location = New System.Drawing.Point(1238, 517)
		Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(112, 40)
		Me.Button1.TabIndex = 14868
		Me.Button1.TabStop = False
		Me.Button1.Text = "Commit"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(970, 301)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(54, 20)
		Me.Label1.TabIndex = 14866
		Me.Label1.Text = "iDiary"
		'
		'YorubaLanguage
		'
		Me.YorubaLanguage.Name = "YorubaLanguage"
		Me.YorubaLanguage.Size = New System.Drawing.Size(134, 24)
		Me.YorubaLanguage.Text = "Yorùbá"
		'
		'ThaiLanguage
		'
		Me.ThaiLanguage.Name = "ThaiLanguage"
		Me.ThaiLanguage.Size = New System.Drawing.Size(134, 24)
		Me.ThaiLanguage.Text = "ไทย"
		'
		'ToolStripMenuItem10
		'
		Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
		Me.ToolStripMenuItem10.Size = New System.Drawing.Size(131, 6)
		'
		'FrenchLanguage
		'
		Me.FrenchLanguage.Name = "FrenchLanguage"
		Me.FrenchLanguage.Size = New System.Drawing.Size(134, 24)
		Me.FrenchLanguage.Text = "français"
		'
		'ToolStripMenuItem9
		'
		Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
		Me.ToolStripMenuItem9.Size = New System.Drawing.Size(131, 6)
		'
		'EnglishLanguage
		'
		Me.EnglishLanguage.Name = "EnglishLanguage"
		Me.EnglishLanguage.Size = New System.Drawing.Size(134, 24)
		Me.EnglishLanguage.Text = "English"
		'
		'LanguageToolStripMenuItem
		'
		Me.LanguageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnglishLanguage, Me.ToolStripMenuItem9, Me.FrenchLanguage, Me.ToolStripMenuItem10, Me.ThaiLanguage, Me.ToolStripSeparator7, Me.YorubaLanguage})
		Me.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
		Me.LanguageToolStripMenuItem.Size = New System.Drawing.Size(93, 24)
		Me.LanguageToolStripMenuItem.Text = "Language"
		Me.LanguageToolStripMenuItem.Visible = False
		'
		'ToolStripSeparator7
		'
		Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
		Me.ToolStripSeparator7.Size = New System.Drawing.Size(131, 6)
		'
		'LinksUsers
		'
		Me.LinksUsers.Image = Global.Program_Log.My.Resources.Resources.Technicalsupportrepresentative_Male_Dark
		Me.LinksUsers.Name = "LinksUsers"
		Me.LinksUsers.Size = New System.Drawing.Size(169, 24)
		Me.LinksUsers.Text = "Users"
		'
		'ToolStripMenuItem14
		'
		Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
		Me.ToolStripMenuItem14.Size = New System.Drawing.Size(166, 6)
		Me.ToolStripMenuItem14.Visible = False
		'
		'ToolStripMenuItem13
		'
		Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
		Me.ToolStripMenuItem13.Size = New System.Drawing.Size(166, 6)
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(1554, 586)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(0, 20)
		Me.Label4.TabIndex = 14879
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(1114, 262)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(100, 26)
		Me.TextBox2.TabIndex = 14880
		Me.TextBox2.TabStop = False
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(1256, 315)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.TextBox1.Size = New System.Drawing.Size(204, 52)
		Me.TextBox1.TabIndex = 14876
		Me.TextBox1.TabStop = False
		'
		'TimeLabel
		'
		Me.TimeLabel.AutoSize = True
		Me.TimeLabel.Location = New System.Drawing.Point(1554, 586)
		Me.TimeLabel.Name = "TimeLabel"
		Me.TimeLabel.Size = New System.Drawing.Size(0, 20)
		Me.TimeLabel.TabIndex = 14878
		'
		'MinimizeButton
		'
		Me.MinimizeButton.AutoSize = True
		Me.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand
		Me.MinimizeButton.Font = New System.Drawing.Font("Franklin Gothic Heavy", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MinimizeButton.Location = New System.Drawing.Point(1073, 286)
		Me.MinimizeButton.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.MinimizeButton.Name = "MinimizeButton"
		Me.MinimizeButton.Size = New System.Drawing.Size(18, 21)
		Me.MinimizeButton.TabIndex = 14871
		Me.MinimizeButton.Text = "_"
		'
		'SystemCloseButton
		'
		Me.SystemCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.SystemCloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SystemCloseButton.Location = New System.Drawing.Point(1238, 517)
		Me.SystemCloseButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.SystemCloseButton.Name = "SystemCloseButton"
		Me.SystemCloseButton.Size = New System.Drawing.Size(112, 40)
		Me.SystemCloseButton.TabIndex = 14869
		Me.SystemCloseButton.TabStop = False
		Me.SystemCloseButton.Text = "Commit"
		Me.SystemCloseButton.UseVisualStyleBackColor = True
		'
		'DialogTitle
		'
		Me.DialogTitle.AutoSize = True
		Me.DialogTitle.Cursor = System.Windows.Forms.Cursors.Hand
		Me.DialogTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DialogTitle.Location = New System.Drawing.Point(970, 301)
		Me.DialogTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.DialogTitle.Name = "DialogTitle"
		Me.DialogTitle.Size = New System.Drawing.Size(54, 20)
		Me.DialogTitle.TabIndex = 14867
		Me.DialogTitle.Text = "iDiary"
		'
		'Feedback
		'
		Me.Feedback.Location = New System.Drawing.Point(1256, 315)
		Me.Feedback.Multiline = True
		Me.Feedback.Name = "Feedback"
		Me.Feedback.ReadOnly = True
		Me.Feedback.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.Feedback.Size = New System.Drawing.Size(204, 52)
		Me.Feedback.TabIndex = 14877
		Me.Feedback.TabStop = False
		'
		'CloseButton
		'
		Me.CloseButton.AutoSize = True
		Me.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand
		Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CloseButton.Location = New System.Drawing.Point(1133, 301)
		Me.CloseButton.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.CloseButton.Name = "CloseButton"
		Me.CloseButton.Size = New System.Drawing.Size(21, 20)
		Me.CloseButton.TabIndex = 14873
		Me.CloseButton.Text = "X"
		'
		'MenuStrip
		'
		Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.None
		Me.MenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TasksToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.LinksToolStripMenuItem, Me.LanguageToolStripMenuItem})
		Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip.Name = "MenuStrip"
		Me.MenuStrip.Size = New System.Drawing.Size(209, 28)
		Me.MenuStrip.TabIndex = 14883
		Me.MenuStrip.Text = "MenuStrip1"
		'
		'TasksToolStripMenuItem
		'
		Me.TasksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutToolStripMenuItem})
		Me.TasksToolStripMenuItem.Name = "TasksToolStripMenuItem"
		Me.TasksToolStripMenuItem.Size = New System.Drawing.Size(63, 24)
		Me.TasksToolStripMenuItem.Text = "Tasks"
		'
		'LogOutToolStripMenuItem
		'
		Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
		Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(135, 24)
		Me.LogOutToolStripMenuItem.Text = "Log Out"
		'
		'SettingsToolStripMenuItem
		'
		Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThemeToolStripMenuItem, Me.ToolStripMenuItem1, Me.ApplicationFeedbackToolStripMenuItem, Me.ToolStripMenuItem8, Me.AdvancedToolStripMenuItem})
		Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
		Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(80, 24)
		Me.SettingsToolStripMenuItem.Text = "Settings"
		'
		'ThemeToolStripMenuItem
		'
		Me.ThemeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassicTheme, Me.ToolStripMenuItem2, Me.LavenderTheme, Me.ToolStripMenuItem3, Me.NightTheme, Me.ToolStripMenuItem4, Me.RoseTheme, Me.ToolStripMenuItem5, Me.StandardTheme})
		Me.ThemeToolStripMenuItem.Name = "ThemeToolStripMenuItem"
		Me.ThemeToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
		Me.ThemeToolStripMenuItem.Text = "Theme"
		Me.ThemeToolStripMenuItem.Visible = False
		'
		'ClassicTheme
		'
		Me.ClassicTheme.Name = "ClassicTheme"
		Me.ClassicTheme.Size = New System.Drawing.Size(144, 24)
		Me.ClassicTheme.Text = "Classic"
		'
		'ToolStripMenuItem2
		'
		Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
		Me.ToolStripMenuItem2.Size = New System.Drawing.Size(141, 6)
		'
		'LavenderTheme
		'
		Me.LavenderTheme.Name = "LavenderTheme"
		Me.LavenderTheme.Size = New System.Drawing.Size(144, 24)
		Me.LavenderTheme.Text = "Lavender"
		Me.LavenderTheme.Visible = False
		'
		'ToolStripMenuItem3
		'
		Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
		Me.ToolStripMenuItem3.Size = New System.Drawing.Size(141, 6)
		Me.ToolStripMenuItem3.Visible = False
		'
		'NightTheme
		'
		Me.NightTheme.Name = "NightTheme"
		Me.NightTheme.Size = New System.Drawing.Size(144, 24)
		Me.NightTheme.Text = "Night"
		'
		'ToolStripMenuItem4
		'
		Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
		Me.ToolStripMenuItem4.Size = New System.Drawing.Size(141, 6)
		'
		'RoseTheme
		'
		Me.RoseTheme.Name = "RoseTheme"
		Me.RoseTheme.Size = New System.Drawing.Size(144, 24)
		Me.RoseTheme.Text = "Rose"
		Me.RoseTheme.Visible = False
		'
		'ToolStripMenuItem5
		'
		Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
		Me.ToolStripMenuItem5.Size = New System.Drawing.Size(141, 6)
		Me.ToolStripMenuItem5.Visible = False
		'
		'StandardTheme
		'
		Me.StandardTheme.Name = "StandardTheme"
		Me.StandardTheme.Size = New System.Drawing.Size(144, 24)
		Me.StandardTheme.Text = "Standard"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(228, 6)
		Me.ToolStripMenuItem1.Visible = False
		'
		'ApplicationFeedbackToolStripMenuItem
		'
		Me.ApplicationFeedbackToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagePromptOnly, Me.ToolStripMenuItem6, Me.MessagePromptWithVoice, Me.ToolStripMenuItem7, Me.VoiceOnly})
		Me.ApplicationFeedbackToolStripMenuItem.Name = "ApplicationFeedbackToolStripMenuItem"
		Me.ApplicationFeedbackToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
		Me.ApplicationFeedbackToolStripMenuItem.Text = "Application Feedback"
		'
		'MessagePromptOnly
		'
		Me.MessagePromptOnly.Name = "MessagePromptOnly"
		Me.MessagePromptOnly.Size = New System.Drawing.Size(278, 24)
		Me.MessagePromptOnly.Text = "Message Prompt Only"
		'
		'ToolStripMenuItem6
		'
		Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
		Me.ToolStripMenuItem6.Size = New System.Drawing.Size(275, 6)
		'
		'MessagePromptWithVoice
		'
		Me.MessagePromptWithVoice.Name = "MessagePromptWithVoice"
		Me.MessagePromptWithVoice.Size = New System.Drawing.Size(278, 24)
		Me.MessagePromptWithVoice.Text = "Message Prompt With Voice"
		'
		'ToolStripMenuItem7
		'
		Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
		Me.ToolStripMenuItem7.Size = New System.Drawing.Size(275, 6)
		'
		'VoiceOnly
		'
		Me.VoiceOnly.Name = "VoiceOnly"
		Me.VoiceOnly.Size = New System.Drawing.Size(278, 24)
		Me.VoiceOnly.Text = "Voice Only"
		'
		'ToolStripMenuItem8
		'
		Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
		Me.ToolStripMenuItem8.Size = New System.Drawing.Size(228, 6)
		Me.ToolStripMenuItem8.Visible = False
		'
		'AdvancedToolStripMenuItem
		'
		Me.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem"
		Me.AdvancedToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
		Me.AdvancedToolStripMenuItem.Text = "Default Actions"
		Me.AdvancedToolStripMenuItem.Visible = False
		'
		'LinksToolStripMenuItem
		'
		Me.LinksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LinksMain, Me.ToolStripMenuItem13, Me.LinksProgramLog, Me.ToolStripMenuItem14, Me.LinksUsers})
		Me.LinksToolStripMenuItem.Name = "LinksToolStripMenuItem"
		Me.LinksToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
		Me.LinksToolStripMenuItem.Text = "Links"
		'
		'LinksMain
		'
		Me.LinksMain.Image = Global.Program_Log.My.Resources.Resources.search
		Me.LinksMain.Name = "LinksMain"
		Me.LinksMain.Size = New System.Drawing.Size(169, 24)
		Me.LinksMain.Text = "Main"
		'
		'PicturePath
		'
		Me.PicturePath.Location = New System.Drawing.Point(1114, 262)
		Me.PicturePath.Name = "PicturePath"
		Me.PicturePath.Size = New System.Drawing.Size(100, 26)
		Me.PicturePath.TabIndex = 14881
		Me.PicturePath.TabStop = False
		'
		'ClientsStat
		'
		Me.ClientsStat.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ClientsStat.Location = New System.Drawing.Point(14, 339)
		Me.ClientsStat.Multiline = True
		Me.ClientsStat.Name = "ClientsStat"
		Me.ClientsStat.ReadOnly = True
		Me.ClientsStat.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.ClientsStat.Size = New System.Drawing.Size(915, 52)
		Me.ClientsStat.TabIndex = 14891
		Me.ClientsStat.TabStop = False
		Me.ClientsStat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'ClientsLocateBy
		'
		Me.ClientsLocateBy.FormattingEnabled = True
		Me.ClientsLocateBy.Location = New System.Drawing.Point(318, 405)
		Me.ClientsLocateBy.Name = "ClientsLocateBy"
		Me.ClientsLocateBy.Size = New System.Drawing.Size(286, 28)
		Me.ClientsLocateBy.TabIndex = 14885
		'
		'LocateByLabel
		'
		Me.LocateByLabel.AutoSize = True
		Me.LocateByLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.LocateByLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LocateByLabel.Location = New System.Drawing.Point(223, 408)
		Me.LocateByLabel.Name = "LocateByLabel"
		Me.LocateByLabel.Size = New System.Drawing.Size(89, 20)
		Me.LocateByLabel.TabIndex = 14886
		Me.LocateByLabel.Text = "Locate By"
		'
		'ClientsLoadThis
		'
		Me.ClientsLoadThis.FormattingEnabled = True
		Me.ClientsLoadThis.Location = New System.Drawing.Point(318, 439)
		Me.ClientsLoadThis.Name = "ClientsLoadThis"
		Me.ClientsLoadThis.Size = New System.Drawing.Size(286, 28)
		Me.ClientsLoadThis.TabIndex = 14887
		'
		'ClientsReset
		'
		Me.ClientsReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.ClientsReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ClientsReset.Location = New System.Drawing.Point(610, 418)
		Me.ClientsReset.Name = "ClientsReset"
		Me.ClientsReset.Size = New System.Drawing.Size(109, 36)
		Me.ClientsReset.TabIndex = 14889
		Me.ClientsReset.Text = "Reset"
		Me.ClientsReset.UseVisualStyleBackColor = True
		'
		'LoadThisLabel
		'
		Me.LoadThisLabel.AutoSize = True
		Me.LoadThisLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.LoadThisLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LoadThisLabel.Location = New System.Drawing.Point(225, 442)
		Me.LoadThisLabel.Name = "LoadThisLabel"
		Me.LoadThisLabel.Size = New System.Drawing.Size(87, 20)
		Me.LoadThisLabel.TabIndex = 14888
		Me.LoadThisLabel.Text = "Load This"
		'
		'ClientsGrid
		'
		Me.ClientsGrid.AllowUserToAddRows = False
		Me.ClientsGrid.AllowUserToDeleteRows = False
		Me.ClientsGrid.AutoGenerateColumns = False
		Me.ClientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.ClientsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RecordSerialDataGridViewTextBoxColumn, Me.LogTitleDataGridViewTextBoxColumn, Me.LogDateDataGridViewTextBoxColumn, Me.LogTimeDataGridViewTextBoxColumn, Me.TriggerUsernameDataGridViewTextBoxColumn, Me.LogMemoDataGridViewTextBoxColumn, Me.UserIDDataGridViewTextBoxColumn, Me.ClientIDDataGridViewTextBoxColumn, Me.ItemID, Me.SessionIDDataGridViewTextBoxColumn, Me.LogIPDataGridViewTextBoxColumn})
		Me.ClientsGrid.DataSource = Me.LogBindingSource
		Me.ClientsGrid.Location = New System.Drawing.Point(14, 63)
		Me.ClientsGrid.Name = "ClientsGrid"
		Me.ClientsGrid.ReadOnly = True
		Me.ClientsGrid.Size = New System.Drawing.Size(915, 262)
		Me.ClientsGrid.TabIndex = 14884
		'
		'RecordSerialDataGridViewTextBoxColumn
		'
		Me.RecordSerialDataGridViewTextBoxColumn.DataPropertyName = "RecordSerial"
		Me.RecordSerialDataGridViewTextBoxColumn.HeaderText = "RecordSerial"
		Me.RecordSerialDataGridViewTextBoxColumn.Name = "RecordSerialDataGridViewTextBoxColumn"
		Me.RecordSerialDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogTitleDataGridViewTextBoxColumn
		'
		Me.LogTitleDataGridViewTextBoxColumn.DataPropertyName = "LogTitle"
		Me.LogTitleDataGridViewTextBoxColumn.HeaderText = "LogTitle"
		Me.LogTitleDataGridViewTextBoxColumn.Name = "LogTitleDataGridViewTextBoxColumn"
		Me.LogTitleDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogDateDataGridViewTextBoxColumn
		'
		Me.LogDateDataGridViewTextBoxColumn.DataPropertyName = "LogDate"
		Me.LogDateDataGridViewTextBoxColumn.HeaderText = "LogDate"
		Me.LogDateDataGridViewTextBoxColumn.Name = "LogDateDataGridViewTextBoxColumn"
		Me.LogDateDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogTimeDataGridViewTextBoxColumn
		'
		Me.LogTimeDataGridViewTextBoxColumn.DataPropertyName = "LogTime"
		Me.LogTimeDataGridViewTextBoxColumn.HeaderText = "LogTime"
		Me.LogTimeDataGridViewTextBoxColumn.Name = "LogTimeDataGridViewTextBoxColumn"
		Me.LogTimeDataGridViewTextBoxColumn.ReadOnly = True
		'
		'TriggerUsernameDataGridViewTextBoxColumn
		'
		Me.TriggerUsernameDataGridViewTextBoxColumn.DataPropertyName = "TriggerUsername"
		Me.TriggerUsernameDataGridViewTextBoxColumn.HeaderText = "TriggerUsername"
		Me.TriggerUsernameDataGridViewTextBoxColumn.Name = "TriggerUsernameDataGridViewTextBoxColumn"
		Me.TriggerUsernameDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogMemoDataGridViewTextBoxColumn
		'
		Me.LogMemoDataGridViewTextBoxColumn.DataPropertyName = "LogMemo"
		Me.LogMemoDataGridViewTextBoxColumn.HeaderText = "LogMemo"
		Me.LogMemoDataGridViewTextBoxColumn.Name = "LogMemoDataGridViewTextBoxColumn"
		Me.LogMemoDataGridViewTextBoxColumn.ReadOnly = True
		'
		'UserIDDataGridViewTextBoxColumn
		'
		Me.UserIDDataGridViewTextBoxColumn.DataPropertyName = "UserID"
		Me.UserIDDataGridViewTextBoxColumn.HeaderText = "UserID"
		Me.UserIDDataGridViewTextBoxColumn.Name = "UserIDDataGridViewTextBoxColumn"
		Me.UserIDDataGridViewTextBoxColumn.ReadOnly = True
		'
		'ClientIDDataGridViewTextBoxColumn
		'
		Me.ClientIDDataGridViewTextBoxColumn.DataPropertyName = "ClientID"
		Me.ClientIDDataGridViewTextBoxColumn.HeaderText = "ClientID"
		Me.ClientIDDataGridViewTextBoxColumn.Name = "ClientIDDataGridViewTextBoxColumn"
		Me.ClientIDDataGridViewTextBoxColumn.ReadOnly = True
		'
		'ItemID
		'
		Me.ItemID.DataPropertyName = "ItemID"
		Me.ItemID.HeaderText = "ItemID"
		Me.ItemID.Name = "ItemID"
		Me.ItemID.ReadOnly = True
		'
		'SessionIDDataGridViewTextBoxColumn
		'
		Me.SessionIDDataGridViewTextBoxColumn.DataPropertyName = "SessionID"
		Me.SessionIDDataGridViewTextBoxColumn.HeaderText = "SessionID"
		Me.SessionIDDataGridViewTextBoxColumn.Name = "SessionIDDataGridViewTextBoxColumn"
		Me.SessionIDDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogIPDataGridViewTextBoxColumn
		'
		Me.LogIPDataGridViewTextBoxColumn.DataPropertyName = "LogIP"
		Me.LogIPDataGridViewTextBoxColumn.HeaderText = "LogIP"
		Me.LogIPDataGridViewTextBoxColumn.Name = "LogIPDataGridViewTextBoxColumn"
		Me.LogIPDataGridViewTextBoxColumn.ReadOnly = True
		'
		'LogBindingSource
		'
		Me.LogBindingSource.DataMember = "StockProgramLog"
		Me.LogBindingSource.DataSource = Me.LogDataSet
		'
		'LogDataSet
		'
		Me.LogDataSet.DataSetName = "LogDataSet"
		Me.LogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'LogDetails
		'
		Me.LogDetails.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LogBindingSource, "LogMemo", True))
		Me.LogDetails.Location = New System.Drawing.Point(279, 149)
		Me.LogDetails.Name = "LogDetails"
		Me.LogDetails.Size = New System.Drawing.Size(100, 26)
		Me.LogDetails.TabIndex = 14892
		'
		'LogTableAdapter
		'
		Me.LogTableAdapter.ClearBeforeFill = True
		'
		'StockLogTableAdapter
		'
		Me.StockLogTableAdapter.ClearBeforeFill = True
		'
		'ClientsLoadThisDataSet
		'
		Me.ClientsLoadThisDataSet.DataSetName = "LogDataSet"
		Me.ClientsLoadThisDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'ClientsLoadThisTableAdapter
		'
		Me.ClientsLoadThisTableAdapter.ClearBeforeFill = True
		'
		'PictureBox6
		'
		Me.PictureBox6.BackColor = System.Drawing.Color.Black
		Me.PictureBox6.Location = New System.Drawing.Point(1037, 410)
		Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox6.Name = "PictureBox6"
		Me.PictureBox6.Size = New System.Drawing.Size(795, 2)
		Me.PictureBox6.TabIndex = 14865
		Me.PictureBox6.TabStop = False
		'
		'PictureBox5
		'
		Me.PictureBox5.BackColor = System.Drawing.Color.Black
		Me.PictureBox5.Location = New System.Drawing.Point(1032, 391)
		Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox5.Name = "PictureBox5"
		Me.PictureBox5.Size = New System.Drawing.Size(795, 2)
		Me.PictureBox5.TabIndex = 14863
		Me.PictureBox5.TabStop = False
		'
		'PictureBox4
		'
		Me.PictureBox4.Location = New System.Drawing.Point(1046, 441)
		Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox4.Name = "PictureBox4"
		Me.PictureBox4.Size = New System.Drawing.Size(118, 20)
		Me.PictureBox4.TabIndex = 14861
		Me.PictureBox4.TabStop = False
		'
		'PictureBox3
		'
		Me.PictureBox3.Location = New System.Drawing.Point(1046, 517)
		Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox3.Name = "PictureBox3"
		Me.PictureBox3.Size = New System.Drawing.Size(118, 20)
		Me.PictureBox3.TabIndex = 14857
		Me.PictureBox3.TabStop = False
		'
		'PictureBox2
		'
		Me.PictureBox2.Location = New System.Drawing.Point(1046, 471)
		Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(118, 20)
		Me.PictureBox2.TabIndex = 14854
		Me.PictureBox2.TabStop = False
		'
		'PictureBox7
		'
		Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
		Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.PictureBox7.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox7.Image = Global.Program_Log.My.Resources.Resources.help
		Me.PictureBox7.Location = New System.Drawing.Point(1046, 326)
		Me.PictureBox7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox7.Name = "PictureBox7"
		Me.PictureBox7.Size = New System.Drawing.Size(30, 31)
		Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox7.TabIndex = 14874
		Me.PictureBox7.TabStop = False
		'
		'PictureBox1
		'
		Me.PictureBox1.Location = New System.Drawing.Point(1046, 487)
		Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(118, 20)
		Me.PictureBox1.TabIndex = 14858
		Me.PictureBox1.TabStop = False
		'
		'HelpButton
		'
		Me.HelpButton.BackColor = System.Drawing.Color.Transparent
		Me.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.HelpButton.Cursor = System.Windows.Forms.Cursors.Hand
		Me.HelpButton.Image = Global.Program_Log.My.Resources.Resources.help
		Me.HelpButton.Location = New System.Drawing.Point(1046, 326)
		Me.HelpButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.HelpButton.Name = "HelpButton"
		Me.HelpButton.Size = New System.Drawing.Size(30, 31)
		Me.HelpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.HelpButton.TabIndex = 14875
		Me.HelpButton.TabStop = False
		'
		'TopLine
		'
		Me.TopLine.BackColor = System.Drawing.Color.Black
		Me.TopLine.Location = New System.Drawing.Point(1032, 391)
		Me.TopLine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.TopLine.Name = "TopLine"
		Me.TopLine.Size = New System.Drawing.Size(795, 2)
		Me.TopLine.TabIndex = 14862
		Me.TopLine.TabStop = False
		'
		'BottomBorder
		'
		Me.BottomBorder.Location = New System.Drawing.Point(1046, 441)
		Me.BottomBorder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.BottomBorder.Name = "BottomBorder"
		Me.BottomBorder.Size = New System.Drawing.Size(118, 20)
		Me.BottomBorder.TabIndex = 14860
		Me.BottomBorder.TabStop = False
		'
		'RightBorder
		'
		Me.RightBorder.Location = New System.Drawing.Point(1046, 517)
		Me.RightBorder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.RightBorder.Name = "RightBorder"
		Me.RightBorder.Size = New System.Drawing.Size(118, 20)
		Me.RightBorder.TabIndex = 14856
		Me.RightBorder.TabStop = False
		'
		'LeftBorder
		'
		Me.LeftBorder.Location = New System.Drawing.Point(1046, 471)
		Me.LeftBorder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.LeftBorder.Name = "LeftBorder"
		Me.LeftBorder.Size = New System.Drawing.Size(118, 20)
		Me.LeftBorder.TabIndex = 14855
		Me.LeftBorder.TabStop = False
		'
		'TopBorder
		'
		Me.TopBorder.Location = New System.Drawing.Point(1046, 487)
		Me.TopBorder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.TopBorder.Name = "TopBorder"
		Me.TopBorder.Size = New System.Drawing.Size(118, 20)
		Me.TopBorder.TabIndex = 14859
		Me.TopBorder.TabStop = False
		'
		'BottomLine
		'
		Me.BottomLine.BackColor = System.Drawing.Color.Black
		Me.BottomLine.Location = New System.Drawing.Point(1037, 410)
		Me.BottomLine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.BottomLine.Name = "BottomLine"
		Me.BottomLine.Size = New System.Drawing.Size(795, 2)
		Me.BottomLine.TabIndex = 14864
		Me.BottomLine.TabStop = False
		'
		'Main
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(943, 536)
		Me.Controls.Add(Me.ClientsStat)
		Me.Controls.Add(Me.ClientsLocateBy)
		Me.Controls.Add(Me.LocateByLabel)
		Me.Controls.Add(Me.ClientsLoadThis)
		Me.Controls.Add(Me.ClientsReset)
		Me.Controls.Add(Me.LoadThisLabel)
		Me.Controls.Add(Me.ClientsGrid)
		Me.Controls.Add(Me.HelpCode)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.PictureBox6)
		Me.Controls.Add(Me.PictureBox5)
		Me.Controls.Add(Me.PictureBox4)
		Me.Controls.Add(Me.PictureBox3)
		Me.Controls.Add(Me.PictureBox2)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.PictureBox7)
		Me.Controls.Add(Me.PictureBox1)
		Me.Controls.Add(Me.HelpButton)
		Me.Controls.Add(Me.TopLine)
		Me.Controls.Add(Me.TimeLabel)
		Me.Controls.Add(Me.MinimizeButton)
		Me.Controls.Add(Me.SystemCloseButton)
		Me.Controls.Add(Me.DialogTitle)
		Me.Controls.Add(Me.BottomBorder)
		Me.Controls.Add(Me.RightBorder)
		Me.Controls.Add(Me.Feedback)
		Me.Controls.Add(Me.CloseButton)
		Me.Controls.Add(Me.LeftBorder)
		Me.Controls.Add(Me.TopBorder)
		Me.Controls.Add(Me.BottomLine)
		Me.Controls.Add(Me.MenuStrip)
		Me.Controls.Add(Me.PicturePath)
		Me.Controls.Add(Me.LogDetails)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.Name = "Main"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Program Log - Stock Manager"
		Me.HelpCode.ResumeLayout(False)
		Me.HelpCode.PerformLayout()
		Me.MenuStrip.ResumeLayout(False)
		Me.MenuStrip.PerformLayout()
		CType(Me.ClientsGrid, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.LogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.LogDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ClientsLoadThisDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.HelpButton, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TopLine, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RightBorder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BottomLine, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents LinksProgramLog As ToolStripMenuItem
	Friend WithEvents HelpCode As MenuStrip
	Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Help As ToolStripMenuItem
	Friend WithEvents TimeTimer As Timer
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents PictureBox6 As PictureBox
	Friend WithEvents YorubaLanguage As ToolStripMenuItem
	Friend WithEvents ThaiLanguage As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem10 As ToolStripSeparator
	Friend WithEvents FrenchLanguage As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem9 As ToolStripSeparator
	Friend WithEvents EnglishLanguage As ToolStripMenuItem
	Friend WithEvents LanguageToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
	Friend WithEvents LinksUsers As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem14 As ToolStripSeparator
	Friend WithEvents ToolStripMenuItem13 As ToolStripSeparator
	Friend WithEvents PictureBox5 As PictureBox
	Friend WithEvents PictureBox4 As PictureBox
	Friend WithEvents PictureBox3 As PictureBox
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents Label4 As Label
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents PictureBox7 As PictureBox
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents HelpButton As PictureBox
	Friend WithEvents TopLine As PictureBox
	Friend WithEvents TimeLabel As Label
	Friend WithEvents MinimizeButton As Label
	Friend WithEvents SystemCloseButton As Button
	Friend WithEvents DialogTitle As Label
	Friend WithEvents BottomBorder As PictureBox
	Friend WithEvents RightBorder As PictureBox
	Friend WithEvents Feedback As TextBox
	Friend WithEvents CloseButton As Label
	Friend WithEvents LeftBorder As PictureBox
	Friend WithEvents TopBorder As PictureBox
	Friend WithEvents BottomLine As PictureBox
	Friend WithEvents LinksMain As ToolStripMenuItem
	Friend WithEvents MenuStrip As MenuStrip
	Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ThemeToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ClassicTheme As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
	Friend WithEvents LavenderTheme As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
	Friend WithEvents NightTheme As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
	Friend WithEvents RoseTheme As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
	Friend WithEvents StandardTheme As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
	Friend WithEvents ApplicationFeedbackToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents MessagePromptOnly As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
	Friend WithEvents MessagePromptWithVoice As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
	Friend WithEvents VoiceOnly As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
	Friend WithEvents AdvancedToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents LinksToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents PicturePath As TextBox
	Friend WithEvents ClientsStat As TextBox
	Friend WithEvents ClientsLocateBy As ComboBox
	Friend WithEvents LocateByLabel As Label
	Friend WithEvents ClientsLoadThis As ComboBox
	Friend WithEvents ClientsReset As Button
	Friend WithEvents LoadThisLabel As Label
	Friend WithEvents ClientsGrid As DataGridView
	Friend WithEvents LogDataSet As LogDataSet
	Friend WithEvents LogTableAdapter As LogDataSetTableAdapters.StockProgramLogTableAdapter
	Friend WithEvents LogBindingSource As BindingSource
	Friend WithEvents StockLogTableAdapter As LogDataSetTableAdapters.StockLogTableAdapter
	Friend WithEvents ClientsLoadThisDataSet As LogDataSet
	Friend WithEvents ClientsLoadThisTableAdapter As LogDataSetTableAdapters.StockProgramLogTableAdapter
	Friend WithEvents LogDetails As TextBox
	Friend WithEvents RecordSerialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents LogTitleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents LogDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents LogTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents TriggerUsernameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents LogMemoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents UserIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents ClientIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents ItemID As DataGridViewTextBoxColumn
	Friend WithEvents SessionIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents LogIPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
	Friend WithEvents TasksToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
End Class
