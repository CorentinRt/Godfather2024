using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            Debug.Log("Le chasseur à gagné");
            // Mettre le passage à la phase suivante
        }
        if (hunterPlayer != null)
        {
            Debug.Log("La proie à gagné");
            // Mettre le passage à la phase suivant
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ResultCondition();
    }
}
