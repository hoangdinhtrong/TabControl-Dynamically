using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using prismTabControl.Views;

namespace prismTabControl.Modules
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ComboboxRegion", typeof(ComboboxChange));
            regionManager.RegisterViewWithRegion("FooterRegion", typeof(FooterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
