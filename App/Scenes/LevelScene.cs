using ImGuiNET;
using KeyCollector_2.App.Entities;
using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;
using rlImGui_cs;
using System.Numerics;
using System.Text.Json;

namespace KeyCollector_2.App.Scenes
{
    internal class LevelScene(string levelDataString, string levelNumber) : Scene
    {
        private readonly Dictionary<string, int[][]> levelData = JsonSerializer.Deserialize<Dictionary<string, int[][]>>(levelDataString) ?? [];
        internal readonly List<Key> keyList = [];
        private readonly List<Spike> spikeList = [];

        internal string levelNumber = levelNumber;

        internal readonly Player player = new();

        internal LevelSelectorScene? levelSelector;
        private bool pauseOpen;

        internal int numActive;

        private Vector2 finishTextPosition;

        public override void Dispose()
        {
            Console.WriteLine("Disposing level scene");
        }

        public override void Render(float dt)
        {
            foreach (Key key in keyList) key.Render();
            foreach (Spike spike in spikeList) spike.Render();

            player.Render();
            player.moving = !(pauseOpen || numActive == 0);

            if (Raylib.IsKeyPressed(KeyboardKey.Escape)) pauseOpen = !pauseOpen;

            if (levelNumber == "10") Raylib.DrawTextEx(KeyCollector2.font50, "Thanks for playing", finishTextPosition, 50, 0, Color.White);

            rlImGui.Begin();

            if(numActive == 0)
            {
                pauseOpen = false;

                ImGui.Begin("Level Complete", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);
                KeyCollector2.DefaultImGuiWindow();
                if (levelNumber == "10" && levelSelector is not null) if (ImGui.Button("View Credits")) SceneManager.SetCurrentScene(SceneManager.AddScene(new CreditsScene(levelSelector)));
                BackButton();
                ImGui.End();
            }

            if (pauseOpen)
            {
                ImGui.Begin("Paused", ref pauseOpen, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);
                KeyCollector2.DefaultImGuiWindow();
                BackButton();
                ImGui.End();
            }

            rlImGui.End();
        }

        internal override void Init()
        {
            foreach (Scene scene in SceneManager.GetScenes()) if (scene is LevelSelectorScene scene1) levelSelector = scene1;

            levelData.TryGetValue("keys", out int[][]? keys);
            if (keys is not null) {
                numActive = keys.Length;

                foreach (int[] keyPos in keys) keyList.Add(new(keyPos, this));
            }

            levelData.TryGetValue("spikes", out int[][]? spikes);
            if (spikes is not null) foreach (int[] spikePos in spikes) spikeList.Add(new(spikePos, this));

            
        }

        public override void Resize(int width, int height)
        {
            foreach (Key key in keyList) key.Resize(width, height);
            foreach (Spike spike in spikeList) spike.Resize(width, height);

            player.Resize(width, height);

            if (levelNumber == "10") {
                Vector2 finishTextSize = Raylib.MeasureTextEx(KeyCollector2.font50, "Thanks for playing", 50, 0);
                finishTextPosition = new(width - finishTextSize.X, height - finishTextSize.Y);
            }
        }

        private void BackButton()
        {
            if (ImGui.Button("Go Back") && levelSelector is not null)
            {
                levelSelector.ResetLevels();

                pauseOpen = false;
                player.Resize(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

                SceneManager.SetCurrentScene(levelSelector);

                Dispose();
            }
        }
    }
}
