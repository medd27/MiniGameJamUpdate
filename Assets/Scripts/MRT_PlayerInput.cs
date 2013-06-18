using UnityEngine;
using System.Collections;

public class MRT_PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Worker_Smack"))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit hitInfo = new RaycastHit();
			if(Physics.Raycast(ray, out hitInfo,Mathf.Infinity))
			{
				//if we click on a worker thats moving
				if(hitInfo.transform.tag == "Worker" && hitInfo.transform.parent.tag == "Holder_Worker_Moving")
				{
					Destroy(hitInfo.transform.gameObject);
				}
			}	
		}	
	}
}
