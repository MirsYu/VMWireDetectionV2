using Prism.Ioc;
using Prism.Unity;
using System.Diagnostics;
using System.Windows;
using VMWireDetectionV2.Services;
using VMWireDetectionV2.Vision;

namespace VMWireDetectionV2.Views
{
    public partial class App : Prism.Unity.PrismApplication
    {
        protected override Window CreateShell()
        {
            Debug.WriteLine("CreateShell method is called."); // 确认方法是否被调用
            return Container.Resolve<MainWindow>(); // 解析主窗口实例
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册所有服务
            containerRegistry.Register<IImageProcessingService, ImageProcessingService>();
            containerRegistry.Register<IDetectionService, DetectionService>();
            containerRegistry.Register<ICameraService, CameraService>();
            containerRegistry.Register<ILightSourceService, LightSourceService>();
            containerRegistry.Register<IModbusService, ModbusService>(); // 注册 Modbus 服务

            // 注册视觉工具
            containerRegistry.Register<VisionToolBase, ColorConverTool>(typeof(ColorConverTool).Name);
            containerRegistry.Register<VisionToolBase, ContourPatMarchTool>(typeof(ContourPatMarchTool).Name);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var container = Container; // 确保容器已初始化
            if (container != null)
            {
                // 输出容器的状态或其他调试信息
                Debug.WriteLine("Container is initialized.");
            }
            else
            {
                Debug.WriteLine("Container is null.");
            }
        }
    }
}
