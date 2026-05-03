using UnityEngine;

public class throwerGrunt : enemyClass
{
    [Header("Thrower")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float preferredDistance = 8f;
    [SerializeField] private float retreatDistance = 5f;
    [SerializeField] private float shootCooldown = 2f;
    [SerializeField] private float projectileSpeed = 9f;
    [SerializeField] private float projectileLifetime = 5f;

    private float shootTimer;

    private new void Start()
    {
        base.Start();

        spawnManager.throwerGruntAmount++;
        shootTimer = shootCooldown;
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        keepDistance();
        aimAtPlayer();
        handleShooting();
    }

    private void keepDistance()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > preferredDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
        }
        else if (distance < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -spd * Time.deltaTime);
        }
    }

    private void aimAtPlayer()
    {
        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }

    private void handleShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer > 0f) return;

        shootTimer = shootCooldown;
        shoot();
    }

    private void shoot()
    {
        if (projectilePrefab == null) return;

        Transform spawnPoint = shootPoint != null ? shootPoint : transform;
        GameObject projectileObject = Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);

        if (projectileObject.TryGetComponent<throwerProjectile>(out throwerProjectile projectile))
        {
            Vector2 direction = (player.transform.position - spawnPoint.position).normalized;
            projectile.Init(direction, projectileSpeed, atk, projectileLifetime);
        }
    }

    private void OnDestroy()
    {
        spawnManager.throwerGruntAmount--;
    }
}
