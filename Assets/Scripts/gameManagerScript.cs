using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameManagerScript : MonoBehaviour
{
    public Text scoreText, gameOverText;
    public AudioSource audioS;
    public AudioClip ballooneffect, gameOvereffect;
    

    int currentScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    public void addScore (int amount)
    {
        currentScore+=amount;
        scoreText.text = "Score: " + currentScore.ToString();
        audioS.PlayOneShot(ballooneffect);
    }

    public void gameOver()
    {
        gameOverText.enabled = true;
        audioS.PlayOneShot(gameOvereffect);

    }
    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("R tuþuna bastýn!");
        }
    }
}
