using System;
using MageSurvivor.Utils;

namespace MageSurvivor
{
    public interface IComposition : IDisposable
    {
        IViewFactory GetViewFactory();
        IResourceManager GetResourceManager();
    }
}
