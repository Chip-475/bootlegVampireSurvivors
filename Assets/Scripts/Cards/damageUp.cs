using UnityEngine;

public class damageUp : MonoBehaviour
{
    public void effect()
    {
        player.playerInstance.atk += player.playerInstance.atk * 0.2f;
    }
}
