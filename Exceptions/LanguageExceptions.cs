using System;

namespace HazelScript.Exceptions;

public class LanguageExceptions {
    public static LineNote PackageNotFoundException(int line, string package) =>
        new LineNote {
            message = "Package \"" + package + "\" not found. Did you included that package?",
            line = line
        };
    public static LineNote ReferenceNotFoundException(int line, string reference) =>
        new LineNote {
            message = "Reference \"" + reference + "\" not found. You must implement that reference.",
            line = line
        };
    public static LineNote MethodsDoesntReturnValuesException(int line, string method, string value) =>
        new LineNote {
            message = "Methods doesn't return values. Your \"" + method + "\" method returns " + value + ". To return a value, switch your method to a function (strings, integers, etc).",
            line = line
        };
    public static LineNote PreambleAusenceException() =>
        new LineNote {
            message = "A complete basic preamble block is needed.",
            line = 1
        };
    public static LineNote LogicalPreambleDelimitationsException(int line,int start, int end) =>
        new LineNote {
            message = "You have to order correctly your preamble. Your preamble start is at line " + start + ", and your preamble end is at line " + end + ".",
            line = line
        };
    public LineNote ImportNotSpecified(int line) =>
        new LinNote {
            message = "The import is not specified. Check and add it.",
            line = line
        };
}