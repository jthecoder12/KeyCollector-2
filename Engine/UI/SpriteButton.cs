using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.Engine.UI
{
    public class SpriteButton : IDisposable, IRenderable
    {
        private Texture2D texture;
        private Rectangle srcRect, btnBounds;

        private Vector2 mousePoint, buttonSize;
        private int btnState;

        public bool IsPressed { get; private set; }

        public SpriteButton(Image image, Vector2 position, float numFrames)
        {
            texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image);

            buttonSize = new(texture.Width, texture.Height / numFrames);
            srcRect = new Rectangle(Vector2.Zero, buttonSize);
            btnBounds = new Rectangle(position, buttonSize);
        }

        public void Render()
        {
            mousePoint = Raylib.GetMousePosition();
            IsPressed = false;

            if (Raylib.CheckCollisionPointRec(mousePoint, btnBounds))
            {
                if (Raylib.IsMouseButtonDown(MouseButton.Left)) btnState = 2;
                else btnState = 1;

                if (Raylib.IsMouseButtonReleased(MouseButton.Left)) IsPressed = true;
            }
            else btnState = 0;

            srcRect.Y = btnState * buttonSize.Y;

            Raylib.DrawTextureRec(texture, srcRect, btnBounds.Position, Color.White);
        }

        public void SetPosition(Vector2 nPos)
        {
            btnBounds.Position = nPos;
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(texture);
        }
    }
}
