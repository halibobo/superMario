using UnityEngine;
using System.Collections;

public class World  {


    public const int jumpAudioIndex = 10;
    public const int dead1AudioIndex = 6;
    public const int spawnObject = 14;
    public const int coinAudio = 4;


    public static void playAudio(int index)
    {
        GameObject.FindGameObjectWithTag("AudiosStation").SendMessage("playAudio", index); ;
    }
	
}
