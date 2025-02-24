using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    public string _name { get; }
    public int _winsCount { get; private set; }
    public int _losesCount { get; private set; }
    public char _figure { get; }


    public Player(string name, char figure)
    {
        _name = name;
        _winsCount = 0;
        _losesCount = 0;
        _figure = figure;
    }

    public void IncrementWinsCount()
    {
        _winsCount++;
    }

    public void IncrementLosesCount()
    {
        _losesCount++;
    }

    public void ShowPlayerStats()
    {
        Console.WriteLine($"Player '{_name}': wins - {_winsCount}, loses - {_losesCount}");
    }
}

