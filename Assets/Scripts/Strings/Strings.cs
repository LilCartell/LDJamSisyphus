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
            {"PSEUDO_LABEL", "Entrez votre pseudo" },
            {"PSEUDO_WATERMARK", "Pseudo..." },
            {"CAMUS_QUOTE", "« La lutte elle-même vers les sommets suffit à remplir un coeur d'homme.\nIl faut imaginer Sisyphe heureux. »" }
        };
    }

    public static Dictionary<string, string> GetEnglishDictionary()
    {
        return new Dictionary<string, string>()
        {
            {"PSEUDO_LABEL", "Enter your username" },
            {"PSEUDO_WATERMARK", "Username..." },
            {"CAMUS_QUOTE", "The struggle itself toward the heights is enough to fill a man's heart.\n One must imagine Sisyphus happy." }
        };
    }

    public static Dictionary<string, string> GetGreekDictionary()
    {
        return new Dictionary<string, string>()
        {
            {"PSEUDO_LABEL", "εισάγετε το ψευδώνυμό σας" },
            {"PSEUDO_WATERMARK", "ψευδής..." },
            {"CAMUS_QUOTE", "Ο ίδιος ο αγώνας προς τα ύψη είναι αρκετός για να γεμίσει την καρδιά ενός ανθρώπου.\n Πρέπει να φανταστεί κανείς τον Σίσυφο ευτυχισμένο." }
        };
    }
}
