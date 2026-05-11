using UnityEngine;

public class proiettili : MonoBehaviour
{
    public float speed;
    public float damage;
    public Vector2 direz;

    void Update()
    {
        transform.Translate(direz*speed*Time.deltaTime);
    }
    private OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IDamageble>(out var target))
        {
            target.damage(damage);
            Destroy(gameObject);
        }
    }
