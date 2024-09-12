using MvCamCtrl.NET;
using VMWireDetectionV2.Models;

namespace VMWireDetectionV2.Services
{
    /// <summary>
    /// 相机服务接口
    /// </summary>
    public interface ICameraService
    {
        void Initialize();
        void StartCapture();
        void StopCapture();
        ImageModel GetCurrentImage();
    }

    public class CameraService : ICameraService
    {
        private CCamera _camera;

        public void Initialize()
        {
            _camera = new CCamera(); // 实例化相机
            //_camera.Setup(); // 配置相机
        }

        public void StartCapture()
        {
            //_camera.Start(); // 开始捕捉
        }

        public void StopCapture()
        {
            //_camera.Stop(); // 停止捕捉
        }

        public ImageModel GetCurrentImage()
        {
            //return _camera.GetImage(); // 获取当前图像
            return null;
        }
    }
}
