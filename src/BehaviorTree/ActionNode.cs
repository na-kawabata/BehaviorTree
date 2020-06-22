using System;

namespace BehaviorTreeSample {
	/// <summary>
	/// アクション実行ノード
	/// </summary>
	public class ActionNode : NodeBase {
		private Func<bool> _action;

		public ActionNode(Func<bool> action) {
			_action = action;
		}

		public override NodeState Run() {
			State = NodeState.RUNNING;
			bool result = _action();
			if (result) {
				State = NodeState.SUCCESS;
			} else {
				State = NodeState.FAILER;
			}
			return State;
		}
	}
}