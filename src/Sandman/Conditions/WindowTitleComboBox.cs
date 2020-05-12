using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ManagedWinapi.Windows;

namespace Sandman
{
    /// <summary>
    /// A ComboBox subclass specifically for selecting a current active window
    /// </summary>
    public partial class WindowTitleComboBox : ComboBox
    {
        /// <summary>
        /// Creates a new WindowTitleComboBox, adding an event handler for the
        /// Format event
        /// </summary>
        public WindowTitleComboBox() : base()
        {
            this.Format += new ListControlConvertEventHandler(WindowTitleComboBox_Format);
            Refresh();
        }

        /// <summary>
        /// Event handler called to format each item to be displayed
        /// </summary>
        void WindowTitleComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            SystemWindow win = ((SystemWindow)e.ListItem);

            string s = string.Format("[{0:00000000}] {1}", win.HWnd, win.Title);

            e.Value = s;
        }

        /// <summary>
        /// Refreshes list of window titles by requerying list of top-level windows
        /// </summary>
        public void RefreshWindowTitles()
        {
            this.DataSource = SystemWindow.FilterToplevelWindows(FilterWindows);
        }

        /// <summary>
        /// Filters windows by looking for visible, non-empty titles,
        /// and excluding the task manager.
        /// </summary>
        /// <param name="win"></param>
        /// <returns></returns>
        private bool FilterWindows(SystemWindow win)
        {
            if (win.Visible && win.HWnd != this.TopLevelControl.Handle &&
                win.Title != "" && win.ClassName != "Progman")
            {
                return true;
            }
            else return false;
        }

    }
}
