using System;
using System.IO;

namespace Maui.Material.You.Source;

public interface ISource : ICloneable
{
    public void Load(Stream stream);
}