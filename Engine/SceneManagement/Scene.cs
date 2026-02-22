namespace KeyCollector_2.Engine.SceneManagement;

public abstract class Scene : IDisposable, IRenderableDT, IResizable
{
    internal bool alreadyInit;

    internal abstract void Init();
    public abstract void Resize(int width, int height);

    public abstract void Dispose();
    public abstract void Render(float dt);
}
