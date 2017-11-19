using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour {
	private GameObject root;
	private GameObject root1;
	private GameObject head1;
	private GameObject food;
	private string direction;
	private ArrayList bodys;

	// Use this for initialization
	void Start () {
//		root = GameObject.Find ("SnakeHead");
//		head1 = root;//head1 = root.transform.Find ("SnakeHead").gameObject;
//		Debug.Log (head1);
//		GameObject root1 = GameObject.Find("MainScene");
//		GameObject food =  root1.transform.Find("food").gameObject;

		//GameObject.FindWithTag ("food").SetActive (true);
		GameObject[] roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject root in roots) {
			if (root.name == "SnakeHead") {
				Debug.Log ("head");
				head1 = root;
			}
			if (root.tag == "food") {
				food = root;
				food.SetActive (true);
				food.transform.position = new Vector3 (10, 0, 10);
			}
		}
		bodys = new ArrayList ();

			
//		GameObject food = GameObject.FindGameObjectWithTag ("food");// (PrimitiveType.Cube);
//		food.SetActive(true);
//		food.transform.position = new Vector3 (10, 0, 10);

	}
	
	// Update is called once per frame
	void Update () {
		head1.transform.position = new Vector3(head1.transform.position.x,0,head1.transform.position.z);
		Vector3 oldposition = head1.transform.position;	

		if (Input.GetKey(KeyCode.DownArrow)) {
			direction = "down";
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			direction = "up";
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			direction = "left";
			}
		if (Input.GetKey(KeyCode.RightArrow)) {
			direction = "right";
			}
		switch (direction) {
		case "down":
			head1.transform.Translate (Vector3.back * Time.deltaTime * 20);
			Debug.Log ("down");
			break;
		case "up":
			head1.transform.Translate (Vector3.forward * Time.deltaTime * 20);
			Debug.Log ("down");
			break;
		case "left":
			head1.transform.Translate (Vector3.left * Time.deltaTime * 20);
			Debug.Log ("down");
			break;
		case "right":
			head1.transform.Translate (Vector3.right * Time.deltaTime * 20);
			Debug.Log ("down");
			break;
		default:
			break;
		}
		foreach (GameObject body in bodys) {
			Vector3 temp = body.transform.position;
			body.transform.position = oldposition;
			oldposition = temp;
		}
			
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag.CompareTo ("food")==0) {

			Debug.Log ("no");
			GameObject food = GameObject.FindGameObjectWithTag ("food");// (PrimitiveType.Cube);
			food.transform.position = new Vector3 (Random.Range(-14,14), 0, Random.Range(1,29));
			GameObject newbody = (GameObject)GameObject.CreatePrimitive (PrimitiveType.Cube);
			bodys.Add (newbody);
		} 

		if(collider.gameObject.tag.CompareTo("wall")== 0) {
			Destroy(head1);
		}
	}
}
