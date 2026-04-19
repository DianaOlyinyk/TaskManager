using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManager.DL.Models;
using Task = System.Threading.Tasks.Task;
using TaskModel = TaskManager.DL.Models.Task;

namespace TaskManager.DAL
{
    public class FileStorageService : IStorageService
    {
        private readonly string filePath;
        private readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = true
        };

        public FileStorageService()
        {
            var dataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TaskManager");

            Directory.CreateDirectory(dataFolder);
            filePath = Path.Combine(dataFolder, "projects.json");
        }

        public async Task<List<Project>> LoadProjectsAsync()
        {
            if (!File.Exists(filePath))
            {
                return new List<Project>();
            }

            await using var stream = File.OpenRead(filePath);
            var projects = await JsonSerializer.DeserializeAsync<List<Project>>(stream, jsonOptions);

            return projects ?? new List<Project>();
        }
       
        public async Task SaveProjectsAsync(List<Project> projects)
        {
            await using var stream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(stream, projects, jsonOptions);
        }
    }
}
