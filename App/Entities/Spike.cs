using KeyCollector_2.App.Scenes;
using KeyCollector_2.Engine.SceneManagement;
using Raylib_cs;

namespace KeyCollector_2.App.Entities
{
    internal class Spike(int[] position, LevelScene level) : Collectable(position, level)
    {
        public override void Render()
        {
            Draw(Color.Red);

            if (Raylib.CheckCollisionCircleRec(position, radius, level.player.rectangle))
            {
                if(level.levelNumber == "0")
                {
                    level.levelSelector?.LoadCustomLevel();
                    level.Dispose();
                } else
                {
                    level.levelSelector?.ResetLevels();

                    if (level.levelSelector is not null)
                    {
                        level.levelSelector.levelMap.TryGetValue(level.levelNumber, out LevelScene? levelScene);
                        if (levelScene is not null) SceneManager.SetCurrentScene(SceneManager.AddScene(levelScene));
                    }

                    level.Dispose();
                }
            }
        }
    }
}
