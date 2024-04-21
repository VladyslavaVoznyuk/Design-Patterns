using System;
using System.Collections.Generic;

namespace LightHTML
{

    public interface IEventListener
    {
        void HandleEvent(string eventType);
    }

    public abstract class LightNode
    {
        public abstract void Render();
        public abstract void AddChild(LightNode node);
        public abstract void AttachEventListener(string eventType, IEventListener listener);
    }

    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public override void Render()
        {
            Console.WriteLine(_text);
        }

        public override void AddChild(LightNode node)
        {
            throw new InvalidOperationException("Cannot add child to text node.");
        }

        public override void AttachEventListener(string eventType, IEventListener listener)
        {
            throw new InvalidOperationException("Cannot attach event listener to text node.");
        }
    }

    public class LightElementNode : LightNode
    {
        private string _tag;
        private List<LightNode> _children;
        private Dictionary<string, List<IEventListener>> _eventListeners;

        public LightElementNode(string tag)
        {
            _tag = tag;
            _children = new List<LightNode>();
            _eventListeners = new Dictionary<string, List<IEventListener>>();
        }

        public override void Render()
        {
            Console.WriteLine($"<{_tag}>");
            foreach (var child in _children)
            {
                child.Render();
            }
            Console.WriteLine($"</{_tag}>");
        }

        public override void AddChild(LightNode node)
        {
            _children.Add(node);
        }

        public override void AttachEventListener(string eventType, IEventListener listener)
        {
            if (!_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType] = new List<IEventListener>();
            }
            _eventListeners[eventType].Add(listener);
        }

        public void TriggerEvent(string eventType)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                foreach (var listener in _eventListeners[eventType])
                {
                    listener.HandleEvent(eventType);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
            var page = new LightElementNode("html");
            var body = new LightElementNode("body");
            var h1 = new LightElementNode("h1");
            var p = new LightElementNode("p");
            var textNode = new LightTextNode("Hello, LightHTML!");

            page.AddChild(body);
            body.AddChild(h1);
            body.AddChild(p);
            p.AddChild(textNode);
            p.AttachEventListener("click", new ClickListener());
            p.AttachEventListener("mouseover", new MouseOverListener());
            h1.AttachEventListener("click", new HeaderClickListener());
            page.Render();
            p.TriggerEvent("click");
            p.TriggerEvent("mouseover");
            h1.TriggerEvent("click");
        }
    }

    public class ClickListener : IEventListener
    {
        public void HandleEvent(string eventType)
        {
            Console.WriteLine($"Clicked on paragraph!");
        }
    }

    public class MouseOverListener : IEventListener
    {
        public void HandleEvent(string eventType)
        {
            Console.WriteLine($"Mouse over paragraph!");
        }
    }

    public class HeaderClickListener : IEventListener
    {
        public void HandleEvent(string eventType)
        {
            Console.WriteLine($"Clicked on header!");
        }
    }
}
