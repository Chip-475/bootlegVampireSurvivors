using UnityEngine;

public class increasedLifelvl1 : MonoBehaviour
{
    [System.Serializable]
    public struct vita
    {
        public float increHp;
    }

    [Header("livelli vita")]
    public vita lvl1 = new vita { increHp = 20f };
    public vita lvl2 = new vita { increHp = 50f };

    public void applicaPot(player p,int livello)
    {
        float valore;
        switch(livello)
        {
            case 1:
                valore = lvl1.increHp;
                break;
            case 2:
                valore = lvl2.increHp;
                break;
            default:
                valore = lvl1.increHp;
                break;
        }
        p.setHpMax(valore);
        p.hp += valore;
        Debug.Log("aggiunto");
        Destroy(this);
    }

    //sull'oggetto che aumenta la vita (botone)
    /*public void livelloVita(player p,int lvl)
    {
        increasedLifelvl1 up = p.gameObject.AddComponent<increasedLifelvl1>();
        up.applicaPot(p, lvl);
    }*/
    
    
}
