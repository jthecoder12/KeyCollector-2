namespace KeyCollector_2.Engine
{
    public class DesktopLauncher
    {
        private readonly Game game;

        public DesktopLauncher(Game game)
        {
            this.game = game;
        }

        public void Run()
        {
            game.Init();
            game.Render();
            game.Dispose();
        }
    }
}
