using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    private Button button;
    public void Start(){
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        string path = Application.persistentDataPath + "/saveData.json";
        SaveData data = SaveManager.LoadFromJSON(path);
        if(data == null){
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick(){
        SceneManager.LoadScene("SampleScene");
    }
}
