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

    // Cards
    public static bool electroBoots;
    public static bool iceAura;
    public static bool fireDamage;
    public static bool moveSpeed;
    public static bool orbitingBlades;
    public static bool rangeIncrease;

    // Counters
    public static int killCount=0;
}
