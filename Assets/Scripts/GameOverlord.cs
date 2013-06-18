using UnityEngine;
using System.Collections;

public class GameOverlord : MonoBehaviour {
	
	private bool IsGameStart = true;
	private bool IsGameEnd = false;
	private bool IsGamePlaying = false;
	
	public Texture GameBeginTexture;
	
	public float GameLengthTimer;
	public GUIStyle GameLengthTimerStyle;
	
	public Texture GameEndTexture;
	

	// Use this for initialization
	void Start () {
		
		//freeze the game on startup
		Time.timeScale = 0.0f;	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(IsGameStart)
		{
			GameBegin();
		}
		else if(IsGamePlaying)
		{
			GamePlaying();	
		}
		else if(IsGameEnd)
		{
			GameEnd();	
		}	
	}
	
	void OnGUI()
	{
		if(IsGameStart)
		{
			GameBeginGUI();
		}
		else if(IsGamePlaying)
		{
			GamePlayingGUI();	
		}
		else if(IsGameEnd)
		{
			GameEndGUI();	
		}
	}
	
	void GameBeginGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), GameBeginTexture);
		if(GUI.Button(new Rect(Screen.width * 0.45f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.1f), "Start"))
		{
			IsGameStart = false;
			IsGamePlaying = true;
			Time.timeScale = 1.0f;
		}
	}
	
	void GameBegin()
	{
		
		
	}
	
	void GamePlayingGUI()
	{
		GUI.Label(new Rect(Screen.width * 0.95f, Screen.height * 0.1f, 50, 50), ((int)GameLengthTimer).ToString(), GameLengthTimerStyle);		
	}
	
	
	void GamePlaying()
	{
		GameLengthTimer -= Time.deltaTime;
		
		//check if the game is over
		if(GameLengthTimer <= 0.0f)
		{
			IsGamePlaying = false;
			IsGameEnd = true;
			Time.timeScale = 0.0f;
		}	
	}
	
	void GameEndGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), GameEndTexture);
		if(GUI.Button(new Rect(Screen.width * 0.45f, Screen.height * 0.75f, Screen.width * 0.1f, Screen.height * 0.1f), "Replay"))
		{
			IsGameEnd = false;
			IsGameStart = true;
			Time.timeScale = 1.0f;
			Application.LoadLevel(Application.loadedLevel);
		}		
	}
	
	void GameEnd()
	{
		
	}
}
