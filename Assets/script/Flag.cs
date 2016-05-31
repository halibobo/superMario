using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

    private bool isSuccess = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}  


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "mario")
        {
            if (!isSuccess)
            {
                rigidbody2D.gravityScale = 0.02f;
                isSuccess = true;
            }
        }
    }
}
