using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    public Button resumeButton;
    public Button saveButton;
    public Button loadButton;
    public Button exitButton;
    public GameObject panel;
    public WordSpawner sp;
    public Toggle sound;
    public AudioSource audioplayer;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
            sp.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        sp.enabled = true;
        panel.SetActive(false);
    }

    private Save CreateSaveGame()
    {
        Save save = new Save();
        save.lives = WordManager.lives;
        save.score = WordManager.score;
        save.dropSpeed = MainMenuOptions.dropSpeedChange;
        save.spawnSpeed = MainMenuOptions.spawnSpeedChange;

        return save;
    }


    public void SaveGame()
    {
        Save save = CreateSaveGame();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            WordManager.score = save.score;
            WordManager.lives = save.lives;
            Debug.Log("Save Loaded");
        }
        else
        {
            Debug.Log("No save file found!");
        }

    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGame();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void ToggleSound()
    {
        if(sound.isOn)
        {
            audioplayer.enabled = true;
        }
        else
        {
            audioplayer.enabled = false;
        }
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
