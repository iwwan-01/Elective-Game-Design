using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public int killAmount = 0;
    [SerializeField]
    private Text killText;
    // Start is called before the first frame update
    void Start()
    {
        killText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killText.text = killAmount.ToString();
    }
}
