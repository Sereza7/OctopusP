using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tentacleManager : MonoBehaviour
{
	public Button[] stateButtons;
	public Material defaultMaterial;
	public Material outlinedMaterial;
	private GameObject[] tentacles;
	//tentacle state
	private int tentacleState;
	private List<int> unlockedStates;
	
	void Start()
    {
		tentacles = new GameObject[8];
		for (int i= 0; i<8; i++)
		{
			tentacles.SetValue(this.transform.GetChild(i).gameObject, i);
		}
		tentacleState = -1;

		//Remove the unlocked later:
		unlockedStates = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
	}
	
    void Update()
    {
        
    }

	public void SwitchTentacleState(int newState)
	{
		if (tentacleState!=-1)((GameObject)tentacles.GetValue(tentacleState-1)).GetComponent<SpriteRenderer>().material = defaultMaterial;
		if (newState == tentacleState) tentacleState = -1;
		else if (unlockedStates.Contains(newState))
		{
			tentacleState = newState;
		}
		else Debug.Log("Tried to switch to a state not unlocked yet.");
		if (tentacleState != -1) ((GameObject)tentacles.GetValue(tentacleState-1)).GetComponent<SpriteRenderer>().material = outlinedMaterial;
	}

	internal void UnlockState(int newState)
	{
		if (!unlockedStates.Contains(newState)) unlockedStates.Add(newState);
		else Debug.Log("State already unlocked.");
		//activate the tools on the tentacle and the buttons
	}

	internal void Activate()
	{
		if (tentacleState != -1)
		{
			//Then do something
			if (tentacleState == 1)
			{
				GameObject bird = GameObject.Find("bird");
				if (bird != null && Vector3.Distance(bird.transform.position, ((GameObject)tentacles.GetValue(0)).transform.position) < 0.5f)
				{
					bird.transform.SetParent(((GameObject)tentacles.GetValue(0)).transform);
				}
			}
		}
		else Debug.Log("No effect since no selected tentacle.");
	}
}
