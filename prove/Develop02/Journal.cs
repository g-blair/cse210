using System;
using System.Collections.Generic;
using System.IO;
namespace Develop02;

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _filepath;
    public void AddEntry()
    {
        Entry entry = new Entry();

        entry._date = DateTime.Now.ToShortDateString();

        Console.WriteLine("What is your journal entry?");
        entry._response = Console.ReadLine() ?? "";

        entry._prompt = "Journal Entry";

        _entries.Add(entry);
    }
    public string DisplayEntries()
    {
        string display = "";
        foreach (Entry entry in _entries)
        {
            display += $"Date: {entry._date}\nPrompt: {entry._prompt}\nResponse: {entry._response}\n\n";
        }
        return display;
    }
    public string Save()    {
        Console.WriteLine("What is the filename you want to save to?");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry._date}");
                outputFile.WriteLine($"Prompt: {entry._prompt}");
                outputFile.WriteLine($"Response: {entry._response}");
                outputFile.WriteLine();
            }
        }
        return $"Journal saved to {filename}";
    }
    public string Load()
    {
        Console.WriteLine("What is the filename you want to load from?");
        string filename = Console.ReadLine() ?? "";

        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;

            while ((line = inputFile.ReadLine()) != null)
            {
                if (line.StartsWith("Date: "))
                {
                    Entry entry = new Entry();

                    entry._date = line.Substring(6);

                    string promptLine = inputFile.ReadLine();
                    string responseLine = inputFile.ReadLine();

                    if (promptLine != null && responseLine != null)
                    {
                        entry._prompt = promptLine.Substring(8);
                        entry._response = responseLine.Substring(10);

                        _entries.Add(entry);
                    }
                }
            }
        }

        return $"Journal loaded from {filename}";
    }
}