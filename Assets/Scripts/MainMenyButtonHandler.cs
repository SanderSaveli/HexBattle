using SceneLoad;
using UnityEngine;
using Zenject;

public class MainMenyButtonHandler : MonoBehaviour
{
    private ISceneLoader _sceneLoader;

    [Inject]
    private void Inject(ISceneLoader sceneLoadwr)
    {
        _sceneLoader = sceneLoadwr;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayOnline()
    {
        _sceneLoader.LoadScene(SceneNames.OnlinePlay);
    }

    public void PlayInOneDevice()
    {

    }
}
