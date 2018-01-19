using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;  

	

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1 - Time.timeScale;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
