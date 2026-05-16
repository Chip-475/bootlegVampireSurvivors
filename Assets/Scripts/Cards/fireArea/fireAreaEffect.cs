using UnityEngine;

public class fireAreaEffect : cardClass, ICardEffect
{
    public GameObject area;
    public void effect()
    {
        Instantiate(area, transform.position, Quaternion.identity);
    }
    public void cardEffect()
    {
        effect();
    }
}
