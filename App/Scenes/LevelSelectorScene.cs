using KeyCollector_2.Engine.SceneManagement;
using KeyCollector_2.Engine.UI;
using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.App.Scenes
{
    internal class LevelSelectorScene : Scene
    {
        private Image? circleButtonImage;
        private readonly SpriteButton[] spriteButtons = new SpriteButton[10];
        private readonly Dictionary<string, LevelScene> levelMap = new Dictionary<string, LevelScene>();

        public override void Dispose()
        {
            foreach (SpriteButton spriteButton in spriteButtons) spriteButton.Dispose();
        }

        public override void Render(float dt)
        {
            foreach (SpriteButton spriteButton in spriteButtons) {
                if (spriteButton.IsPressed) {
                    levelMap.TryGetValue(spriteButton.Text, out LevelScene? levelScene);
                    if (levelScene is not null) SceneManager.SetCurrentScene(SceneManager.AddScene(levelScene));

                    KeyCollector2.clickSound?.Play();
                }
                spriteButton.Render();
            }
        }

        internal override void Init()
        {
            levelMap.Add("1", new LevelScene(Properties.Resources.level1));

            circleButtonImage = Raylib.LoadImageFromMemory(".png", Properties.Resources.circlebutton);
            Image x = circleButtonImage ?? new Image();

            for (int i = 0; i < 10; i++) spriteButtons[i] = new SpriteButton(x, Vector2.Zero, 3, KeyCollector2.font50, 50, (i + 1).ToString(), i != 9);
        }

        internal override void Resize(float width, float height)
        {
            for(int i = 0; i < 10; i++)
            {
                if (i == 0) spriteButtons[i].SetPosition(new(width / 6.4f, height / 7.2f));
                else spriteButtons[i].SetPosition(new(width / 6.4f + (width - width / 3.2f - 64) / 9 * i, height / 7.2f));
            }
        }
    }
}
