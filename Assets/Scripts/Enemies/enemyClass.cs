using UnityEngine;

public abstract class enemyClass : MonoBehaviour, IDamageable
{
    [Header("Meta Data")]
    protected GameObject player;
    protected Rigidbody2D rb;
    protected Collider2D _collider;

    protected bool inRange;
    protected bool detecting;

    [Header("Stats")]
    [SerializeField] protected float hp;
    protected float hpMax;
    [SerializeField] protected float spd;

    public float fovRange;
    [Range(0, 360)] public float fovAngle;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        hpMax = hp;
    }
    protected virtual void Update()
    {
        if (hp == 0) Destroy(gameObject);
    }

    protected void onDamaged(float damage)
    {
        hp -= damage;
        Mathf.Clamp(hp, 0, hpMax);
    }
    protected void detect()
    {
        
    }

    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
