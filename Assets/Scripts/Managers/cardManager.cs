using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class cardManager : MonoBehaviour
{
    // NON RUNNARE spawnCards FIGLIO DI PUTTANA e non modificare

    public List<GameObject> cardPrefabs = new List<GameObject>();
    public List<GameObject> cardObjects = new List<GameObject>();

    [ContextMenu("diocane")]
    void spawnCards()
    {
        List<int> indexes = new List<int>(3);
        for(int i = 0; i < indexes.Capacity; i++)
        {
            while (indexes.Count < 3)
            {
                int x = Random.Range(0, cardPrefabs.Count);
                if (!indexes.Contains(x))
                {
                    indexes.Add(x);
                }
            }
        }
        foreach (var x in indexes)
        {
            print(x);
        }
    }

    void electroAuraClick()
    {
        foreach(GameObject x in cardObjects)
        {
            cardClass temp = x.GetComponent<cardClass>();
            if(temp.perk == cardClass.type.electroAuraPerk)
            {
                data.electroAura = true;
                temp.lvl++;
                cardObjects.Remove(x);
            }
        }
    }
    void iceAuraClick()
    {
        foreach (GameObject x in cardObjects)
        {
            cardClass temp = x.GetComponent<cardClass>();
            if (temp.perk == cardClass.type.iceAuraPerk)
            {
                data.electroAura = true;
                temp.lvl++;
                cardObjects.Remove(x);
            }
        }
    }
    void fireAreaClick()
    {
        foreach (GameObject x in cardObjects)
        {
            cardClass temp = x.GetComponent<cardClass>();
            if (temp.perk == cardClass.type.fireAreaPerk)
            {
                data.electroAura = true;
                temp.lvl++;
                cardObjects.Remove(x);
            }
        }
    }
}
