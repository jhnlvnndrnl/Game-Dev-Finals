using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public AudioSource bgm; // Assign your background music AudioSource here

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;

        // // Pause or stop audio
        // if (bgm != null)
        // {
        //     bgm.Pause(); // or bgm.Stop(); if you want it completely stopped
        // }
    }

    public void MainMenuButton()
    {
        // Resume time before changing scene
        Time.timeScale = 1;

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
