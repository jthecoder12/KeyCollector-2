using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.App.Scenes
{
    public class TitleScene : Scene
    {
        private const int fontSize = 50;
        private const string titleText = "Key Collector 2";

        private Vector2 titlePosition;

        internal override void Init()
        {
            titlePosition = new Vector2(Raylib.GetScreenWidth() / 2 - Raylib.MeasureTextEx(KeyCollector2.font50, titleText, fontSize, 0).X / 2, Raylib.GetScreenWidth() / 80);
        }

        internal override void Render(float dt)
        {
            Raylib.DrawTextEx(KeyCollector2.font50, titleText, titlePosition, fontSize, 0, Color.White);
        }

        public override void Dispose()
        {
            Console.WriteLine("Disposing scene");
        }
    }
}
