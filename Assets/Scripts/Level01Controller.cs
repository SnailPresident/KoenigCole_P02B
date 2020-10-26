using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    int _currentScore;
    public GameObject Menu;
    bool showMenu = false;
    public GameObject crossHor;
    public GameObject crossVer;
    bool showCrosshair = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed.");
            if (showMenu == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                showCrosshair = false;
                Menu.SetActive(true);
                showMenu = true;
                Debug.Log("Menu On");
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                showCrosshair = true;
                Menu.SetActive(false);
                showMenu = false;
                Debug.Log("Menu Off");
            }

            if (showCrosshair == false)
            {
                crossHor.SetActive(false);
                crossVer.SetActive(false);
            }
            else
            {
                crossHor.SetActive(true);
                crossVer.SetActive(true);
            }

        }

        //Increase Score
        //TODO Replace with real implementation Later
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }*/
    }

    public void ExitLevel()
    {
        //compare score to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            //save current score as high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New High Score: " + _currentScore);
        }
        //load new Level
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        //increase score
        _currentScore += scoreIncrease;
        //update display
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

    public void LockNHideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
