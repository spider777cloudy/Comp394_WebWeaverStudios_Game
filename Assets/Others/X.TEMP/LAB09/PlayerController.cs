//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    Rigidbody2D rb;
//    Vector3 movement = Vector3.zero;
//    [SerializeField] float moveForce = 10;
//    [SerializeField] float jumpForce = 5.0f;
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Jump();
//        }
//        movement.x = Input.GetAxis("Horizontal");
//        movement.y = Input.GetAxis("Vertical");

//    }
//    private void FixedUpdate()
//    {
//        rb.AddForce(movement * moveForce);
//    }
//    void Jump()
//    {
//        //rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
//        rb.velocity = Vector3.up * jumpForce;
//    }
//}
