using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasketControl : MonoBehaviour
{
    private float movement;
    private bool hitLeftWall;
    private bool hitRightWall;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting Basket");
    }

    // Update is called once per frame
    void Update()
    {
        float modMove = movement; 
        if(hitRightWall && movement>0) modMove = 0;
        if(hitLeftWall && movement<0) modMove = 0;
        transform.position = new Vector2(transform.position.x + modMove*Manager.Instance.playerSpeed*Time.deltaTime
            , transform.position.y);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<float>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitting" + collision.gameObject.name);
        if(collision.gameObject.name =="RightWall") hitRightWall = true;
        if(collision.gameObject.name =="LeftWall") hitLeftWall = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("releasing" + collision.gameObject.name);
        if(collision.gameObject.name =="RightWall") hitRightWall = false;
        if(collision.gameObject.name =="LeftWall") hitLeftWall = false;
    }
}
