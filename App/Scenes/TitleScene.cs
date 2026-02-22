using KeyCollector_2.Engine.SceneManagement;
using KeyCollector_2.Engine.UI;
using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.App.Scenes
{
    internal class TitleScene : Scene
    {
        private const int fontSize = 50;
        private const string titleText = "Key Collector 2";

        private Vector2 titlePosition;

        private int playButtonWidth;
        private SpriteButton? playButton;

        private LevelSelectorScene? levelSelectorScene;

        internal override void Init()
        {
            Image playButtonImage = Raylib.LoadImageFromMemory(".png", Properties.Resources.rectbutton);
            playButtonWidth = playButtonImage.Width;
            playButton = new(playButtonImage, Vector2.Zero, 3, KeyCollector2.font50, 50, "Play");
        }

        public override void Render(float dt)
        {
            Raylib.DrawTextEx(KeyCollector2.font50, titleText, titlePosition, fontSize, 0, Color.White);

            if (playButton?.IsPressed ?? false) {
                KeyCollector2.clickSound?.Play();

                levelSelectorScene ??= new LevelSelectorScene(this);
                SceneManager.SetCurrentScene(SceneManager.AddScene(levelSelectorScene));
            }

            playButton?.Render();
        }

        public override void Dispose()
        {
            playButton?.Dispose();
            Console.WriteLine("Disposing scene");
        }

        public override void Resize(int width, int height)
        {
            playButton?.SetPosition(new(width / 2 - playButtonWidth / 2, height / 3.6f));
            titlePosition = new(width / 2 - Raylib.MeasureTextEx(KeyCollector2.font50, titleText, fontSize, 0).X / 2, height / 80);
        }
    }
}
