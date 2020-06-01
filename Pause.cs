using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GameIspause = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIspause)
            {
                Resume();
            }
            else
            {
                Pause1();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIspause = false;
    }

    void Pause1()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIspause = true;
    }


}
