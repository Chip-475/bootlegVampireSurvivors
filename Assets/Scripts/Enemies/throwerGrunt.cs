using UnityEngine;

public class throwerGrunt : enemyClass
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

        spawnManager.throwerGruntAmount++;
    }
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        follow();
        if (canShoot && sinceShoot >= shootCD) shoot();
        sinceShoot += Time.deltaTime;
    }

    protected void follow()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > fovRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
            canShoot = false;
        }
        else canShoot = true;

        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }
    public void shoot()
    {
        Instantiate(projectile, shootPoint.position, Quaternion.identity, transform);
        sinceShoot = 0;
    }

    private void OTriggerEnter2D(Collider2D other)
    {
        if ((!(other.gameObject.tag == "Obstacle")) || ((other.gameObject.tag == "Player"))) 
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.damage(atk);
            }
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        spawnManager.throwerGruntAmount--;
    }
}