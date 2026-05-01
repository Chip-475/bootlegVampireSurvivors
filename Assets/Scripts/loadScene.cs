using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public const string loadingScreen = "loadingScreen";
    public string toLoad;
    public async void loadFunc()
    {
        await SceneManager.LoadSceneAsync(loadingScreen, LoadSceneMode.Single);
        await SceneManager.LoadSceneAsync(toLoad, LoadSceneMode.Single);
    }
}
