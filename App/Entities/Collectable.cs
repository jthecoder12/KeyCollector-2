using KeyCollector_2.App.Scenes;
using KeyCollector_2.Engine;
using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.App.Entities
{
    internal abstract class Collectable : IRenderable, IResizable
    {
        private readonly int[] positionArray;

        protected readonly LevelScene level;

        protected Vector2 position;
        protected float radius;

        internal Collectable(int[] position, LevelScene level)
        {
            positionArray = position;
            this.level = level;
        }

        public abstract void Render();

        public void Resize(int width, int height)
        {
            radius = MathF.Sqrt(width * width + height * height) / 146.860478f;
            position = new(width * positionArray[0] / 1280, height * positionArray[1] / 720);
        }

        protected void Draw(Color color)
        {
            Raylib.DrawCircleV(position, radius, color);
        }
    }
}
