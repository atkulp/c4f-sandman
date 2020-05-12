namespace Sandman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sysTrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.immediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.actionLabel = new System.Windows.Forms.Label();
            this.timeBasedTimer = new System.Windows.Forms.Timer(this.components);
            this.conditionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.conditionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.conditionPanel = new System.Windows.Forms.Panel();
            this.sysTrayMenuStrip.SuspendLayout();
            this.conditionSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysTrayMenuStrip
            // 
            this.sysTrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.immediateToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.sysTrayMenuStrip.Name = "trayToolStripMenuItem";
            this.sysTrayMenuStrip.Size = new System.Drawing.Size(125, 76);
            this.sysTrayMenuStrip.Text = "Tray";
            // 
            // immediateToolStripMenuItem
            // 
            this.immediateToolStripMenuItem.Name = "immediateToolStripMenuItem";
            this.immediateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.immediateToolStripMenuItem.Text = "Immediate";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.appNotifyIcon.BalloonTipTitle = "Sandman";
            this.appNotifyIcon.ContextMenuStrip = this.sysTrayMenuStrip;
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Text = "Sandman ";
            this.appNotifyIcon.Visible = true;
            this.appNotifyIcon.BalloonTipClicked += new System.EventHandler(this.appNotifyIcon_BalloonTipClicked);
            this.appNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.appNotifyIcon_MouseDoubleClick);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Location = new System.Drawing.Point(143, 272);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // actionComboBox
            // 
            this.actionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(94, 241);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(174, 22);
            this.actionComboBox.TabIndex = 4;
            this.actionComboBox.SelectedValueChanged += new System.EventHandler(this.actionComboBox_SelectedValueChanged);
            // 
            // actionLabel
            // 
            this.actionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(15, 245);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(73, 14);
            this.actionLabel.TabIndex = 3;
            this.actionLabel.Text = "Action to take";
            // 
            // timeBasedTimer
            // 
            this.timeBasedTimer.Tick += new System.EventHandler(this.ReadyForAction);
            // 
            // conditionSettingsGroupBox
            // 
            this.conditionSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionSettingsGroupBox.Controls.Add(this.conditionPanel);
            this.conditionSettingsGroupBox.Location = new System.Drawing.Point(12, 34);
            this.conditionSettingsGroupBox.Name = "conditionSettingsGroupBox";
            this.conditionSettingsGroupBox.Size = new System.Drawing.Size(329, 191);
            this.conditionSettingsGroupBox.TabIndex = 2;
            this.conditionSettingsGroupBox.TabStop = false;
            // 
            // conditionComboBox
            // 
            this.conditionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conditionComboBox.FormattingEnabled = true;
            this.conditionComboBox.Location = new System.Drawing.Point(72, 6);
            this.conditionComboBox.Name = "conditionComboBox";
            this.conditionComboBox.Size = new System.Drawing.Size(274, 22);
            this.conditionComboBox.TabIndex = 1;
            this.conditionComboBox.SelectedIndexChanged += new System.EventHandler(this.conditionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Condition";
            // 
            // conditionPanel
            // 
            this.conditionPanel.AutoScroll = true;
            this.conditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionPanel.Location = new System.Drawing.Point(3, 16);
            this.conditionPanel.Name = "conditionPanel";
            this.conditionPanel.Size = new System.Drawing.Size(323, 172);
            this.conditionPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 309);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conditionComboBox);
            this.Controls.Add(this.conditionSettingsGroupBox);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Sandman Options";
            this.sysTrayMenuStrip.ResumeLayout(false);
            this.conditionSettingsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip sysTrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem immediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Timer timeBasedTimer;
        private System.Windows.Forms.GroupBox conditionSettingsGroupBox;
        private System.Windows.Forms.ComboBox conditionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel conditionPanel;
    }
}