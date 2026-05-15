using UnityEngine;

public class moveSpeedUp : MonoBehaviour
{
    public void effect()
    {
        player.playerInstance.spd += player.playerInstance.spd * 0.2f;
    }
}
