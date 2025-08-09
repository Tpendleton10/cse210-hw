using System;

namespace EternalQuest
{
    // Abstract base class for all goal types
    abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int Points { get => _points; set => _points = value; }

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        protected Goal() { }

        public abstract int RecordEvent();
        public abstract string GetStatus();
        public abstract string Serialize();
        public abstract void Deserialize(string serializedLine);

        protected static string Escape(string s) => s?.Replace("|", "/") ?? "";
        protected static string Unescape(string s) => s?.Replace("/", "|") ?? "";
    }
}
