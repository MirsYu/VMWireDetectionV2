using VisionDesigner;

namespace VMWireDetectionV2.Vision
{
    public abstract class VisionToolBase
    {
        public abstract void Configure();

        public abstract CMvdImage ProcessImage(CMvdImage inputImage);

        // 可以添加其他通用功能，例如初始化参数、设置日志等
    }
}
