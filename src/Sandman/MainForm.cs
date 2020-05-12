using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Org.Mentalis.Utilities;
using ManagedWinapi.Windows;

namespace Sandman
{
    public partial class MainForm : Form
    {
        private ICondition[] conditions;
        private ICondition waitingOnCondition;
        private RestartOptions selectedAction;
        private EventHandler actionHandler;

        private EventHandler immediateMenuEventHandler;

        /// <summary>
        /// Creates the MainForm object, and initializes the user interface
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Handler if any condition occurs
            actionHandler = new EventHandler(ReadyForAction);

            InitializeConditions();

            // Load list of restart actions to Action combo box
            actionComboBox.DataSource = Enum.GetValues(typeof(RestartOptions));
            actionComboBox.SelectedIndex = 0;

            // Initialize menu
            immediateMenuEventHandler = new EventHandler(immediateMenuItem_Click);
            ToolStripMenuItem item;
            foreach (RestartOptions option in Enum.GetValues(typeof(RestartOptions)))
            {
                item = new ToolStripMenuItem(option.ToString());
                item.Tag = option;

                immediateToolStripMenuItem.DropDownItems.Add(item);
                item.Click += immediateMenuEventHandler;
            }
        }

        /// <summary>
        /// Dynamically creates Condition objects, initializes them
        /// based on the containing form, and adds the ReadyForAction method
        /// (referenced in the actionHandler delegate) as a handler
        /// for the ConditionOccurred event.
        /// </summary>
        private void InitializeConditions()
        {
            // Create new Conditions
            conditions = new ICondition[4];
            conditions[0] = null;
            conditions[1] = new Conditions.ActualTimeCondition();
            conditions[2] = new Conditions.ElapsedTimeCondition();
            conditions[3] = new Conditions.WindowBasedCondition();

            // Initialize and add condition to the UI
            foreach (ICondition c in conditions)
            {
                if (c == null)
                {
                    conditionComboBox.Items.Add("None");
                }
                else
                {
                    conditionComboBox.Items.Add(c.Description);
                    c.ConditionOccurred += actionHandler;
                    c.VisualControl.Left = 6;
                    c.VisualControl.Top = 19;
                    c.VisualControl.Visible = false;
                    conditionPanel.Controls.Add(c.VisualControl);
                }
            }

            // Selects first option ("None")
            conditionComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for Immediate menu option --
        /// triggers power management event without condition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void immediateMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            WindowsController.ExitWindows((RestartOptions)(item.Tag), true);
        }

        /// <summary>
        /// Event handler invoked when condition occurs
        /// </summary>
        private void ReadyForAction(object sender, EventArgs e)
        {
            // Events from the Timer thread cannot interact with UI controls
            if (InvokeRequired)
            {
                Invoke(actionHandler, new object[] { sender, e });
                return;
            }

            TakeAction();
        }

        /// <summary>
        /// Invoked based on condition or 10-second timer.  Displays
        /// tooltip, then performs specified action if not cancelled.
        /// </summary>
        private void TakeAction()
        {
            string action = selectedAction.ToString();

            // If timer ticks with Disabled checked, it is immediate action
            if (waitingOnCondition == null)
            {
                timeBasedTimer.Stop();
                appNotifyIcon.Visible = false;
                appNotifyIcon.Visible = true;

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show("In debug mode: Action not taken");
                }
                else
                {
                    WindowsController.ExitWindows(selectedAction, false);
                }
            }
            // Otherwise, provide ten second warning
            else
            {
                waitingOnCondition.StopMonitoring();
                conditionComboBox.SelectedIndex = 0;

                appNotifyIcon.BalloonTipText = "The system will " + action + " in ten seconds.  Click to cancel.";
                appNotifyIcon.ShowBalloonTip(10);

                timeBasedTimer.Interval = 10000;
                timeBasedTimer.Start();
            }
        }

        /// <summary>
        /// Event handler invoked when user double-clicks application notification icon
        /// </summary>
        private void appNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Prevent events while viewing settings
            if( waitingOnCondition != null )
                waitingOnCondition.StopMonitoring();
            
            this.Show();
            this.BringToFront();
        }

        /// <summary>
        /// Event handler invoked when user click Quit in menu
        /// </summary>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Confirm quit -- system won't sleep/shutdown if exited...
            if (waitingOnCondition != null)
            {
                if( MessageBox.Show(
                    "You have specified an action to take.  If you quit, this will not take place.  Are you sure?",
                    "Quit Sandman?",
                    MessageBoxButtons.YesNo) == DialogResult.No )
                    return;
            }

            // If user clicked Yes or no action was specified, just quit now
            this.appNotifyIcon.Visible = false;
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Invoked when user click OK in settings form.  Starts monitoring
        /// and hides the form.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (waitingOnCondition != null)
            {
                try
                {
                    waitingOnCondition.StartMonitoring();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error trying to set the condition: " + ex.Message);
                    return;
                }
            }

            // After setting options, hide the form
            this.Hide();
        }

        /// <summary>
        /// Event handler invoked when user clicks Options in app notify menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        /// <summary>
        /// Event handler invoked when user clicks the balloon tip --
        /// used to cancel a pending action.
        /// </summary>
        private void appNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            string action = selectedAction.ToString();

            timeBasedTimer.Stop();
        }

        /// <summary>
        /// Updates selected action when user changes value in ComboBox
        /// </summary>
        private void actionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedAction = (RestartOptions)actionComboBox.SelectedValue;
        }

        /// <summary>
        /// Updates currently displayed condition based on conditionComboBox.
        /// Sets Visible property on the underlying VisualControl property of
        /// the Condition object.
        /// </summary>
        private void conditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( waitingOnCondition != null )
                waitingOnCondition.VisualControl.Visible = false;
            
            waitingOnCondition = (ICondition)conditions[conditionComboBox.SelectedIndex];
            
            if (waitingOnCondition != null)
                waitingOnCondition.VisualControl.Visible = true;

        }

    }
}
