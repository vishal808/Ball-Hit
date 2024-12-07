using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(blockPrefab,new Vector3(0,0,0),transform.rotation);
        Instantiate(blockPrefab,new Vector3(0,1,0),transform.rotation);
        Instantiate(blockPrefab,new Vector3(1,1,0),transform.rotation);
        Instantiate(blockPrefab,new Vector3(-1,2,0),transform.rotation);
        Instantiate(blockPrefab,new Vector3(2,2,0),transform.rotation);
        Instantiate(blockPrefab,new Vector3(-1,0,0),transform.rotation);
    }

}
