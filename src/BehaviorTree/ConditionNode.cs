using System;

namespace BehaviorTreeSample {
	public class ConditionNode : ControlFlowNodeBase {
		private Func<bool> _condition;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="count">repeat count</param>
		/// <param name="nodes">child</param>
		/// <returns></returns>
		public ConditionNode(Func<bool> condition, NodeBase node) : base(new NodeBase[] {
			node
		}) {
			_condition = condition;
		}

		public override NodeState Run() {
			State = NodeState.RUNNING;
			if (_condition()) {
				State = children[0].Run();
			} else {
				State = NodeState.FAILER;
			}
			return State;
		}
	}
}