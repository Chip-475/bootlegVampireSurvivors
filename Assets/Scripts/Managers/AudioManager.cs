using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    private static AudioManager inst;
    private AudioMixer mix;

    [Header("sorgenti")]
    public AudioSource bckAudio;  //musica sottofondo
    public AudioSource audioPrefab;  //effetti sonor

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
        //EnsureSliderReferences(); // controlla se gli slider sono assegnati se no l cerca per nome nella scena
        //SyncSlidersWithSavedValues(); // imposta i valori salvati 
        volume(100,"master");
        volume(100,"sfx");
        volume(100,"music");
    }

    public void playSFX(AudioClip clip, Transform spawn, float volume = 1f) //passiamo il trasform perche deve essere fatto in un punto della mappa(dove si trova il nemico)
    {
        AudioSource a = Instantiate(audioPrefab, spawn.position, Quaternion.identity);
        a.clip = clip;
        a.volume = volume;
        a.Play();
        Destroy(a.gameObject, clip.length);
    }

    /*
    public void play(AudioClip clip)
    {
        sor.PlayOneShot(clip);
    }*/

    public void playMusic(AudioClip clip,float volume=1f)
    {
        bckAudio.clip = clip;
        bckAudio.volume = volume;
        bckAudio.loop = true;
        bckAudio.Play();
    }

    public void setMaster(float vol)
    {

    }

    private void volume(float vol,string funz)
    {
        if(vol<=0f)return;
        mix.SetFloat(funz,Mathf.Log10(vol)*20);
    }

    private void rife()
    {
        if(masterSlider==null)
        {
            GameObject ob=GameObject.Find("master");
            if(ob!=null)masterSlider=ob.GetComponent<Slider>();
        }
        if(sfxSlider==null)
        {
            GameObject ob=GameObject.Find("sfx");
            if (ob != null) prefabSlider=ob.GetComponent<Slider>();
        }
        if(bckSlider==null)
        {
            GameObject ob=GameObject.Find("music");
            if(ob!=null)bckSlider=ob.GetComponent<Slider>();
        }


    }
}
