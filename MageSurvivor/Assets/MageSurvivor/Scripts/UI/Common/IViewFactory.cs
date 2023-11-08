namespace MageSurvivor
{
    public interface IViewFactory
    {        
        TResult CreateView<TResult>(EViews view) where TResult : class;
    }
}
