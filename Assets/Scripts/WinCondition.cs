using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    CoinCounter coinCounter;
    KillCounter killCounter;

    // Start is called before the first frame update
    void Awake()
    {
       coinCounter = GameObject.Find("Coin Counter Canvas 2D").GetComponentInChildren<CoinCounter>();
       killCounter = GameObject.Find("Kill Counter Canvas 2D").GetComponentInChildren<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
       if (killCounter.killAmount == 8 && coinCounter.coinAmount == 8)
        {
            SceneManager.LoadScene("WinScreen");
        } 
    }
}
