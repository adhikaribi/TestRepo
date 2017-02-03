/*
    Author : Bibek Adhikari
    Date : 02/03/2017
    Description : IModule interface for abstraction of all the modules
*/
using System.Collections.Generic;
public interface IModule {

    string Name { get; }
    // TODO : Is it a List of Parameters for module invocation ?
    List<string> Parameters { get; set;}
    // 
    string Description { get; } 
    // TODO : May be required to add some functions, after the code analysis
    void Run();
}