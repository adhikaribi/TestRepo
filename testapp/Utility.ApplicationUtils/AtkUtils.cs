using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utility.Applicationutils {
    /*
    Author : Bibek Adhikari
    Date : 02/03/2017
    Description : AtkUtils for common Utility Routines for Utility Module Application
    */
     public static class AtkUtils {
         
        // TODO : We may or may not need this
        //  public static string GetModuleNameFromConfiguration {
        //    get {
        //         var moduleName = ConfigurationManager.AppSettings["modulename"]?.ToString();
        //         return moduleName;
        //      }
        //  }

         // TODO : May be later we Use Unity IoC for getting / creating instances
         public static object  GetInstance(string moduleName){
            if(!Regex.IsMatch(moduleName, "Utility.BusinessLogic.*"))
                moduleName = $"Utility.BusinessLogic.{moduleName}";
            Type type = Type.GetType(moduleName);
            if (type != null){
                // send in the parameters required for it, for now no need since we have nothing on class constructors
               return Activator.CreateInstance(type);
            }    
            return null;              
         }

         public static IEnumerable<string>  GetAllModules(){
            // Search all classes under Utility.BusinessLogic namespace
            //var listOfAssemblies = Assembly.GetExecutingAssembly().GetTypes();
            var allModules = Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace == "Utility.BusinessLogic").Select( typ => typ.FullName)
                      .ToList();   
            return allModules;         
         }
     }
}