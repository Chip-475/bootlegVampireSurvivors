using UnityEngine;

public class moveSpeedUp : MonoBehaviour, ICardEffect
{
    public void effect()
    {
        player.playerInstance.spd += player.playerInstance.spd * 0.2f;
    }
    public void cardEffect()
    {
        effect();
    }
}
