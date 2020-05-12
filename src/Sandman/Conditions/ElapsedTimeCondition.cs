using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Sandman.Conditions
{
    /// <summary>
    /// A condition that occurs when a specified amount of time elapses
    /// </summary>
    public partial class ElapsedTimeCondition : UserControl, ICondition
    {
        private System.Threading.Timer timer;
        private int quantityValue;
        private int multiplier;

        /// <summary>
        /// Creates a new ElapsedTimeCondition, initializing the UI fields
        /// and the underlying timer
        /// </summary>
        public ElapsedTimeCondition()
        {
            InitializeComponent();

            elapsedUnitComboBox.SelectedIndex = 0;
            quantityValue = Int32.Parse(elapsedNumberTextBox.Text);

            timer = new System.Threading.Timer(new TimerCallback(Tick));
        }

        /// <summary>
        /// Invoked when the timer ticks -- meaning the condition (time) is reached
        /// </summary>
        private void Tick(object stateInfo)
        {
            StopMonitoring();

            if (ConditionOccurred != null)
                ConditionOccurred(this, null);
        }

        /// <summary>
        /// Returns the selected amount of elapsed time for this condition
        /// </summary>
        public int ElapsedTime
        {
            get
            {
                return quantityValue * 1000 * 60 * multiplier;
            }
        }

        /// <summary>
        /// Event handler for KeyDown to only allow digits
        /// </summary>
        private void elapsedNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = !Char.IsDigit((char)e.KeyValue);
        }

        /// <summary>
        /// Changes the multiplier for the specified elapsed time based
        /// on hours or minutes selected for units.
        /// </summary>
        private void elapsedUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (elapsedUnitComboBox.SelectedIndex == 1) multiplier = 60;
            else  multiplier = 1;
        }

        /// <summary>
        /// Updates the integer representation of elapsed hours/minutes selected
        /// </summary>
        private void elapsedNumberTextBox_Leave(object sender, EventArgs e)
        {
            quantityValue = Int32.Parse(elapsedNumberTextBox.Text);
        }


        #region Condition Members

        public event EventHandler ConditionOccurred;

        /// <summary>
        /// Starts monitoring by enabling the timer for the specified amount of time
        /// </summary>
        public void StartMonitoring()
        {
            if( ElapsedTime > 0 )
                timer.Change(ElapsedTime, System.Threading.Timeout.Infinite);
            else
                throw new ArgumentException("Time must be in the future");
        }

        /// <summary>
        /// Stops monitoring by disabling the timer
        /// </summary>
        public void StopMonitoring()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Returns the Condition casted as a UserControl for UI manipulation
        /// </summary>
        public UserControl VisualControl
        {
            get { return (UserControl)this; }
        }

        /// <summary>
        /// Returns the description string used in the selection UI
        /// </summary>
        public string Description
        {
            get { return "Based on elapsed time"; }
        }

        #endregion
    }

}
