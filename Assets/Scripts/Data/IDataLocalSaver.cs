using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    public class IDataLocalSaver : IDataSaver
    {
        private const string FileName = "PlayerSave2";
        private const string SaveFileExtension = ".json";

        private IPersistentData _persistentData;

        public IDataLocalSaver(IPersistentData persistentData) => _persistentData = persistentData;

        private string SavePath => Application.persistentDataPath;
        private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

        public bool TryLoad()
        {
            if (IsDataAlreadyExist() == false)
                return false;

            _persistentData.BuildingData = JsonConvert.DeserializeObject<BuildingsData>(File.ReadAllText(FullPath));

            return true;
        }

        public void Save()
        {
            File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.BuildingData, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private bool IsDataAlreadyExist() => File.Exists(FullPath);
    }
}
