using System;

namespace BehaviorTreeSample {
	public abstract class NodeBase {

		public virtual NodeState State {
			get;
			set;
		}

		public NodeBase() {
			State = NodeState.PENDING;
		}

		public virtual NodeState Run() {
			State = NodeState.RUNNING;
			return State;
		}

		public virtual void ResetState(){
			State = NodeState.PENDING;
		}
	}
}