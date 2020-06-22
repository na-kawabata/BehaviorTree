using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeSample {
	/// <summary>
	/// 子を持つノード
	/// </summary>
	public abstract class ControlFlowNodeBase : NodeBase {
		protected NodeBase[] children;

		public ControlFlowNodeBase(NodeBase[] nodes) {
			children = nodes;
		}

		public override NodeState Run() {
			return base.Run();
		}

		public override void ResetState() {
			State = NodeState.PENDING;
			for (int i = 0; i < children.Length; i++) {
				children[i].State = NodeState.PENDING;
				if (children[i].GetType() == typeof(ControlFlowNodeBase)) {
					var node = (ControlFlowNodeBase) children[i];
					node.ResetState();
				}
			}
		}
	}
}