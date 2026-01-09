using Enochian_Encryption_System;
using System;
using System.Diagnostics;

public class MetricProbe
{
    private long _startMem;
    private TimeSpan _startCpu;
    private Stopwatch _sw;
    private bool _isEncryption;

    // Start measuring immediately when created
    public MetricProbe(bool isEncryption)
    {
        _isEncryption = isEncryption;
        GC.Collect(); // Clean up previous garbage
        GC.WaitForPendingFinalizers();

        _startMem = GC.GetTotalMemory(true);
        _startCpu = Process.GetCurrentProcess().TotalProcessorTime;
        _sw = Stopwatch.StartNew();
    }

    // Stop and add to Global Totals
    public void StopAndAccumulate()
    {
        _sw.Stop();
        long endMem = GC.GetTotalMemory(false);
        TimeSpan endCpu = Process.GetCurrentProcess().TotalProcessorTime;

        long memDelta = Math.Max(0, endMem - _startMem);
        double cpuDelta = (endCpu - _startCpu).TotalMilliseconds;
        double timeDelta = _sw.Elapsed.TotalMilliseconds;

        if (_isEncryption)
        {
            GlobalSession.Total_Enc_TimeMs += timeDelta;
            GlobalSession.Total_Enc_MemBytes += memDelta;
            GlobalSession.Total_Enc_CpuMs += cpuDelta;
        }
        else
        {
            GlobalSession.Total_Dec_TimeMs += timeDelta;
            GlobalSession.Total_Dec_MemBytes += memDelta;
            GlobalSession.Total_Dec_CpuMs += cpuDelta;
        }
    }
}