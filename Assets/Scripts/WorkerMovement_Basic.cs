using UnityEngine;
using System.Collections;

public class WorkerMovement_Basic : MonoBehaviour {
	
	public float Speed;
	public Vector3 WorkerDir;	
	public bool IsMoving;
	private GameObject WorkerOverlord;
	
	// Use this for initialization
	void Start () 
	{
		WorkerOverlord = GameObject.FindGameObjectWithTag("MRT_Worker_Overlord");
	
	}//Start
	
	// Update is called once per frame
	void Update () 
	{
		if( IsMoving )
		{		
			//Vector3 NewPosition = new Vector3();
			rigidbody.velocity = Speed * WorkerDir;
			//NewPosition = transform.position + (Speed * WorkerDir * Time.deltaTime);
			//transform.position = NewPosition;			
		}//if
		
	}//Update
	
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "MRT_Barrier")
		{
			WorkerOverlord.GetComponent<MRT_WorkerOverlord>().WorkerFailed(gameObject);			
		}
	}
}
