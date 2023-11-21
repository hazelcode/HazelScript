namespace HazelScript.Exceptions;
public class ExceptionManager {
    public static List<LineNote> ExceptionList = new List<LineNote>();
    public static void ThrowExceptions(){
        LineNote[] exceptions = ExceptionManager.ExceptionList.ToArray<LineNote>();
        
        foreach(LineNote ex in exceptions){
            Console.WriteLine("ERROR >> " + ex.message);
            Console.WriteLine("\tat line " + ex.line);
        }
    }
}