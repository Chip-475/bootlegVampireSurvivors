using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    public static audioManager manager;

    public AudioMixer mixer;
    public AudioSource source;
    

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
    }

    public void playSFX(AudioClip clip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(source, spawn.position, Quaternion.identity); ;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void setMaster(float volume)
    {
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void setSFX(float volume)
    {
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    public void setBGM(float volume)
    {
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
}