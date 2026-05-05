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
    // //  //<3| >--------<| <3
        protected void follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, spd * Time.deltaTime);

        transform.rotation = utilitiesDB.LookAt2D(playerObj.transform.position - transform.position);
    }

    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
        spawnManager.heavyGruntAmount--;
    }
}
