using System;
using System.Collections.Generic;

namespace MageSurvivor
{
    public class ViewManager 
    {
        private List<IView> _views;
        private Dictionary<EViewLayer, int> LayerOrder;

        private const int ViewCount = 100;

        public ViewManager()
        {
            _views = new List<IView>();
            LayerOrder = new Dictionary<EViewLayer, int>();

            int index = 0;

            foreach (EViewLayer element in Enum.GetValues(typeof(EViewLayer)))
            {
                LayerOrder.Add(element, index);
                index += ViewCount;
            }
        }

        public void Register(IView view)
        {
            if (_views.Contains(view))
                return;

            _views.Add(view);
            var canvasOrder = LayerOrder[view.ViewLayer];
            LayerOrder[view.ViewLayer] += 1;
            view.SetCanvasOrder(canvasOrder);
        }

        public void UnRegister(IView view)
        {
            if (_views.Contains(view) == false)
                return;

            _views.Remove(view);
            LayerOrder[view.ViewLayer] -= 1;
        }

        public void Disable()
        {
            _views.ForEach(view => view.Disable());
            _views.Clear();
        }
    }
}
