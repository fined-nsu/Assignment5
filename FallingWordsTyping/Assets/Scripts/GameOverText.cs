using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    //public Text gameOverText;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector2(Random.Range(50, 1000), 1000);
    }

    public void ReturntoMainMenu()
    {
        WordManager.score = 0;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
