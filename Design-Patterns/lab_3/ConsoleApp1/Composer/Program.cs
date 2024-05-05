using System;
using System.Collections.Generic;
using System.Text;

public interface IVisitor
{
    void Visit(LightElementNode node);
    void Visit(LightTextNode node);
}

public abstract class LightNode
{
    public abstract string OuterHtml { get; }
    public abstract string InnerHtml { get; }

    public abstract void Accept(IVisitor visitor);
}

public class LightElementNode : LightNode
{
    public string TagName { get; set; }
    public bool IsBlock { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<LightNode> Children { get; set; }
    public List<string> Classes { get; set; }

    public LightElementNode(string tagName, bool isBlock, bool isSelfClosing, List<LightNode> children, List<string> classes)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        Children = children;
        Classes = classes;
    }

    public override string OuterHtml
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{TagName}");

            if (Classes != null && Classes.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", Classes)}\"");
            }

            sb.Append(">");

            if (!IsSelfClosing)
            {
                sb.Append(InnerHtml);
                sb.Append($"</{TagName}>");
            }

            return sb.ToString();
        }
    }

    public override string InnerHtml
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.OuterHtml);
            }
            return sb.ToString();
        }
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var child in Children)
        {
            child.Accept(visitor);
        }
    }
}

public class LightTextNode : LightNode
{
    public string Text { get; set; }

    public LightTextNode(string text)
    {
        Text = text;
    }

    public override string OuterHtml => Text;
    public override string InnerHtml => Text;

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class HtmlRenderingVisitor : IVisitor
{
    public StringBuilder Result { get; }

    public HtmlRenderingVisitor()
    {
        Result = new StringBuilder();
    }

    public void Visit(LightElementNode node)
    {
        Result.Append(node.OuterHtml);
    }

    public void Visit(LightTextNode node)
    {
        Result.Append(node.OuterHtml);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var div = new LightElementNode("div", isBlock: true, isSelfClosing: false, children: new List<LightNode>(), classes: new List<string>() { "container" });
        var h1 = new LightElementNode("h1", isBlock: true, isSelfClosing: false, children: new List<LightNode>(), classes: null);
        var p = new LightElementNode("p", isBlock: true, isSelfClosing: false, children: new List<LightNode>(), classes: null);
        var textNode = new LightTextNode("Hello, Vladyslava!");

        div.Children.Add(h1);
        div.Children.Add(p);
        h1.Children.Add(new LightTextNode("My Title"));
        p.Children.Add(textNode);

        var visitor = new HtmlRenderingVisitor();
        div.Accept(visitor);

        Console.WriteLine(visitor.Result.ToString());
    }
}
