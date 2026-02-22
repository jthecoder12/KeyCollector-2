using ImGuiNET;
using KeyCollector_2.Engine.SceneManagement;
using rlImGui_cs;
using System.Numerics;

namespace KeyCollector_2.App.Scenes
{
    internal class CreditsScene(LevelSelectorScene levelSelector) : Scene
    {
        private LevelSelectorScene levelSelector = levelSelector;

        private Vector2 windowSize;

        public override void Dispose()
        {
            
        }

        public override void Render(float dt)
        {
            rlImGui.Begin();

            ImGui.Begin("Credits", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);
            ImGui.SetWindowPos(Vector2.Zero);
            ImGui.SetWindowSize(windowSize);
            ImGui.TextUnformatted(Properties.Resources.credits);
            ImGui.Separator();
            if (ImGui.Button("Back")) SceneManager.SetCurrentScene(levelSelector);
            ImGui.End();

            rlImGui.End();
        }

        public override void Resize(int width, int height)
        {
            windowSize = new(width, height);
        }

        internal override void Init()
        {
            
        }
    }
}
