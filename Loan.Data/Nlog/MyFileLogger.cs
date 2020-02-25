using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Loan.Data.Nlog
{
 public   class MyFileLogger: NLog.Targets.TargetWithLayout

    {
        [Target("MyFirst")]
        public sealed class MyFirstTarget : TargetWithLayout
        {
            public MyFirstTarget()
            {
                this.Host = "localhost";
            }

            [RequiredParameter]
            public string Host { get; set; }

            protected override void Write(LogEventInfo logEvent)
            {
                string logMessage = this.Layout.Render(logEvent);

                SendTheMessageToRemoteHost(this.Host, logMessage);
            }

            private void SendTheMessageToRemoteHost(string host, string message)
            {
                // TODO - write me 
            }
        }
    }

}

