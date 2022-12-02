using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject option;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        option.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameStart()
    {
        Debug.Log("Game start");
        GotoStage1();
    }
    public void GotoStage1()
    {
        SceneManager.LoadScene("stage_1");
        Debug.Log("Stage_1 load");
    }

    public void Option()
    {
        Debug.Log("Option");
        option.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();

    }

    public void CloseOption()
    {
        Debug.Log("Back to main");
        option.SetActive(false);
    }





    void Update()
    {
        
    }
}
