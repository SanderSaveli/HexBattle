using UnityEngine.SceneManagement;

namespace SceneLoad
{
    public class SceneLoader: ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
