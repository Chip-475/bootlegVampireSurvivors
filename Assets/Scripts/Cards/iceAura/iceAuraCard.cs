using UnityEngine;

public class iceAuraCard : MonoBehaviour
{
    public GameObject aura;
    
    public void onClick()
    {
        data.iceAura = true;
        aura.SetActive(true);
    }
}   
