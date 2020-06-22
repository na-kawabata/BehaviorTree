using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorTreeSample;

public class Program {
	private static void Main(string[] args) {
		var main = new Sample();
		Console.WriteLine("スキル１の発動率を入力してください");

		string line = Console.ReadLine();
		int n;

		if (System.Int32.TryParse(line, out n)) {
			main.Init(n);
			main.Run();
		} else {
			System.Console.WriteLine($"入力値「{line}」は整数ではありません");
		}
	}

}

public class Sample {
	BehaviorTree tree;
	Player player;
	Enemy enemy;

	public void Init(int odds) {
		tree = new BehaviorTree();
		player = new Player();
		enemy = new Enemy();
		ControlFlowNodeBase rootNode = new SequenceNode(new NodeBase[] {
			new ActionNode(() => Start()),
				new ConditionNode(() => player.Hp >= 100,
					new ActionNode(() => player.MoveToEnemy())
				),
				new ParallelNode(new NodeBase[] {
					new ActionNode(() => player.CallFriend("A")),
						new ActionNode(() => player.CallFriend("B"))
				}),
				new RepeaterNode(2,
					new SelecterNode(new NodeBase[] {
						new ActionNode(() => {
								int damage = 0;
								bool result = player.Skill1(odds, out damage);
								if (result) {
									enemy.Hp -= damage;
								}
								return result;
							}),
							new ActionNode(() => {
								int damage = 0;
								bool result = player.Skill2(out damage);
								if (result) {
									enemy.Hp -= damage;
								}
								return result;
							})
					})
				),
				new SelecterNode(new NodeBase[] {
					new ConditionNode(() => enemy.Hp <= 0,
							new ActionNode(() => End1())
						),
						new ConditionNode(() => enemy.Hp > 0,
							new ActionNode(() => End2())
						)
				})
		});

		tree.Init(rootNode);
	}

	public void Run() {
		tree.Run();
	}

	private bool Start() {
		Console.WriteLine("[Sample]: 出発");
		return true;
	}

	private bool End1() {
		Console.WriteLine($"[Sample]: End1 Enemy HP:{enemy.Hp}");
		return true;
	}

	private bool End2() {
		Console.WriteLine($"[Sample]: End2 Enemy HP:{enemy.Hp}");
		return true;
	}
}