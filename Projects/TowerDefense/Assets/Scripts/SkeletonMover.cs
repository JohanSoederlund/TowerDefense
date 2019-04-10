using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkeletonMover : MonoBehaviour {

    private GameController controller;
    public GameObject nodePoints;
    private Transform targetNode;
    public float speed, startTime;
    private int max, index = 0;

	// Use this for initialization
	void Start () {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        startTime = Time.time;
        nodePoints = GameObject.FindGameObjectWithTag("Node");
        max = nodePoints.transform.childCount;
    }
    public void getNextNode()
    {
        if (max > index)
        {
            targetNode = nodePoints.transform.GetChild(index);
            index++;
        }
    }
    // Update is called once per frame
    void Update () {
        if (targetNode == null)
        {
            getNextNode();
            if (targetNode == null)
            {
                ReachedGoal();
            }
        }
        if (targetNode != null)
        {
            Vector3 direction = (targetNode.transform.position - transform.position);
            float distanceThisFrame = speed * Time.deltaTime;
            if (direction.magnitude <= distanceThisFrame)
            {
                targetNode = null;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, distanceThisFrame);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }
        }
        
    }
    public void ReachedGoal()
    {
        controller.GameOver();
    }
}
