using UnityEngine;
using System.Collections;
public class haste : MonoBehaviour
{
    public void attacoVeloce(player p,float velocita)
    {
        p.aspd /= velocita;  //decremento la velocita permanente
        Destroy(this); //nonn serve piu e si distrugge
    }
}
