using ImGuiNET;
using KeyCollector_2.App.Scenes;
using KeyCollector_2.Engine;
using KeyCollector_2.Engine.Audio;
using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;
using rlImGui_cs;
using System.Numerics;
using System.Runtime.InteropServices;

/*
 * Key Collector 2
 * Author: jthecoder12
 * A submission to the Brackeys Game Jam 2026.1
 * Licensed under the GNU General Public License v3.0 (GPL-3.0)
*/
namespace KeyCollector_2.App
{
    internal class KeyCollector2(int width, int height, string title) : Game(width, height, title)
    {
        private StreamedSound? music;

        internal static SoundEffect? clickSound, coinSound;
        internal static Font font50;

        private static unsafe void InitImGui()
        {
            ImFontConfigPtr fontConfig = new(ImGuiNative.ImFontConfig_ImFontConfig())
            {
                // Prevent double free
                FontDataOwnedByAtlas = false
            };

            // Start initialization
            rlImGui.BeginInitImGui();

            // Load the font as a byte array and get it's memory address
            ImGui.GetIO().Fonts.AddFontFromMemoryTTF(GCHandle.Alloc(Properties.Resources.OpenSans, GCHandleType.Pinned).AddrOfPinnedObject(), Properties.Resources.OpenSans.Length, 32, fontConfig);

            // Destroy the font config
            fontConfig.Destroy();

            rlImGui.EndInitImGui();
        }

        internal override void Init()
        {
            Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(Raylib.GetCurrentMonitor()));

            InitImGui();

            music = new(".ogg", Properties.Resources.music);
            music.SetLooping(true);
            music.Play();

            clickSound = new(".ogg", Properties.Resources.click);
            coinSound = new(".wav", Properties.Resources.coin);
            font50 = Raylib.LoadFontFromMemory(".ttf", Properties.Resources.OpenSans, 50, null, 0);

            SceneManager.SetCurrentScene(SceneManager.AddScene(new TitleScene()));
        }

        protected override void Update(float dt)
        {
            // Updates the music stream
            music?.Render();

            // Clears the background
            Raylib.ClearBackground(new Color(23, 24, 26));
        }

        protected override void Shutdown()
        {
            // Shutdown all of ImGui
            rlImGui.Shutdown();

            // Dispose sounds
            music?.Dispose();
            clickSound?.Dispose();
            coinSound?.Dispose();

            // Dispose font
            Raylib.UnloadFont(font50);
        }

        internal static void DefaultImGuiWindow()
        {
            ImGui.SetWindowSize(new(Raylib.GetScreenWidth() / 3.2f, Raylib.GetScreenHeight() / 2.4f));
            ImGui.SetWindowPos(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2) - ImGui.GetWindowSize() / 2);
        }
    }
}
