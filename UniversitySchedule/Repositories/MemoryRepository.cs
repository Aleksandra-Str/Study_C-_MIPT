using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UniversitySchedule.Models;

namespace UniversitySchedule.Repositories
{
    public class MemoryRepository
    {
        private const string FilePath = "data.json";

        public List<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public List<Group> Groups { get; private set; } = new List<Group>();
        public List<Subject> Subjects { get; private set; } = new List<Subject>();

        public MemoryRepository()
        {
            Load();
        }

        public void Save()
        {
            var data = new SerializableData
            {
                Teachers = Teachers,
                Groups = Groups,
                Subjects = Subjects
            };

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            File.WriteAllText(FilePath, json);
        }

        private void Load()
        {
            if (!File.Exists(FilePath)) return;

            var json = File.ReadAllText(FilePath);
            var data = JsonConvert.DeserializeObject<SerializableData>(json,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            if (data != null)
            {
                Teachers = data.Teachers ?? new List<Teacher>();
                Groups = data.Groups ?? new List<Group>();
                Subjects = data.Subjects ?? new List<Subject>();
            }
        }

        private class SerializableData
        {
            public List<Teacher> Teachers { get; set; }
            public List<Group> Groups { get; set; }
            public List<Subject> Subjects { get; set; }
        }
    }
}
