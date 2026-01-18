using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restart button pressed!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
