using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirectionOfBelt : MonoBehaviour
{
    private bool isTalkative = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        if (isTalkative && Input.GetKeyDown(KeyCode.R))
        {
            ConveyorBelt conveyorBelt = this.GetComponentInChildren<ConveyorBelt>();
            animatedTexture textureObj = this.gameObject.GetComponentInChildren<animatedTexture>();
            
            Transform LEDIndicator = transform.GetChild(0).GetChild(0).GetChild(0);
            Material LEDMaterial = LEDIndicator.GetComponent<Renderer>().material;
            
            if (textureObj.scrollSpeed < 0) LEDMaterial.SetColor("_EmissionColor", Color.red);
            else LEDMaterial.SetColor("_EmissionColor", Color.green);
            if (conveyorBelt != null)
            {
                conveyorBelt.speed = conveyorBelt.speed * -1;
                textureObj.scrollSpeed *= -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTalkative = true;   
    }

    private void OnTriggerExit(Collider other)
    {
        isTalkative = false;
    }
}
