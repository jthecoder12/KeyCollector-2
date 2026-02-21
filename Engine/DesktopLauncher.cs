namespace KeyCollector_2.Engine
{
    public class DesktopLauncher(Game game)
    {
        public void Run()
        {
            game.Init();
            game.Render();
            game.Dispose();
        }
    }
}
