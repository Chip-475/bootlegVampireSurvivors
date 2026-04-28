using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scythe : MonoBehaviour
{
    IDamageable IDamageable;
    List<IDamageable> toDamage = new List<IDamageable>();

    public player player;
    public SpriteRenderer sr;
    public BoxCollider2D bc;
    public AnimationCurve curve;
    
    void Start()
    {
        player = GetComponentInParent<player>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;

        curve = AnimationCurve.EaseInOut(0, 0, player.aspd / 2, 180);
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;

        transform.localEulerAngles = new Vector3(0, 0, 45);
    }

    public IEnumerator swing()
    {
        player.canAttack = false;

        sr.enabled = true;

        yield return new WaitForSeconds(player.aspd / 2);
        bc.enabled = true;

        // Swing
        float time = 0;
        while (time < player.aspd)
        {
            var x = curve.Evaluate(time);
            transform.Rotate(0, 0, -(x / player.aspd) * Time.deltaTime);

            yield return null;
            time += Time.deltaTime;
        }

        // Damage Enemies
        yield return new WaitForSeconds(player.aspd / 5);
        for (int i = 0; i < toDamage.Count; i++)
        {
            toDamage[i].damage(player.atk);
        }
        toDamage.Clear();

        yield return new WaitForSeconds(player.aspd / 2);
        
        bc.enabled = false;
        sr.enabled = false;
        transform.localEulerAngles = new Vector3(0, 0, 45);

        player.canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var x = other.GetComponent<IDamageable>();
        toDamage.Add(x);
    }
}
