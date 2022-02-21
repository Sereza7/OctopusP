using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollow : MonoBehaviour
{
	public Transform endMarker;
	
	public float smoothTime = 0.1f;

	private Vector3 speed = Vector3.zero;


	void Start()
	{
	}

	// Move to the target end position.
	void Update()
	{
		// Define a target position above and behind the target transform

		// Smoothly move the camera towards that target position
		transform.position = Vector3.SmoothDamp(transform.position, endMarker.position, ref speed, smoothTime);
	}
}