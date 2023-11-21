using System;

namespace HazelScript.Lang;

public class PreambleBlock {
    string[] preambles = {};
    public static string[] imports = {};
    public static string[] importsRefs = {};
    public PreambleBlock(string[] preambles){
        this.preambles = preambles;
    }
    public void ReadLines(string[] preambles){
        for(int i = 0; i < preambles.Length; i++){
            preambles[i] = preambles[i].Trim().Replace("\t", "");
            if(preambles[i].StartsWith("import")){
                string[] arguments = preambles[i].Split(" ");
                string library = arguments[1];
                string[] libraryDirections = library.Split(
                    new char[] {':','/'}
                );
                string libraryPath = Environment.CurrentDirectory;
                foreach (var direction in libraryDirections)
                {
                    libraryPath += '\\' + direction;
                }
                libraryPath += ".hzl";
                imports[imports.Length] = libraryPath;
                if(arguments.Length == 4){
                    if(arguments[2] == "as"){
                        importsRefs[imports.Length] = arguments[3];
                    }
                } else {
                    importsRefs[imports.Length] = imports[imports.Length];
                }
            }
        }
    }
}