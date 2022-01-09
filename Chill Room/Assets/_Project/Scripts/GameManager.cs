using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   
    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
