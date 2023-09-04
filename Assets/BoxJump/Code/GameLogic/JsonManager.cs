using System.IO;
using UnityEngine;

namespace BoxJump.Code.GameLogic
{
    public static class JsonManager
    {
        private static string jsonPath = Application.dataPath + "/BoxJump/Resources/FileSaves/PlayerData.json";
        
        public static void SaveToJson(object _object)
        {
            string json = JsonUtility.ToJson(_object, true);
            File.WriteAllText(jsonPath, json);
        }
        
        public static T LoadFromJson<T>()
        {
            string json = File.ReadAllText(jsonPath);
            T jsonData = JsonUtility.FromJson<T>(json);
            return jsonData;
        }
    }
}