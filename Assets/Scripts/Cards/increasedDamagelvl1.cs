using UnityEngine;

public class increasedDamagelvl1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        scythe s = other.GetComponentInChildren<scythe>();
        if(s!= null )
        {
            s.saliDanno();
            Destroy(gameObject);
        }
    }
    
    /*
    public void effetto(player p,float extraDamage)
    {
        p.atk += extraDamage;  //per lo stesso motivo di haste
        Destroy(this);
    }*/
}
