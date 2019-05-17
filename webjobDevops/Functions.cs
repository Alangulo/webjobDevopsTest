using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace webjobDevops
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
       /* public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }*/

        public static void DownloadStatsFile([TimerTrigger("0 * * * * *", RunOnStartup = true)] TimerInfo timerInfo, TextWriter log)
        {
            log.WriteLine("Stats Downloader has started.");
        }
    }
}
