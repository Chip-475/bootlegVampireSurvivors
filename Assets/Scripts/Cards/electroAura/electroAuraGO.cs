using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class electroAuraGO : cardClass, ICardEffect
{
    private List<GameObject> list = new List<GameObject>();

    private new void Start()
    {
        StartCoroutine(damage());
    }
    IEnumerator damage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            foreach (GameObject enemy in list.ToArray())
            {
                if(enemy != null) enemy.GetComponent<IDamageable>().damage(player.atk / 2);
                else list.Remove(enemy);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")) list.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) list.Remove(collision.gameObject);
    }

    public void effect()
    {
        transform.localScale = new Vector2(radius * 2, radius * 2);
        print("electroAura picked");
    }
    public void cardEffect()
    {
        effect();
    }
}
