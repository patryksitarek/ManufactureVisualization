using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotController : MonoBehaviour
{
    private bool controlAvailable = false;
    private GameObject robotRotation;
    private GameObject arm1;
    private GameObject arm2;
    private GameObject arm3;
    private GameObject gimbal;
    private GameObject holder;
    private GameObject armL;
    private GameObject armR;

    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        robotRotation = this.gameObject;
        arm1 = transform.GetChild(0).gameObject;
        arm2 = transform.GetChild(0).GetChild(0).gameObject;
        arm3 = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        gimbal = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        holder = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        armL = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        armR = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlAvailable)
        {

            if (Input.GetKey(KeyCode.RightBracket)) robotRotation.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
            else if (Input.GetKey(KeyCode.LeftBracket)) robotRotation.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.Self);

            if (Input.GetKey(KeyCode.O) && arm1.transform.rotation.x < 0.7f) arm1.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            else if (Input.GetKey(KeyCode.P) && arm1.transform.rotation.x > -0.7f) arm1.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.K) && arm2.transform.rotation.x < 0.7f) arm2.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            else if (Input.GetKey(KeyCode.L) && arm2.transform.rotation.x > -0.7f) arm2.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.N) && arm3.transform.rotation.x < 0.7f) arm3.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            else if (Input.GetKey(KeyCode.M) && arm3.transform.rotation.x > -0.8f) arm3.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.Semicolon) && gimbal.transform.rotation.x < 0) gimbal.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            else if (Input.GetKey(KeyCode.Quote) && gimbal.transform.rotation.x  > -0.96f) gimbal.transform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);

            if (Input.GetKey(KeyCode.Comma)) holder.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
            else if (Input.GetKey(KeyCode.Period)) holder.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.Self);

            if (Input.GetKey(KeyCode.Q) && armL.transform.position.x <= 55f)
            {
                armL.transform.position += new Vector3(0.01f * rotationSpeed * Time.deltaTime, 0, 0);
                armR.transform.position += new Vector3(0.01f * -rotationSpeed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.E) && armL.transform.position.x >= 54.5f) 
            {
                armL.transform.position += new Vector3(0.01f * -rotationSpeed * Time.deltaTime, 0, 0);
                armR.transform.position += new Vector3(0.01f * rotationSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") controlAvailable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player") controlAvailable = false;
    }
}
