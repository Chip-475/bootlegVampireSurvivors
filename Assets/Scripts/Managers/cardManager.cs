using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class cardManager : MonoBehaviour
{
    public List<GameObject> cardPrefabs = new List<GameObject>();
    public List<GameObject> cardObjects = new List<GameObject>();
    List<cardClass> cardComps = new List<cardClass>();

    void Start()
    {
        foreach(GameObject x in cardObjects)
        {
            cardComps.Add(x.GetComponent<cardClass>());
        }
    }

    void Update()
    {

    }

    void pickCard()
    {
        
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
