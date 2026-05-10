using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class fireArea : MonoBehaviour
{
    public player player;
    public CircleCollider2D circleCollider;
    public float duration;
    public float radius;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        circleCollider = GetComponent<CircleCollider2D>();
        Destroy(gameObject, duration);

        circleCollider.radius = radius;
        transform.localScale = new Vector3(radius * 2, radius * 2, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !collision.gameObject.TryGetComponent<DoT>(out _))
        {
            DoT dot = collision.gameObject.AddComponent<DoT>();
            dot.damage = player.atk / 5;
            dot.duration = 5f;
            dot.tick = 1 / 3f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
