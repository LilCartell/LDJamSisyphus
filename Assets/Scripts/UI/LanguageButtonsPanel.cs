using UnityEngine;

public class LanguageButtonsPanel : MonoBehaviour
{
    public void OnFrenchButtonClick()
    {
        Strings.Language = "French";
        ReloadAllTexts();
    }

    public void OnEnglishButtonClick()
    {
        Strings.Language = "English";
        ReloadAllTexts();
    }

    public void OnGreekButtonClick()
    {
        Strings.Language = "Greek";
        ReloadAllTexts();
    }

    private void ReloadAllTexts()
    {
        foreach (var localizedText in Resources.FindObjectsOfTypeAll<I18NText>())
        {
            localizedText.ReloadText();
        }
    }
}