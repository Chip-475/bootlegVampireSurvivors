using UnityEngine;

public class healthUp : MonoBehaviour
{
    public void effect()
    {
        player.playerInstance.hp += player.playerInstance.hp * 0.2f;
    }
}
