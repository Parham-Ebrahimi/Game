using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Vector2 playerInput;
    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput * moveSpeed;
        if(playerInput.x < 0){
            GetComponent<SpriteRenderer>().flipX=true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX=false;
        } 
    }
}
