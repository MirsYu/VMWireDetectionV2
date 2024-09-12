using System.Threading.Tasks;
using VMWireDetectionV2.Models;

namespace VMWireDetectionV2.Services
{
    /// <summary>
    /// 检测服务接口
    /// </summary>
    public interface IDetectionService
    {
        Task DetectAsync(ImageModel image);
    }

    /// <summary>
    /// 检测服务实现
    /// </summary>
    public class DetectionService : IDetectionService
    {
        public async Task DetectAsync(ImageModel image)
        {
            // 模拟检测过程
            await Task.Delay(1000);
            image.DetectionResult = "检测完成";
        }
    }
}
