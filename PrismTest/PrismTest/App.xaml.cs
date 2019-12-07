using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace PrismTest
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Overrides of PrismApplicationBase

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        /// <summary>Creates the shell or main window of the application.</summary>
        /// <returns>The shell of the application.</returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        #endregion

       ///// <summary>
       ///// 自定义设置view和viewmodel关联关系
       ///// </summary>
       // protected override void ConfigureViewModelLocator()
       // {
       //     base.ConfigureViewModelLocator();

       //     ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
       //     {
       //         var viewName = viewType.FullName;
       //         var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
       //         var viewModelName = $"{viewName}VM, {viewAssemblyName}";
       //         return Type.GetType(viewModelName);
       //     });
       // }
    }
}
