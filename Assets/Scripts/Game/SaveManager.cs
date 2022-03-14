using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;
using Game;
using Game.Quests;
using MoreMountains.CorgiEngine;
using System;

namespace Game
{
    [Serializable]
    public class SaveInfo
    {
        public string currentScene;
        public Dictionary<string, string> additionalSceneInfo;
        public Character player;
        public int MaximumLives;
		public int CurrentLives;
        public Vector2 LevelMapPosition; 
        public int Points;
        public bool HasDoneMainQuest;
        public Quest CurrentQuest;
    }

    //A delegate 
    public delegate void ObjectSpecificMethods(Dictionary<string, string> additionalSceneInfo);


    public class SaveManager : MMSingleton<SaveManager>
    {
        //A delegate to which you can add methods that should be called upon saving.
        //Those methods cansave data as string Key/Value pairs in the savedata.additionalSceneInfo
        public ObjectSpecificMethods specificMethodsOnSave;
        public const string defaultFileName = "SavedData.data";

        

        // Start is called before the first frame update
        void Start()
        {
        }

        public void Save(string fileName = defaultFileName)
        {
            SaveInfo saveInfo = new SaveInfo();
            saveInfo.currentScene = SceneManager.GetActiveScene().name;
            if(specificMethodsOnSave != null)
            {
                specificMethodsOnSave(saveInfo.additionalSceneInfo);
            }
            Character player = RHLevelManager.GetPlayer;
            saveInfo.player = player;
            
            Health health = player.GetComponent<Health>();
            saveInfo.CurrentLives = health.CurrentHealth;
            saveInfo.MaximumLives = health.MaximumHealth;

            saveInfo.Points = RHGameManager.Instance.Points;
            saveInfo.LevelMapPosition = new Vector2(player.transform.position.x, player.transform.position.y);

            saveInfo.HasDoneMainQuest = RHGameManager.Instance.HasDoneMainQuest();
            Debug.Log("HasDoneMainQuest : " + RHGameManager.Instance.HasDoneMainQuest() + " Saved Value : " + saveInfo.HasDoneMainQuest);
            saveInfo.CurrentQuest = RHGameManager.Instance.CurrentQuest;


            MMSaveLoadManager.Save(saveInfo, fileName);
        }

        
    }
}

