using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> Effectcards = new List<GameObject>();
    public static cardManager CardManager;
    public List<GameObject> Selectedcards = new List<GameObject>();
    private List <cardClass> cardsComp=new List <cardClass>();
    void Start()
    {
        CardManager = this;
        for(int i = 0;i < Effectcards.Count; i++)
        {
            cardsComp.Add(Effectcards[i].GetComponent<cardClass>());
        }
        
    }
    public void spawnCards()
    {
        for(int i=0; i < 3; i++)
        {
            int x=Random.Range(0, cards.Count);
            if (cardsComp[x].lvl==5)
            {
                cards.Remove(cards[x]);
                cardsComp.Remove(cardsComp[x]);
                i--;
            }
            else
            {
                Selectedcards.Add(cards[x]);
                Instantiate(Selectedcards[i]);
            }
            
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Selectedcards[i]);
        }
    }
    [ContextMenu("canedio")]
    public void electroAura()
    {
        foreach(GameObject x  in Effectcards)
        {
            if(x is electroAura)
            {
                data.electroAura = true;
                x.SetActive(true);

            }
        }
    }
}

    

