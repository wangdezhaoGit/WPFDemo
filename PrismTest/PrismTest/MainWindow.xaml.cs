using Prism.Regions;
using System.Windows;
using Prism.Ioc;
using UserModuleA.Views;
using UserModuleB.Views;

namespace PrismTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion("ContentRegionA", typeof(UserControlA));
            regionManager.RegisterViewWithRegion("ContentRegionB", typeof(UserControlB));
            regionManager.RegisterViewWithRegion("ContentRegionC", typeof(UserControlA));
        }

        /*
         *第二种Region中添加View的方式‘
         *
         


        

        private IContainerExtension _container;
        private IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
           
        }

        public void SetRegionWithView()
        {
            var view = _container.Resolve<UserControlA>();
            IRegion region = _regionManager.Regions["ContentRegionA"];
            region.Add(view);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetRegionWithView();
        } */
    }
}
