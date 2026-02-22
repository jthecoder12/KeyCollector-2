using Raylib_cs;

namespace KeyCollector_2.Engine.Audio
{
    internal class StreamedSound(string fileType, byte[] soundData) : IDisposable, IRenderable, IPlayable
    {
        private Music music = Raylib.LoadMusicStreamFromMemory(fileType, soundData);

        public void Dispose()
        {
            Raylib.UnloadMusicStream(music);
        }

        public void Play()
        {
            Raylib.PlayMusicStream(music);
        }

        public void Render()
        {
            Raylib.UpdateMusicStream(music);
        }

        public void SetLooping(bool looping)
        {
            music.Looping = looping;
        }
    }
}
