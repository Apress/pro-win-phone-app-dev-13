using System;
using System.Collections.Generic;

namespace ShakeGestures.Classes
{
public class Answers
{
    private List<string> _list = new List<string>();  
    private string[] _replies = 
    {
        "You betcha", 
        "It is decidedly so", 
        "Outlook good", 
        "Ask again later",  
        "Don't count on it", 
        "Very doubtful", 
        "You're kidding, right?"
    };
    private Random _random = new Random();

    public Answers()
    {
        _list.AddRange(_replies); 
    }

    public string Ask()
    {
        if (_list.Count.Equals(0))
        {
            _list.AddRange(_replies); 
        }
        var index = _random.Next(0, _list.Count - 1);
        var result = _list[index];
        _list.RemoveAt(index); 
        return result;
    }
}
}
