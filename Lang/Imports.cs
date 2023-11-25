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
    public string GetFromLine(string line){
        string[] parts = line.Split(" ");
        if(parts.Length == 2){
            //..
        } else {
            //..
        }
        return "";
    }
}