using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickBox : MonoBehaviour
{
    Rigidbody rb;
    Transform collidedObject;
    private bool isEmpty = true;

    protected Transform stuckTo = null;
    protected Vector3 offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isEmpty && Input.GetKeyDown(KeyCode.Space))
        {
            stuckTo = null;
            rb.useGravity = true;
            rb.isKinematic = false;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (isEmpty && col.gameObject.name == "holder")
        {
            isEmpty = false;
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;

            if (stuckTo == null || stuckTo != col.gameObject.transform) offset = col.gameObject.transform.position - transform.position;

            stuckTo = col.gameObject.transform;
        }
    }
    private void LateUpdate()
    {
        if (stuckTo != null)
            transform.position = stuckTo.position - offset;
    }
}
