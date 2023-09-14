using System;
using System.Diagnostics;
using System.IO;

namespace TPP.Laboratory.Concurrency.Lab09 {
    /// <summary>
    /// Clase ProcessThreadDemo
    /// </summary>
    class ProcessThreadDemo {
        /// <summary>
        /// Método ShowProcesses
        /// </summary>
        /// <param name="process"></param>
        /// <param name="output"></param>
        private void ShowProcesses(Process[] process, TextWriter output) {
            foreach (Process proc in process) {
                output.WriteLine("- PID: {0}\tName: {1}\tVirtual memory: {2:N} MB",
                        proc.Id, proc.ProcessName, proc.VirtualMemorySize64 / 1024.0 / 1024
                        );
            }
        }

        /// <summary>
        /// Método ShowProcess
        /// </summary>
        /// <param name="process"></param>
        /// <param name="output"></param>
        /// <param name="showMemory"></param>
        private void ShowProcess(Process process, TextWriter output, bool showMemory) {
            output.Write("- PID: {0}\tName: {1}", process.Id, process.ProcessName);
            if (showMemory)
                output.Write("\tVirtual memory: {2:N} MB",process.VirtualMemorySize64 / 1024.0 / 1024);
            output.WriteLine(".");
        }

        /// <summary>
        /// Método ShowThreads
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="output"></param>
        private void ShowThreads(ProcessThreadCollection collection, TextWriter output) {
            foreach (ProcessThread thread in collection) 
                output.WriteLine("\t- ThreadId: {0}\tPriority: {1}\tState: {2}.",
                    thread.Id, thread.CurrentPriority, thread.ThreadState);
        }

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main() {
            ProcessThreadDemo demo = new ProcessThreadDemo();
            var processes = Process.GetProcesses();

            TextWriter outFile = new StreamWriter("output.txt");
            demo.ShowProcesses(processes, outFile);
            
            Console.Write("Press enter to continue... ");
            Console.ReadLine();

            foreach (var process in processes) {
                demo.ShowProcess(process, outFile, false);
                demo.ShowThreads(process.Threads, outFile);
            }

            outFile.Close();
        }
    }
}
