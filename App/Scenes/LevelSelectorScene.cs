using KeyCollector_2.Engine.SceneManagement;
using KeyCollector_2.Engine.UI;
using Raylib_cs;
using System.Numerics;
using TinyDialogsNet;

namespace KeyCollector_2.App.Scenes
{
    internal class LevelSelectorScene(TitleScene title) : Scene
    {
        private readonly TitleScene titleScene = title;

        private readonly SpriteButton[] spriteButtons = new SpriteButton[10];
        internal readonly Dictionary<string, LevelScene> levelMap = [];

        private SpriteButton? backButton, customLevelButton, creditsButton;

        private string currentCustomLevelData = "";

        public override void Dispose()
        {
            spriteButtons[0].Dispose();
            backButton?.Dispose();
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

            if (backButton?.IsPressed ?? false)
            {
                SceneManager.SetCurrentScene(titleScene);

                KeyCollector2.clickSound?.Play();
            }
            backButton?.Render();

            if (customLevelButton?.IsPressed ?? false)
            {
                KeyCollector2.clickSound?.Play();

                FileFilter fileFilter = new("Level JSON File", ["*.json"]);
                var (canceled, paths) = TinyDialogs.OpenFileDialog("Select Level JSON File", "", false, fileFilter);

                if (canceled) Console.WriteLine("User pressed cancel");
                else
                {
                    currentCustomLevelData = File.ReadAllText(paths.FirstOrDefault() ?? "");
                    LoadCustomLevel();
                }
            }
            customLevelButton?.Render();

            if(creditsButton?.IsPressed ?? false)
            {
                SceneManager.SetCurrentScene(SceneManager.AddScene(new CreditsScene(this)));

                KeyCollector2.clickSound?.Play();
            }
            creditsButton?.Render();
        }

        internal override void Init()
        {
            AddLevels();

            Image x = Raylib.LoadImageFromMemory(".png", Properties.Resources.circlebutton);
            Texture2D y = Raylib.LoadTextureFromImage(x);
            Raylib.UnloadImage(x);

            for (int i = 0; i < 10; i++) spriteButtons[i] = new(x, Vector2.Zero, 3, KeyCollector2.font50, 50, (i + 1).ToString(), y);

            Image x1 = Raylib.LoadImageFromMemory(".png", Properties.Resources.rectbutton);
            Texture2D y1 = Raylib.LoadTextureFromImage(x1);
            Raylib.UnloadImage(x1);

            backButton = new(x1, Vector2.Zero, 3, KeyCollector2.font50, 50, "Back", y1);
            customLevelButton = new(x1, Vector2.Zero, 3, KeyCollector2.font50, 50, "Custom", y1);
            creditsButton = new(x1, Vector2.Zero, 3, KeyCollector2.font50, 50, "Credits", y1);
        }

        private void AddLevels()
        {
            levelMap.Add("1", new LevelScene(Properties.Resources.level1, "1"));
            levelMap.Add("2", new LevelScene(Properties.Resources.level2, "2"));
            levelMap.Add("3", new LevelScene(Properties.Resources.level3, "3"));
            levelMap.Add("4", new LevelScene(Properties.Resources.level4, "4"));
            levelMap.Add("5", new LevelScene(Properties.Resources.level5, "5"));
            levelMap.Add("6", new LevelScene(Properties.Resources.level6, "6"));
            levelMap.Add("7", new LevelScene(Properties.Resources.level7, "7"));
            levelMap.Add("8", new LevelScene(Properties.Resources.level8, "8"));
            levelMap.Add("9", new LevelScene(Properties.Resources.level9, "9"));
            levelMap.Add("10", new LevelScene(Properties.Resources.level10, "10"));
        }

        internal void ResetLevels()
        {
            levelMap.Clear();
            SceneManager.RemoveSceneType(typeof(LevelScene));
            AddLevels();
        }

        internal void LoadCustomLevel()
        {
            SceneManager.RemoveSceneType(typeof(LevelScene));
            SceneManager.SetCurrentScene(SceneManager.AddScene(new LevelScene(currentCustomLevelData, "0")));
        }

        public override void Resize(int width, int height)
        {
            for(int i = 0; i < 10; i++)
            {
                if (i == 0) spriteButtons[i].SetPosition(new(width / 6.4f, height / 7.2f));
                else spriteButtons[i].SetPosition(new(width / 6.4f + (width - width / 3.2f - 64) / 9 * i, height / 7.2f));
            }

            backButton?.SetPosition(Vector2.Zero);
            customLevelButton?.SetPosition(Vector2.UnitY * height - Vector2.UnitY * 64);
            creditsButton?.SetPosition(new(width - 192, height - 64));
        }
    }
}
