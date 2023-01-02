namespace Maui.Material.You.Source;

public interface ISourceManager
{
    public void LoadFolder(string path);

    public void LoadSource(string path, string alias);

    public void UnloadSource(string name);

    public ISource GetSource(string name);
}