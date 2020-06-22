using System;

namespace BehaviorTreeSample {
	public class SelecterNode : ControlFlowNodeBase {
		public SelecterNode(NodeBase[] nodes) : base(nodes) { }

		public override NodeState Run() {
			State = NodeState.RUNNING;
			NodeBase node;
			// 子を順次実行
			for (int i = 0; i < children.Length; i++) {
				node = children[i];
				// 子がすでに成功していれば成功を返す
				if (node.State == NodeState.SUCCESS) {
					State = NodeState.SUCCESS;
					return State;
				}
				// 子がすでに失敗していれば次の子へ
				if (node.State == NodeState.FAILER) {
					continue;
				}
				// 待機状態の子を実行
				if (node.State == NodeState.PENDING) {
					var result = node.Run();
					// 結果が成功なら成功を返す
					if (result == NodeState.SUCCESS) {
						State = NodeState.SUCCESS;
						return State;
					}
				}
			}
			// 全て失敗したら失敗を返す
			State = NodeState.FAILER;
			return State;
		}
	}
}