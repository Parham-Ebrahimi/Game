using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 playerInput;
    public Rigidbody2D rb;

    public float moveSpeed = 5f;
    public Animator animator;
    // Update is called once per frame
    void FixedUpdate()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput * moveSpeed;
        if(playerInput.x < 0){
            GetComponent<SpriteRenderer>().flipX=true;
        }
        else if(playerInput.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX=false;
        } 
        if(playerInput.magnitude > 0)
        {
            animator.SetBool("moving",true);
        }
        else
        {
            animator.SetBool("moving",false);
        }
        GameObject obj = FindClosestObject();
        GameObject player = GameObject.Find("MainCharacter");
        //obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0);;
        if(player.transform.position.y > obj.transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Debug.Log(0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            Debug.Log(2);
        }
        Debug.Log(obj.name);
    }
    public GameObject FindClosestObject()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Overlapping");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
