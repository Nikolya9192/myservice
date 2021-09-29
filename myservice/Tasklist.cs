using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MSOservice
{
    class Tasklist
    {
       
            enum NameProc
            {
                mshearts,
                freecell,
                sol,
                PINBALL,
                spider,
                winmine
            }

        
        public void KillRunningProcesses()
        {
            
            List<string> localProcByName = new List<string>();

            localProcByName.Add(NameProc.freecell.ToString());
            localProcByName.Add(NameProc.mshearts.ToString());
            localProcByName.Add(NameProc.PINBALL.ToString());
            localProcByName.Add(NameProc.sol.ToString());
            localProcByName.Add(NameProc.spider.ToString());
            localProcByName.Add(NameProc.winmine.ToString());

            //localProcByName.Add("freecell.exe");
            //localProcByName.Add("mshearts.exe");
            //localProcByName.Add("PINBALL.exe");
            //localProcByName.Add("sol.exe");
            //localProcByName.Add("spider.exe");
            //localProcByName.Add("winmine.exe");

            // Get all instances of Notepad running on the local 
            // computer.
            //Process[] localProc = null;
            foreach (string s in localProcByName)
            {
                //localProc = Process.GetProcessesByName(s);

                var Processes = Process.GetProcesses().
                                 Where(pr => pr.ProcessName == s);

                foreach (var process in Processes)
                {
                    process.Kill();
                }
            }

            //List<Process> listProcessInMemo = new List<Process>(localProc);
            //return listProcessInMemo;

            
                                  
        }

        public void TaskillProc(List<Process> listProcess)
        {

            
        }
    }
}
