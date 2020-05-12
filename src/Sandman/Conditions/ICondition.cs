using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sandman
{
    /// <summary>
    /// Interface defining the contract to which any condition must adhere
    /// </summary>
    interface ICondition
    {
        event EventHandler ConditionOccurred;
        void StopMonitoring();
        void StartMonitoring();

        UserControl VisualControl { get;  }
        string Description  { get;  }
    }
}
