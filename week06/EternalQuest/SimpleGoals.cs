using System;

namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public SimpleGoal() : base() { }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("That goal is already completed. No points awarded.");
                return 0;
            }
            _isComplete = true;
            return Points;
        }

        public override string GetStatus()
        {
            string mark = _isComplete ? "[X]" : "[ ]";
            return $"{mark} {Name} ({Description}) — +{Points} pts";
        }

        public override string Serialize()
        {
            return $"SimpleGoal|{Escape(Name)}|{Escape(Description)}|{Points}|{_isComplete}";
        }

        public override void Deserialize(string serializedLine)
        {
            string[] tokens = serializedLine.Split('|');
            Name = Unescape(tokens[1]);
            Description = Unescape(tokens[2]);
            Points = int.Parse(tokens[3]);
            _isComplete = bool.Parse(tokens[4]);
        }
    }
}
