using UnityEngine;
using System.Collections;

public class MRT_WorkerOverlord : MonoBehaviour {
	
	public float WorkerSpawnTime;
	public GameObject Holder_Worker_Line;
	public GameObject Holder_Worker_Moving;
	public GameObject Holder_Worker_Failed;
	public GameObject Worker;
	
	private float WorkerTimer;
	
	// Use this for initialization
	void Start () 
	{
		WorkerTimer = 0.0f;
	}//Start
	
	// Update is called once per frame
	void Update () 
	{
		WorkerTimer += Time.deltaTime;
		
		if( WorkerTimer > WorkerSpawnTime )
		{
			WorkerTimer = 0.0f;			
			SpawnWorker();			
		}//if
		
	}//Update
	
	
	void SpawnWorker()
	{
		//find new random position
		int WorkerAmt = Holder_Worker_Line.transform.childCount;
		int Index = Random.Range(0,WorkerAmt);
		
		//create the game object
		GameObject NewWorker = (GameObject)GameObject.Instantiate( Worker );
		
		//set position according to the random position we chose earlier
		NewWorker.transform.position = Holder_Worker_Line.transform.GetChild (Index).transform.position + new Vector3(4,0,0);
		
		//activate the workers movement
		WorkerMovement_Basic WM = NewWorker.GetComponent<WorkerMovement_Basic>();
		WM.IsMoving = true;
		
		//set new parent
		NewWorker.transform.parent = Holder_Worker_Moving.transform;		
				
	}//SpawnWorker
	
	public void WorkerFailed(GameObject FailedWorker)
	{	
		//update the parent
		FailedWorker.transform.parent = Holder_Worker_Failed.transform;
		
		//make the collider super small so they can stack
		FailedWorker.GetComponent<BoxCollider>().size = new Vector3(0.3f,0.3f,0.3f);
	}
	
}
