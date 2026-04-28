using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [Header("Misc")]
    public Rigidbody2D rb;
    public GameObject scytheTrf;
    public scythe scythe;
    public bool canAttack = true;
    public Vector3 mousePosition;
    public Vector3 mouseWorldPosition;

    [Header("Stats")]
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
    void Update()
    {
        // Mouse Positions Assignment
        mousePosition = Mouse.current.position.ReadValue();
        mouseWorldPosition = new Vector3(Camera.main.ScreenToWorldPoint(mousePosition).x, Camera.main.ScreenToWorldPoint(mousePosition).y, 0);

        // Player Flip
        var x = mouseWorldPosition.x >= transform.position.x ? transform.localScale = new Vector3(1, 1, 1) : transform.localScale = new Vector3(-1, 1, 1);

        // Player Movement
        rb.linearVelocity = moveInput * spd;
    }

    // Player Controls
    public void move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void attack(InputAction.CallbackContext context)
    {
        if (!context.performed || !canAttack) return;

        StartCoroutine(scythe.swing());
    }
}
