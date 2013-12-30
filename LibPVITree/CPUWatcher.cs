using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Broker
{
    public partial class CPUWatcher : Component
    {
        public CPUWatcher()
        {
            InitializeComponent();
        }

        public CPUWatcher(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
