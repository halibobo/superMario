using UnityEngine;
using System.Collections;

public class OtherSprites : MonoBehaviour {


    public GameObject golden;
    public GameObject wall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void addGolden(Vector3 pos)
    {
        GameObject go = (GameObject)Instantiate(golden, pos, Quaternion.identity);
        go.GetComponent<Golden>().setFly();
    }

    public void addWall(Vector3 pos)
    {
        Instantiate(wall,pos, Quaternion.identity);
    }
}
