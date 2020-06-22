using System;

namespace BehaviorTreeSample {
	public class RepeaterNode : ControlFlowNodeBase {
		private int _count;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="count">repeat count</param>
		/// <param name="nodes">child</param>
		/// <returns></returns>
		public RepeaterNode(int count, NodeBase node) : base(new NodeBase[] {
			node
		}) {
			_count = count;
		}

		public override NodeState Run() {
			State = NodeState.RUNNING;
			for (int i = 0; i < _count; i++) {
				children[0].Run();
				children[0].ResetState();
			}
			// 全て終了したら成功を返す
			State = NodeState.SUCCESS;
			return State;
		}
	}
}