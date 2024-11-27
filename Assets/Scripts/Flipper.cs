using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void FlipSprites()
    {
        foreach (Transform child in transform)
        {
            Vector3 currentScale = child.localScale;
            currentScale.x *= -1;
            child.localScale = currentScale;
        }
    }
}
