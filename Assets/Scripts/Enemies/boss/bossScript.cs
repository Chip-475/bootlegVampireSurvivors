using UnityEngine;

public class bossScript : enemyClass
{
    private new void Start()
    {
        base.Start();

    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
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
