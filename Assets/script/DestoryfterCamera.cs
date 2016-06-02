using UnityEngine;
using System.Collections;

public class DestoryfterCamera : MonoBehaviour {

    public float objectWidth = Screen.width;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
        if (Camera.main.WorldToScreenPoint(transform.position).x < -objectWidth)  //小玛丽不能超出坐屏幕
        {
           // Debug.Log(Camera.main.WorldToScreenPoint(transform.position).x);
            Destroy(this.gameObject);
        }
	}*/
}
