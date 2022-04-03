using UnityEngine;
using UnityEngine.UI;

public class EnterPseudoPanel : MonoBehaviour
{
    public InputField PseudoInput;
    public Button SubmitPseudoButton;

    public void OnPseudoValueChanged(string newValue)
    {
        SubmitPseudoButton.interactable = (newValue.Length > 0);
    }

    public void OnPseudoSubmitted()
    {
        GameSession.Instance.Pseudo = PseudoInput.text;
        StateMachine.Instance.TransitionToState(StateType.TITLE_SCREEN);
    }
}