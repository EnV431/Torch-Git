using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Scriptable Objects/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    [Header("Resources")]
    public int food;
    public int water;
    public int money;
    [Range(0, 100)]
    public int happiness;
    public int security;
    [Range(0, 100)]
    public int lightLevel;
    public int alcohol;


}
