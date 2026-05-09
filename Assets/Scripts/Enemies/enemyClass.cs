using Unity.Behavior;
using UnityEngine;

public abstract class enemyClass : MonoBehaviour, IDamageable
{
    [Header("Meta Data")]

    IDamageable IDamageable;
    public GameObject playerObj;
    public player player;
    public xpBar xpBar;
    protected Rigidbody2D prb;
    protected Collider2D _collider;
    protected BehaviorGraphAgent _graph;

    protected bool inRange;
    protected bool detecting;

    [Header("Stats")]
    [SerializeField] public float hp;
    [SerializeField ] public int spawnCost;
    protected float hpMax;
    public float xpGiven;
    [SerializeField] public float atk;
    [SerializeField] protected float spd;

    public float fovRange;
    [Range(0, 360)] public float fovAngle;


    // Virtuals
    protected virtual void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<player>();
        xpBar = playerObj.GetComponent<xpBar>();
        prb = playerObj.GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _graph = GetComponent<BehaviorGraphAgent>();

        hpMax = hp;
    }
    protected virtual void FixedUpdate()
    {
        
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable))
        {
            collision.gameObject.GetComponent<IDamageable>().damage(atk);
        }
        Destroy(gameObject);
    }
    protected virtual void OnDestroy()
    {
        data.killCount++;
        data.xpQueue.Enqueue(xpGiven);
        if(!xpBar.queueing) xpBar.startMedium();
    }


    // Misc
    protected void onDamaged(float damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, hpMax);
        if (hp == 0) { Destroy(gameObject); return; }
    }
    //protected void detect()
    //{
    //    // To do
    //}


    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
