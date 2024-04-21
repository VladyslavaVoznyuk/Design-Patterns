using System;

public class TextDocument
{
    public string Content { get; set; }

    public TextDocument(string content)
    {
        Content = content;
    }
}

public class Memento
{
    public TextDocument DocumentSnapshot { get; }

    public Memento(TextDocument document)
    {
        DocumentSnapshot = document;
    }
}

public class TextEditor
{
    private TextDocument _document;

    public Memento Save()
    {
        return new Memento(_document);
    }

    public void Restore(Memento memento)
    {
        _document = memento.DocumentSnapshot;
    }

    public void ModifyDocument(string newContent)
    {
        _document.Content = newContent;
    }

    public void PrintDocument()
    {
        Console.WriteLine("Current content of the document:");
        Console.WriteLine(_document.Content);
    }

    public TextEditor(string initialContent)
    {
        _document = new TextDocument(initialContent);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor("Initial content");
        editor.PrintDocument();
        editor.ModifyDocument("Modified content");
        editor.PrintDocument();
        Memento savedState = editor.Save();
        editor.ModifyDocument("Another modified content");
        editor.PrintDocument();
        editor.Restore(savedState);
        editor.PrintDocument();
    }
}
