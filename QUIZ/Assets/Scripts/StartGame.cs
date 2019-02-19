using Assets.MaterialUI.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    void Start()
    {
    List<RootObject> rootObjects = new List<RootObject>();
        string path = Application.streamingAssetsPath + "/Questions.json";
        using (StreamReader stream = new StreamReader(path, Encoding.UTF8))
        {
            string JsonFormat = stream.ReadToEnd();
            rootObjects = JsonConvert.DeserializeObject<List<RootObject>>(JsonFormat);
            gameManager.Init(rootObjects);
        }


    }
}
