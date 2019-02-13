using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will make the color of the background of the camera.
 * 
 * 
 */
public class ChangeBackgroundColor : MonoBehaviour
{
    private Camera cam;
    private float rDirection, gDirection, bDirection;

    //variables are initialized
    void Start()
    {
        cam = GetComponent<Camera>();
        rDirection = 1f;
        gDirection = 1f;
        bDirection = 1f;
    }

    private void FixedUpdate()
    {
        randomColorGnerator();
    }

    //randomizes the color of the background but in a way that blends.
    // dacides if rg or b should be changed the according by the direction it will be changed by 0.01f
    private void randomColorGnerator ()
    {
        int colorSelection = Random.Range(1, 4);

        if (colorSelection == 1)
        {
            float temp = ApplicationModel.r;
            temp += 0.01f * rDirection;
            if (temp >= 1.0f)
            {
                temp = 1.0f;
                rDirection = -1f;
            }
            else if (temp < 0f)
            {
                temp = 0f;
                rDirection = 1f;
            }
            ApplicationModel.r = temp;
        }
        else if (colorSelection == 2)
        {
            float temp = ApplicationModel.g;
            temp += 0.01f * gDirection;
            if (temp >= 1.0f)
            {
                temp = 1.0f;
                gDirection = -1f;
            }
            else if (temp < 0f)
            {
                temp = 0f;
                gDirection = 1f;
            }
            ApplicationModel.g = temp;
        }
        else if (colorSelection == 3)
        {
            float temp = ApplicationModel.b;
            temp += 0.01f * bDirection;
            if (temp > 1.0f)
            {
                temp = 1.0f;
                bDirection = -1f;
            }
            else if (temp < 0f)
            {
                temp = 0f;
                bDirection = 1f;
            }
            ApplicationModel.b = temp;
        }
        cam.backgroundColor = new Color(ApplicationModel.r, ApplicationModel.g, ApplicationModel.b);
    }
}
