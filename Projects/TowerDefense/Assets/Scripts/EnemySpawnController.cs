using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

    public GameObject skeleton;
    public GameObject boss;
    private GameController controller;
    public int skeletonCount;
    public float startWait, spawnWait;
    public Transform skeletonSpawn;
    private int nrOfWaves = 0;
    private bool moreWaves = true;
    // Use this for initialization
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while (moreWaves)
        {
            nrOfWaves++;
            controller.GainGold(20);
            controller.setLevel();
            Vector3 spawnPos = skeletonSpawn.position;
            spawnPos.y = skeletonSpawn.position.y;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            spawnPos.x = skeletonSpawn.position.x + 1;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            spawnPos.x = skeletonSpawn.position.x + 2;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            spawnPos.z = skeletonSpawn.position.z - 1;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            spawnPos.x = skeletonSpawn.position.x;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            spawnPos.x = skeletonSpawn.position.x + 1;
            Instantiate(skeleton, spawnPos, skeletonSpawn.rotation);
            if (nrOfWaves >= 10)
            {
                spawnPos.y = 0;
                Instantiate(boss, spawnPos, skeletonSpawn.rotation);
                moreWaves = false;
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
