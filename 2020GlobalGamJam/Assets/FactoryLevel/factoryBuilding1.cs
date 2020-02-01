using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factoryBuilding1 : MonoBehaviour
{
    public GameObject SmokeStack;

    public List<GameObject> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        int amountToSpawn = Random.Range(1, spawnPoints.Count);

        for(int i = 1; i <= amountToSpawn; i++)
        {
            GameObject newStack = Instantiate(SmokeStack);

            //potential problem to spawn in positions
            newStack.transform.position = spawnPoints[i-1].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
