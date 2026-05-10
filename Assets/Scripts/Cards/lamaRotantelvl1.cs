using UnityEngine;

public class lamaRotante : MonoBehaviour
{
    [SerializeField] private player _play;
    [SerializeField] private float velocita;
    [SerializeField] private float dist;
    private float ang;
    float x, y;
    void Start()
    {
        if (_play == null) _play = FindObjectOfType<player>(); //cosi trova il player nella scena
    }
    void Update()
    {
        if(_play == null) return;
        ang += velocita * Time.deltaTime;//calcolo posizioni cosi puo giraee
        x=_play.transform.position.x+Mathf.Cos(ang*Mathf.Deg2Rad)*dist;
        y=_play.transform.position.y + Mathf.Sin(ang * Mathf.Deg2Rad)*dist;
        this.transform.position=new Vector3(x,y,0);
        this.trasform.Rotate(Vector3.forward*500f*Time.deltaTime);//ruota su stessa
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IDamageable>(out var bers))
        {
            bers.damage(_play.atk);
            Debug.Log("Fatto");
        }
    }
}
