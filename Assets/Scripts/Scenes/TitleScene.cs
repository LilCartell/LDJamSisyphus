using UnityEngine;

public class TitleScene : GenericScene
{
    public LanguageButtonsPanel LanguageButtonsPanel;
    public EnterPseudoPanel EnterPseudoPanel;
    public GameObject TitleScreen;
    public GameObject EndTitleScreen;
    public float EndTitleScreenTimer = 5;

    private bool _endTitleTimerStarted;
    private float _timeBeforeTransition = 0;

    public static TitleScene Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && StateMachine.Instance.CurrentState == StateType.TITLE_SCREEN)
        {
            StateMachine.Instance.TransitionToState(StateType.END_TITLE_SCENE);
        }

        if(_endTitleTimerStarted)
        {
            _timeBeforeTransition -= Time.deltaTime;
            if(_timeBeforeTransition <= 0)
            {
                _endTitleTimerStarted = false;
                StateMachine.Instance.TransitionToState(StateType.BALL_ROLLING);
            }
        }
    }

    public void StartEndTitleScreenTimer()
    {
        _endTitleTimerStarted = true;
        _timeBeforeTransition = EndTitleScreenTimer;
    }

    public void OnTitleScreenClick()
    {
        StateMachine.Instance.TransitionToState(StateType.END_TITLE_SCENE);
    }

    public string GetRegisteredPseudo()
    {
        return "";
    }

    protected override StateType GetFirstState()
    {
        return StateType.LANGUAGE_SELECT;
    }
}