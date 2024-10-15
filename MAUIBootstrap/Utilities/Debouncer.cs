using Timer = System.Timers.Timer;

namespace MAUIBootstrap.Utilities;

public class Debouncer
{
    private Timer? _Timer = null;
    private double _DebounceTime;

    public Debouncer(double debounceTimeInSeconds = 1.0)
    {
        _DebounceTime = debounceTimeInSeconds;
    }

    public void Debounce(Action action)
    {
        if (_Timer != null)
        {
            _Timer.Stop();
            _Timer = null;
        }

        _Timer = new Timer();
        _Timer.Interval = _DebounceTime * 1000;
        _Timer.AutoReset = false;
        _Timer.Enabled = true;
        _Timer.Elapsed += (_, _) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                action?.Invoke();
            });
        };

        _Timer.Start();
    }
}
