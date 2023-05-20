namespace redioProj
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer_fft = new System.Windows.Forms.Timer(this.components);
            this.receivGPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.maxFreKeepCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.switchIpText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.switchIpLab = new DevComponents.DotNetBar.LabelX();
            this.bandScanNumBtn = new DevComponents.DotNetBar.ButtonX();
            this.singlePointBtn = new DevComponents.DotNetBar.ButtonX();
            this.closeReceiverBtn = new DevComponents.DotNetBar.ButtonX();
            this.conReceiverBtn = new DevComponents.DotNetBar.ButtonX();
            this.focusFreCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.showSignalCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.freMarkCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.centerReceivText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.centerReceivLab = new DevComponents.DotNetBar.LabelX();
            this.imgGPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.aheadFre40 = new DevComponents.DotNetBar.ButtonX();
            this.nextFre40 = new DevComponents.DotNetBar.ButtonX();
            this.loadDataBtn = new DevComponents.DotNetBar.ButtonX();
            this.loadDataLab = new DevComponents.DotNetBar.LabelX();
            this.centerText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.centerLab = new DevComponents.DotNetBar.LabelX();
            this.fluoreGPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.setFlowBtn = new DevComponents.DotNetBar.ButtonX();
            this.flowText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.showDpxBtn = new DevComponents.DotNetBar.ButtonX();
            this.signalImgBox = new System.Windows.Forms.PictureBox();
            this.signalViewBox = new System.Windows.Forms.PictureBox();
            this.dpxBox = new System.Windows.Forms.PictureBox();
            this.setCenterFreBtn = new DevComponents.DotNetBar.ButtonX();
            this.widthSignCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.receivGPanel.SuspendLayout();
            this.imgGPanel.SuspendLayout();
            this.fluoreGPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signalImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalViewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpxBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_fft
            // 
            this.timer_fft.Enabled = true;
            this.timer_fft.Interval = 25;
            this.timer_fft.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // receivGPanel
            // 
            this.receivGPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.receivGPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.receivGPanel.Controls.Add(this.maxFreKeepCheck);
            this.receivGPanel.Controls.Add(this.textBoxX1);
            this.receivGPanel.Controls.Add(this.labelX1);
            this.receivGPanel.Controls.Add(this.switchIpText);
            this.receivGPanel.Controls.Add(this.switchIpLab);
            this.receivGPanel.Controls.Add(this.bandScanNumBtn);
            this.receivGPanel.Controls.Add(this.singlePointBtn);
            this.receivGPanel.Controls.Add(this.closeReceiverBtn);
            this.receivGPanel.Controls.Add(this.conReceiverBtn);
            this.receivGPanel.Controls.Add(this.focusFreCheck);
            this.receivGPanel.Controls.Add(this.showSignalCheck);
            this.receivGPanel.Controls.Add(this.freMarkCheck);
            this.receivGPanel.Controls.Add(this.centerReceivText);
            this.receivGPanel.Controls.Add(this.centerReceivLab);
            this.receivGPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.receivGPanel.Location = new System.Drawing.Point(13, 17);
            this.receivGPanel.Margin = new System.Windows.Forms.Padding(2);
            this.receivGPanel.Name = "receivGPanel";
            this.receivGPanel.Size = new System.Drawing.Size(304, 234);
            // 
            // 
            // 
            this.receivGPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.receivGPanel.Style.BackColorGradientAngle = 90;
            this.receivGPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.receivGPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.receivGPanel.Style.BorderBottomWidth = 1;
            this.receivGPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.receivGPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.receivGPanel.Style.BorderLeftWidth = 1;
            this.receivGPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.receivGPanel.Style.BorderRightWidth = 1;
            this.receivGPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.receivGPanel.Style.BorderTopWidth = 1;
            this.receivGPanel.Style.CornerDiameter = 4;
            this.receivGPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.receivGPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.receivGPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.receivGPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.receivGPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.receivGPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.receivGPanel.TabIndex = 0;
            this.receivGPanel.Text = "交换机";
            // 
            // maxFreKeepCheck
            // 
            this.maxFreKeepCheck.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.maxFreKeepCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.maxFreKeepCheck.Location = new System.Drawing.Point(112, 96);
            this.maxFreKeepCheck.Margin = new System.Windows.Forms.Padding(2);
            this.maxFreKeepCheck.Name = "maxFreKeepCheck";
            this.maxFreKeepCheck.Size = new System.Drawing.Size(75, 18);
            this.maxFreKeepCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.maxFreKeepCheck.TabIndex = 13;
            this.maxFreKeepCheck.Text = "最大保持";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(86, 46);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(106, 21);
            this.textBoxX1.TabIndex = 12;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 49);
            this.labelX1.Margin = new System.Windows.Forms.Padding(2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 18);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "端口号：";
            // 
            // switchIpText
            // 
            // 
            // 
            // 
            this.switchIpText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchIpText.Location = new System.Drawing.Point(86, 14);
            this.switchIpText.Margin = new System.Windows.Forms.Padding(2);
            this.switchIpText.Name = "switchIpText";
            this.switchIpText.PreventEnterBeep = true;
            this.switchIpText.Size = new System.Drawing.Size(106, 15);
            this.switchIpText.TabIndex = 10;
            // 
            // switchIpLab
            // 
            this.switchIpLab.AutoSize = true;
            this.switchIpLab.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.switchIpLab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchIpLab.Location = new System.Drawing.Point(15, 17);
            this.switchIpLab.Margin = new System.Windows.Forms.Padding(2);
            this.switchIpLab.Name = "switchIpLab";
            this.switchIpLab.Size = new System.Drawing.Size(56, 18);
            this.switchIpLab.TabIndex = 9;
            this.switchIpLab.Text = "ip地址：";
            // 
            // bandScanNumBtn
            // 
            this.bandScanNumBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bandScanNumBtn.AutoSize = true;
            this.bandScanNumBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bandScanNumBtn.Location = new System.Drawing.Point(188, 174);
            this.bandScanNumBtn.Margin = new System.Windows.Forms.Padding(2);
            this.bandScanNumBtn.Name = "bandScanNumBtn";
            this.bandScanNumBtn.Size = new System.Drawing.Size(89, 25);
            this.bandScanNumBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bandScanNumBtn.TabIndex = 8;
            this.bandScanNumBtn.Text = "频段扫描数";
            this.bandScanNumBtn.Click += new System.EventHandler(this.bandScanNumBtn_Click);
            // 
            // singlePointBtn
            // 
            this.singlePointBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.singlePointBtn.AutoSize = true;
            this.singlePointBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.singlePointBtn.Location = new System.Drawing.Point(46, 174);
            this.singlePointBtn.Margin = new System.Windows.Forms.Padding(2);
            this.singlePointBtn.Name = "singlePointBtn";
            this.singlePointBtn.Size = new System.Drawing.Size(89, 25);
            this.singlePointBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.singlePointBtn.TabIndex = 7;
            this.singlePointBtn.Text = "单频点数据";
            this.singlePointBtn.Click += new System.EventHandler(this.singlePointBtn_Click);
            // 
            // closeReceiverBtn
            // 
            this.closeReceiverBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.closeReceiverBtn.AutoSize = true;
            this.closeReceiverBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.closeReceiverBtn.Location = new System.Drawing.Point(188, 126);
            this.closeReceiverBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeReceiverBtn.Name = "closeReceiverBtn";
            this.closeReceiverBtn.Size = new System.Drawing.Size(89, 25);
            this.closeReceiverBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.closeReceiverBtn.TabIndex = 6;
            this.closeReceiverBtn.Text = "关闭交换机";
            this.closeReceiverBtn.Click += new System.EventHandler(this.closeReceiverBtn_Click);
            // 
            // conReceiverBtn
            // 
            this.conReceiverBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.conReceiverBtn.AutoSize = true;
            this.conReceiverBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.conReceiverBtn.Location = new System.Drawing.Point(46, 126);
            this.conReceiverBtn.Margin = new System.Windows.Forms.Padding(2);
            this.conReceiverBtn.Name = "conReceiverBtn";
            this.conReceiverBtn.Size = new System.Drawing.Size(89, 25);
            this.conReceiverBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.conReceiverBtn.TabIndex = 5;
            this.conReceiverBtn.Text = "连接交换机";
            this.conReceiverBtn.Click += new System.EventHandler(this.conReceiverBtn_Click);
            // 
            // focusFreCheck
            // 
            this.focusFreCheck.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.focusFreCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.focusFreCheck.Location = new System.Drawing.Point(218, 80);
            this.focusFreCheck.Margin = new System.Windows.Forms.Padding(2);
            this.focusFreCheck.Name = "focusFreCheck";
            this.focusFreCheck.Size = new System.Drawing.Size(75, 18);
            this.focusFreCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.focusFreCheck.TabIndex = 4;
            this.focusFreCheck.Text = "焦点频率";
            // 
            // showSignalCheck
            // 
            this.showSignalCheck.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.showSignalCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.showSignalCheck.Location = new System.Drawing.Point(218, 50);
            this.showSignalCheck.Margin = new System.Windows.Forms.Padding(2);
            this.showSignalCheck.Name = "showSignalCheck";
            this.showSignalCheck.Size = new System.Drawing.Size(75, 18);
            this.showSignalCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.showSignalCheck.TabIndex = 3;
            this.showSignalCheck.Text = "信号显示";
            // 
            // freMarkCheck
            // 
            this.freMarkCheck.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.freMarkCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.freMarkCheck.Location = new System.Drawing.Point(218, 15);
            this.freMarkCheck.Margin = new System.Windows.Forms.Padding(2);
            this.freMarkCheck.Name = "freMarkCheck";
            this.freMarkCheck.Size = new System.Drawing.Size(75, 18);
            this.freMarkCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.freMarkCheck.TabIndex = 2;
            this.freMarkCheck.Text = "频率标记";
            // 
            // centerReceivText
            // 
            // 
            // 
            // 
            this.centerReceivText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.centerReceivText.Location = new System.Drawing.Point(86, 74);
            this.centerReceivText.Margin = new System.Windows.Forms.Padding(2);
            this.centerReceivText.Name = "centerReceivText";
            this.centerReceivText.PreventEnterBeep = true;
            this.centerReceivText.Size = new System.Drawing.Size(106, 15);
            this.centerReceivText.TabIndex = 1;
            this.centerReceivText.Text = "100";
            // 
            // centerReceivLab
            // 
            this.centerReceivLab.AutoSize = true;
            this.centerReceivLab.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.centerReceivLab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.centerReceivLab.Location = new System.Drawing.Point(15, 78);
            this.centerReceivLab.Margin = new System.Windows.Forms.Padding(2);
            this.centerReceivLab.Name = "centerReceivLab";
            this.centerReceivLab.Size = new System.Drawing.Size(68, 18);
            this.centerReceivLab.TabIndex = 0;
            this.centerReceivLab.Text = "中心频率：";
            // 
            // imgGPanel
            // 
            this.imgGPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.imgGPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.imgGPanel.Controls.Add(this.widthSignCheck);
            this.imgGPanel.Controls.Add(this.setCenterFreBtn);
            this.imgGPanel.Controls.Add(this.aheadFre40);
            this.imgGPanel.Controls.Add(this.nextFre40);
            this.imgGPanel.Controls.Add(this.loadDataBtn);
            this.imgGPanel.Controls.Add(this.loadDataLab);
            this.imgGPanel.Controls.Add(this.centerText);
            this.imgGPanel.Controls.Add(this.centerLab);
            this.imgGPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.imgGPanel.Location = new System.Drawing.Point(345, 22);
            this.imgGPanel.Margin = new System.Windows.Forms.Padding(2);
            this.imgGPanel.Name = "imgGPanel";
            this.imgGPanel.Size = new System.Drawing.Size(273, 230);
            // 
            // 
            // 
            this.imgGPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.imgGPanel.Style.BackColorGradientAngle = 90;
            this.imgGPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.imgGPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.imgGPanel.Style.BorderBottomWidth = 1;
            this.imgGPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.imgGPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.imgGPanel.Style.BorderLeftWidth = 1;
            this.imgGPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.imgGPanel.Style.BorderRightWidth = 1;
            this.imgGPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.imgGPanel.Style.BorderTopWidth = 1;
            this.imgGPanel.Style.CornerDiameter = 4;
            this.imgGPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.imgGPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.imgGPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.imgGPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.imgGPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.imgGPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.imgGPanel.TabIndex = 1;
            this.imgGPanel.Text = "信号图像";
            // 
            // aheadFre40
            // 
            this.aheadFre40.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aheadFre40.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.aheadFre40.Location = new System.Drawing.Point(49, 128);
            this.aheadFre40.Margin = new System.Windows.Forms.Padding(2);
            this.aheadFre40.Name = "aheadFre40";
            this.aheadFre40.Size = new System.Drawing.Size(56, 18);
            this.aheadFre40.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aheadFre40.TabIndex = 7;
            this.aheadFre40.Text = "上40帧";
            this.aheadFre40.Click += new System.EventHandler(this.aheadFre40_Click);
            // 
            // nextFre40
            // 
            this.nextFre40.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.nextFre40.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.nextFre40.Location = new System.Drawing.Point(162, 121);
            this.nextFre40.Margin = new System.Windows.Forms.Padding(2);
            this.nextFre40.Name = "nextFre40";
            this.nextFre40.Size = new System.Drawing.Size(56, 18);
            this.nextFre40.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.nextFre40.TabIndex = 6;
            this.nextFre40.Text = "下40帧";
            this.nextFre40.Click += new System.EventHandler(this.nextFre40_Click);
            // 
            // loadDataBtn
            // 
            this.loadDataBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.loadDataBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.loadDataBtn.Location = new System.Drawing.Point(92, 66);
            this.loadDataBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loadDataBtn.Name = "loadDataBtn";
            this.loadDataBtn.Size = new System.Drawing.Size(56, 18);
            this.loadDataBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loadDataBtn.TabIndex = 5;
            this.loadDataBtn.Text = "加载数据";
            this.loadDataBtn.Click += new System.EventHandler(this.loadDataBtn_Click);
            // 
            // loadDataLab
            // 
            this.loadDataLab.AutoSize = true;
            this.loadDataLab.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.loadDataLab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.loadDataLab.Location = new System.Drawing.Point(23, 71);
            this.loadDataLab.Margin = new System.Windows.Forms.Padding(2);
            this.loadDataLab.Name = "loadDataLab";
            this.loadDataLab.Size = new System.Drawing.Size(0, 0);
            this.loadDataLab.TabIndex = 4;
            // 
            // centerText
            // 
            // 
            // 
            // 
            this.centerText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.centerText.Location = new System.Drawing.Point(92, 25);
            this.centerText.Margin = new System.Windows.Forms.Padding(2);
            this.centerText.Name = "centerText";
            this.centerText.PreventEnterBeep = true;
            this.centerText.Size = new System.Drawing.Size(75, 15);
            this.centerText.TabIndex = 3;
            this.centerText.Text = "100";
            // 
            // centerLab
            // 
            this.centerLab.AutoSize = true;
            this.centerLab.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.centerLab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.centerLab.Location = new System.Drawing.Point(23, 28);
            this.centerLab.Margin = new System.Windows.Forms.Padding(2);
            this.centerLab.Name = "centerLab";
            this.centerLab.Size = new System.Drawing.Size(68, 18);
            this.centerLab.TabIndex = 2;
            this.centerLab.Text = "中心频率：";
            // 
            // fluoreGPanel
            // 
            this.fluoreGPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.fluoreGPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.fluoreGPanel.Controls.Add(this.setFlowBtn);
            this.fluoreGPanel.Controls.Add(this.flowText);
            this.fluoreGPanel.Controls.Add(this.labelX2);
            this.fluoreGPanel.Controls.Add(this.showDpxBtn);
            this.fluoreGPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.fluoreGPanel.Location = new System.Drawing.Point(633, 22);
            this.fluoreGPanel.Margin = new System.Windows.Forms.Padding(2);
            this.fluoreGPanel.Name = "fluoreGPanel";
            this.fluoreGPanel.Size = new System.Drawing.Size(394, 230);
            // 
            // 
            // 
            this.fluoreGPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fluoreGPanel.Style.BackColorGradientAngle = 90;
            this.fluoreGPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fluoreGPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fluoreGPanel.Style.BorderBottomWidth = 1;
            this.fluoreGPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.fluoreGPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fluoreGPanel.Style.BorderLeftWidth = 1;
            this.fluoreGPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fluoreGPanel.Style.BorderRightWidth = 1;
            this.fluoreGPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fluoreGPanel.Style.BorderTopWidth = 1;
            this.fluoreGPanel.Style.CornerDiameter = 4;
            this.fluoreGPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.fluoreGPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.fluoreGPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.fluoreGPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.fluoreGPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.fluoreGPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fluoreGPanel.TabIndex = 2;
            this.fluoreGPanel.Text = "荧光频谱";
            // 
            // setFlowBtn
            // 
            this.setFlowBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.setFlowBtn.AutoSize = true;
            this.setFlowBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.setFlowBtn.Location = new System.Drawing.Point(230, 93);
            this.setFlowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.setFlowBtn.Name = "setFlowBtn";
            this.setFlowBtn.Size = new System.Drawing.Size(89, 25);
            this.setFlowBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.setFlowBtn.TabIndex = 9;
            this.setFlowBtn.Text = "确定偏移量";
            this.setFlowBtn.Click += new System.EventHandler(this.setFlowBtn_Click);
            // 
            // flowText
            // 
            // 
            // 
            // 
            this.flowText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.flowText.Location = new System.Drawing.Point(151, 102);
            this.flowText.Margin = new System.Windows.Forms.Padding(2);
            this.flowText.Name = "flowText";
            this.flowText.PreventEnterBeep = true;
            this.flowText.Size = new System.Drawing.Size(75, 15);
            this.flowText.TabIndex = 8;
            this.flowText.Text = "0";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(30, 100);
            this.labelX2.Margin = new System.Windows.Forms.Padding(2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(130, 18);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "设置频谱上下偏移量：";
            // 
            // showDpxBtn
            // 
            this.showDpxBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.showDpxBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.showDpxBtn.Location = new System.Drawing.Point(132, 26);
            this.showDpxBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showDpxBtn.Name = "showDpxBtn";
            this.showDpxBtn.Size = new System.Drawing.Size(94, 37);
            this.showDpxBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.showDpxBtn.TabIndex = 6;
            this.showDpxBtn.Text = "显示荧光频谱";
            this.showDpxBtn.Click += new System.EventHandler(this.showDpxBtn_Click);
            // 
            // signalImgBox
            // 
            this.signalImgBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.signalImgBox.Location = new System.Drawing.Point(5, 270);
            this.signalImgBox.Margin = new System.Windows.Forms.Padding(2);
            this.signalImgBox.Name = "signalImgBox";
            this.signalImgBox.Size = new System.Drawing.Size(1660, 400);
            this.signalImgBox.TabIndex = 3;
            this.signalImgBox.TabStop = false;
            // 
            // signalViewBox
            // 
            this.signalViewBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.signalViewBox.Location = new System.Drawing.Point(5, 678);
            this.signalViewBox.Margin = new System.Windows.Forms.Padding(2);
            this.signalViewBox.Name = "signalViewBox";
            this.signalViewBox.Size = new System.Drawing.Size(1660, 329);
            this.signalViewBox.TabIndex = 4;
            this.signalViewBox.TabStop = false;
            // 
            // dpxBox
            // 
            this.dpxBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.dpxBox.Location = new System.Drawing.Point(5, 270);
            this.dpxBox.Margin = new System.Windows.Forms.Padding(2);
            this.dpxBox.Name = "dpxBox";
            this.dpxBox.Size = new System.Drawing.Size(1660, 737);
            this.dpxBox.TabIndex = 5;
            this.dpxBox.TabStop = false;
            // 
            // setCenterFreBtn
            // 
            this.setCenterFreBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.setCenterFreBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.setCenterFreBtn.Location = new System.Drawing.Point(171, 25);
            this.setCenterFreBtn.Margin = new System.Windows.Forms.Padding(2);
            this.setCenterFreBtn.Name = "setCenterFreBtn";
            this.setCenterFreBtn.Size = new System.Drawing.Size(68, 18);
            this.setCenterFreBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.setCenterFreBtn.TabIndex = 8;
            this.setCenterFreBtn.Text = "设置";
            this.setCenterFreBtn.Click += new System.EventHandler(this.setCenterFreBtn_Click);
            // 
            // widthSignCheck
            // 
            this.widthSignCheck.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.widthSignCheck.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.widthSignCheck.Location = new System.Drawing.Point(82, 93);
            this.widthSignCheck.Margin = new System.Windows.Forms.Padding(2);
            this.widthSignCheck.Name = "widthSignCheck";
            this.widthSignCheck.Size = new System.Drawing.Size(136, 18);
            this.widthSignCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.widthSignCheck.TabIndex = 14;
            this.widthSignCheck.Text = "采用带宽标记信号";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 966);
            this.Controls.Add(this.signalViewBox);
            this.Controls.Add(this.signalImgBox);
            this.Controls.Add(this.fluoreGPanel);
            this.Controls.Add(this.imgGPanel);
            this.Controls.Add(this.receivGPanel);
            this.Controls.Add(this.dpxBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrm";
            this.Text = "无线电分析系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.receivGPanel.ResumeLayout(false);
            this.receivGPanel.PerformLayout();
            this.imgGPanel.ResumeLayout(false);
            this.imgGPanel.PerformLayout();
            this.fluoreGPanel.ResumeLayout(false);
            this.fluoreGPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signalImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalViewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpxBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel receivGPanel;
        private DevComponents.DotNetBar.Controls.GroupPanel imgGPanel;
        private DevComponents.DotNetBar.Controls.GroupPanel fluoreGPanel;
        private DevComponents.DotNetBar.ButtonX bandScanNumBtn;
        private DevComponents.DotNetBar.ButtonX singlePointBtn;
        private DevComponents.DotNetBar.ButtonX closeReceiverBtn;
        private DevComponents.DotNetBar.ButtonX conReceiverBtn;
        private DevComponents.DotNetBar.Controls.CheckBoxX focusFreCheck;
        private DevComponents.DotNetBar.Controls.CheckBoxX showSignalCheck;
        private DevComponents.DotNetBar.Controls.CheckBoxX freMarkCheck;
        private DevComponents.DotNetBar.Controls.TextBoxX centerReceivText;
        private DevComponents.DotNetBar.LabelX centerReceivLab;
        private DevComponents.DotNetBar.ButtonX loadDataBtn;
        private DevComponents.DotNetBar.LabelX loadDataLab;
        private DevComponents.DotNetBar.Controls.TextBoxX centerText;
        private DevComponents.DotNetBar.LabelX centerLab;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX switchIpText;
        private DevComponents.DotNetBar.LabelX switchIpLab;
        private System.Windows.Forms.PictureBox signalImgBox;
        private System.Windows.Forms.PictureBox signalViewBox;
        private DevComponents.DotNetBar.ButtonX setFlowBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX flowText;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX showDpxBtn;


        //tianxin
        private System.Windows.Forms.Timer timer_fft;
        private System.Windows.Forms.PictureBox dpxBox;
        private DevComponents.DotNetBar.ButtonX aheadFre40;
        private DevComponents.DotNetBar.ButtonX nextFre40;
        private DevComponents.DotNetBar.Controls.CheckBoxX maxFreKeepCheck;
        private DevComponents.DotNetBar.ButtonX setCenterFreBtn;
        private DevComponents.DotNetBar.Controls.CheckBoxX widthSignCheck;
    }
}

