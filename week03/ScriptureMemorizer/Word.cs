using System.Text;
using System.Text.RegularExpressions;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;
    public void Show() => _isHidden = false;
    public bool IsHidden() => _isHidden;

    // Return underscores for letters but keep punctuation and non-letter characters
    public string GetDisplayText()
    {
        if (!_isHidden)
            return _text;

        var sb = new StringBuilder();
        foreach (char c in _text)
        {
            // treat letters as masked, leave punctuation/digits as-is
            sb.Append(char.IsLetter(c) ? '_' : c);
        }
        return sb.ToString();
    }
}