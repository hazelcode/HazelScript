namespace HazelScript.Lang;

public class Imports {
    public Dictionary<String,String> imports = new Dictionary<String, String>();
    public void Add(string name, string reference){
        imports.Add(name, reference);
    }
    public string GetReference(string reference){
        string[] keys = imports.Keys.ToArray<String>();
        string[] values = imports.Values.ToArray<String>();
        if(keys.Length > 0 && values.Length > 0)
        if(imports.ContainsKey(reference)){
            for(int i = 0; i < keys.Length; i++){
                if(keys[i] == reference && values.Length > i) return values[i];
            }
        }
        return null!;
    }
    public string GetValueFromLine(string lineContent, int lineNumber){
        string[] parts = lineContent.Split(" ");
        if(parts.Length >= 1 && lineContent){
            // import 'thing1:thing2' || 'thing "thing1:thing2"         -- EXAMPLE 1
            // convert to thing1/thing2
            // import 'thing1:thing2/thing3' || "thing1:thing2/thing3"  -- EXAMPLE 2
            // convert to thing1/thing2/thing3
            // import 'thing1:thing2\thing3' || "thing1:thing2\thing3"  -- EXAMPLE 3
            // convert to thing1/thing2/thing3
            return parts[1]
                .Replace(new char[] {'\"', '\''}, "")
                .Replace(":", "/")
                .Replace("\\", "/");
        }
        // return null import, and add an error: the package was not found in, or is bad written.
        ExceptionManager.ExceptionList.Add(LanguageExceptions.ImportNotSpecified(lineNumber));
        return null;
    }
}