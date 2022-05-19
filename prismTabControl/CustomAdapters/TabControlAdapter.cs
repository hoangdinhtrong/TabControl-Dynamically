using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;

namespace prismTabControl.CustomAdapters
{
    public class TabControlAdapter : RegionAdapterBase<TabControl>
    {
        public TabControlAdapter(IRegionBehaviorFactory regionBehaviorFactory) : 
            base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                   
                    foreach (UserControl item in e.NewItems)
                    {
                        var tabItemExist = regionTarget.Items.OfType<TabItem>().FirstOrDefault(n => n.Header.Equals(item.Name));
                        if(tabItemExist != null)
                        {
                            tabItemExist.IsSelected = true;
                            return ;
                        }
                        regionTarget.Items.Add(new TabItem { Header = item.Name, Content = item, IsSelected = true });
                    }
                }
                    
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (UserControl item in e.OldItems)
                    {
                        var tabItemExist = regionTarget.Items.OfType<TabItem>().FirstOrDefault(n => n.Header.Equals(item.Name));
                        if (tabItemExist != null)
                        {
                            regionTarget.Items.Remove(tabItemExist);
                        }
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
