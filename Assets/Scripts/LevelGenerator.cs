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

    public LevelGenerator(string levelName, GameObject wallTile, GameObject wallTileCollered, GameObject colorizeField)
    {
        this.levelName = levelName;
        this.wallTile = wallTile;
        this.wallTileCollered = wallTileCollered;
        this.colorizeField = colorizeField;
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
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Red;
                        break;

                    case 'G':
                        forCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Green;
                        break;

                    case 'B':
                        forCollering = ((GameObject)GameObject.Instantiate(wallTileCollered, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Blue;
                        break;

                    case 'W':
                        GameObject.Instantiate(wallTile, new Vector3(countX, -countY, 0), Quaternion.identity);
                        break;

                    case 'r':
                        forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Red;
                        break;
                    case 'g':
                        forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Green;
                        break;
                    case 'b':
                        forCollering = ((GameObject)GameObject.Instantiate(colorizeField, new Vector3(countX, -countY, 0), Quaternion.identity));
                        forCollering.GetComponent<ColorizerField>().fieldColor = ColorizationColors.Blue;
                        break;

                }
                countX++;
            }
            countY++;
            countX = 0;
        }



    }
}
