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
    /// Used to specift a specific time/date as a condition
    /// </summary>
    public partial class ActualTimeCondition : UserControl, ICondition
    {
        private System.Threading.Timer timer;
        private DateTime date;
        private TimeSpan time;

        /// <summary>
        /// Creates a new ActualTimeCondition, initializes the time/date and creates a timer
        /// </summary>
        public ActualTimeCondition()
        {
            InitializeComponent();

            date = datePicker.Value.Date;
            time = timePicker.Value.TimeOfDay;

            timer = new System.Threading.Timer(new TimerCallback(Tick));
        }

        /// <summary>
        /// Event handler for timer, when enabled.
        /// Only fires when time is reached, therefore condition is true.
        /// </summary>
        /// <param name="stateInfo">not used</param>
        private void Tick(object stateInfo)
        {
            StopMonitoring();

            if (ConditionOccurred != null)
                ConditionOccurred(this, null);
        }

        /// <summary>
        /// Determines time to wait from now to selected date/time
        /// </summary>
        public int RelateTimeFromNow
        {
            get
            {
                TimeSpan ts = this.ActualTime.Subtract(DateTime.Now);
                return (int)ts.TotalMilliseconds;
            }
        }

        /// <summary>
        /// Returns the selected date/time by combining the two selected values
        /// </summary>
        public DateTime ActualTime
        {
            get
            {
                return date.Add(time);
            }
        }

        /// <summary>
        /// Updated Time property based on TimePicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            time = timePicker.Value.TimeOfDay;
        }

        /// <summary>
        /// Updates Date property based on DatePicker
        /// </summary>
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            date = datePicker.Value.Date;
        }


        #region Condition Members

        public event EventHandler ConditionOccurred;

        /// <summary>
        /// Starts monitoring by enabling a timer based on select date/time
        /// </summary>
        public void StartMonitoring()
        {
            if (RelateTimeFromNow > 0)
                timer.Change(RelateTimeFromNow, System.Threading.Timeout.Infinite);
            else throw new ArgumentException("Time must be in the future");
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
            get { return "Based on a specific time"; }
        }

        #endregion
    }
}
