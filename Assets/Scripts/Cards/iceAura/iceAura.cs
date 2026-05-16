using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class iceAura : cardClass, ICardEffect
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) collision.GetComponent<enemyClass>().spd *= 0.5f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) collision.GetComponent<enemyClass>().spd *= 2;
    }

    public void effect()
    {
        transform.localScale = new Vector3(radius * 2, radius * 2, 0);
        print("iceAura picked");
    }
    public void cardEffect()
    {
        effect();
    }
}
