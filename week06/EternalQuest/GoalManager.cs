using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new();
        private int _score;
        private int _level = 1;
        private HashSet<string> _badges = new();

        public int Score => _score;
        public int Level => _level;
        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

        public void AddGoal(Goal g) => _goals.Add(g);

        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }

        public void DisplayScoreAndBadges()
        {
            Console.WriteLine($"Score: {_score} pts");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine("Badges: " + (_badges.Count > 0 ? string.Join(", ", _badges) : "(none)"));
        }

        public int RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= _goals.Count) return 0;
            int awarded = _goals[goalIndex].RecordEvent();
            if (awarded > 0)
            {
                _score += awarded;
                CheckLevelUp();
                CheckBadges(_goals[goalIndex]);
            }
            return awarded;
        }

        public void SaveToFile(string path)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine($"{_score}|{_level}");
            foreach (var g in _goals) sw.WriteLine(g.Serialize());
            sw.WriteLine("BADGES|" + string.Join(",", _badges));
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            var header = lines[0].Split('|');
            _score = int.Parse(header[0]);
            _level = int.Parse(header[1]);
            _goals.Clear();
            _badges.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("BADGES|"))
                {
                    foreach (var b in lines[i].Substring(7).Split(',', StringSplitOptions.RemoveEmptyEntries))
                        _badges.Add(b);
                    continue;
                }

                var type = lines[i].Split('|')[0];
                Goal g = type switch
                {
                    "SimpleGoal" => new SimpleGoal(),
                    "EternalGoal" => new EternalGoal(),
                    "ChecklistGoal" => new ChecklistGoal(),
                    _ => null
                };
                g?.Deserialize(lines[i]);
                if (g != null) _goals.Add(g);
            }
        }

        private void CheckLevelUp()
        {
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                _badges.Add($"ReachedLevel{_level}");
                Console.WriteLine($"Level up! Now level {_level}!");
            }
        }

        private void CheckBadges(Goal g)
        {
            if (!_badges.Contains("FirstPoints") && _score > 0) _badges.Add("FirstPoints");
            if (!_badges.Contains("Earned10000") && _score >= 10000) _badges.Add("Earned10000");
            if (g is ChecklistGoal) _badges.Add($"Checklist:{g.Name}");
        }
    }
}
