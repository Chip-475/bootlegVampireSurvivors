using UnityEngine;

public class increasedRangelvl1 : MonoBehaviour
{
    [System.Serializable]
    public struct livelloRange
    {
        public float incremento;
    }
    [Header("livelli")]
    public livelloRange lvl1;
    public livelloRange lvl2;

    public void potenziamento(player p,int livello)
    {
        float val=0f;
        switch(livello)
        {
            case 1:
                val = lvl1.incremento;
                break;
            case 2:
                val = lvl2.incremento; 
                break;
            default:
                val = lvl1.incremento;
                break;
        }
        p.range += val;
        Debug.Log("duce");
        Destroy(this);
    }
}
