using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;

namespace KeyCollector_2.App.Scenes
{
    public class TitleScene : Scene
    {
        internal override void Init()
        {
            
        }

        internal override void Render(float dt)
        {
            Raylib.DrawText("Key Collector 2", 200, 200, 25, Color.Black);
        }

        public override void Dispose()
        {
            Console.WriteLine("Disposing scene");
        }
    }
}
