using System;
using System.Collections.Generic;

namespace MageSurvivor
{
    public class ViewManager 
    {
        private List<IView> _views;
        private Dictionary<EViewLayer, int> _layerOrder;

        private const int ViewCount = 100;

        public ViewManager()
        {
            _views = new List<IView>();
            _layerOrder = new Dictionary<EViewLayer, int>();

            int index = 0;

            foreach (EViewLayer element in Enum.GetValues(typeof(EViewLayer)))
            {
                _layerOrder.Add(element, index);
                index += ViewCount;
            }
        }

        public void Register(IView view)
        {
            if (_views.Contains(view))
                return;

            _views.Add(view);
            var canvasOrder = _layerOrder[view.ViewLayer];
            _layerOrder[view.ViewLayer] += 1;
            view.SetCanvasOrder(canvasOrder);
        }

        public void UnRegister(IView view)
        {
            if (_views.Contains(view) == false)
                return;

            _views.Remove(view);
            _layerOrder[view.ViewLayer] -= 1;
        }

        public void Disable()
        {
            _views.ForEach(view => view.Disable());
            int index = 0;
            foreach(var layer in _layerOrder.Keys)
            {
                _layerOrder[layer] = index;
                index += ViewCount;
            }
            _views.Clear();
        }
    }
}
