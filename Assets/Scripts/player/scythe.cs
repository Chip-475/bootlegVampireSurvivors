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

    [System.Serializable]
    public struct livelloFuoco
    {
        public float damagePerTick;
        public float duration;
    }

    [Header("Livelli")]
    public livelloFuoco level1;
    public livelloFuoco level2;
    public livelloFuoco level3;
    public float interval;

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

        bc.enabled = false;
        yield return new WaitForSeconds(player.aspd / 2);

        // Swing
        float time = 0;
        bc.enabled = true;
        while (time < player.aspd)
        {
            var x = curve.Evaluate(time);
            transform.Rotate(0, 0, -(x / player.aspd) * Time.deltaTime);

            yield return null;
            time += Time.deltaTime;
        }
        bc.enabled = false;

        yield return new WaitForSeconds(player.aspd / 2);   
        
        sr.enabled = false;
        transform.localEulerAngles = new Vector3(0, 0, 45);

        player.canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable))
        {
            other.GetComponent<IDamageable>().damage(player.atk);
            if(data.fireAspectLvl > 0)
            {
                var dot = other.gameObject.AddComponent<DoT>();
                dot.damage = (player.atk * 0.2f) * data.fireAspectLvl;
                dot.duration = 3;
                dot.tick = 0.5f;
            }
        }
    }

    public void applicaFuoco(int livello)
    {
        livelloFuoco selezionato;
        switch(livello)
        {
            case 1:
                selezionato = level1;
                break;
            case 2:
                selezionato = level2;
                break;
            case 3:
                selezionato = level3;
                break;
            default:
                selezionato = level1;
                break;
        }
        foreach(IDamageable tar in toDamage)
        {
            if(tar is MonoBehaviour)
            {
                MonoBehaviour target = (MonoBehaviour)tar;
                fireDamagelvl1 fire = target.gameObject.AddComponent<fireDamagelvl1>();
                fire.Initialize(tar,selezionato.damagePerTick,selezionato.duration, interval);   
            }
        }
    }
}
