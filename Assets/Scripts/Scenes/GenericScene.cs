using UnityEngine;

public abstract class GenericScene : MonoBehaviour
{
    private void Start()
    {
        if (StateMachine.Instance.CurrentState == StateType.NONE) //Starting from this scene : must initialize state machine
            StateMachine.Instance.TransitionToState(GetFirstState());
    }
    protected abstract StateType GetFirstState();
}