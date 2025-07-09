/*
 This script will vary the objects size over time, creating a pulsating effect.
 
 This is acheived by passing the time to a cosine function.
 */
using UnityEngine;
using System.Collections;

public class Pulsate : MonoBehaviour {
	
	//The initial scale of the game object
	Vector3 initialScale;
	public float speed = 10;
	public Vector3 sizeIncrease = new Vector3(1.5f, 1.5f, 1.5f);
	
	void Start () 
	{
		//We need to save the initial scale of the game object
		this.initialScale = this.transform.localScale;
	}
	
	void Update () 
	{
		

		float t = Mathf.Cos( speed * Time.time ); 

		t = convertRange(t, -1, 1, 0, 1);
		
		//We set the size of the object to be the correct fraction of its original size.
		this.transform.localScale = Vector3.Scale(this.initialScale , Vector3.Lerp(Vector3.one, sizeIncrease, t));
	}
	
	// This function converts a number in one range, into another.
	// Same as map function in processing.
	float convertRange(float numberToConvert, float originalMin, float originalMax, float outputMin, float outputMax)
	{
		return (numberToConvert - originalMin) / (originalMax - originalMin) * (outputMax - outputMin) + outputMin;
	}
}
