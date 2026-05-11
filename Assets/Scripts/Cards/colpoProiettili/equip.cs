using UnityEngine;

public class equip : MonoBehaviour
{
    public GameObject prefab;
    public float cooldown;
    private float ultimo = -30f;  //inizia a -30per il primo colpo

    public bool isSpara()
    {
        if(Time.deltaTime>=ultimo+cooldown) return true;
        else return false;
    }
    
    public void spara(Vector2 spawn,Vector2 dir)
    {
        GameObject pro = Instantiate(prefab, dir);
        proiettili logic = pro.GetComponent<proiettili>();
        logic.direz = dir;
        pro.transform.rotation = utilitiesDB.LookAt2D(dir);
        ultimo=Time.deltaTime;
    }

}
