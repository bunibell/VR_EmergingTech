using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light pointLight; // Reference to the light component
    public float minTime = 0.1f; // Minimum time between flickers
    public float maxTime = 0.5f; // Maximum time between flickers
    public float flickerIntensity = 0.5f; // Minimum intensity during flicker
    private float originalIntensity; // Original intensity of the light

    void Start()
    {
        // Get the Light component attached to this GameObject
        pointLight = GetComponent<Light>();

        if (pointLight != null)
        {
            originalIntensity = pointLight.intensity;
            StartCoroutine(FlickerLight());
        }
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            // Randomly toggle the light intensity
            pointLight.intensity = Random.value > 0.5f ? originalIntensity : flickerIntensity;

            // Wait for a random interval before the next flicker
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}