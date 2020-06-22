using System;

namespace BehaviorTreeSample {
	public class SequenceNode : ControlFlowNodeBase {
		public SequenceNode(NodeBase[] nodes) : base(nodes) { }

		public override NodeState Run() {
			State = NodeState.RUNNING;
			NodeBase node;
			// 子を順次実行
			for (int i = 0; i < children.Length; i++) {
				node = children[i];
				// 子がすでに失敗していれば失敗を返す
				if (node.State == NodeState.FAILER) {
					State = NodeState.FAILER;
					return State;
				}
				// 子がすでに成功していれば次の子へ
				if (node.State == NodeState.SUCCESS) {
					continue;
				}
				// 待機状態の子を実行
				if (node.State == NodeState.PENDING) {
					var result = node.Run();
					// 結果が失敗なら失敗を返す
					if (result == NodeState.FAILER) {
						State = NodeState.FAILER;
						return State;
					}
				}
			}
			// 全て成功したら成功を返す
			State = NodeState.SUCCESS;
			return State;
		}
	}
}