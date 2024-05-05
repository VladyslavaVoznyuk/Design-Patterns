
public interface ICommand
{
    void Execute();
}

public class DeleteCommand : ICommand
{
    private LightNode _nodeToRemove;
    private List<LightNode> _parentNodeChildren;

    public DeleteCommand(LightNode nodeToRemove, List<LightNode> parentNodeChildren)
    {
        _nodeToRemove = nodeToRemove;
        _parentNodeChildren = parentNodeChildren;
    }

    public void Execute()
    {
        _parentNodeChildren.Remove(_nodeToRemove);
    }
}
var deleteCommand = new DeleteCommand(textNode, p.Children);
deleteCommand.Execute();

