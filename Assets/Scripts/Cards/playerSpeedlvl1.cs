using UnityEngine;

public class playerSpeedlvl1 : MonoBehaviour
{
    public player pg;
    public float speedMulti=1.15f;
    private bool used = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void useCard()
    {
        if(used == true) return;
        if(pg==null) return;

        pg.spd=pg.spd*speedMulti;

        used=true;
        Destroy(gameObject);
    }

}
