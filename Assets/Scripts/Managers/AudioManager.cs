using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager inst;
    private AudioMixer mix;

    [Header("sorgenti")]
    public AudioSource bckAudio  //musica sottofondo
    public AudioSource audioPrefab   //effetti sonori

    [Header("slider")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider prefabSlider;
    [SerializeField] private Slider bckSlider;
    /*
     * master tutto
     * effetti sonori
     * music (background)
     */

    void Awake()
    {
        if(inst == null) inst = this;
        /*
        inst = this;
        sor = GetComponent<AudioSource>();*/
    }

    void Start()
    {
        EnsureSliderReferences(); // controlla se gli slider sono assegnati se no l cerca per nome nella scena
        SyncSlidersWithSavedValues(); // imposta i valori salvati 
        ApplyMixerVolume("master", 100);
        ApplyMixerVolume("sfx", 100);
        ApplyMixerVolume("music", 100);
    }

    public void playSFX(AudioClip clip,Transform spawn,float volume=1f) //passiamo il trasform perche deve essere fatto in un punto della mappa(dove si trova il nemico)
    {
        AudioSource a = Instantiate(audioPrefab, spawn.position, Quaternion.identity);
        a.clip = clip;
        a.volume = volume;
        a.Play();
        Destroy(a.gameObject,clip.length);
    }

    /*
    public void play(AudioClip clip)
    {
        sor.PlayOneShot(clip);
    }*/
}
