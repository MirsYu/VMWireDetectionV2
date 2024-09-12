using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using VMWireDetectionV2.Models;
using VMWireDetectionV2.Services;

namespace VMWireDetectionV2.ViewModels
{
    /// <summary>
    /// ImageProcessingViewModel 负责图像处理的逻辑
    /// </summary>
    public class ImageProcessingViewModel : BindableBase
    {
        private readonly IDetectionService _detectionService;

        public ImageProcessingViewModel(IDetectionService detectionService)
        {
            _detectionService = detectionService;
            ProcessImageCommand = new DelegateCommand<ImageModel>(async image => await ProcessImageAsync(image)); // 初始化处理图像命令
        }

        /// <summary>
        /// 处理图像的命令
        /// </summary>
        public DelegateCommand<ImageModel> ProcessImageCommand { get; }

        /// <summary>
        /// 处理图像的逻辑
        /// </summary>
        /// <param name="image">待处理的图像</param>
        /// <returns></returns>
        private async Task ProcessImageAsync(ImageModel image)
        {
            await _detectionService.DetectAsync(image); // 调用检测服务
        }
    }
}
