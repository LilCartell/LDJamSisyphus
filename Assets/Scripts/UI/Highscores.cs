using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Highscores : MonoBehaviour
{

    const string privateCode = "og8dk0JLQUCae1C1tktDbQWr_1EpLeUkOMQF5BsvpSkw";
    const string publicCode = "5cd301993ebb39187033a0ed";
    const string secretKey = "qs4v7ir58g4d8e";
    const string webURL = "http://dreamlo.com/lb/";

    DisplayHighscores highscoreDisplay;
    public Highscore[] highscoresList;
    static Highscores instance;

    void Awake()
    {
        highscoreDisplay = GetComponent<DisplayHighscores>();
        instance = this;
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }


      //  -- MD5 AJOUT
    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    // -- fin MD5 AJOUT
 


    IEnumerator UploadNewHighscore(string username, int score)
    {

        string hash = Md5Sum(username + score + secretKey);
        

        UnityWebRequest www = UnityWebRequest.Get("https://christophermatt.fr/games/sisyphe_leaderboard/addscore.php?name=" + UnityWebRequest.EscapeURL(username) + "&score=" + score + "&hash=" + hash);
        www.SetRequestHeader("User-Agent", "DefaultBrowser");
        yield return www.SendWebRequest();




        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            // DownloadHighscores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://christophermatt.fr/games/sisyphe_leaderboard/display.php");
        www.SetRequestHeader("User-Agent", "DefaultBrowser");
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.downloadHandler.text);
            highscoreDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            // print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}