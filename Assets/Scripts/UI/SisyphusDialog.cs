using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SisyphusDialog : MonoBehaviour
{
    public Button NextButton;
    public Text Dialog;

    private List<string> _remainingStrings = new List<string>();
    public void LoadTutorialDialog()
    {
        _remainingStrings = new List<string>()
        {
            "TUTO_01",
            "TUTO_02",
            "TUTO_03",
            "TUTO_04"
        };
        this.gameObject.SetActive(true);
        NextButton.gameObject.SetActive(true);
        NextDialog();
    }

    public void LoadFirstWinDialog()
    {
        Dialog.text = Strings.Get("FIRST_WIN_DIALOG");
        this.gameObject.SetActive(true);
        NextButton.gameObject.SetActive(false);
    }

    public void NextDialog()
    {
        if(_remainingStrings.Count > 0)
        {
            Dialog.text = Strings.Get(_remainingStrings[0]);
            _remainingStrings.RemoveAt(0);
        }
        else
        {
            StateMachine.Instance.TransitionToState(StateType.PLACING_OBJECTS);
        }
    }
}