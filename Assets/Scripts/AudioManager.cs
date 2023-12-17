using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source ------------")]
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------ Audio Clip ------------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip collected;
    public AudioClip finish;

    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        soundSource.clip = background;
        soundSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
