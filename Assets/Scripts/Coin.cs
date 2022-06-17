using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotateSpeed = 0.5f;
    CoinCounter coinCounterScript;

    void Awake()
    {
        coinCounterScript = GameObject.Find("Coin Counter Canvas 2D").GetComponentInChildren<CoinCounter>();
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        coinCounterScript.coinAmount ++;
        Destroy(gameObject);
    }
}
