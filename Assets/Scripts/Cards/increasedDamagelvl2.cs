using Unity.Mathematics;
using UnityEngine;

public class increasedDamagelvl2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public player pg;

    public float dmgMult=1.20f;
    private bool used=false;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    public void useCard()
    {
        if(used==true) return;
        if(pg==null)return; 
        pg.atk=pg.atk*dmgMult;

        used=true;
        Destroy(gameObject);
    }
}
