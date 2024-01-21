using UnityEngine;
using UnityEngine.Events;

public class ColorLerp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private static Color sharedColor; // Static variable for shared color
    private Color targetColor;
    [SerializeField]
    private float lerpTime = 1f;
    private float currentLerpTime;
    public bool shareColor = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sharedColor = spriteRenderer.color;

        if (shareColor)
        {
             spriteRenderer.color = sharedColor;
        }
        else 
            SetRandomTargetColor();
    }

    void Update()
    {
        // Increment timer
        currentLerpTime += Time.deltaTime;

        // Lerp color
        if (shareColor == true)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, sharedColor, currentLerpTime / lerpTime);
        }
        else
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, currentLerpTime / lerpTime);
       

        // Check if lerping is complete
        if (currentLerpTime >= lerpTime && shareColor == false)
        {
            // Set a new random target color (excluding white and black)
            SetRandomTargetColor();
            // Reset lerp timer
            currentLerpTime = 0f;
        }
    }

    public void SetRandomTargetColor()
    {
        // Generate a random color (excluding white and black)
        do
        {
            targetColor = new Color(Random.value, Random.value, Random.value);
            sharedColor = targetColor;
        } while (IsWhiteOrBlack(targetColor));
    }
    
    public static void SetRandomTargetColor(bool lol)
    {
        // Generate a random color (excluding white and black)
        do
        {
            sharedColor = new Color(Random.value, Random.value, Random.value);
        } while (IsWhiteOrBlack(sharedColor));
    }

    static bool IsWhiteOrBlack(Color color)
    {
        // Check if the color is close to white or black
        return color.r > 0.9f && color.g > 0.9f && color.b > 0.9f || color.r < 0.1f && color.g < 0.1f && color.b < 0.1f;
    }
}
