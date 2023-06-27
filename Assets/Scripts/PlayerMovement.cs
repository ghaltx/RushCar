using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xRange = 4.5f;
    public float yRange = 3.8f;

    public Rigidbody2D rb;
    
    public GameObject pfFumaca;
    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;

    Vector2 movement;

    void Update()
    {

        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            
            if ( Time.time > podeDisparar )

                Instantiate(pfFumaca,transform.position + new Vector3(0,-1.6f,0),Quaternion.identity);

                podeDisparar = Time.time + tempoDeDisparo ; 
            }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Limita o movimento do jogador dentro da tela
        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);
        newPosition.y = Mathf.Clamp(newPosition.y, -yRange, yRange);

        rb.MovePosition(newPosition);
    }
}
