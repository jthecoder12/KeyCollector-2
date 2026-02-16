using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;

namespace KeyCollector_2.Engine
{
    public abstract class Game : IDisposable
    {
        public Game(int width, int height, string title)
        {
            Raylib.InitWindow(width, height, title);
        }

        public void Render()
        {
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                float dt = Raylib.GetFrameTime();
                Update(Raylib.GetFrameTime());
                SceneManager.Render(dt);
                Raylib.EndDrawing();
            }
        }

        internal abstract void Init();
        protected abstract void Update(float dt);
        
        protected void Shutdown()
        {

        }

        public void Dispose()
        {
            Console.WriteLine("Disposing");
            Shutdown();
            SceneManager.Dispose();
            Raylib.CloseWindow();
        }
    }
}
