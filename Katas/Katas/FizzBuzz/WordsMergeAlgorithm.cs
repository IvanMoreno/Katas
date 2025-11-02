namespace Katas.FizzBuzz;

public readonly struct WordsMergeAlgorithm(Func<IEnumerable<Word>, Word> wordsMergeAlgorithm)
{
    public Word Merge(IEnumerable<Word> words) => wordsMergeAlgorithm(words);

    public static WordsMergeAlgorithm MergeAllWords() =>
        new(words => words.Aggregate(string.Empty, (acc, word) => acc + word));

    public static WordsMergeAlgorithm MergeAndRepeatLastWord() =>
        new(words => words.Aggregate(string.Empty, (acc, word) => acc + word) + words.Last());
}