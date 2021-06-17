using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{

    public GameObject[] spawnegg;
    public bool stopSpawning = false;
    private float spawnTime = 1000f;
    public float spawnDelay;
    private float elapsed = 0f;
    private GameObject boxObject;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed > spawnDelay)
        {          
            elapsed = 0;
            light.SetActive(true);

            int drawBox = Random.Range(0, spawnegg.Length);
            float drawRotation = Random.Range(0, 360);
            float drawPosition = Random.Range(-1.2f, 1.2f);

            boxObject = Instantiate(spawnegg[drawBox], new Vector3(-8.5f, 4f, drawPosition), transform.rotation * Quaternion.Euler(0f, drawRotation, 0f));
            boxObject.transform.SetParent(this.transform);
            if (stopSpawning) 
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}
