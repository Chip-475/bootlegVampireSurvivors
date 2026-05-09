using UnityEngine;
using TMPro;
public class uiManager : MonoBehaviour
{
    public TMP_Text wave;
    public TMP_Text enemyKilled;
    public TMP_Text enemyRemaining;
    public spawnManager spawnManager;
    void Start()
    {
        wave.text = "wave:1";
        enemyKilled.text = "killed:0";
        enemyRemaining.text = "remaining:1";
    }

    void Update()
    {
        wave.text="wave:"+spawnManager.waves;
        enemyKilled.text = "killed:"+data.killCount;
        enemyRemaining.text = "remaining:" + spawnManager.enemyCount;
    }
}
