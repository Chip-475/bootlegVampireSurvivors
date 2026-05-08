using UnityEngine;

public class increasedDamagelvl1 : MonoBehaviour
{
    public void effetto(player p,float extraDamage)
    {
        p.atk += extraDamage;  //per lo stesso motivo di haste
        Destroy(this);
    }
}
