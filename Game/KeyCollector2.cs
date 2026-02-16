using KeyCollector_2.Engine;
using KeyCollector_2.Engine.SceneManagement;
using KeyCollector_2.App.Scenes;
using Raylib_cs;

namespace KeyCollector_2.App
{
    internal class KeyCollector2 : Game
    {
        public KeyCollector2(int width, int height, string title) : base(width, height, title)
        {
        }

        internal override void Init()
        {
            SceneManager.SetCurrentScene(SceneManager.AddScene(new TitleScene()));
        }

        protected override void Update(float dt)
        {
            Raylib.ClearBackground(Color.RayWhite);
        }
    }
}
