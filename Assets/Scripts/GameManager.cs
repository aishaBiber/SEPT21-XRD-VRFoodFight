using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab;

    private BoxCollider box;

    public void SpawnTarget()
    {
        var newTarget = Instantiate(targetPrefab, GenerateRandomPosition(), targetPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        var randomPosition = new Vector3(Random.Range(box.bounds.min.x, box.bounds.max.x),
                                            Random.Range(box.bounds.min.y, box.bounds.max.y),
                                            Random.Range(box.bounds.min.z, box.bounds.max.z));
        return randomPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
