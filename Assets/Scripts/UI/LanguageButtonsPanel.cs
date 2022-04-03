using UnityEngine;

public class LanguageButtonsPanel : MonoBehaviour
{
    public void OnFrenchButtonClick()
    {
        Strings.Language = "French";
        ReloadAllTexts();
        GoToNextScreen();
    }

    public void OnEnglishButtonClick()
    {
        Strings.Language = "English";
        ReloadAllTexts();
        GoToNextScreen();
    }

    public void OnGreekButtonClick()
    {
        Strings.Language = "Greek";
        ReloadAllTexts();
        GoToNextScreen();
    }

    private void ReloadAllTexts()
    {
        foreach (var localizedText in Resources.FindObjectsOfTypeAll<I18NText>())
        {
            localizedText.ReloadText();
        }
    }

    private void GoToNextScreen()
    {
        var registeredPseudo = TitleScene.Instance.GetRegisteredPseudo();
        if (string.IsNullOrEmpty(registeredPseudo))
            StateMachine.Instance.TransitionToState(StateType.PSEUDO_SELECT);
        else
        {
            GameSession.Instance.Pseudo = registeredPseudo;
            StateMachine.Instance.TransitionToState(StateType.TITLE_SCREEN);
        }
    }
}