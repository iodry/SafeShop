using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelData
{
    public int levelAt=2;
    public int[] levelScores;

    public LevelData()
    {
        //levelScores = new int[SceneManager.sceneCountInBuildSettings];
        //levelAt = 0;

        //int nbOfLevelsInGame = SceneManager.sceneCountInBuildSettings - 4;

        /*        for (int i = 0; i < levelScores.Length; i++)
                {
                    levelScores[i] = 0;
                    Debug.Log("INIT1 lvl#" + i + "=" + levelScores[i]);

                }*/

    }
    public LevelData(int levelNb)
    {
        levelAt = levelNb;
        //levelScores = new int[SceneManager.sceneCountInBuildSettings];
        //int nbOfLevelsInGame = SceneManager.sceneCountInBuildSettings - 4;

        /*       for (int i = 0; i < levelScores.Length; i++)
                {
                    levelScores[i] = 0;
                    Debug.Log("INIT lvl#" + i + "=" + levelScores[i]);

                }*/

    }
    //Surcharge constructor with data star level completed
    public LevelData(int levelNb, int starNB)
    {
        levelAt = levelNb;
        levelScores[levelNb] = starNB;
        for (int i = 0; i < levelScores.Length; i++)
        {
            Debug.Log("UPDATE lvl#" + i + "=" + levelScores[i]);
        }

    }
}
