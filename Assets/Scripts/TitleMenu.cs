using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleMenu : MonoBehaviour
{
 
    public AudioMixer myMixer;

    void Start() {
        //Upon loading into this scene it will always make the mouse cursor viewable and moveable
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //This function makes it when it is clicked it will take the player to the next scene in the index order
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //This function takes the player to the controls scene once clicked
       public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    //This closes the game once clicked
    public void QuitGame()
    {
        Application.Quit();
    }

    //Volume slider
    public void SetVolume (float volume) {
        myMixer.SetFloat("volume", volume);
    }

    //Fullscreen toggle
    public void SetFullscreen (bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

}