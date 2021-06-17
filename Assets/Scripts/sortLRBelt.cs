using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortLRBelt : MonoBehaviour
{
    private bool direction = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ConveyorBelt conveyorBelt = this.GetComponentInChildren<ConveyorBelt>();
        animatedTexture textureObj = this.gameObject.GetComponentInChildren<animatedTexture>();
        Light LEDIndicator = transform.GetChild(2).GetChild(3).GetComponent<Light>();

        if (other.tag == "box01")
        {
            LEDIndicator.color = Color.blue;

            if (direction && conveyorBelt != null)
            {
                conveyorBelt.speed = conveyorBelt.speed * -1;
                textureObj.scrollSpeed *= -1;
                direction = false;
            }
        }
        else
        {
            LEDIndicator.color = Color.white;

            if (!direction && conveyorBelt != null)
            {
                conveyorBelt.speed = conveyorBelt.speed * -1;
                textureObj.scrollSpeed *= -1;
                direction = true;
            }
        }
    }
}
