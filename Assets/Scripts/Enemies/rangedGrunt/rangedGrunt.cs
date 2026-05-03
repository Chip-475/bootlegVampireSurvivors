using UnityEngine;

public class rangedGrunt : enemyClass
{
    public GameObject projectile;
    public Transform shootPoint;
    public float shootCD;
    private float sinceShoot;
    private bool canShoot;
    private new void Start()
    {
        base.Start();
        canShoot = false;
        sinceShoot = shootCD;

        spawnManager.rangedGruntAmount++;
    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        follow();
        if(canShoot && sinceShoot >= shootCD) shoot();
        sinceShoot += Time.deltaTime;
    }

    protected void follow()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > fovRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
            canShoot = false;
        }else canShoot = true;

        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }
    public void shoot()
    {
        Instantiate(projectile, shootPoint.position, Quaternion.identity, transform);
        sinceShoot = 0;
    }

    private void OnDestroy()
    {
        spawnManager.rangedGruntAmount--;
    }
}
