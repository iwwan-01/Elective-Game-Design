using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinAmount = 0;
    [SerializeField]
    private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
    }
}
