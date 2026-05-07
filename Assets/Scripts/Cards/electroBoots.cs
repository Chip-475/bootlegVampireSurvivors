using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class electroBoots : MonoBehaviour
{
    [SerializeField]private float _danno;
    private bool equip;
    bool dentro;
    List<GameObject> enemy=new List<GameObject>();
    public float cooldown = 0.5f;
    IDamageable IDamageable;
    void OnTriggerEnter2D(Collider2D other)
    {
        dentro = true;
        enemy.Add(other.gameObject);
    }

    IEnumerator danno()
    {
        float tick = 0f;
        while(dentro==true)
        {
            if(tick>cooldown)
            {
                foreach (var en in enemy)
                {
                    if (en.TryGetComponent<IDamageable>(out IDamageable)) // restitusce true  o false se ce o non il componente
                    {
                        en.GetComponent<IDamageable>().damage(_danno); //chiama il metodo di interfaccia
                    }
                }
                tick=0f;
            }
            tick += Time.deltaTime;
            yield return null; //aspetta un frame
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dentro = false;
        enemy.Remove(other.gameObject);
    }

    private void setEquip()
    {
        equip=true;
    }
}
