using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeIndicator : MonoBehaviour
{
    public Image rangeIndicatorImage;
    public bool isVisible;

    // Start is called before the first frame update
    void Awake()
    {
        rangeIndicatorImage = GetComponentInChildren<Image>();
        rangeIndicatorImage.enabled = false;
        isVisible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isVisible)
        {
            rangeIndicatorImage.enabled = true;
            isVisible = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && isVisible)
        {
            rangeIndicatorImage.enabled = false;
            isVisible = false;
        }
    }
}