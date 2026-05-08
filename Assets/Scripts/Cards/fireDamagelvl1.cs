using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class fireDamagelvl1 : MonoBehaviour
{
    private IDamageable nemico;

    public void Initialize(IDamageable _nemico,float damage,float duration,float inter)
    {
        nemico = _nemico;  
        StartCoroutine(fireDamage(damage, duration, inter));
    }

    private IEnumerator fireDamage(float _damage,float duration,float inter)
    {
        //questo per il tempo giusto e dare il danno giusto,dal nemico che gli passa scythe
        float trascorso=0f;    
        while(trascorso<duration)
        {
            if(nemico!=null)nemico.damage(_damage);
            trascorso += inter;
            yield return new WaitForSeconds(inter);
        }
        Destroy(this);
    }
}
