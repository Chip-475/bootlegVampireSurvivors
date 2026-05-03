using System.Collections;
using UnityEngine;

public class rangedGruntProj : MonoBehaviour
{
    IDamageable IDamageable;

    public float spd;
    private float atk;
    private Rigidbody2D self;
    private throwerGrunt parent;
    private Vector3 dir;

    private void Start()
    {
        Destroy(gameObject, 10);

        self = GetComponent<Rigidbody2D>();
        parent = transform.parent.GetComponent<throwerGrunt>();

        dir = ((Vector2)(parent.player.transform.position) - self.position).normalized;
        atk = parent.atk;

        transform.SetParent(null, true);

        self.linearVelocity = new Vector2(spd * dir.x, spd * dir.y);
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
}
