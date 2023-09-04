using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BoxJump.Code.GameLogic
{
    public static class JsonManager
    {
        private static string jsonPath;

        public static void SaveToJson(object _object, string fileName)
        {
            jsonPath = $"{Application.dataPath}/BoxJump/Resources/FileSaves/{fileName}.json";
            var json = JsonUtility.ToJson(_object, true);
            File.WriteAllText(jsonPath, json);
        }

        public static T LoadFromJson<T>(string fileName, T defaultData = default)
        {
            jsonPath = $"{Application.dataPath}/BoxJump/Resources/FileSaves/{fileName}.json";

            if (!File.Exists(jsonPath))
            {
                if (EqualityComparer<T>.Default.Equals(defaultData, default))
                    defaultData = Activator.CreateInstance<T>();

                SaveToJson(defaultData, fileName);
            }

            var json = File.ReadAllText(jsonPath);

            var jsonData = JsonUtility.FromJson<T>(json);
            return jsonData;
        }
    }
}