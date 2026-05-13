using UnityEngine;

public class cardClass : MonoBehaviour
{
    protected player player;
    public enum type
    {
        electroAuraPerk,
        iceAuraPerk,
        fireAreaPerk
    }
    public type perk;
    
    public int lvl;
    public int lvlMax;
    protected bool active = false;

    public float radius;
    public float duration;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
    }
}
