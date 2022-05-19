using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace prismTabControl.ViewModels
{
    public class FooterViewModel : BindableBase
    {
        public FooterViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseTabItemCommand = new DelegateCommand<object>(OnCloseTabItem);
        }

        private void OnCloseTabItem(object obj)
        {
            TabItem tabitem = obj as TabItem;
            _regionManager.Regions["TabRegion"].Remove(tabitem.Content);
        }

        public IRegionManager _regionManager { get; }

        public DelegateCommand<object> CloseTabItemCommand { get; set; }
    }
}
