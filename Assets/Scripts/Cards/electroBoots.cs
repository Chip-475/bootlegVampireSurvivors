using UnityEngine;

public class electroBoots : MonoBehaviour
{
    [SerializeField]private float danno;
    private float tick = 0.5f;
    private float timer = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        enemyClass en = other.GetComponent<enemyClass>();
        if (en == null) return;
        timer += Time.deltaTime;
        if(timer>=tick)
        {
            en.onDamaged(danno);
            timer=0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        timer = 0f;
    }
}
