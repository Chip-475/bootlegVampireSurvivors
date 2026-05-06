using UnityEngine;

public class increasedLifelvl1 : MonoBehaviour
{
    public player pg;
    public float lifeMult = 1.15f;
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
        if(pg == null) return;

        pg.hp= pg.hp*lifeMult;

        used = true;
        Destroy(gameObject);
    }

}
