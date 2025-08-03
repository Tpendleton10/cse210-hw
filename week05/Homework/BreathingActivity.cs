public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing", "Relax through guided breathing.") 
    {
        _duration = duration;
    }

    public void Run() { /* ... */ }
}
