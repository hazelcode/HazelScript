using System;

namespace HazelScript.Exceptions;

public class InterpreterExceptions {
    public static Exception FileNotFoundException(string file){
        return new Exception("File \"" + file + "\" not found. Doesn't exist, or isn't written correctly.");
    }
    public static Exception FileTypeException(string file){
        return new Exception("Your \"" + file + "\" file isn't a HazelScript file. Please check the extension.");
    }
}