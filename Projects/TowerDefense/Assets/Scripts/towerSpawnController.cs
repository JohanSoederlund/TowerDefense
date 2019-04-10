using UnityEngine;
using System.Collections;

public class towerSpawnController : MonoBehaviour {
    
    public GameObject tower;

    public GameObject frostTower;
    private GameController controller;
    //private bool noTowerSpawnInstantiated = true;
    
    // Use this for initialization
    void Start () {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("m") && controller.InstantiatePossibleControl(20, "m"))
        {
            //GameObject fB = Instantiate(fireBolt, boltSpawn.position, boltSpawn.rotation) as GameObject;
            //GameObject fB = Instantiate(tower, transform.position, transform.rotation) as GameObject;
            //fB.SendMessage("MoveTo", target);
            Instantiate(tower, transform.position, transform.rotation);
            //noTowerSpawnInstantiated = false;
        }
        if (Input.GetKeyDown("n") && controller.InstantiatePossibleControl(40, "n"))
        {
            Instantiate(frostTower, transform.position, transform.rotation);
        }
    }
    //private 
    
}

