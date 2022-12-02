using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGamePageManager : SceneManage
{
    public GameObject pause; 
    public GameObject gameover;
    public GameObject stageclear;
    public PlayerCol player;
    public TimeLimit limit;
    public GameObject missonCP;
    public Image gameClearBG;
    public Image gameOverBG;
    public BGM_List bgmPlayer;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        pause.SetActive(false);
        option.SetActive(false);
        gameover.SetActive(false);
        stageclear.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void PauseMenu()
    {
        Debug.Log("PauseMenu");
        pause.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Resume");
        pause.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void GameOver()
    {
        bgmPlayer.BGM_SoundPlay(1);
        bgmPlayer.BGM_LoopOFF();
        Debug.Log("GameOver");
        gameover.SetActive(true);
        StartCoroutine(FadeInGameOver(3f, true));
        Cursor.visible = true;
    }
    public void StageClear()
    {
        bgmPlayer.BGM_SoundStop();
        Debug.Log("StageClear");
        stageclear.SetActive(true);
        StartCoroutine(FadeInGameClear(3f, true));
        Cursor.visible = true;
    }

    public void Main()
    {
        Debug.Log("Main");
        SceneManager.LoadScene("MainTitle");
        Time.timeScale = 1;
    }

    public void Next()
    {
        Debug.Log("Next");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("BossStage");
    }
   
    // Update is called once per frame
    void Update()
    {
     
        if(pause != null && Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            PauseMenu();
        }

        if (player.currHP <= 0 || limit.limitTime <= 0 || player.currDP >= 100)
        {
            GameOver();
        }

        if(player.currHP > 0 || limit.limitTime > 0 || player.currDP < 100 )
        {
            if (player.safe == true)
            {
                StageClear();
            }
        }
    }

    IEnumerator FadeInGameClear(float fadeTime, bool isFadeEnded)
    {
        float t = 0;

        while (t < fadeTime)
        {

            t += Time.deltaTime;

            float percent = t / fadeTime;

            if (isFadeEnded)
                gameClearBG.color = new Color(gameClearBG.color.r,
                                            gameClearBG.color.g,
                                            gameClearBG.color.b,
                                            Mathf.Lerp(0, 1f, percent));
            yield return null;
        }
        Time.timeScale = 0;
        isFadeEnded = false;
    }

    IEnumerator FadeInGameOver(float fadeTime, bool isFadeEnded)
    {
        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            float percent = t / fadeTime;

            if (isFadeEnded)
                gameOverBG.color = new Color(gameOverBG.color.r,
                                            gameOverBG.color.g,
                                            gameOverBG.color.b,
                                            Mathf.Lerp(0, 1f, percent));
            yield return null;
        }
        Time.timeScale = 0;
        isFadeEnded = false;
    }
}
