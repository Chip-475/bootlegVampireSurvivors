using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    static List<int> cardIndexes = new List<int>();

    void Start()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cardIndexes.Add(i);
        }
    }

    void Update()
    {

    }

    public static void spawnCards()
    {

        int[] toSpawn = new int[3];
        for(int i = 0; i < 3; i++)
        {
            var x = Random.Range(0, cardIndexes.Count);
            toSpawn[i] = x;
            cardIndexes.Remove(x);
        }

        // Card spawn to code
    }
    public int countCards()
    {
        int i = 0;
        for ( i = 0; i < cards.Count; i++)
        {
        }
        return i;
    }
}
