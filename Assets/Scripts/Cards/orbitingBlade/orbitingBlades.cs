using UnityEngine;

public class orbitingBlades : MonoBehaviour
{
    public GameObject playerObj;
    public player player;
    public float distance;
    private float angle;
    public float angSpeed;
    float x, y;

    void Start()
    {
        playerObj = transform.parent.gameObject;
        player = playerObj.GetComponent<player>();
    }
    void Update()
    {
        if (playerObj == null) return;

        angle += angSpeed * Time.deltaTime;
        x = playerObj.transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        y = playerObj.transform.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

        transform.position = new Vector3(x, y, 0);
        transform.Rotate(Vector3.forward * 500f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var bers))
        {
            bers.damage(player.atk);
            Debug.Log("blade hit");
        }
    }
}
