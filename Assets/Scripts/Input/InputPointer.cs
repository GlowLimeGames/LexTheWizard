/*
 * Author(s): Isaiah Mann
 * Description: Describes a single pointer (either a touch or a mouse click)
 */

public class InputPointer {
	public UnityEngine.Vector3 Position;
	public int ID;
	public bool IsPrimaryPointer;

	public InputPointer (UnityEngine.Vector3 position, int id, bool isPrimaryPointer) {
		this.Position = position;
		this.ID = id;
		this.IsPrimaryPointer = isPrimaryPointer;
	}
}
