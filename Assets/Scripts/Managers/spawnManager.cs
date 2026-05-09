using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemyList;
    public int[] enemyCost;
    public int waves=1;
    public int spawnLimit;
    public static int enemyCount;
    [ContextMenu("Run Function")]
    public void newWave()
    {
        spawnLimit = waves * 10;
        int waveCost = 0;
        int index=0;
        enemyCount = 0;
        while(waveCost<spawnLimit)
        {
            index = UnityEngine.Random.Range(0, enemyList.Length);
            if (waveCost + enemyCost[index] <= spawnLimit)
            {
                float x = UnityEngine.Random.Range(0f, 1f);
                float y = UnityEngine.Random.Range(0f, 1f);
                Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 10));
                Instantiate(enemyList[index], spawnPos, Quaternion.identity);
                enemyCount++;
                waveCost += enemyCost[index];
            }
            
        }
    }
}
