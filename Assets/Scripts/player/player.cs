using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour, IDamageable
{
    [Header("Misc")]
    public Rigidbody2D rb;
    public GameObject scytheTrf;
    public scythe scythe;

    public gameManager gameManager;

    public bool canAttack = true;

    public Vector3 mousePosition;
    public Vector3 mouseWorldPosition;

    [Header("Stats")]
    public float hp;
    private float hpMax;
    public float atk;
    public float spd;
    public float aspd;

    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scythe = GetComponentInChildren<scythe>();
        scytheTrf.SetActive(true);
    }
    void FixedUpdate()
    {
        hpMax = hp;

        // Mouse Positions Assignment
        mousePosition = Mouse.current.position.ReadValue();
        mouseWorldPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePosition).x, Camera.main.ScreenToWorldPoint(mousePosition).y, 0);

        // Player Rotation
        transform.rotation = utilitiesDB.LookAt2D(mouseWorldPosition - transform.position);
        var x = mouseWorldPosition.x >= transform.position.x ? transform.localScale = new Vector3(1, 1, 1) : transform.localScale = new Vector3(1, -1, 1);

        // Player Movement
        rb.linearVelocity = moveInput * spd;
    }

    // Player Controls
    public void move(InputAction.CallbackContext context)
    {
        if(data.isPaused) return;

        moveInput = context.ReadValue<Vector2>();
    }
    public void attack(InputAction.CallbackContext context)
    {
        if (!context.performed || !canAttack || data.isPaused) return;

        StartCoroutine(scythe.swing());
    }
    public void togglePause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        gameManager.togglePause();
    }

    // Player Misc
    public void onDamaged(float damage)
    {
        hp -= damage;
        Mathf.Clamp(hp, 0, hpMax);
        if (hp == 0) Destroy(gameObject);
        print("Damaged for: " + damage + "\n" + "Remaining HP: " + hp + "\n");
    }

    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
