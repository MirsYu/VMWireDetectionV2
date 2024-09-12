using VisionDesigner;

namespace VMWireDetectionV2.Vision
{
    public class VisionToolManager
    {
        public VisionToolBase ColorConverTool { get; }
        public VisionToolBase ContourPatMarchTool { get; }
        // 其他工具...

        public VisionToolManager(VisionToolBase colorConverTool, VisionToolBase contourPatMarchTool /*,其他工具*/)
        {
            ColorConverTool = colorConverTool;
            ContourPatMarchTool = contourPatMarchTool;
            // 初始化其他工具
        }

        public CMvdImage ProcessWithColorConver(CMvdImage inputImage)
        {
            return ColorConverTool.ProcessImage(inputImage);
        }

        public CMvdImage DetectContours(CMvdImage inputImage)
        {
            return ContourPatMarchTool.ProcessImage(inputImage);
        }

        // 其他工具的处理方法
    }

}
