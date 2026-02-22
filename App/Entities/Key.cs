using KeyCollector_2.App.Scenes;
using Raylib_cs;

namespace KeyCollector_2.App.Entities
{
    internal class Key(int[] position, LevelScene level) : Collectable(position, level)
    {
        private bool active = true;

        public override void Render()
        {
            if(active)
            {
                Draw(Color.Yellow);
                if (Raylib.CheckCollisionCircleRec(position, radius, level.player.rectangle))
                {
                    KeyCollector2.coinSound?.Play();
                    active = false;
                    level.numActive--;
                }
            }
        }
    }
}
