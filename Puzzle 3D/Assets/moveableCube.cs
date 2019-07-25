using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableCube : MonoBehaviour
{

    private Rigidbody rb;
    //public float rbMass;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.mass = rbMass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
