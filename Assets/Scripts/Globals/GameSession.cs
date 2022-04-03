public class GameSession
{
	public string Pseudo;

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