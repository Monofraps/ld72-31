using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class LevelGenerator
{
    public string levelName;
    private List<List<char>> list = new List<List<char>>();
    private List<char> listLine;
    public GameObject wallTile;
    public GameObject wallTileCollered;
    public GameObject colorizeField;
	public GameObject pickUpItem;
	public GameObject parent;

    public LevelGenerator(string levelName, GameObject wallTile, GameObject wallTileCollered, GameObject colorizeField, GameObject pickUpItem, GameObject parent)
    {
        this.levelName = levelName;
        this.wallTile = wallTile;
        this.wallTileCollered = wallTileCollered;
        this.colorizeField = colorizeField;
		this.pickUpItem = pickUpItem;
		this.parent = parent;
    }

    public void readLevel()
    {
        List<string> lines = new List<string>(levelName.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        Debug.Log(lines.Count);
        foreach (string line in lines)
        {
            listLine = new List<char>(line.ToCharArray());
            list.Add(listLine);
        }
        int countX = 0;
        int countY = 0;
        GameObject forCollering;

        foreach (List<char> listLine in list)
        {
            foreach (char sign in listLine)
            {


                switch (sign)
                {
                    case 'R':
                        forCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					forCollering.GetComponent<ColoredWallTile>().tileColor = ColorizationColors.Red;
					forCollering.transform.parent = parent.transform;
                        break;

                    case 'G':
                        forCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					Debug.Log(forCollering);
					forCollering.GetComponent<ColoredWallTile>().tileColor = ColorizationColors.Green;
					forCollering.transform.parent = parent.transform;
                        break;

                    case 'B':
                        forCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
					forCollering.GetComponent<ColoredWallTile>().tileColor = ColorizationColors.Blue;
					forCollering.transform.parent = parent.transform;
                        break;

                    case 'W':
					forCollering = (GameObject)GameObject.Instantiate(wallTile, new Vector3(countX, -countY, 0), Quaternion.identity);
					forCollering.transform.parent = parent.transform;
                        break;

                    case 'r':
                        forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Red;
					forCollering.transform.parent = parent.transform;
                        break;
                    case 'g':
                        forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Green;
					forCollering.transform.parent = parent.transform;
                        break;
                    case 'b':
					forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Blue;
					forCollering.transform.parent = parent.transform;
                        break;
				case 'I':
					forCollering = (GameObject)GameObject.Instantiate(pickUpItem, new Vector3(countX, -countY, 0), Quaternion.identity);
					forCollering.transform.parent = parent.transform;
					break;

                }
                countX++;
            }
            countY++;
            countX = 0;
        }



    }
}
