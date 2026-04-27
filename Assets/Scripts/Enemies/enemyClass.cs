using UnityEngine;

public abstract class enemyClass : MonoBehaviour, IDamageable
{
    protected GameObject player;
    protected Rigidbody rb;

    protected float hp, hpMax;
    protected float spd, atkSpd;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    protected void onDamaged(float damage)
    {
        hp -= damage;
        Mathf.Clamp(hp, 0, hpMax);
    }

    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
