using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split on spaces — keep punctuation attached to words
        var parts = text.Split(' ');
        foreach (var p in parts)
        {
            if (!string.IsNullOrWhiteSpace(p))
                _words.Add(new Word(p));
        }
    }

    // Hide up to numberToHide words; prefer visible words
    public void HideRandomWords(int numberToHide)
    {
        var visibleIndices = _words
            .Select((w, i) => new { w, i })
            .Where(x => !x.w.IsHidden())
            .Select(x => x.i)
            .ToList();

        if (visibleIndices.Count == 0) return;

        int toHide = Math.Min(numberToHide, visibleIndices.Count);

        for (int i = 0; i < toHide; i++)
        {
            // pick random visible index and hide it
            int pickIndex = _random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[pickIndex];
            _words[wordIndex].Hide();

            // remove chosen index so we don't pick it again
            visibleIndices.RemoveAt(pickIndex);
            if (visibleIndices.Count == 0) break;
        }
    }

    public string GetDisplayText()
    {
        var wordDisplays = _words.Select(w => w.GetDisplayText());
        return $"{_reference.GetDisplayText()} - {string.Join(" ", wordDisplays)}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}