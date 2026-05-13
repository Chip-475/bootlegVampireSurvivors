using UnityEngine;

public class electroAuraCard : MonoBehaviour
{
    public GameObject aura;

    [ContextMenu("func")]
    
    public void onClick()
    {
        data.electroAura = true;
        aura.SetActive(true);
    }
}
