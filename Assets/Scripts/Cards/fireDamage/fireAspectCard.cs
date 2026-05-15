using UnityEngine;

public class fireAspectCard : cardClass, ICardEffect
{
    private void effect()
    {
        data.fireAspectLvl++;
    }
    public void cardEffect()
    {
        effect();
    }
}
