using Raylib_cs;

namespace KeyCollector_2.App.Entities
{
    public abstract class Entity
    {
        protected Rectangle rect;
        protected Color color;

        public void Render()
        {
            Raylib.DrawRectangle((int) rect.X, (int) rect.Y, (int) rect.Width, (int) rect.Height, color);
        }
    }
}
