using UnityEngine;
using System.Collections;
public class attackSpeedUp : MonoBehaviour, ICardEffect
{
    public void effect()
    {
        player.playerInstance.aspd += player.playerInstance.aspd * 0.2f;
    }

    public void cardEffect()
    {
        effect();
    }
}
