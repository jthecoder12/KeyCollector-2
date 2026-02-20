namespace KeyCollector_2.Engine.SceneManagement;

public abstract class Scene : IDisposable, IRenderableDT
{
    internal bool alreadyInit;

    internal abstract void Init();
    internal abstract void Resize(float width, float height);

    public abstract void Dispose();
    public abstract void Render(float dt);
}
