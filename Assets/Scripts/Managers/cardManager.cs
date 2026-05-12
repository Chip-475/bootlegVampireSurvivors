using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public static cardManager CardManager;
    public List<GameObject> Selectedcards = new List<GameObject>();
    public List <cardClass> cardsComp=new List <cardClass>();
    void Start()
    {
        CardManager = this;
        for (int i = 0; i < cards.Count; i++)
        {
            cardsComp[i]=cards[i].GetComponent<cardClass>();
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
            }
            
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Selectedcards[i]);
        }
    }
}

    

