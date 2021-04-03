using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    public Text playerNameText;
    public Text playerScoreText;
    public Text playerLivesText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = "Player: " + MainMenuOptions.username;
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Score: " + WordManager.score;
        playerLivesText.text = "Lives: " + WordManager.lives;
    }
}
