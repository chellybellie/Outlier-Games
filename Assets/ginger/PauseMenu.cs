using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;  

	public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
