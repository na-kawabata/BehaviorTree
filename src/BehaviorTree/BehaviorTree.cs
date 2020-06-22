using System;

namespace BehaviorTreeSample {
	public enum NodeState {
		PENDING,
		RUNNING,
		SUCCESS,
		FAILER,
	}

	public class BehaviorTree {
		private ControlFlowNodeBase _rootNode;
		public NodeState TreeState {
			get;
			private set;
		}

		public void Init(ControlFlowNodeBase rootNode) {
			_rootNode = rootNode;
			TreeState = NodeState.PENDING;
		}

		public void Run() {
			TreeState = NodeState.RUNNING;
			_rootNode.Run();
		}
	}
}