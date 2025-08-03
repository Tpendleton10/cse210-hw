public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity(int duration)
        : base("Listing", "List things that bring joy.") 
    {
        _duration = duration;
        _prompts = new List<string> { /* ... */ };
    }

    public void Run() { /* ... */ }
    private void GetUserItems() { /* ... */ }
}
