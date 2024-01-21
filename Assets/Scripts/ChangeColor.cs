using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private float lerpTime = 1f;
    private float currentLerpTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment timer
        currentLerpTime += Time.deltaTime;

        // Check if lerping is complete
        if (currentLerpTime >= lerpTime)
        {
            // Set a new random target color (excluding white and black)
            ColorLerp.SetRandomTargetColor(true);
            // Reset lerp timer
            currentLerpTime = 0f;
        }
    }
}
