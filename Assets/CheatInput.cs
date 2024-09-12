using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatInput : MonoBehaviour
{

    [SerializeField] private Countdown _countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("MainGame");
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            _countdown.TimeLeft += 30;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            _countdown.TimeLeft -= 30;
        }
    }
}
