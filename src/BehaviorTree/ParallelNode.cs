using System;

namespace BehaviorTreeSample {
	public class ParallelNode : ControlFlowNodeBase {
		public ParallelNode(NodeBase[] nodes) : base(nodes) { }

		public override NodeState Run() {
			State = NodeState.RUNNING;
			// 子を順次実行
			for (int i = 0; i < children.Length; i++) {
				children[i].Run();
			}
			State = NodeState.SUCCESS;
			return State;
		}
	}
}