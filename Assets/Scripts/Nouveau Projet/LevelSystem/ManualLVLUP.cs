using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualLVLUP : MonoBehaviour
{
    public float XPamount =1;
    public float XPtotal;
    public KeyCode resizeKey = KeyCode.Space; //temporaire

    private RectTransform XPbar;
    // changé le transform x / la width en fonction de la différence entre xp et xp cap
    void Start()
    {
        XPbar = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(resizeKey))
        {
            // Resize the image by modifying its width
            XPbar.sizeDelta = new Vector2(XPbar.sizeDelta.x + XPamount, XPbar.sizeDelta.y);
        }

        if (XPamount == XPtotal)
        {
            XPamount = 0; // et trigger lvlup? 
        }
    }
}
