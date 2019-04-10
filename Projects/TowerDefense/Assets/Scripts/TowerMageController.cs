using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerMageController : MonoBehaviour {

    private Vector3 offset;
    public GameObject fireBolt;
    public GameObject[] enemies;
    public Transform boltSpawn;
    public float boltSpeed;
    private float range, sqrLen;
    public float fireRate;
    private float nextFire = 0;

    // Use this for initialization
    void Start()
    {
        range = 50;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = SearchForEnemies();
        if (target != null)
        {
            GameObject fB = Instantiate(fireBolt, boltSpawn.position, boltSpawn.rotation) as GameObject;
            fB.SendMessage("MoveTo", target);
        }
    }
    private GameObject SearchForEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if (enemies != null)
        {
            foreach (GameObject potentialTarget in enemies)
            {
                offset = transform.position - potentialTarget.transform.position;
                sqrLen = offset.sqrMagnitude;
                if (sqrLen < range && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    return potentialTarget;
                }
            }
        }
        return null;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
    }

}
