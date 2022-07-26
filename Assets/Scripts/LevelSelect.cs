using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
           public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Track1()
    {
        SceneManager.LoadScene("Track1");
    }

        public void Track2()
    {
        SceneManager.LoadScene("Track2");
    }
}
