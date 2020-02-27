using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int HighestChestCount;
    public SaveData(SaveState save,int Highest){
        HighestChestCount = Highest;
    }
}
