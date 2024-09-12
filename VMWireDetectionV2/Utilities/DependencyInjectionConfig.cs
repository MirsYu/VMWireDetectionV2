using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using VMWireDetectionV2.Services;
using VMWireDetectionV2.Views;

namespace VMWireDetectionV2.Utilities
{
    /// <summary>
    /// 应用程序启动类，配置依赖注入
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>(); // 解析主窗口
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册服务
            containerRegistry.Register<IImageProcessingService, ImageProcessingService>();
            containerRegistry.Register<IDetectionService, DetectionService>();
        }
    }
}
