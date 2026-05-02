using UnityEngine;
using UnityEngine.Rendering;

public abstract class enemyClass : MonoBehaviour, IDamageable
{
    [Header("Meta Data")]

    IDamageable IDamageable;
    protected GameObject player;
    protected Rigidbody2D rb;
    protected Collider2D _collider;

    protected bool inRange;
    protected bool detecting;

    [Header("Stats")]
    [SerializeField] protected float hp;
    protected float hpMax;
    [SerializeField] protected float atk;
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
    protected virtual void FixedUpdate()
    {
        follow();
    }

    protected void onDamaged(float damage)
    {
        hp -= damage;
        Mathf.Clamp(hp, 0, hpMax);
        if (hp == 0) Destroy(gameObject);
    }

    //protected void detect()
    //{
    //    // To code later
    //}

    protected void follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
        transform.rotation = utilitiesDB.LookAt2D(player.transform.position - transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        var x = collision.gameObject.GetComponent<IDamageable>();
        x.damage(atk);
        Destroy(gameObject);
    }

    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
