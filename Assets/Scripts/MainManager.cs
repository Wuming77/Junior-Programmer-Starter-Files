using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MainManager Instance;

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            //Debug.Log(path);
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
}
