using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    // Misc
    public static bool isPaused;

    // Player
    public static int level;
    public static float xp;
    public static Queue<float> xpQueue = new Queue<float>();
    public static float xpMax = 100;

    // Counters
    public static int killCount=0;
}
