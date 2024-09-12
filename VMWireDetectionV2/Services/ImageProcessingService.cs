using VMWireDetectionV2.Models;

namespace VMWireDetectionV2.Services
{
    /// <summary>
    /// 图像处理服务接口
    /// </summary>
    public interface IImageProcessingService
    {
        ImageModel LoadImage(string filePath);
    }

    /// <summary>
    /// 图像处理服务实现
    /// </summary>
    public class ImageProcessingService : IImageProcessingService
    {
        public ImageModel LoadImage(string filePath)
        {
            // 模拟加载图像数据
            return new ImageModel
            {
                FilePath = filePath,
                ImageData = System.IO.File.ReadAllBytes(filePath)
            };
        }
    }
}
