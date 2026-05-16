using UnityEngine;

public class healthUp : cardClass, ICardEffect
{
    public void effect()
    {
        player.playerInstance.hp += player.playerInstance.hp * 0.2f;
    }
    public void cardEffect()
    {
        effect();
    }
}
