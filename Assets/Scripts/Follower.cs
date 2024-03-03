using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public GameObject destination;
    float distanceTravelled;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        distanceTravelled = 0;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            start =  !start;
        }
        if(Vector3.Distance(transform.position, destination.transform.position)<0.1)
        {
            start = false;
        }
    }
}
