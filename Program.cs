using System;
using System.IO;
using HazelScript.Exceptions;
using HazelScript.Lang;
using System.Diagnostics;

namespace HazelScript;

public class Program {
    public static void Main(string[] args)
    {
        bool showElapsedMilliseconds = false;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if(args.Length >= 1){
            switch(args[0]){
                case "run":
                    if(args.Length == 1){
                        Console.WriteLine("You must specify a script to run");
                    } else {
                        string[] getScripts(string[] arr){
                            string[] newArray = {};
                            foreach(string s in arr){
                                if(s != "run") newArray = newArray.Prepend<String>(s).ToArray<String>();
                            }
                            return newArray;
                        }
                        string[] scripts = getScripts(args);
                        foreach(string script in scripts)
                        {
                            if(!File.Exists(script)){
                                throw InterpreterExceptions.FileNotFoundException(script);
                            }
                            if(!script.EndsWith(".hzl")){
                                throw InterpreterExceptions.FileTypeException(script);
                            }
                            CodeReader Script = new CodeReader(script);
                            Script.ReadPreamble(Script.SeparateLines());
                            Script.ReadCode(Script.SeparateLines());
                            ExceptionManager.ThrowExceptions();
                        }
                        showElapsedMilliseconds = true;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        else if(args.Length == 0){
            Console.WriteLine("HazelScript 0.1.0 (2023.1114.0) by Hazel Rojas");
        }
        stopwatch.Stop();
        if(showElapsedMilliseconds == true){
            Console.WriteLine("Code interpretation performed " + stopwatch.ElapsedMilliseconds + " milliseconds");
        }
    }
}