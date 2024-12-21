using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource Music;
    public AudioSource SFX;

    public AudioClip DECKTHEHALLS;
    public AudioClip ODETOALL;
    public AudioClip punch;
    public AudioClip kick;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Music.clip = DECKTHEHALLS;
        Music.Play();
    }

    public void PlayODE()
    {
        Music.clip = ODETOALL;
        Music.Play();
    }
    public void PlayPunch()
    {
        SFX.PlayOneShot(punch);
    }

    public void PlayKick()
    {
        SFX.PlayOneShot(kick);
    }
}
