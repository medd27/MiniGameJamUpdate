using UnityEngine;
using System.Collections;

public class Escalator_WorkerOverlord : MonoBehaviour {
	
	public Transform[] SpawnPoints;
	public GameObject[] Workers;
	public float	SpawnTime;
	private float	SpawnTimeTimer = 0.0f;
	public Transform Escalator_Standing;
	public Transform Escalator_Walking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		SpawnTimeTimer += Time.deltaTime;
		
		if(SpawnTimeTimer > SpawnTime)
		{
			SpawnTimeTimer = 0.0f;
			SpawnWorker();			
		}	
	}
	
	
	void SpawnWorker()
	{
		int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
		int workerIndex = Random.Range(0, Workers.Length);
		
		GameObject NewObject = (GameObject)Instantiate(Workers[workerIndex]);
		NewObject.transform.position = SpawnPoints[spawnPointIndex].position + new Vector3(0,0,-1);
		
		NewObject.GetComponent<WorkerMovement_Basic>().IsMoving = true;
		
		NewObject.transform.parent = SpawnPoints[spawnPointIndex].parent;
	}	
	
	public void SwitchWorkerEscalatorSide(GameObject worker)
	{
		if(worker.transform.parent == Escalator_Standing)
		{
			worker.transform.parent = Escalator_Walking;
			worker.transform.position = new Vector3(Escalator_Walking.transform.position.x,
													worker.transform.position.y, 
													worker.transform.position.z);
		}
		else if(worker.transform.parent == Escalator_Walking)
		{
			worker.transform.parent = Escalator_Standing;
			worker.transform.position = new Vector3(Escalator_Standing.transform.position.x,
													worker.transform.position.y, 
													worker.transform.position.z);
		}
	}
}
