using KeyCollector_2.engine;

namespace KeyCollector_2.App
{
    static class Program
    {
        static void Main()
        {
            new DesktopLauncher(new KeyCollector2(1280, 720, "Key Collector 2")).Run();
        }
    }
}
