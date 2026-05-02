using UnityEngine;

public class heavyGrunt : enemyClass
{
    private new void Start()
    {
        base.Start();

        spawnManager.heavyGruntAmount++;
    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        follow();
    }

    protected void follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);

        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }

    private void OnDestroy()
    {
        spawnManager.heavyGruntAmount--;
    }
}
