using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Levels");
    }

    public void levl1()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level");
    }
    public void levl2()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level2");
    }
    public void levl3()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level3");
    }

    public void Controls()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("ControlsScene");
    }

    public void Options()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("OptionsScene");
    }

    public void Credits()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("CreditsScene");
    }

      public void ExitGame()
    {
      Cursor.lockState = CursorLockMode.None;
      Application.Quit();
    }
}
