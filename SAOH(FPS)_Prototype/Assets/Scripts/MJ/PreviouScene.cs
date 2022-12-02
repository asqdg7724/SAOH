using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreviouScene : MonoBehaviour
{
    int sceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("OptionPrev"));
    }


  
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
