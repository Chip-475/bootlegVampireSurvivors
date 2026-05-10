using UnityEngine;

public class playerSpeedlvl1 : MonoBehaviour
{
    [System.Serializable]
    public struct lvlVelocita
    {
        public float incremento;
    }
    [Header("livelli")]
    public lvlVelocita livello1 = new lvlVelocita { incremento = 2f };
    public lvlVelocita livello2 = new lvlVelocita { incremento = 5f };

    public void applica(player p,int livello)
    {
        float valore=0f;
        switch(livello)
        {
            case 1:
                valore = livello1.incremento;
                break;
            case 2:
                valore = livello2.incremento;
                break;
        }
        p.spd += valore;
        Debug.Log("ci siamo");
        Destroy(this);
    }
}
