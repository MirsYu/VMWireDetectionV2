using System.Windows.Controls;
using VMWireDetectionV2.ViewModels;

namespace VMWireDetectionV2.Views
{
    /// <summary>
    /// ImageViererControl.xaml 的交互逻辑
    /// </summary>
    public partial class ImageViewerControl : UserControl
    {
        public ImageViewerControl()
        {
            InitializeComponent();
            DataContext = new ImageViewerViewModel(); // 确保使用你的 ViewModel
        }
    }
}
