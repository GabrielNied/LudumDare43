using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour {

    public GameObject[] tiles;

	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, tiles.Length);
        Instantiate(tiles[rand], transform.position, Quaternion.identity, this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
