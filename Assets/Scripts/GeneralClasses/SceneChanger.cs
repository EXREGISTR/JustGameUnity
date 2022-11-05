using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}