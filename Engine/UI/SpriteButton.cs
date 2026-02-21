using Raylib_cs;
using System.Numerics;

namespace KeyCollector_2.Engine.UI
{
    public class SpriteButton : IDisposable, IRenderable
    {
        private readonly Texture2D texture;
        private Rectangle srcRect, btnBounds;

        private readonly Font font;
        private readonly int fontSize;
        private readonly Vector2 textSize;

        private Vector2 mousePoint, buttonSize, textOffset;
        private int btnState;

        public bool IsPressed { get; private set; }
        public string Text { get; private set; }

        public SpriteButton(Image image, Vector2 position, float numFrames, Font font, int fontSize, string text, bool dontUnloadImage)
        {
            this.font = font;
            this.fontSize = fontSize;
            Text = text;

            textSize = Raylib.MeasureTextEx(font, Text, fontSize, 0);

            texture = Raylib.LoadTextureFromImage(image);
            if(!dontUnloadImage) Raylib.UnloadImage(image);

            buttonSize = new(texture.Width, texture.Height / numFrames);
            srcRect = new(Vector2.Zero, buttonSize);
            btnBounds = new(position, buttonSize);
        }

        public void Render()
        {
            mousePoint = Raylib.GetMousePosition();
            IsPressed = false;

            if (Raylib.CheckCollisionPointRec(mousePoint, btnBounds))
            {
                if (Raylib.IsMouseButtonDown(MouseButton.Left)) {
                    textOffset.Y = btnBounds.Y + (btnBounds.Height / 2) - (textSize.Y / 2);
                    btnState = 2;
                }
                else {
                    textOffset.Y = btnBounds.Y - 5 + (btnBounds.Height / 2) - (textSize.Y / 2);
                    btnState = 1;
                }

                if (Raylib.IsMouseButtonReleased(MouseButton.Left)) IsPressed = true;
            }
            else {
                textOffset.Y = btnBounds.Y - 5 + (btnBounds.Height / 2) - (textSize.Y / 2);
                btnState = 0;
            }

            srcRect.Y = btnState * buttonSize.Y;

            Raylib.DrawTextureRec(texture, srcRect, btnBounds.Position, Color.White);
            Raylib.DrawTextEx(font, Text, textOffset, fontSize, 0, Color.Black);
        }

        public void SetPosition(Vector2 nPos)
        {
            btnBounds.Position = nPos;
            textOffset = new(btnBounds.X + (btnBounds.Width / 2) - (textSize.X / 2), 0);
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(texture);
        }
    }
}
