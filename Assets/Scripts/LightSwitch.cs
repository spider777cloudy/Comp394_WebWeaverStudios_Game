using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightSwitch;
    [SerializeField] private Light2D light2D;

    Color color1 = Color.red;
    Color color2 = Color.green;
    Color color3 = Color.blue;
    Color color4 = Color.white;

    void Start()
    {
        lightSwitch = GetComponent<GameObject>();
        light2D = GetComponent<Light2D>();
    }

    private void Update()
    {
        ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            light2D.enabled = true;
            light2D.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            light2D.enabled = false;
        }
    }
}
