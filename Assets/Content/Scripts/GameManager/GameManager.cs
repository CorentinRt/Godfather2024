using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public PlayerPrey preyScript;
    public Countdown clockScript;

    public GameObject preyPlayer;
    public GameObject hunterPlayer;

    // Start is called before the first frame update
    private void ResultCondition()
    {
        if (preyPlayer != null)
        {
            Debug.Log("Le chasseur � gagn�");
            // Mettre le passage � la phase suivante
        }
        if (hunterPlayer != null)
        {
            Debug.Log("La proie � gagn�");
            // Mettre le passage � la phase suivant
        }

        if (clockScript.TimeLeft <= 0)
        {
            Debug.Log("La proie � gagn�");
            // peut-�tre animation de d�faite 
            SceneManager.LoadScene(3);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ResultCondition();
    }
}
