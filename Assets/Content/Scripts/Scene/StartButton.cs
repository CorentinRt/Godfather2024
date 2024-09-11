using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public int sceneSwitcher;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneSwitcher);
    }

}
