using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class mainloop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 	 

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag.CompareTo ("food")==0) {
			
			Debug.Log ("no");

		} else {
			
			Debug.Log (collider.gameObject.name);
		}
	}

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag.CompareTo ("food")==0) {
			GameObject root = GameObject.Find ("SnakeHead");

			Debug.Log ("no");
			root.transform.Translate (Vector3.back*0);

		} 
		Debug.Log (collider.gameObject.name);
	}
}
