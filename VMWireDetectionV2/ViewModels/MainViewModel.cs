using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using VisionDesigner;
using VMWireDetectionV2.Models;
using VMWireDetectionV2.Services;
using VMWireDetectionV2.Vision;

namespace VMWireDetectionV2.ViewModels
{
    /// <summary>
    /// MainViewModel 负责管理主窗口的逻辑
    /// </summary>
    public class MainViewModel : BindableBase
    {
        private readonly IImageProcessingService _imageProcessingService;
        private readonly ICameraService _cameraService;
        private readonly ILightSourceService _lightSourceService;
        private readonly IModbusService _modbusService;
        private readonly VisionToolManager _toolManager;

        private ImageModel _currentImage;

        private string _modbusStatus;

        public MainViewModel(IImageProcessingService imageProcessingService, ICameraService cameraService, ILightSourceService lightSourceService, IModbusService modbusService, VisionToolManager toolManager)
        {
            _imageProcessingService = imageProcessingService;
            LoadImageCommand = new DelegateCommand<string>(LoadImage); // 初始化加载图片命令
            _cameraService = cameraService;
            _cameraService.Initialize();
            _cameraService.StartCapture();
            _lightSourceService = lightSourceService;
            _modbusService = modbusService;
            _modbusService.StatusChanged += OnModbusStatusChanged;
            _modbusService.Connect();
            _toolManager = toolManager;
        }

        public ImageModel CurrentImage
        {
            get => _currentImage;
            set => SetProperty(ref _currentImage, value); // 通知 UI 数据变化
        }

        /// <summary>
        /// 加载图像的命令
        /// </summary>
        public ICommand LoadImageCommand { get; }

        /// <summary>
        /// 加载图像的逻辑
        /// </summary>
        /// <param name="filePath">图像文件路径</param>
        private void LoadImage(string filePath)
        {
            CurrentImage = _imageProcessingService.LoadImage(filePath);
        }

        public ICommand CaptureImageCommand => new DelegateCommand(() =>
        {
            CurrentImage = _cameraService.GetCurrentImage();
        });

        public ICommand TurnOnLightCommand => new DelegateCommand(() =>
        {
            _lightSourceService.TurnOn();
        });

        public ICommand TurnOffLightCommand => new DelegateCommand(() =>
        {
            _lightSourceService.TurnOff();
        });

        public ICommand ReadDataCommand => new DelegateCommand(() =>
        {
            var data = _modbusService.ReadData("someAddress");
            // 处理读取的数据
        });

        public ICommand WriteDataCommand => new DelegateCommand(() =>
        {
            _modbusService.WriteData("someAddress", new byte[] { 0x01, 0x02 });
        });

        public string ModbusStatus
        {
            get => _modbusStatus;
            set => SetProperty(ref _modbusStatus, value);
        }

        private void OnModbusStatusChanged(string status)
        {
            // 确保在 UI 线程中更新 UI
            Application.Current.Dispatcher.Invoke(() =>
            {
                ModbusStatus = status;
            });
        }

        // 在 ViewModel 关闭时停止设备
        public void Cleanup()
        {
            _modbusService.Disconnect();
        }

        public ICommand ProcessImageCommand => new DelegateCommand(() =>
        {
            var processedImage = _toolManager.ProcessWithColorConver(new CMvdImage());
            // 处理图像
        });

        public ICommand DetectContoursCommand => new DelegateCommand(() =>
        {
            var contourResult = _toolManager.DetectContours(new CMvdImage());
            // 处理轮廓结果
        });

        // 其他命令和属性
    }
}
