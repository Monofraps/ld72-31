﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class LevelGenerator  {
	public string levelName;
	private List<List<char>> list = new List<List<char>> ();
	private List<char> listLine;
	public GameObject wallTile;
	public GameObject wallTileCollered;
	public Color redColor;
	public Color greenColor;
	public Color blueColor;




	// Use this for initialization
	void Start (string levelName, GameObject wallTile, GameObject wallTileCollered)
	{
	    this.levelName = levelName;
	    this.wallTile = wallTile;
	    this.wallTileCollered = wallTileCollered;
	}

	public void readLevel(){
		List<string> lines = new List<string>(levelName.Split (new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries));
		Debug.Log (lines.Count);
		foreach(string line in lines){	
			listLine = new List<char> (line.ToCharArray ());
			list.Add (listLine);
		}
		int countX = 0;
		int countY = 0;
		GameObject wallTileForCollering;
		foreach(List<char> listLine in list){
			foreach(char sign in listLine){


				switch (sign) 
				{
					case 'R':
					Debug.Log (sign);
					wallTileForCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					wallTileForCollering.GetComponent<ColorizerField>().fieldColor= ColorizationColors.Red;
					break;

					case 'G':
					Debug.Log (sign);
                    wallTileForCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					wallTileForCollering.GetComponent<ColorizerField>().fieldColor= ColorizationColors.Green;
					break;

					case 'B':
					Debug.Log (sign);
                    wallTileForCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					wallTileForCollering.GetComponent<ColorizerField>().fieldColor= ColorizationColors.Blue;
					break;

					case 'W':
					Debug.Log (sign);
                    GameObject.Instantiate(wallTile, new Vector3(countX, -countY, 0), Quaternion.identity);
					break;

				}
				countX++;
			}
			countY++;
			countX = 0;
		}



		}
	// Update is called once per frame
	void Update () {
	
	}
}