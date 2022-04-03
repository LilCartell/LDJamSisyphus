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
            {"CAMUS_QUOTE", "« La lutte elle-même vers les sommets suffit à remplir un coeur d'homme.\nIl faut imaginer Sisyphe heureux. »" },
            {"REMAINING_POINTS", "Drachmes restantes" },
            {"TUTO_01", "La putain de sa meeeeeere !" },
            {"TUTO_02", "Bon ça va bien 5 minutes" },
            {"TUTO_03", "Je vais acheter des trucs à Dédale pour foutre sur la colline" },
            {"TUTO_04", "Je vais peut-être réussir à avoir la paix 2 minutes comme ça" },
            {"FIRST_WIN_DIALOG", "Enfiiiin 2 minutes pour aller pisser" },
            {"DEFEAT_SCORE_SCREEN", "Déja ???" },
            {"FIRST_WIN_SCORE_SCREEN", "Youpi !" },
            {"RANDOM_WIN_SCORE_SCREEN", "Encore un peu plus..." },
            {"BEST_SCORE", "Meilleur temps :"},
            {"LEADERBOARD_TITLE", "Ils m'ont aidés" },
            {"START_AGAIN", "Recommencer" }
        };
    }

    public static Dictionary<string, string> GetEnglishDictionary()
    {
        return new Dictionary<string, string>()
        {
            {"PSEUDO_LABEL", "Enter your username" },
            {"PSEUDO_WATERMARK", "Username..." },
            {"CAMUS_QUOTE", "The struggle itself toward the heights is enough to fill a man's heart.\n One must imagine Sisyphus happy." },
            {"REMAINING_POINTS", "Remaining drachmas" },
            {"TUTO_01", "Awwwww shit, here we go again !" },
            {"TUTO_02", "It's getting real old real fast" },
            {"TUTO_03", "Maybe Daedalus can hook me up with some stuff to put on the hill" },
            {"TUTO_04", "It might finally buy me a bit of peace" },
            {"FIRST_WIN_DIALOG", "Finally 2 minutes to go pee" },
            {"DEFEAT_SCORE_SCREEN", "Already ???" },
            {"FIRST_WIN_SCORE_SCREEN", "Yeeeeees !" },
            {"RANDOM_WIN_SCORE_SCREEN", "I can buy more time..." },
            {"BEST_SCORE", "Personal best :"},
            {"LEADERBOARD_TITLE", "They helped me" },
            {"START_AGAIN", "Start again" }
        };
    }

    public static Dictionary<string, string> GetGreekDictionary()
    {
        return new Dictionary<string, string>()
        {
            {"PSEUDO_LABEL", "εισάγετε το ψευδώνυμό σας" },
            {"PSEUDO_WATERMARK", "ψευδής..." },
            {"CAMUS_QUOTE", "Ο ίδιος ο αγώνας προς τα ύψη είναι αρκετός για να γεμίσει την καρδιά ενός ανθρώπου.\n Πρέπει να φανταστεί κανείς τον Σίσυφο ευτυχισμένο." },
            {"REMAINING_POINTS", "υπόλοιπες δραχμές" },
            {"TUTO_01", "Πόρνη της μάνας του!" },
            {"TUTO_02", "Γερνάει πολύ γρήγορα" },
            {"TUTO_03", "Ίσως ο Δαίδαλος μπορεί να με κολλήσει με κάποια πράγματα για να βάλω στον λόφο" },
            {"TUTO_04", "Ίσως τελικά να μου χαρίσει λίγη ηρεμία" },
            {"FIRST_WIN_DIALOG", "Επιτέλους 2 λεπτά για να κατουρήσει" },
            {"DEFEAT_SCORE_SCREEN", "Ήδη ???" },
            {"FIRST_WIN_SCORE_SCREEN", "Εεεεεεε !" },
            {"RANDOM_WIN_SCORE_SCREEN", "Μπορώ να αγοράσω περισσότερο χρόνο..." },
            {"BEST_SCORE", "Η καλύτερη στιγμή:"},
            {"LEADERBOARD_TITLE", "Με βοήθησαν" },
            {"START_AGAIN", "επανεκκίνηση" }
        };
    }
}
