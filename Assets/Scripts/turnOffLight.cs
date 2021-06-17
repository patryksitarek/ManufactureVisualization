using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffLight : MonoBehaviour
{
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf) turnOff();
        

    }

    void turnOff()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.1f)
        {
            this.gameObject.SetActive(false);
            elapsedTime = 0;
        }
    }
}
