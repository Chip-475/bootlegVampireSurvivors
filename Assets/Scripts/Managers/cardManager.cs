using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    [System.Serializable]
    public class CardEntry
    {
        public GameObject prefab;
        public cardClass effect;
        public int level = 1;
    }

    public static cardManager instance;
    public List<CardEntry> cards = new List<CardEntry>();
    public Transform cardParent;
    public int choices = 3;

    void Start()
    {
        instance = this;
    }

    public void spawnCards()
    {

        List<CardEntry> availableCards = getAvailableCards();
        int cardsToSpawn = Mathf.Min(choices, availableCards.Count);

        for(int i = 0; i < cardsToSpawn; i++)
        {
            int index = Random.Range(0, availableCards.Count);
            CardEntry entry = availableCards[index];
            GameObject spawnedCard = Instantiate(entry.prefab, cardParent);

            cardChoice choice = spawnedCard.GetComponent<cardChoice>();
            if (choice != null)
            {
                choice.setup(this, entry);
            }
            else
            {
                spawnedCard.AddComponent<cardChoice>().setup(this, entry);
            }

            availableCards.RemoveAt(index);
        }
    }

    public void pickCard(CardEntry entry)
    {
        if (!canSpawn(entry)) return;

        entry.effect.lvl = entry.level;
        clearSpawnedCards();
    }

    private List<CardEntry> getAvailableCards()
    {
        List<CardEntry> availableCards = new List<CardEntry>();

        foreach (CardEntry entry in cards)
        {
            if (canSpawn(entry))
            {
                availableCards.Add(entry);
            }
        }

        return availableCards;
    }

    private bool canSpawn(CardEntry entry)
    {
        if (entry == null || entry.prefab == null || entry.effect == null) return false;

        int maxLevel = 5;
        if (entry.effect.lvl >= maxLevel) return false;
        if (entry.level > maxLevel) return false;

        return entry.level == entry.effect.lvl + 1;
    }

    private void clearSpawnedCards()
    {

        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }
    }
}
