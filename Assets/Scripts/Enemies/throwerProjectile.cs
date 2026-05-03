using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class throwerProjectile : MonoBehaviour
{
    private float damage;
    private float lifetime;
    private Rigidbody2D rb;
    private Collider2D projectileCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        projectileCollider = GetComponent<Collider2D>();
        projectileCollider.isTrigger = true;
    }

    public void Init(Vector2 direction, float speed, float projectileDamage, float projectileLifetime)
    {
        damage = projectileDamage;
        lifetime = projectileLifetime;

        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }

        transform.rotation = utilitiesDB.LookAt2D(direction);
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.damage(damage);
        }

        Destroy(gameObject);
    }
}
