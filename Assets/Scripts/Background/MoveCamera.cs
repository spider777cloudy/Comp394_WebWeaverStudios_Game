using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    void Start()
    {
        
    }

    [SerializeField] float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2 (x, 0);

        transform.Translate (movement*speed *Time.deltaTime);
    }
}
