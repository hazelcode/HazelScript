using System;
using System.Text;
using HazelScript.Exceptions;

namespace HazelScript.Lang;

public class CodeReader {
    string file = "";
    public CodeReader(string file){
        this.file = file;
    }
    public string[] SeparateLines(){
        string[] lines = File.ReadAllLines(this.file);
        return lines;
    }
    public int CountLines(string[] script){
        return script.Length;
    }
    public bool DetectPreambleStart(string[] script){
        string[] lines = script;
        bool detected = false;
        for(int i = 0; i < lines.Length; i++){
            if(lines[i] == "#preamble") detected = true;
            if(i == (lines.Length-1) && detected == false) return false;
        }
        return detected;
    }
    public bool DetectPreambleEnd(string[] script){
        string[] lines = script;
        bool detected = false;
        for(int i = 0; i < lines.Length; i++){
            if(lines[i] == "#endpreamble") detected = true;
            if(i == (lines.Length-1) && detected == false) return false;
        }
        return detected;
    }
    public int GetPreambleStartDelimitation(string[] script){
        string[] fileLines = script;
        int pos = 0;
        for(int i = 0; i < fileLines.Length; i++){
            if(fileLines[i] == "#preamble") pos = i+1;
        }
        return pos;
    }
    public int GetPreambleEndDelimitation(string[] script){
        string[] fileLines = script;
        int pos = 0;
        for(int i = 0; i < fileLines.Length; i++){
            if(fileLines[i] == "#endpreamble") pos = i+1;
        }
        return pos;
    }
    public bool HasLogicalPreambleDelimitations(string[] script){
        if(GetPreambleStartDelimitation(script) < GetPreambleEndDelimitation(script)) return true;
        else return false;
    }
    public bool DetectPreamble(string[] script){
        if(DetectPreambleStart(script) == true && DetectPreambleEnd(script) == true){
            if(!HasLogicalPreambleDelimitations(script)){
                ExceptionManager.ExceptionList.Add(LanguageExceptions.LogicalPreambleDelimitationsException(GetPreambleEndDelimitation(script),GetPreambleStartDelimitation(script), GetPreambleEndDelimitation(script)));
            }
        } else ExceptionManager.ExceptionList.Add(LanguageExceptions.PreambleAusenceException());
        return true;
    }
    public string[] RemovePreambleBlock(string[] script){
        string[] fileLines = script;
        int preambleEnd = GetPreambleEndDelimitation(script);
        string[] lines = {};
        int pos = preambleEnd;
        while(pos < (fileLines.Length-1)){
            lines = lines.Prepend(script[pos]).ToArray<String>();
        }
        return lines;
    }
    public string[] GetPreambleLines(string[] script, int start, int end){
        string[] preambleLines = {};
        int space = 0;
        for(int i = start; i < (end-1); i++){
            preambleLines[space] = script[i];
            if(space < (end-1)) space++;
        }
        return preambleLines;
    }
    public void ReadPreamble(string[] script){
        bool hasCompletePreamble = DetectPreamble(script);
        if(hasCompletePreamble){
            string[] preamble = GetPreambleLines(script, GetPreambleStartDelimitation(script), GetPreambleEndDelimitation(script));
        }
    }
    public void ReadCode(string[] script){
        bool hasCompletePreamble = DetectPreamble(script);
        string[] lines = script;
        if(hasCompletePreamble){
            string[] linesWithoutPreamble = RemovePreambleBlock(script);
            Types t = new Types();
            string json = JsonSerializer.Serialize<Types>(t);
        }
    }
}