﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    private Button button;
    public void Start(){
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        string path = Application.persistentDataPath + "/saveData.json";
        SaveData data = SaveManager.LoadFromJSON(path);
        GameObject score = GameObject.Find("Score");
        //If there is no save data, you can't load so disable the button.
        if(data == null){
            button.interactable = false;
        }else{
            score.GetComponent<TMPro.TextMeshProUGUI>().text = data.HighestChestCount.ToString(); 
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
