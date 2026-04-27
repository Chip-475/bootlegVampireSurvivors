using System.Collections;
using UnityEngine;

public class scythe : MonoBehaviour
{
    public player player;
    IDamageable IDamageable;
    void Start()
    {
        player = GetComponentInParent<player>();
        transform.rotation = new Quaternion(0, 0, 0.382683426f, 0.923879564f);
    }

    public IEnumerator swing()
    {
        float t = 0;
        Quaternion toRot = new Quaternion(0, 0, -0.382683426f, 0.923879564f);
        while (t < player.aspd)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, toRot, t/player.aspd);
            yield return null;
        }
        transform.rotation = new Quaternion(0, 0, 0.382683426f, 0.923879564f);
        yield return new WaitForSeconds(0.5f);
        player.canAttack = true;
    }
}
