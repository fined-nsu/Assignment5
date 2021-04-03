using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public InputField nameInput;
    public Dropdown spawnSpeedSelector;
    public Dropdown dropSpeedSelector;
    public Button startGameButton;

    public static string username;
    public static float spawnSpeedChange;
    public static float dropSpeedChange;

    void Start()
    {
        spawnSpeedChange = 1.5f;
        dropSpeedChange = 1f;
    }

    public void StartGame()
    {
        WordManager.score = 0;
        WordManager.lives = 3;
        SceneManager.LoadScene(1);
        username = nameInput.text;
    }

    public void SetWordSpawnSpeed()
    {
        if(spawnSpeedSelector.value == 1)
        {
            spawnSpeedChange = 4f;
        }
        else if (spawnSpeedSelector.value == 2)
        {
            spawnSpeedChange = 2f;
        }
        else if (spawnSpeedSelector.value == 3)
        {
            spawnSpeedChange = 0.7f;
        }
        else if (spawnSpeedSelector.value == 0)
        {
            spawnSpeedChange = 1.5f;
        }
    }

    public void SetWordDropSpeed()
    {
        if (dropSpeedSelector.value == 1)
        {
            dropSpeedChange = .5f;
        }
        else if (dropSpeedSelector.value == 2)
        {
            dropSpeedChange = 1f;
        }
        else if (dropSpeedSelector.value == 3)
        {
            dropSpeedChange =2f;
        }
        else if(dropSpeedSelector.value == 0)
        {
            dropSpeedChange = 1f;
        }
    }
}
