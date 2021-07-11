using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
	// for Scoring system
	int currentScore;
	int currentPlayerHealth;

	// for Reset values
	Vector3 gombaSpawnPointStart = new Vector3(2.5f, -0.45f, 0); // hardcoded location
																 // .. other reset values 

	// for Consume.cs
	public int consumeTimeStep = 10;
	public int consumeLargestScale = 4;

	// for Break.cs
	public int breakTimeStep = 30;
	public int breakDebrisTorque = 10;
	public int breakDebrisForce = 10;

	// for SpawnDebris.cs
	public int spawnNumberOfDebris = 10;

	// for Rotator.cs
	public int rotatorRotateSpeed = 6;

	// for testing
	public int testValue;

	public int groundSurface = -1;

	public int maxOffset = 10;
	public int enemyPatroltime = 5;
}