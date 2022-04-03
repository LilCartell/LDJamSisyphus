using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    public static string Language = "English";

    public static string Get(string key)
    {
        switch(Language)
        {
            case "English":
                return GetEnglishDictionary()[key];

            case "French":
                return GetFrenchDictionary()[key];

            case "Greek":
                return GetGreekDictionary()[key];
        }
        return key;
    }

    public static Dictionary<string,string> GetFrenchDictionary()
    {
        return new Dictionary<string, string>()
        {

        };
    }

    public static Dictionary<string, string> GetEnglishDictionary()
    {
        return new Dictionary<string, string>()
        {

        };
    }

    public static Dictionary<string, string> GetGreekDictionary()
    {
        return new Dictionary<string, string>()
        {

        };
    }
}
