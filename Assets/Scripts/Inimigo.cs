using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float _velocidade = 6.0f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * _velocidade * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-4f, 4f), 8.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);


        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag == "Inimigo")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }
        }

        Destroy(this.gameObject);

        Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);

    }
}
