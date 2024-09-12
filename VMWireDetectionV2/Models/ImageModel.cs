namespace VMWireDetectionV2.Models
{
    /// <summary>
    /// 图像模型，存储图像数据和检测结果
    /// </summary>
    public class ImageModel
    {
        public byte[] ImageData { get; set; } // 图像数据
        public string FilePath { get; set; } // 图像文件路径
        public string DetectionResult { get; set; } // 图像检测结果
    }
}
