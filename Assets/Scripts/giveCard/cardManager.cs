using UnityEngine;

public class cardManager : MonoBehaviour
{
   public GameObject[] cards;
   public int killnecessarie;

    void Start()
    {
    data.nemiciuccisi = Mathf.RoundToInt(20 +data.crescita1 * data.cardCount + data.crescita2 * Mathf.Pow(data.cardCount, 1.45f));

    }

    void Update()
    {
        if (data.nemiciuccisi >= killnecessarie)
        {
            data.nemiciuccisi = 0; 
            killnecessarie = Mathf.RoundToInt(20 + data.crescita1 * data.cardCount + data.crescita2 * Mathf.Pow(data.cardCount, 1.45f));
            pickCard();
        }
    }
    void pickCard()
    {
        int randomIndex = 0;
       int randomIndex2 = 0;
       int randomIndex3 = 0;
        while(randomIndex == randomIndex2 || randomIndex == randomIndex3 || randomIndex2 == randomIndex3)
        {
            randomIndex = Random.Range(0, cards.Length);
            randomIndex2 = Random.Range(0, cards.Length);
            randomIndex3 = Random.Range(0, cards.Length);
        GameObject randomCard1 = cards[randomIndex];    
        GameObject randomCard2 = cards[randomIndex];
        GameObject randomCard3 = cards[randomIndex];
        }
    }
}
