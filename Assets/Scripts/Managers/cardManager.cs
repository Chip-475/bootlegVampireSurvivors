using System.Collections.Generic;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    [System.Serializable]
    public class CardEntry
    {
        public GameObject prefab;
        public cardClass effect;
        public bool levelable;
    }

    public static cardManager instance;

    public List<CardEntry> cards = new List<CardEntry>();
    public List<CardEntry> spawnableCards = new List<CardEntry>();
    public Transform cardParent;
    public int choices = 3;
    public GameObject cardPanel;

    void Awake()
    {
        instance = this;
        spawnableCards = cards;
    }

    public void spawnCards()
    {
        Time.timeScale = 0;
        cardPanel.SetActive(true);

        int cardsToSpawn = Mathf.Min(choices, spawnableCards.Count);
        Debug.Log($"cardManager: {spawnableCards.Count} available cards out of {cards.Count} total.");

        if (cardsToSpawn == 0)
        {
            Debug.LogWarning("cardManager: no valid cards to spawn.");
            return;
        }

        List<int> index = new List<int>();
        for (int i = 0; i < cardsToSpawn; i++)
        {
            int x = Random.Range(choices, spawnableCards.Count);
            if (index.Contains(x)) { i--; continue; }
            index.Add(x);

            CardEntry entry = spawnableCards[x];
            if(entry.levelable && entry.effect.lvl == 5)
            {
                spawnableCards.Remove(entry);
                i--;
                continue;
            }

            GameObject spawnedCard = Instantiate(entry.prefab, cardParent);
            spawnedCard.name = $"{entry.prefab.name} lvl {entry.effect.lvl}";

            spawnedCard.TryGetComponent(out cardChoice choice);
            if(choice != null)
            {
                choice.setup(instance, entry);
            }
        }
    }

    public void pickCard(CardEntry entry)
    {
        if (!canSpawn(entry)) return;

        clearSpawnedCards();
        cardPanel.SetActive(false);
    }

    private bool canSpawn(CardEntry entry)
    {
        if (entry.levelable && entry.effect.lvl == 5)
        {
            Debug.Log($"cardManager: skipped {entry.prefab.name} lvl {entry.effect.lvl}; effect is already maxed at {entry.effect.lvl}/{5}.");
            return false;
        }

        return true;
    }

    private void clearSpawnedCards()
    {

        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }
    }
}
