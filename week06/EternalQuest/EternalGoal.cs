using System;

namespace EternalQuest
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public EternalGoal() : base() { }

        public override int RecordEvent() => Points;

        public override string GetStatus()
        {
            return $"[∞] {Name} ({Description}) — +{Points} pts each time";
        }

        public override string Serialize()
        {
            return $"EternalGoal|{Escape(Name)}|{Escape(Description)}|{Points}";
        }

        public override void Deserialize(string serializedLine)
        {
            string[] tokens = serializedLine.Split('|');
            Name = Unescape(tokens[1]);
            Description = Unescape(tokens[2]);
            Points = int.Parse(tokens[3]);
        }
    }
}
