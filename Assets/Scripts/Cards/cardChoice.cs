using UnityEngine;
using UnityEngine.UI;

public class cardChoice : MonoBehaviour
{
    private cardManager manager;
    private cardManager.CardEntry entry;
    public void setup(cardManager manager, cardManager.CardEntry entry)
    {
        this.manager = manager;
        this.entry = entry;
    }

    public void onClick()
    {
        if (manager != null && entry != null)
        {
            Debug.Log("card picked");
            manager.pickCard(entry);
        }
    }
}