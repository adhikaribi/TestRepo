using System;
using System.Collections.Generic;

namespace Utitlity.BusinessLogic {
    /*
    Author : Bibek Adhikari
    Date : 02/03/2017
    Description : UtilityAtk for core business logic handling of modules
    */
   public class IntercomUpdate : IModule {

       private static string _moduleName = "IntercomUpdate";
       private static string _description = "IntercomUpdate does all the updates";
       public IntercomUpdate(){
       }
        public string Name
        {
            get
            {
                return _moduleName;
            }
        }

        // TODO : Is this the actual method to run or Run is in the interface itself ?
        public void Run(){

        }

        public List<string> Parameters
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }
    }
}