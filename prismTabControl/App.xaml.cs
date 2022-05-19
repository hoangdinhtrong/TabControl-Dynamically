using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using prismTabControl.CustomAdapters;
using prismTabControl.Modules;
using prismTabControl.Views;
using System.Windows;
using System.Windows.Controls;

namespace prismTabControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var modules = base.CreateModuleCatalog();
            modules.AddModule<MainModule>();
            return modules;
        }
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(TabControl),
                Container.Resolve<TabControlAdapter>());
        }
    }
}
