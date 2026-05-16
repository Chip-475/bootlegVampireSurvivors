using UnityEngine;
using UnityEngine.UI;
public class enemyHP : MonoBehaviour
{
    public enemyClass enemyClass;
    public Image hpBar;
    void Update()
    {
        hpBar.fillAmount = enemyClass.hp/enemyClass.hpMax;
    }
}
