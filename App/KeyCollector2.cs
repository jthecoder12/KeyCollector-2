using KeyCollector_2.Engine;
using KeyCollector_2.Engine.SceneManagement;
using KeyCollector_2.App.Scenes;
using Raylib_cs;

namespace KeyCollector_2.App
{
    internal class KeyCollector2(int width, int height, string title) : Game(width, height, title)
    {
        internal static Font font50;

        internal override void Init()
        {
            Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(Raylib.GetCurrentMonitor()));

            font50 = Raylib.LoadFontFromMemory(".ttf", Properties.Resources.OpenSans, 50, null, 0);
            SceneManager.SetCurrentScene(SceneManager.AddScene(new TitleScene()));
        }

        protected override void Update(float dt)
        {
            Raylib.ClearBackground(new Color(23, 24, 26));
        }

        protected override void Shutdown()
        {
            Raylib.UnloadFont(font50);
        }
    }
}
