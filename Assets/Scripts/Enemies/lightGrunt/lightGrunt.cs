using UnityEngine;

public class lightGrunt : enemyClass
{
    private new void Start()
    {
        base.Start();

    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        follow();
    }

    public void follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, spd * Time.deltaTime);
        transform.rotation = utilitiesDB.LookAt2D(transform.position - playerObj.transform.position);
    }

    private new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
    }
}
