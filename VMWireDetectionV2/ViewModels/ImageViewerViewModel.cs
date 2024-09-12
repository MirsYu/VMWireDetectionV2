using Prism.Mvvm;
using System.Collections.ObjectModel;
using VisionDesigner;

namespace VMWireDetectionV2.ViewModels
{
    public class ImageProcessingResult
    {
        public string Name { get; set; }
        public CMvdImage Image { get; set; }
    }


    public class ImageViewerViewModel : BindableBase
    {
        private ImageProcessingResult _selectedResult;

        public ImageViewerViewModel()
        {
            // 初始化图像处理结果
            ImageResults = new ObservableCollection<ImageProcessingResult>
        {
            new ImageProcessingResult { Name = "Original", Image = LoadImage("path/to/original.png") },
            new ImageProcessingResult { Name = "Processed", Image = LoadImage("path/to/processed.png") }
            // 添加更多结果
        };
        }

        public ObservableCollection<ImageProcessingResult> ImageResults { get; }

        public ImageProcessingResult SelectedResult
        {
            get => _selectedResult;
            set => SetProperty(ref _selectedResult, value);
        }

        private CMvdImage LoadImage(string path)
        {
            return null;
        }
    }
}
