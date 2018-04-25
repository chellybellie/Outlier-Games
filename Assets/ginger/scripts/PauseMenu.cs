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
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1 - Time.timeScale;
    }

}
