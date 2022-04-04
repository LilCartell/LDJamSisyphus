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
            {"TUTO_01", "La putain de sa meeeere\u00A0!" },
            {"TUTO_02", "Si elle pouvait rouler un peu plus longtemps..." },
            {"TUTO_03", "Au moins une minute quoi !" },
            {"TUTO_04", "Que j'aie le temps d'aller pisser pendant la descente" },
            {"TUTO_05", "Je peux peut-etre pimper un peu la colline..." },
            {"TUTO_06", "Dedale aura surement des trucs à me vendre pour ca\u00A0!" },
            {"FIRST_WIN_DIALOG", "Enfiiiin un peu de paix\u00A0!" },
            {"DEFEAT_SCORE_SCREEN", "Déja\u00A0???" },
            {"FIRST_WIN_SCORE_SCREEN", "Youpi\u00A0!" },
            {"RANDOM_WIN_SCORE_SCREEN", "Pas mal\u00A0!" },
            {"BEAT_PERSONAL_BEST_SCORE_SCREEN", "Nouveau record !" },
            {"BEAT_PERSONAL_BEST_SISYPHUS", "Hmmm, est-ce que je peux gratter encore un peu de temps\u00A0?" },
            {"BEST_SCORE", "Meilleur temps :"},
            {"LEADERBOARD_TITLE", "Ils m'ont aidé" },
            {"START_AGAIN", "Recommencer" },
            {"OBJECTIVE", "Objectif : 1'OO" }
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
            {"TUTO_01", "Awwwww shit, here we go again!" },
            {"TUTO_02", "If only it could roll a bit longer..." },
            {"TUTO_03", "One minute, is it too much to ask?!" },
            {"TUTO_04", "At least let me take a piss once I move it up the hill!" },
            {"TUTO_05", "Maybe I can pimp up the hill a little..." },
            {"TUTO_06", "I'm sure Daedalus can hook me up with something!" },
            {"FIRST_WIN_DIALOG", "Finally a bit of peace!" },
            {"DEFEAT_SCORE_SCREEN", "Already???" },
            {"FIRST_WIN_SCORE_SCREEN", "Yeeeeees!" },
            {"RANDOM_WIN_SCORE_SCREEN", "Not bad!" },
            {"BEAT_PERSONAL_BEST_SCORE_SCREEN", "New record!" },
            {"BEAT_PERSONAL_BEST_SISYPHUS", "Hmmm, maybe I can buy yet more time... ?" },
            {"BEST_SCORE", "Personal best :"},
            {"LEADERBOARD_TITLE", "They helped me" },
            {"START_AGAIN", "Start again" },
            {"OBJECTIVE", "Goal: 1'OO" }
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
            {"TUTO_02", "Μόνο που θα μπορούσε να κυλήσει λίγο περισσότερο..." },
            {"TUTO_03", "Ένα λεπτό, είναι πάρα πολύ να ρωτήσω;!" },
            {"TUTO_04", "Τουλάχιστον άσε με να τσαντιστώ μόλις το ανεβώ στο λόφο!" },
            {"TUTO_05", "Ίσως μπορέσω να ανεβώ λίγο τον λόφο..." },
            {"TUTO_06", "Είμαι σίγουρος ότι ο Δαίδαλος μπορεί να με κολλήσει με κάτι!" },
            {"FIRST_WIN_DIALOG", "Επιτέλους λίγη ησυχία!" },
            {"DEFEAT_SCORE_SCREEN", "Ήδη ???" },
            {"FIRST_WIN_SCORE_SCREEN", "Εεεεεεε !" },
            {"RANDOM_WIN_SCORE_SCREEN", "Καθόλου άσχημα!" },
            {"BEAT_PERSONAL_BEST_SCORE_SCREEN", "Νέο ρεκόρ !" },
            {"BEAT_PERSONAL_BEST_SISYPHUS", "Χμμμ, ίσως μπορώ να αγοράσω ακόμα περισσότερο χρόνο... ;" },
            {"BEST_SCORE", "Η καλύτερη στιγμή:"},
            {"LEADERBOARD_TITLE", "Με βοήθησαν" },
            {"START_AGAIN", "επανεκκίνηση" },
            {"OBJECTIVE", "Στόχος: 1'OO" }
        };
    }
}
