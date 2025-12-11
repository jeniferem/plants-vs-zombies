using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public int currenttLevelIndex =0;
    public List<LevelData> levels;

    public void SetLevel(int levelIndex)
    {
        currenttLevelIndex = levelIndex;
    }
     public void AddLevel(int number)
    {
        currenttLevelIndex +=number;
        if(currenttLevelIndex >=levels.Count)
        {
             currenttLevelIndex =0;
        }
    }
}
