using UnityEngine;
public class SaveState : MonoBehaviour {
    private string savePath;
    public int HighestChestCount = 0;
    void Update()
    {
        float hp = GameObject.Find("Player").GetComponent<PlayerStats>().hp;
        if(hp <=0 ){ //If the player dies, save the chest count if it beats the record
            Load();
            if(HighestChestCount < GenChest.score)
                HighestChestCount = GenChest.score;
            Debug.Log(GenChest.score);
            Save();
        }
    }
    private void Awake() {        
        savePath = Application.persistentDataPath + "/saveData.json"; 
        Debug.Log("Save will be save to the path: " + savePath);
        Load();
    }    
    private void Save() {        
        SaveManager.SaveAsJSON(savePath, new SaveData(this,HighestChestCount));  
    }
    private void Load() {  
        SaveData save = SaveManager.LoadFromJSON(savePath);
        this.HighestChestCount = save.HighestChestCount;
    }
}