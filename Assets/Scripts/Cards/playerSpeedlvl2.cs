using UnityEngine;

public class playerSpeedlvl2 : MonoBehaviour
{
    public player pg;
    public float speedMulti=1.25f;
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
