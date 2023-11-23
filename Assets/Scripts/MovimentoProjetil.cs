using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoProjetil : MonoBehaviour

{
    public float velocProjetil = 12.0f;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocProjetil * Time.deltaTime);

        if ( transform.position.y > 6.0f){
            Destroy(this.gameObject); 
        }
    }
}