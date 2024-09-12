using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour
{
    public GameObject creditTxt;

    // Start is called before the first frame update
    void Start()
    {
        creditTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showCredit()
    {
        creditTxt.SetActive(true);
    }

    public void unshowCredit()
    {
        creditTxt.SetActive(false);
    }
}
