using UnityEngine;
using System.Collections;

public class Mushroomhy : MonoBehaviour {


    private int coinCount = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setHarm()
    {
        GameObject.FindGameObjectWithTag("SpritesHouse").GetComponent<OtherSprites>().addGolden(transform.position);
        World.playAudio(World.coinAudio);
        coinCount--;
        if (coinCount <= 0)
        {
            die();
        }
    }

    private void die()
    {
        GameObject.FindGameObjectWithTag("SpritesHouse").GetComponent<OtherSprites>().addWall(transform.position);
        Destroy(this.gameObject);
    }
}
