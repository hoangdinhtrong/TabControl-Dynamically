using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace prismTabControl.ViewModels
{
    public class ComboboxChangeViewModel : BindableBase
    {
        public ComboboxChangeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChanged);
        }

        private void OnSelectionChanged(object obj)
        {
            Type formType = Type.GetType(obj.ToString());
            _regionManager.RegisterViewWithRegion("TabRegion", formType);
        }

        public IRegionManager _regionManager { get; }

        public DelegateCommand<object> SelectionChangedCommand { get; set; }
    }
}
