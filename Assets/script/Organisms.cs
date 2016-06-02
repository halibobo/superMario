using UnityEngine;
using System.Collections;

public class Organisms : MonoBehaviour {

    public bool isDie = false;
    public int dieAudioIndex = 14;
    public  Vector3 dir = Vector3.left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localEulerAngles = Vector3.zero;
        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Board")
        {
            dir = -dir;
        }
        //Destroy(other.gameObject);
    }

    

    public void die()
    {
        
    }
}
