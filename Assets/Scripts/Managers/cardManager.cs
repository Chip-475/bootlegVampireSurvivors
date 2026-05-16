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
    [Space]
    public List<Transform> spawnPoints = new List<Transform>();
    private List<CardEntry> spawnableCards = new List<CardEntry>();
    [Space]
    private List<GameObject> spawnedCards = new List<GameObject>();

    public int choices = 3;
    public GameObject cardPanel;

    void Awake()
    {
        instance = this;
        spawnableCards = cards;
    }

    [ContextMenu("Run spawnCards")]
    public void spawnCards()
    {
        Time.timeScale = 0;
        cardPanel.SetActive(true);

        int cardsToSpawn = Mathf.Min(choices, spawnableCards.Count);
        if (cardsToSpawn == 0)
        {
            Debug.LogWarning("cardManager: no valid cards to spawn.");
            return;
        }

        List<int> index = new List<int>();
        for (int i = 0; i < cardsToSpawn; i++)
        {
            print("index cycle iteration " + i);

            int x = Random.Range(0, spawnableCards.Count);
            print("index " + x);
            if (index.Contains(x)) { i--; continue; }
            index.Add(x);

            CardEntry entry = spawnableCards[x];
            if (entry.levelable && entry.effect.lvl == 5)
            {
                spawnableCards.Remove(entry);
                i--;
                continue;
            }
            else if(!entry.levelable && entry.effect.lvl == 1)
            {
                spawnableCards.Remove(entry);
                i--;
                continue;
            }

            spawnedCards.Add(Instantiate(entry.prefab, spawnPoints[i]));
            print("card spawned");

            spawnedCards[i].TryGetComponent(out cardChoice choice);
            if (choice != null)
            {
                choice.setup(instance, entry);
            }
            else
            {
                print($"card {spawnedCards[i]} doesnt contain cardChoice");
                continue;
            }
        }
    }

    public void pickCard(CardEntry entry)
    {
        if (!canSpawn(entry)) return;
        print("card picked");

        entry.effect.GetComponent<ICardEffect>().cardEffect();
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
        foreach (GameObject x in spawnedCards)
        {
            Destroy(x);
        }
    }
}