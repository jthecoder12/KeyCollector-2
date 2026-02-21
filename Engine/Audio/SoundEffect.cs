using Raylib_cs;

namespace KeyCollector_2.Engine.Audio
{
    public class SoundEffect : IDisposable, IPlayable
    {
        private Sound sound;

        public SoundEffect(string fileType, byte[] soundData)
        {
            Wave wave = Raylib.LoadWaveFromMemory(fileType, soundData);
            sound = Raylib.LoadSoundFromWave(wave);
            Raylib.UnloadWave(wave);
        }

        public void Play()
        {
            Raylib.PlaySound(sound);
        }

        public void Dispose()
        {
            Raylib.UnloadSound(sound);
        }
    }
}
