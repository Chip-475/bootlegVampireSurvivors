using UnityEngine;

public class menuManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject options;

    public void onMenuClick()
    {
        pause.SetActive(true);
        options.SetActive(false);
    }
    public void onOptionsClick()
    {
        pause.SetActive(false);
        options.SetActive(true);
    }
}
