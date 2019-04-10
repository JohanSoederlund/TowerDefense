using UnityEngine;
using System.Collections;

public class PrebuiltController : MonoBehaviour {

    public AudioClip towerBuildSound;
    public GameObject tower;
    private GameController controller;
    // Use this for initialization
    void Start () {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("m"))
        {
            Destroy(gameObject);
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 newPosition = new Vector3(hit.point.x, 1.0f, hit.point.z);
            transform.position = newPosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            controller.Purchase(20);
            Instantiate(tower, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(towerBuildSound, transform.position);
            Destroy(gameObject);
        }
    }



}
