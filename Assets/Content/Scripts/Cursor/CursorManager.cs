using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        SetupCursor();
    }

    private void SetupCursor()
    {
        string name = SceneManager.GetActiveScene().name;

        switch (name)
        {
            case "MainScene":
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case "MainMenu":
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
}
