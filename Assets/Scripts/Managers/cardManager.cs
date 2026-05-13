using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class cardManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs = new List<GameObject>();
    public List<GameObject> cardObjects = new List<GameObject>();

    [ContextMenu("diocane")]
    void spawnCards()
    {
        List<int> indexes = new List<int>(3);
        for(int i = 0; i < indexes.Count - 1; i++)
        {
            while (true)
            {
                var x = Random.Range(0, indexes.Count - 1);
                indexes[i] = x;
                if (!indexes.Contains(x)) break;
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
