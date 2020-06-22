using System;

namespace BehaviorTreeSample {
	public class Player {
		private Random _random;
		public int Hp {
			get;
			set;
		}
		public Player() {
			Hp = 150;
			_random = new Random();
		}

		public bool MoveToEnemy() {
			Console.WriteLine("[Player]: 敵に寄った");
			return true;
		}

		public bool CallFriend(string name) {
			Console.WriteLine(string.Format("[Player]: 友達{0}を呼んだ",name));
			return true;
		}

		public bool Skill1(int odds, out int damage) {
			if (_random.Next(0, 100) > odds) {
				damage = 0;
				return false;
			}
			Console.WriteLine("[Player]: スキル１発動");
			damage = 50;
			return true;
		}

		public bool Skill2(out int damage) {
			Console.WriteLine("[Player]: スキル２発動");
			damage = 60;
			return true;
		}
	}
}