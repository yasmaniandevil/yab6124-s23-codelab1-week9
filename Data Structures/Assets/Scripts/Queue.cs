using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Queue : MonoBehaviour
{
    private Queue<object> SpawnQueue = new Queue<object>();

    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;

    public Vector3 minPosition;
    public Vector3 maxPosition;
    
    //float spawnInterval = 3f;
    //private int enemiesSpawned = 0;

    private float timer = 0;
    private float timePerTurn = 5;

    public TextMeshProUGUI display;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 randomPos = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z));

        timer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnQueue.Enqueue(Instantiate(spherePrefab, randomPos, transform.rotation));
            spherePrefab.SetActive(false);
            Debug.Log(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnQueue.Enqueue(Instantiate(cubePrefab, randomPos, transform.rotation));
            cubePrefab.SetActive(false);
        }

        if (timer >= timePerTurn)
        {
            display.text = "time is up";
            ShowQueue();
            
        }
        else
        {
            display.text = (timePerTurn - timer).ToString("F2");
        }
        
    }

    private void ShowQueue()
    {
        while(SpawnQueue.Count > 0)
            SpawnQueue.Dequeue();
    }
}
