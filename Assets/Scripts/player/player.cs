using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player : MonoBehaviour, IDamageable
{
    [Header("Misc")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public GameObject scytheTrf;
    public scythe scythe;

    public gameManager gameManager;
    public hpBar hpBar;
    public xpBar xpBar;

    public bool isDead;
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
        sr = GetComponent<SpriteRenderer>();

        scythe = GetComponentInChildren<scythe>();
        scytheTrf.SetActive(true);

        hpBar = GetComponent<hpBar>();
        xpBar = GetComponent<xpBar>();
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
         //<3| >--------<| <3
        {
            
        }
    }

    // Player Controls
    public void move(InputAction.CallbackContext context)
    {
        if(data.isPaused || isDead == true) return;

        moveInput = context.ReadValue<Vector2>();
    }
    public void attack(InputAction.CallbackContext context)
    {
        if (!context.performed || !canAttack || data.isPaused || isDead == true) return;

        StartCoroutine(scythe.swing());
    }
    public void togglePause(InputAction.CallbackContext context)
    {
        if (!context.performed || isDead == true) return;

        gameManager.togglePause();
    }

    // Couroutines
    

    // Player Misc
    public void onDamaged(float damage)
    {
        hpBar.hpBarCurve = AnimationCurve.EaseInOut(0, hp / 100f, hpBar.animTime, (hp - damage) / 100f);
        hp -= damage;
        Mathf.Clamp(hp, 0, hpMax);
        StartCoroutine(hpBar.hpBarMovement());
        if (hp == 0) { sr.enabled = false; isDead = true; }
        print("Damaged for: " + damage + "\n" + "Remaining HP: " + hp + "\n");
    }
    public void onKill(float toGain)
    {
        data.xp += toGain;
        xpBar.xpBarCurve = AnimationCurve.EaseInOut(0, (data.xp - toGain) / 100f, xpBar.animTime, data.xp / 100f);
        StartCoroutine(xpBar.xpBarMovement());
        print("onKill");
    }

    // Interface Methods
    public void damage(float damage)
    {
        onDamaged(damage);
    }
}
