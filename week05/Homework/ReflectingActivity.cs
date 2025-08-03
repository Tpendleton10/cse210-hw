public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration)
        : base("Reflecting", "Reflect on times you showed strength.") 
    {
        _duration = duration;
        _prompts = new List<string> { /* ... */ };
        _questions = new List<string> { /* ... */ };
    }

    public void Run() { /* ... */ }
    private void DisplayPrompt() { /* ... */ }
    private void DisplayQuestions() { /* ... */ }
}
