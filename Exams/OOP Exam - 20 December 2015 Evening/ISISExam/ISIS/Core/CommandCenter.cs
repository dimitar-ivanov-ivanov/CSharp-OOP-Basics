namespace ISIS.Core
{
    using ISIS.Models.Attacks;
    using ISIS.Models.Groups;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandCenter
    {
        private Dictionary<string, Group> groups;
        private Dictionary<string, Group> deadGroups;
        private bool toggleEffect;

        public CommandCenter()
        {
            this.groups = new Dictionary<string, Group>();
            this.deadGroups = new Dictionary<string, Group>();
        }

        public void ToggleEffect()
        {
            if (toggleEffect)
            {
                return;
            }

            toggleEffect = true;

            foreach (var group in groups)
            {
                group.Value.ToggleEffect = true;
            }
        }

        public void CreateGroup
            (string name, int health, int damage, string warEffect, string attackType)
        {
            if (groups.ContainsKey(name))
            {
                return;
            }

            Group group = null;
            Attack attack = null;

            if (attackType == "Paris")
            {
                attack = new Paris();
            }
            else if (attackType == "SU24")
            {
                attack = new SU24();
            }

            if (warEffect == "Jihad")
            {
                group = new Jihad(name, damage, health, attack);
            }
            else if (warEffect == "Kamikaze")
            {
                group = new Kamikaze(name, damage, health, attack);
            }

            if (toggleEffect)
            {
                group.ToggleEffect = true;
            }
            groups.Add(name, group);
            Akbar();
        }

        public void Attack(string attacker, string target)
        {
            if (groups.ContainsKey(attacker) && groups.ContainsKey(target))
            {
                var damage = groups[attacker].InitiateAttack();
                groups[target].ReceiveAttack(damage);
                if (groups[target].Health <= 0)
                {
                    deadGroups.Add(target, groups[target]);
                    groups.Remove(target);
                    if (toggleEffect)
                    {
                        Console.WriteLine($"Group {target} was killed ");
                    }
                }
            }
        }

        public void Akbar()
        {
            var groupsToRemove = new List<string>();
            foreach (var group in groups)
            {
                group.Value.ApplyEffect();
                if (group.Value.Health <= 0)
                {
                    groupsToRemove.Add(group.Key);
                    deadGroups.Add(group.Key, group.Value);
                }
            }

            foreach (var group in groupsToRemove)
            {
                groups.Remove(group);
            }
        }

        public string Status()
        {
            var output = new StringBuilder();
            groups = groups
                .OrderByDescending(x => x.Value.Health)
                .ThenByDescending(x => x.Value.Damage)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var group in groups)
            {
                output.AppendLine(group.Value.ToString());
            }

            deadGroups = deadGroups
                .OrderByDescending(x => x.Value.Health)
                .ThenByDescending(x => x.Value.Damage)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var group in deadGroups)
            {
                output.AppendLine(group.Value.ToString());
            }

            Akbar();
            return output.ToString();
        }
    }
}
