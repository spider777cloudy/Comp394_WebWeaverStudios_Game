using System.Collections;
using UnityEngine;

public class CameraVibration : MonoBehaviour
{
    public float vibrationDuration = 0.2f;
    public float vibrationIntensity = 0.2f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = Camera.main.transform.position;
    }

    public void Vibrate()
    {
        StopAllCoroutines();
        StartCoroutine(PerformVibration());
    }

    IEnumerator PerformVibration()
    {
        float elapsedTime = 0f;

        while (elapsedTime < vibrationDuration)
        {
            float xOffset = UnityEngine.Random.Range(-1f, 1f) * vibrationIntensity;
            float yOffset = UnityEngine.Random.Range(-1f, 1f) * vibrationIntensity;

            Camera.main.transform.position = originalPosition + new Vector3(xOffset, yOffset, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
