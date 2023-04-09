using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Queue : MonoBehaviour
{
    //setting up queue
    private Queue<object> SpawnQueue = new Queue<object>();

    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;

    public Vector3 minPosition;
    public Vector3 maxPosition;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        //increase timer by time passed since last frame
        timer += Time.deltaTime;
        
        //if you press e
        if (Input.GetKeyDown(KeyCode.E))
        {
            //it will add the prefab to the queue
            SpawnQueue.Enqueue(spherePrefab);
            Debug.Log("Sphere Position" + transform.position);
        }

        //add prefab to queue when you press c
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnQueue.Enqueue(cubePrefab);
            Debug.Log("Cube");
        }

        //if the timer that is counting is greater or equal to timePerTurn which is 5 seconds
        if (timer >= timePerTurn)
        {
            //then display time is up
            display.text = "time is up";
            //run the show queue function, that shows all objects that are in the queue
            ShowQueue();
            timer = 0; //Reset the timer after the objects have been shown

        }
        else
        {
            display.text = (timePerTurn - timer).ToString("F2");
        }
        
    }

    //function that shows objs in queue
    private void ShowQueue()
    {
        //loop that executes when there are objects in the queue
        //if there is objects that it is counting then
        while (SpawnQueue.Count > 0)
        {
            
            //Dequeue the next object in the queue (at first it said it was wrong so I had to cast it, idk what that means rider did it)
            //returns the object at beginning of queue then assigns it to new variable
            GameObject obj = (GameObject)SpawnQueue.Dequeue(); 
            Vector3 randomPos = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z));
            //Instantiate the object at a random position
            Instantiate(obj, randomPos, transform.rotation);
        }
            
    }
}
