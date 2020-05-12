using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ManagedWinapi.Windows;

namespace Sandman.Conditions
{
    public partial class WindowBasedCondition : UserControl, ICondition
    {
        private WindowScannerTimer scanner;

        private WindowScannerMode selectedMode;
        private string title;
        private SystemWindow win;

        /// <summary>
        /// Creates a new WindowBasedCondition, populates the Condition ComboBox based
        /// on the WindowScannerMode enumerated values, and sets up the scanner timer.
        /// </summary>
        public WindowBasedCondition()
        {
            InitializeComponent();

            conditionComboBox.DataSource = Enum.GetValues(typeof(WindowScannerMode));

            scanner = new WindowScannerTimer();
            scanner.WindowScannerEvent += new EventHandler(scanner_WindowScannerEvent);

        }

        /// <summary>
        /// Returns the current scanning mode selected (TITLE_CHANGES, WINDOW_APPEARS)
        /// </summary>
        public WindowScannerMode SelectedMode
        {
            get { return selectedMode; }
        }

        /// <summary>
        /// Returns the title (sub)string entered in the text box.
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// Returns the select SystemWindow object
        /// </summary>
        public SystemWindow SelectedWindow
        {
            get { return win; }
        }

        /// <summary>
        /// Handler for the underlying scanner object's WindowScannerEvent.
        /// Raises ConditionOccurred event to indicate condition is true.
        /// </summary>
        void scanner_WindowScannerEvent(object sender, EventArgs e)
        {
            if (ConditionOccurred != null)
                ConditionOccurred(this, null);
        }

        /// <summary>
        /// Scans current system windows and updates the combox box
        /// </summary>
        public void RefreshWindowTitles()
        {
            windowComboBox.RefreshWindowTitles();
        }

        /// <summary>
        /// Event handler for Refresh button
        /// </summary>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            windowComboBox.RefreshWindowTitles();
        }

        /// <summary>
        /// Event handler for SelectedValueChanged event of windowComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            win = (SystemWindow)windowComboBox.SelectedValue;
        }

        /// <summary>
        /// Event handler for conditionComboBox SelectedValueChanged event.  Disabled/enables
        /// the text box and shows/hides the "Ignored" label.
        /// </summary>
        private void conditionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (conditionComboBox.SelectedItem != null)
            {
                selectedMode = (WindowScannerMode)conditionComboBox.SelectedItem;
                
                if (selectedMode == WindowScannerMode.WINDOW_DISAPPEARS ||
                    selectedMode == WindowScannerMode.TITLE_CHANGES)
                {
                    ignoredLabel.Visible = true;
                    titleTextBox.Enabled = false;
                }
                else
                {
                    ignoredLabel.Visible = false;
                    titleTextBox.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Updates Title property when user leaves titleTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleTextBox_Leave(object sender, EventArgs e)
        {
            title = titleTextBox.Text;
        }

        /// <summary>
        /// Refreshes window list when this UserControl appears
        /// </summary>
        private void WindowBasedCondition_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshWindowTitles();
            }
        }

#region Condition Members

        public event EventHandler ConditionOccurred;

        /// <summary>
        /// Instructs the underlying WindowScannerTimer to start monitoring
        /// </summary>
        public void StartMonitoring()
        {
            //TODO: Throw ArgumentException if not valid choices
            scanner.StartMonitoring(SelectedMode, SelectedWindow, Title);
        }

        /// <summary>
        /// Instructs the underlying WindowScannerTimer to stop monitoring
        /// </summary>
        public void StopMonitoring()
        {
            scanner.StopMonitoring();
        }

        /// <summary>
        /// Returns this object cast as a UserControl for UI manipulation
        /// </summary>
        public UserControl VisualControl
        {
            get { return (UserControl)this; }
        }

        /// <summary>
        /// Returns a description of this condition for display to the user
        /// </summary>
        public string Description
        {
            get { return "Based on a window"; }
        }

        #endregion
    }
}
