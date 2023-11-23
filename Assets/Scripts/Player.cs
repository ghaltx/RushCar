using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xRange = 4.5f;
    public float yRange = 3.8f;

    public Rigidbody2D rb;

    public GameObject pfParafuso;
    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;

    public bool possoDarDisparoTriplo = false;
    public GameObject disparoTriploPrefab;

    public int vidas = 3;

    [SerializeField]
    private GameObject _explosaoPlayerPrefab;

    Vector2 movement;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            if (Time.time > podeDisparar)
            {
                if (possoDarDisparoTriplo == true)

                {
                    Instantiate(disparoTriploPrefab, transform.position + new Vector3(1.8f, 2.8f, 0), Quaternion.identity);
                }

                else

                {
                    Instantiate(pfParafuso, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                }

                podeDisparar = Time.time + tempoDeDisparo;

            }
        }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo = true;
        StartCoroutine(DisparoTriploRotina());

    }

    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0f);
        possoDarDisparoTriplo = false;
    }


    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Limita o movimento do jogador dentro da tela
        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);
        newPosition.y = Mathf.Clamp(newPosition.y, -yRange, yRange);

        rb.MovePosition(newPosition);
    }

    public void DanoAoPlayer()
    {
        vidas--;
        if (vidas < 1)
        { 
            Instantiate(_explosaoPlayerPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }


}
