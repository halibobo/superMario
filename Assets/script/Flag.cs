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
<<<<<<< HEAD
                GetComponent<Rigidbody2D>().gravityScale = 0.02f;
=======
                rigidbody2D.gravityScale = 0.02f;
>>>>>>> 8c9a1df50fb98a4abbda29382c341737c5fca2fe
                isSuccess = true;
            }
        }
    }
}
