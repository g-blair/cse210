using System;
namespace Develop02;

class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public void Display()
    {
        Console.WriteLine($"{_date} \n {_prompt} \n {_response}");
    }
}