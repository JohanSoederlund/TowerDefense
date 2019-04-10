using UnityEngine;
using System.Collections;

public class ControllerBolt : MonoBehaviour {

    private Vector3 target;
    public int speed;
    public int damage;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float distanceThisFrame = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, distanceThisFrame);
        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }
    void MoveTo(GameObject enemyTarget)
    {
        enemyTarget.SendMessage("ApplyDamage", damage);
        target = enemyTarget.transform.position;
    }
}
