using UnityEngine;
using UnityEngine.Rendering.Universal;  

public class LightBlink : MonoBehaviour
{
    public Light2D light2D;  // Reference to the Light2D component
    public float blinkInterval = 0.5f;  // Time between blinks in seconds
    public float minIntensity = 0f;  // Minimum intensity (light off)
    public float maxIntensity = 1f;  // Maximum intensity (light on)

    private void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<Light2D>();  
        }

        // Start the blinking coroutine
        StartCoroutine(BlinkLight());
    }

    private System.Collections.IEnumerator BlinkLight()
    {
        while (true)
        {
            light2D.intensity = (light2D.intensity == minIntensity) ? maxIntensity : minIntensity;
            yield return new WaitForSeconds(blinkInterval);  // Wait for the interval before toggling again
        }
    }
}
