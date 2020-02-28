using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewGame: MonoBehaviour
{
    private Button button;
     AudioSource ad;
    public void Start(){
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        ad = GetComponent<AudioSource>();
        ad.pitch = 1.2f;

        // ad.Play();
    }
    public void Update(){
    }
    private void OnClick(){
        Debug.Log("Click!");
        string path = Application.persistentDataPath + "/saveData.json";
        SaveManager.SaveAsJSON(path, new SaveData(0));
        SceneManager.LoadScene("SampleScene");
    }
}
