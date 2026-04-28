using UnityEngine;

public class lightGrunt : enemyClass
{
    private new void Start()
    {
        base.Start();

        spawnManager.lightGruntAmount++;
    }

    private void OnDestroy()
    {
        spawnManager.lightGruntAmount--;
    }
}
