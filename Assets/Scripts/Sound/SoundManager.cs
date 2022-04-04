using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip TitleSceneMusic;
	public AudioClip RollingMusic;
	public AudioClip PlacingMusic;

	public AudioSource AudioSource;



	public AudioClip CollisionSound;
    public AudioClip BumpSound;
    public AudioClip FlipperSound;
    public AudioClip PortalSound;

    public AudioSource EffectsAudioSource;

     public AudioClip ExplosionSound;

    public AudioSource ExplosionAudioSource;


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
		AudioSource.clip = PlacingMusic;
		AudioSource.Play();
	}





	public void PlayItemSound(AudioClip ObjectSound){
		EffectsAudioSource.clip = ObjectSound;
        EffectsAudioSource.Play();
	}
    public void PlayExplosion()
    {
        ExplosionAudioSource.clip = ExplosionSound;
        ExplosionAudioSource.Play();
    }

}