using KeyCollector_2.Engine;
using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.App.Entities
{
    internal class Player : IRenderable, IResizable
    {
        private const float speed = 250;
        private readonly float sqrt2 = MathF.Sqrt(2);

        internal bool moving = true;

        internal Rectangle rectangle = new();

        public void Render()
        {
            Raylib.DrawRectangleRec(rectangle, Color.White);

            if (moving)
            {
                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.D)) Move(Vector2.UnitY * -speed / sqrt2);
                    else Move(Vector2.UnitY * -speed);
                }
                if (Raylib.IsKeyDown(KeyboardKey.A))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.S)) Move(Vector2.UnitX * -speed / sqrt2);
                    else Move(Vector2.UnitX * -speed);
                }
                if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.D)) Move(Vector2.UnitY * speed / sqrt2);
                    else Move(Vector2.UnitY * speed);
                }
                if (Raylib.IsKeyDown(KeyboardKey.D))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.S)) Move(Vector2.UnitX * speed / sqrt2);
                    else Move(Vector2.UnitX * speed);
                }
            }
        }

        public void Resize(int width, int height)
        {
            rectangle.Size = new(MathF.Sqrt(width * width + height * height) / 48.95349267f, MathF.Sqrt(width * width + height * height) / 48.95349267f);
            rectangle.Position = new((width - rectangle.Width) / 2, (height - rectangle.Height) / 2);
        }

        private void Move(Vector2 moveBy)
        {
            rectangle.Position += moveBy * Raylib.GetFrameTime();
        }
    }
}
