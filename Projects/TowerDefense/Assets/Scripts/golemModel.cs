using UnityEngine;
using System.Collections;

public class golemModel : MonoBehaviour {

    private GameController controller;
    public int healthPoints;
    // Use this for initialization
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            controller.GameWon();
            Destroy(gameObject);
        }
    }
    public void ApplyDamage(int damage)
    {
        healthPoints -= damage;
    }
}
