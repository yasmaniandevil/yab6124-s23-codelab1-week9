using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTwo : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 5f;
    public float dequeueInterval = 5f;

    private Queue<GameObject> _queue = new Queue<GameObject>();
    //private float spawnTimer = 0;
    //private float dequeueTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("QueueObj", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        /*spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            GameObject newObject = Instantiate(cubePrefab);
            _queue.Enqueue(newObject);
            spawnTimer = 0f;
        }

        dequeueTimer += Time.deltaTime;
        if (dequeueTimer >= dequeueInterval && _queue.Count > 0)
        {
            GameObject dequeuedObject = _queue.Dequeue();
            Destroy(dequeuedObject);
            dequeueTimer = 0f;
        }*/
        
    }
}
