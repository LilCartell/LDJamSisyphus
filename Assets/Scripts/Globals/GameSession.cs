public class GameSession
{
	public string Pseudo;
	public float LastScore;
	public bool SawTutorial;
	public bool HasWonOnce;

	private static GameSession _instance;
	public static GameSession Instance
	{
		get
		{
			if (_instance == null)
				_instance = new GameSession();
			return _instance;
		}
	}

	private GameSession()
	{}
}