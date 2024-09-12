using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{

    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager != null)
        {
            _gameManager._onWin += ActivateCursor;
        }

        SetupCursor();
    }
    private void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager._onWin -= ActivateCursor;
        }
    }

    private void ActivateCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void DesactivateCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void SetupCursor()
    {
        string name = SceneManager.GetActiveScene().name;

        switch (name)
        {
            case "MainGame":
                if (_gameManager == null)
                    break;
                DesactivateCursor();
                break;
            case "MainMenu":
                ActivateCursor();
                break;
        }
    }
}
