using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerState : MonoBehaviour
{
	public Collider2D waterCollider;
	public TextMeshProUGUI debugLabel;


	private float wetness; //between 100 and 0
	private float air = 1000; // between 1000 and 0
	private bool isInWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	

    void FixedUpdate()
    {
		if (isInWater) wetness = 100;
		else wetness--;

		if (isInWater) air += 5;
		else air--;
		air = Mathf.Min(1000, air);

		if (debugLabel != null) debugLabel.text = "wetness: " + wetness.ToString() + "; o2: " + air.ToString();
	}
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider == waterCollider) isInWater = true;
	}

	private void OnTriggerExit2D(Collider2D otherCollider)
	{
		if (otherCollider == waterCollider) isInWater = false;
	}
}
