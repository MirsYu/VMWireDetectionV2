using System;
using System.Threading;
using System.Threading.Tasks;

namespace VMWireDetectionV2
{
    public class ThreadPoolManager
    {
        // 启动任务并返回一个 CancellationTokenSource 以便后续可以取消任务
        public CancellationTokenSource StartTask(Action<CancellationToken> taskAction)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                try
                {
                    taskAction(token);
                }
                catch (OperationCanceledException)
                {
                    // 任务被取消
                }
                catch (Exception ex)
                {
                    // 处理其他异常
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }, token);

            return cancellationTokenSource;
        }
    }
}
