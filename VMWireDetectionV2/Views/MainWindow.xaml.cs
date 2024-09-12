using Prism.Ioc;
using System;
using System.Windows;
using VMWireDetectionV2.Services;
using VMWireDetectionV2.ViewModels;
using VMWireDetectionV2.Vision;

namespace VMWireDetectionV2.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private  MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // 如果你希望手动设置 UserControl 的 DataContext
            var imageViewerControl = (ImageViewerControl)FindName("ImageViewerControl");
            imageViewerControl.DataContext = new ImageViewerViewModel(); // 确保使用正确的 ViewModel


        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _viewModel.Cleanup();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                        var container = (Application.Current as Prism.Unity.PrismApplication)?.Container;
            if (container != null)
            {
                // 从容器中解析所有依赖项
                var imageProcessingService = container.Resolve<IImageProcessingService>();
                var cameraService = container.Resolve<ICameraService>();
                var lightSourceService = container.Resolve<ILightSourceService>();
                var modbusService = container.Resolve<IModbusService>();
                var visionToolManager = container.Resolve<VisionToolManager>();

                _viewModel = new MainViewModel(
                    imageProcessingService,
                    cameraService,
                    lightSourceService,
                    modbusService,
                    visionToolManager);

                DataContext = _viewModel;
            }
            else
            {
                // 处理容器为空的情况
                MessageBox.Show("Container is not available.");
            }
        }
    }
}
