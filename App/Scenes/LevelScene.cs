using KeyCollector_2.Engine.SceneManagement;
using System.Text.Json;

namespace KeyCollector_2.App.Scenes
{
    internal class LevelScene : Scene
    {
        private readonly Dictionary<string, int[][]> levelData;

        public LevelScene(string levelDataString)
        {
            levelData = JsonSerializer.Deserialize<Dictionary<string, int[][]>>(levelDataString) ?? [];
        }

        public override void Dispose()
        {
            Console.WriteLine("Disposing level scene");
        }

        public override void Render(float dt)
        {
            
        }

        internal override void Init()
        {
            
        }

        internal override void Resize(float width, float height)
        {
            
        }
    }
}
