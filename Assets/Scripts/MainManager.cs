using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Handling Data Presistance
/// </summary>
public class MainManager : MonoBehaviour
{
    //Access from any other script
    public static MainManager Instance;

    //Turning into serializable date that can be saved through sessions
    public Color TeamColor;

    private void Awake()
    {
        //Checking if another scheen has been created - singleton
        if(Instance != null)
        {
            Destroy(gameObject); //Destroying extra scene if a scene has already been made
            return;
        }

        Instance = this; //Initial scene being made
        DontDestroyOnLoad(gameObject); //Ensuring that the scene has not been deleted upon reload

        LoadColor();
    }

    #region Saved Data

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    #region Saved Color

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        //checking for file existence
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
    #endregion
    #endregion
}
