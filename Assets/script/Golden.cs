using UnityEngine;
using System.Collections;

public class Golden : MonoBehaviour {

    private bool canFly = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canFly)
        {
            transform.Translate(Vector3.up*1f*Time.deltaTime);
        }
	}

    public void setFly()
    {
        canFly = true;
        Destroy(this.gameObject,1.5f);
    }

}
