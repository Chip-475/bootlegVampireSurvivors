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


    [System.Serializable]
    public struct livelloDanno
    {
        public float incremento;
    }

    [Header("livelli")]
    public livelloDanno lvl1 = new livelloDanno { incremento = 5f };
    public livelloDanno lvl2 = new livelloDanno { incremento = 10f };
    public livelloDanno lvl3 = new livelloDanno { incremento = 15f };

    public int lvlDanno=1;

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
        if (other.TryGetComponent<IDamageable>(out var target))
        {
            if (!toDamage.Contains(target)) toDamage.Add(target);  // per effetti fuoco e danno extra
            //other.GetComponent<IDamageable>().damage(player.atk);
            target.damage(player.atk); //danno subito allo swing
        }
    }

    private void OnTriggerExit2D(Collider2D other)  // per se in caso si allotanano dal raggio di azione
    {
        if (other.TryGetComponent<IDamageable>(out var target)) toDamage.Remove(target);
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
                Debug.Log("successo");
            }
        }
    }

    public void applicaDanno()
    {
        float dannoExtra = 0;
        switch (lvlDanno)
        {
            case 1:
                dannoExtra = lvl1.incremento;
                break;
            case 2:
                dannoExtra = lvl2.incremento;
                break;
            case 3:
                dannoExtra = lvl3.incremento;
                break;
        }
        float dannoTotale = player.atk + dannoExtra;
        foreach (IDamageable t in toDamage)
        {
            t.damage(dannoTotale);
        }
    }

    public void saliLivello()
    {
        if(lvlDanno<3)lvlDanno++;
    }

    /*
     * if(equip!=null&&equip.isSpara())
     * {
     *      Vector2 direction=player.sr.flipX? Vector2.left:Vector2.right;
     *      equip.spara(transform.position,direzione);
     * }
     */
}
