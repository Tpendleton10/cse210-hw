using System;

namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;
        private bool _isComplete;

        public ChecklistGoal(string name, string description, int pointsPerEvent, int targetCount, int bonusPoints)
            : base(name, description, pointsPerEvent)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
            _isComplete = false;
        }

        public ChecklistGoal() : base() { }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("Checklist goal already completed. No additional points.");
                return 0;
            }

            _currentCount++;
            int awarded = Points;

            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                awarded += _bonusPoints;
                Console.WriteLine($"Checklist completed! Bonus {_bonusPoints} points.");
            }
            return awarded;
        }

        public override string GetStatus()
        {
            string mark = _isComplete ? "[X]" : "[ ]";
            return $"{mark} {Name} ({Description}) — Completed {_currentCount}/{_targetCount} — +{Points} pts (+{_bonusPoints} bonus)";
        }

        public override string Serialize()
        {
            return $"ChecklistGoal|{Escape(Name)}|{Escape(Description)}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}|{_isComplete}";
        }

        public override void Deserialize(string serializedLine)
        {
            string[] tokens = serializedLine.Split('|');
            Name = Unescape(tokens[1]);
            Description = Unescape(tokens[2]);
            Points = int.Parse(tokens[3]);
            _currentCount = int.Parse(tokens[4]);
            _targetCount = int.Parse(tokens[5]);
            _bonusPoints = int.Parse(tokens[6]);
            _isComplete = bool.Parse(tokens[7]);
        }
    }
}
