using System;
using System.Threading.Tasks;
using Utility.Applicationutils;
using Utitlity.BusinessLogic;

namespace ConsoleApplication
{
    /*
    Author : Bibek Adhikari
    Date : 02/03/2017
    Description : Console Gui for Utility Module Application
    */
    public class Program
    {
        public static void Main(string[] args)
        {
            // Main Application Entry Point
            // Check if the command line arguments exists or else move with console gui
            // LogTo.Information("Application Started..");
            // Log.Time(nameof(Main))
            Console.WriteLine("Starting the application..");

            if(args.Length > 0){
                // Get parameters from args
                var paramArg = args[0];
                
            }else {
                string infoText = $"Listing all the available modules..";
                Console.WriteLine(infoText);
                // If user inserts one, just display the available modules.
                // display, get list of all available modules
                var lists = AtkUtils.GetAllModules();
                foreach(var item in lists) 
                    Console.WriteLine(item);

                string moduleName = string.Empty;
                    Console.Write("Enter the module name : ");
                    moduleName = Console.ReadLine();
                    // Check if the given module exists
                    Console.WriteLine("Do you want to schedule this module's task, Y or N ?");
                    var readChar = Console.ReadKey();
                    if(readChar.KeyChar == 'Y'){
                         Console.WriteLine("This module's task is now scheduled to run everyday at 10 am !!!");
                         JobScheduler.ScheduleJob(moduleName);
                    }
                    else{
                        Console.WriteLine($"Running the task from {moduleName} module..");
                        // LogTo.Information($"Running the {moduleName} module");
                        // Invoke the required module here
                        Task.Run(() => ((IModule)AtkUtils.GetInstance(moduleName))?.Run());
                    }      
            }
        }

        private void RunModule(){

        }
    }
}
