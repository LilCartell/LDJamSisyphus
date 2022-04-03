using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{

    public Text[] highscoreFields;
    public Text[] pseudoFields;
    Highscores highscoresManager;

    void Start()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            pseudoFields[i].text = "Chargement...";
            highscoreFields[i].text = "...";
        }


        highscoresManager = GetComponent<Highscores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            
            if (i < highscoreList.Length)
            {   
                pseudoFields[i].text = highscoreList[i].username ;
                highscoreFields[i].text = highscoreList[i].score.ToString("N0", CultureInfo.CreateSpecificCulture("sv-SE"));
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}