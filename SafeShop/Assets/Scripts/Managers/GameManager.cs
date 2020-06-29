using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        if (SaveSystem.LoadLevelData() != null)
        {
            levelData = SaveSystem.LoadLevelData();
/*            Debug.Log("level At" + levelData.levelAt);
            Debug.Log("star level" + levelData.levelScores[SceneManager.GetActiveScene().buildIndex]);*/
        }
        else
        {
            levelData = new LevelData();
        }
        Array.Resize(ref levelData.levelScores, SceneManager.sceneCountInBuildSettings);
    }
    #endregion

    private bool gameEnded = false;
    private bool levelComplete = false;
    private bool gameIsPaused = false;
    private TimerCountDown timer;
    [HideInInspector] public LevelData levelData;
    /*    public float delayRestart = 2f;
        public GameObject completeLvlUI;
        public GameObject gameOverUI;*/
    //public UIManager uIManager;


    private void Start()
    {
        //Screen.autorotateToLandscapeLeft;

    }
    public void ResetLevels()
    {
        levelData = new LevelData();
        SaveSystem.SaveLevelAt(levelData);

    }
    public void CompleteLevel()
    {
        levelComplete = true;
        if (gameEnded == false)
        {
            UpdateLevelAt();// levelData.levelScores[SceneManager.GetActiveScene().buildIndex] = nbStars;
            UpdateStarScore();// levelData.levelAt = SceneManager.GetActiveScene().buildIndex + 1;
            SaveSystem.SaveLevelAt(levelData);
            //Debug.Log("Loop complete");
            GetComponent<UIManager>().ShowLevelComplete();
        }
    }

    private void UpdateLevelAt()
    {
        if (levelData.levelAt < (SceneManager.GetActiveScene().buildIndex + 1))
        {
            levelData.levelAt = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log("Level Updated");
        }

    }

    private void UpdateStarScore()
    {
        int star = CalculateLevelStars();
        if (levelData.levelScores[SceneManager.GetActiveScene().buildIndex] < star)
        {
            levelData.levelScores[SceneManager.GetActiveScene().buildIndex] = star;
            GetComponent<UIManager>().ShowStarLevel(star);
        }
        else
        {
            GetComponent<UIManager>().ShowStarLevel(levelData.levelScores[SceneManager.GetActiveScene().buildIndex]);
        }

    }
    public void EndGame()
    {
       
        if(!levelComplete)
        {
            
            if (gameEnded == false)
            {

               GetComponent<UIManager>().ShowGameOver();
                gameEnded = true;
            }
        }

    }

    public void TimeUpEndGame()
    {
        if (!levelComplete)
        {
            if (gameEnded == false)
            {
                gameEnded = true;
                GetComponent<UIManager>().ShowTimesUp();
   
            }
        }

    }

    public void Restart()
    {
        SetTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if(!gameIsPaused)
        {
            //StartCoroutine(CRpause());
            Time.timeScale = 0f;
            GetComponent<UIManager>().ShowPauseMenu();
            gameIsPaused = true;
        }

        //Time.timeScale = 0f;
        //GetComponent<UIManager>().ShowPauseMenu();
    }

/*    IEnumerator CRpause()
    {
        GetComponent<UIManager>().ShowPauseMenu();

        yield return new WaitForSeconds(.3f);

        Time.timeScale = 0f;
    }*/

    public void Resume()
    {
        SetTimeScale();
        GetComponent<UIManager>().HidePauseMenu();
        
        //Time.timeScale = 1f;
        
    }

    private void SetTimeScale()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void NextLevel()
    {
       //Debug.Log("Nb scene=" + SceneManager.sceneCount + "vs #current=" + SceneManager.GetActiveScene().buildIndex);
        if(SceneManager.sceneCountInBuildSettings> SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Debug.Log("delegate" + levelIndex) ;
    }

    public void GotoMenu()
    {
        //StartCoroutine(goMenuCo());
        SetTimeScale();
        SceneManager.LoadScene(0);
    }

    public void BlackFridayLevel()
    {
        SceneManager.LoadScene(6);
    }

    IEnumerator goMenuCo()
    {
        SetTimeScale();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
       // Debug.Log(Time.timeScale);
    }

/*    public void SaveLevel(int levelAt, int levelStars )
    {
        SaveSystem.SaveLevelAt(new LevelData(levelAt, levelStars));
    }*/

    public int CalculateLevelStars()
    {
        int health = GetComponent<HealthManager>().currentHealth;
        timer = GetComponent<TimerCountDown>();
        float time = timer.timeDuration;
        int stars = 0;
        if ((health <= 1 && time < 45 && time > 20) | (health == 2 && time < 30))
        {
            stars = 1;
        }
        else if ((health <= 1 && time > 45) | (health == 2 && time > 30) | (health >= 3 && time < 25)) 
        {
            stars = 2;
        }
        else if (time > 25 && health >= 3)
        {
            stars = 3;
        }

        //Debug.Log("CALCULATE STAR=" + stars);
        return stars;
    }
}
