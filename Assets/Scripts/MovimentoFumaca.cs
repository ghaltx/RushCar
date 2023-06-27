using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFumaca : MonoBehaviour

{
    public float velocFumaca = 12.0f;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocFumaca * Time.deltaTime);

        if ( transform.position.y < -6.0f ){
            Debug.Log("Objeto destruído!");
            Destroy(this.gameObject); 
        }
    }
}