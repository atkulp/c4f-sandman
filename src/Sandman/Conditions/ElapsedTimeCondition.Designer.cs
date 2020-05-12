namespace Sandman.Conditions
{
    partial class ElapsedTimeCondition
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.elapsedUnitComboBox = new System.Windows.Forms.ComboBox();
            this.elapsedNumberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Take action in";
            // 
            // elapsedUnitComboBox
            // 
            this.elapsedUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elapsedUnitComboBox.FormattingEnabled = true;
            this.elapsedUnitComboBox.Items.AddRange(new object[] {
            "Minute(s)",
            "Hour(s)"});
            this.elapsedUnitComboBox.Location = new System.Drawing.Point(131, 0);
            this.elapsedUnitComboBox.Name = "elapsedUnitComboBox";
            this.elapsedUnitComboBox.Size = new System.Drawing.Size(80, 21);
            this.elapsedUnitComboBox.TabIndex = 2;
            this.elapsedUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.elapsedUnitComboBox_SelectedIndexChanged);
            // 
            // elapsedNumberTextBox
            // 
            this.elapsedNumberTextBox.Location = new System.Drawing.Point(82, 0);
            this.elapsedNumberTextBox.MaxLength = 3;
            this.elapsedNumberTextBox.Name = "elapsedNumberTextBox";
            this.elapsedNumberTextBox.Size = new System.Drawing.Size(43, 20);
            this.elapsedNumberTextBox.TabIndex = 1;
            this.elapsedNumberTextBox.Text = "1";
            this.elapsedNumberTextBox.Leave += new System.EventHandler(this.elapsedNumberTextBox_Leave);
            this.elapsedNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.elapsedNumberTextBox_KeyDown);
            // 
            // ElapsedTimeCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elapsedUnitComboBox);
            this.Controls.Add(this.elapsedNumberTextBox);
            this.Name = "ElapsedTimeCondition";
            this.Size = new System.Drawing.Size(215, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox elapsedUnitComboBox;
        private System.Windows.Forms.TextBox elapsedNumberTextBox;
    }
}
