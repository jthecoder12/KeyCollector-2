using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;
using System.Numerics;
using System.Text.Json;

namespace KeyCollector_2.App.Scenes
{
    internal class LevelScene(string levelDataString) : Scene
    {
        private readonly Dictionary<string, int[][]> levelData = JsonSerializer.Deserialize<Dictionary<string, int[][]>>(levelDataString) ?? [];
        private readonly List<Vector2> keyPositions = [];

        private float keyRadius;

        public override void Dispose()
        {
            Console.WriteLine("Disposing level scene");
        }

        public override void Render(float dt)
        {
            foreach (Vector2 keyPos in keyPositions) Raylib.DrawCircle((int) keyPos.X, (int) keyPos.Y, keyRadius, Color.Yellow);
        }

        internal override void Init()
        {
            levelData.TryGetValue("keys", out int[][]? keys);
            if (keys is not null) keyPositions.Add(new Vector2(keys[0][0], keys[0][1]));
        }

        internal override void Resize(float width, float height)
        {
            keyRadius = (float) Math.Sqrt(width * width + height * height) / 146.860478f;
        }
    }
}
