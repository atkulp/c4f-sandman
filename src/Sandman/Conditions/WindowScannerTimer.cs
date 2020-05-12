using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using ManagedWinapi.Windows;

namespace Sandman
{
    /// <summary>
    /// Enumeration to represent different window scanning modes
    /// </summary>
    public enum WindowScannerMode
    {
        /// <summary>
        /// True when window with given title appears
        /// </summary>
        WINDOW_APPEARS,
        /// <summary>
        /// True when specified window disappears
        /// </summary>
        WINDOW_DISAPPEARS,
        /// <summary>
        /// True when specified window's title contains given text
        /// </summary>
        TITLE_CONTAINS,
        /// <summary>
        /// True when specified window's title does not contain given text
        /// </summary>
        TITLE_DOES_NOT_CONTAIN,
        /// <summary>
        /// True when specified window's title changes
        /// </summary>
        TITLE_CHANGES
    }

    /// <summary>
    /// Timer that periodically scans window for selected condition
    /// </summary>
    public class WindowScannerTimer
    {
        private Timer timer;
        private WindowScannerMode _mode;
        private SystemWindow _win;
        private string _title;

        public event EventHandler WindowScannerEvent;

        public WindowScannerTimer()
        {
            timer = new Timer(new TimerCallback(Tick));
        }

        /// <summary>
        /// Starts monitoring in five seconds (not immediate to allow chance
        /// to cancel)
        /// </summary>
        /// <param name="mode">Specifies the scanning mode</param>
        /// <param name="win">The window of interest (when needed)</param>
        /// <param name="title">The comparison string (when needed)</param>
        public void StartMonitoring(WindowScannerMode mode, SystemWindow win, string title)
        {
            _mode = mode;
            _win = win;

            // Changes is the same as DOES_NOT_EQUAL, except it compares
            // to the current title value.
            if (_mode == WindowScannerMode.TITLE_CHANGES) _title = win.Title;
            else _title = title;

            timer.Change(5000, 1000);
        }

        /// <summary>
        /// Stops monitoring for window conditions
        /// </summary>
        public void StopMonitoring()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Invoked every five seconds to see if window condition is true
        /// </summary>
        /// <param name="stateInfo">not used</param>
        private void Tick(object stateInfo)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);

            // If a window matched the criteria...
            if (CheckCondition())
            {
                // Make sure there is a listener
                if (WindowScannerEvent != null) WindowScannerEvent(this, null);
            }
            // Re-enable if necessary...
            else timer.Change(1000, 1000);
        }

        /// <summary>
        /// Performs the actual window iteration to see if the specified condition is true
        /// </summary>
        /// <param name="windows">Collection of all current windows</param>
        /// <returns>whether or not the specified condition is true</returns>
        private bool CheckCondition()
        {
            switch (_mode)
            {
                case WindowScannerMode.WINDOW_APPEARS:
                    foreach (SystemWindow win in SystemWindow.AllToplevelWindows)
                    {
                        if (win.Title == _title) return true;
                    }
                    break;

                case WindowScannerMode.TITLE_DOES_NOT_CONTAIN:
                    if (_win.Title.IndexOf(_title) == -1) return true;
                    break;

                case WindowScannerMode.TITLE_CHANGES:
                    if (_win.Title != _title) return true;
                    break;

                case WindowScannerMode.WINDOW_DISAPPEARS:
                    if (_win.Visible == false && _win.Title == "" && _win.ClassName == "") return true;
                    break;

                case WindowScannerMode.TITLE_CONTAINS:
                    if (_win.Title.IndexOf(_title) > -1) return true;
                    break;
            }

            return false;
        }
    }
}
