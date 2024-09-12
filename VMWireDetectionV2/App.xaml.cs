﻿using Prism.Ioc;
using System.Windows;
using VMWireDetectionV2.Views;
using VMWireDetectionV2.Services;

namespace VMWireDetection
{
    public partial class App : Prism.Unity.PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>(); // 解析主窗口实例
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册所有服务
            containerRegistry.Register<IImageProcessingService, ImageProcessingService>();
            containerRegistry.Register<IDetectionService, DetectionService>();
        }
    }
}
