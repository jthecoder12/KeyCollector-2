namespace KeyCollector_2.Engine.SceneManagement;

public abstract class Scene : IDisposable
{
    internal bool alreadyInit;

    internal abstract void Init();
    internal abstract void Render(float dt);

    public abstract void Dispose();
}
