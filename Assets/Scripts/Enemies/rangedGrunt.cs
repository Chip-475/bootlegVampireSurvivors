using UnityEngine;

public class rangedGrunt : enemyClass
{
    private new void Start()
    {
        base.Start();
        
        spawnManager.rangedGruntAmount++;
    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        follow();
    }

    protected void follow()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
        }

        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }

    private void OnDestroy()
    {
        spawnManager.rangedGruntAmount--;
    }
}
