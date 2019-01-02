using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guns_behaviour : MonoBehaviour {
	Vector3 mouse_pos,dist_from_gunpivot_mouse,d1;float dot_d1_dist,angle;public float h,directed_beam_length;
	[SerializeField]private GameObject goli;GameObject g1;public float maxtime;
	// Use this for initialization
	void Start () {
		mouse_pos = Input.mousePosition;
		dist_from_gunpivot_mouse = mouse_pos - transform.position;
		d1 = dist_from_gunpivot_mouse;//goli g = new goli();
		transform.GetChild (1).position = transform.GetChild (1).position + transform.GetChild (0).right * directed_beam_length;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouse_pos = new Vector3 (Vector3.Dot(mouse_pos,Vector3.right),Vector3.Dot(mouse_pos,Vector3.up),0);
		dist_from_gunpivot_mouse = mouse_pos - transform.position;
		dot_d1_dist = Vector3.Dot (d1, dist_from_gunpivot_mouse);


		angle = Mathf.Acos(dot_d1_dist / (Vector3.Magnitude (dist_from_gunpivot_mouse) * Vector3.Magnitude (d1)));
		angle = angle * 180f / 3.14f;
		if (Vector3.Dot(new Vector3(0,0,1),Vector3.Normalize(Vector3.Cross (d1, dist_from_gunpivot_mouse)))<0) {
			angle = -angle;
		}
		//Debug.Log (Vector3.Normalize (Vector3.Cross (d1, dist_from_gunpivot_mouse)));	
		d1 = dist_from_gunpivot_mouse;
		//transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y,transform.rotation.z + angle,0);
		transform.Rotate(0,0,angle);

			
		if (Input.GetMouseButtonDown(0)) {
			g1=Instantiate (goli,transform.GetChild(0).GetComponent<BoxCollider2D>().bounds.center+transform.GetChild(0).right*h, transform.GetChild(0).rotation,null);
			g1.gameObject.GetComponent<goli> ().set (maxtime);
			g1.GetComponent<Rigidbody2D> ().velocity = transform.GetChild (0).right * -100f;
		}

	}
}
