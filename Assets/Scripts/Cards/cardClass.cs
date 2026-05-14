using UnityEngine;

public class cardClass : MonoBehaviour
{
    protected player player;
    
    public int lvl;
    public int lvlMax;
    protected bool active = false;

    public float radius;
    public float duration;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
    }

}
