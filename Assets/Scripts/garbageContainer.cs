using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box01" || collision.gameObject.tag == "box02" || collision.gameObject.tag == "box03") 
        {
            Destroy(collision.gameObject);
        }
    }
}
