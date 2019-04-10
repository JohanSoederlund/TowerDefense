using UnityEngine;
using System.Collections;

public class skeletonModel : MonoBehaviour {

    private GameController controller;
    public int healthPoints;
	// Use this for initialization
	void Start () {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        int lvl = controller.getLevel();
        healthPoints = healthPoints + (4 * lvl);
    }
	
	// Update is called once per frame
	void Update () {
	    if (healthPoints <= 0)
        {
            controller.GainGold(1);
            Destroy(gameObject);
        }
	}
    public void ApplyDamage(int damage)
    {
        healthPoints -= damage;
    }
    public void increaseHealth(int points)
    {
        healthPoints += points;
    }
}
