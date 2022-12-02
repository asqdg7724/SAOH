using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{ 
    public void GotoStage1()
    {
        SceneManager.LoadScene("stage1");
        PlayerPrefs.SetInt("stage1Prev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Stage1 load");
    }

    public void GotoStage2()
    {
        SceneManager.LoadScene("stage2");
        PlayerPrefs.SetInt("stage2Prev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Stage2 load");
    }

    public void GotoStage3()
    {
        SceneManager.LoadScene("stage3");
        PlayerPrefs.SetInt("stage3Prev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Stage3 load");
    }

    public void GotoOption()
    {
        SceneManager.LoadScene("Option");
        PlayerPrefs.SetInt("OptionPrev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Option Page load");
    }

    public void GotoPausePage()
    {
        SceneManager.LoadScene("Pause");
        PlayerPrefs.SetInt("PausePrev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Pause Page load");
    }

    public void GotoMainPage()
    {
        SceneManager.LoadScene("1.MainPage");
        PlayerPrefs.SetInt("MainPagePrev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Main Page load");
    }

    public void GotoGameOver()
    {
        SceneManager.LoadScene("GameOver");
        PlayerPrefs.SetInt("GameOverPrev", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("GameOver Page load");
    }

    public void GotoStageClear()
    {
        SceneManager.LoadScene("StageClear");
        Debug.Log("StageClear Page load");
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
