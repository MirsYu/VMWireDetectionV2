using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using VMWireDetectionV2.Models;
using VMWireDetectionV2.Services;

namespace VMWireDetectionV2.ViewModels
{
    /// <summary>
    /// MainViewModel 负责管理主窗口的逻辑
    /// </summary>
    public class MainViewModel : BindableBase
    {
        private readonly IImageProcessingService _imageProcessingService;
        private ImageModel _currentImage;

        public MainViewModel(IImageProcessingService imageProcessingService)
        {
            _imageProcessingService = imageProcessingService;
            LoadImageCommand = new DelegateCommand<string>(LoadImage); // 初始化加载图片命令
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
    }
}
