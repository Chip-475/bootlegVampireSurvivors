using UnityEngine;

public class damageUp : MonoBehaviour, ICardEffect
{
    public void effect()
    {
        player.playerInstance.atk += player.playerInstance.atk * 0.2f;
    }

    public void cardEffect()
    {
        effect();
    }
}
