using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	public string levelName;
    public TextAsset levelAsset;
	private List<List<char>> list = new List<List<char>> ();
	private List<char> listLine;
	public GameObject wallTile;



	// Use this for initialization
	void Start () {
        levelName = levelAsset.text;
        readLevel();
	}

	public void readLevel(){
		List<string> lines = new List<string>(levelName.Split ('\n'));
		foreach(string line in lines){
			listLine = new List<char> (line.ToCharArray ());
			list.Add (listLine);
		}
		int countX = 0;
		int countY = 0;
		foreach(List<char> listLine in list){
			foreach(char sign in listLine){
				if(sign == 'W'){
				Instantiate(wallTile, new Vector3(countX, countY, 0), Quaternion.identity);
				}
				countY++;
			}
			countX++;
			countY = 0;
		}



		}
	// Update is called once per frame
	void Update () {
	
	}
}
