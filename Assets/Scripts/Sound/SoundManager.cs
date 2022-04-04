using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip TitleSceneMusic;
	public AudioClip RollingMusic;
	public AudioClip PlacingMusic;

	public AudioSource AudioSource;

	public static SoundManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		Instance = this;

		DontDestroyOnLoad(this.gameObject);
	}

	public void PlayTitleMusic()
	{
		AudioSource.clip = TitleSceneMusic;
		AudioSource.Play();
	}

	public void PlayRollingMusic()
	{
		AudioSource.clip = RollingMusic;
		AudioSource.Play();
	}

	public void PlayPlacingMusic()
	{
		AudioSource.clip = RollingMusic;
		AudioSource.Play();
	}
}