using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {


    public GameObject mario;
    private Transform marioTransform;

	// Use this for initialization
	void Start () {
        mario = GameObject.FindGameObjectWithTag("mario");
        marioTransform = mario.transform;
	}
	
	// Update is called once per frame
	void Update () {

        //相机不能回退
        
	}

    void LateUpdate()
    {
        if (marioTransform.position.x - 0.5f > transform.position.x)
        {
            Camera.main.transform.position = new Vector3(marioTransform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
    }
}
