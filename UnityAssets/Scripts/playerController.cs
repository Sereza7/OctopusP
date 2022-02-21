using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	//movement
	private int speed = 500;
	private Rigidbody2D rigidbody;

	

	public void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		
	}
	public void Move(float x, float y)
	{
		Vector3 Movement = new Vector3(x, y, 0);
		rigidbody.AddForce(Movement * speed * Time.deltaTime);


		//float magnitude = Vector2.Angle(rigidbody.velocity,Vector2.zero)-rigidbody.rotation;
		//transform.rotation +=  magnitude;
	}

	
}
