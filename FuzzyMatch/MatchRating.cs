using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuzzyMatch
{
    public class MatchRatingResponse
    {
        public int MinimumRating { get; set; }
        public int ActualRating { get; set; }
        public string CodexFirst { get; set; }
        public string CodexSecond { get; set; }
    }

    public class MatchRating
    {
        private readonly Regex wordValidator = new Regex("^[a-z]+$", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
        private readonly Regex codexStepOne = new Regex("(?<!^)([aouie]*(?![aouie]))", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
        private readonly Regex codexStepTwo = new Regex("([a-z])\\1+", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);

        public MatchRatingResponse Rating(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
            {
                throw new ArgumentException("first must not be null or empty", "first");
            }

            if (string.IsNullOrEmpty(second))
            {
                throw new ArgumentException("second must not be null or empty", "second");
            }

            if (ValidateWord(first) == false)
            {
                throw new ArgumentException("first be alpha characters only", "first");
            }

            if (ValidateWord(second) == false)
            {
                throw new ArgumentException("second be alpha characters only", "second");
            }

            var response = new MatchRatingResponse();

            response.CodexFirst = EncodeWord(first);
            response.CodexSecond = EncodeWord(second);

            response.MinimumRating = CalculateMinimum(response.CodexFirst, response.CodexSecond);
            response.ActualRating = CalculateSimilarity(response.CodexFirst, response.CodexSecond);

            return response;
        }

        private int CalculateMinimum(string first, string second)
        {
            int minimum = 0;

            int length = first.Length + second.Length;

            if (length == 12)
            {
                minimum = 2;
            }
            else if (length <= 11 && length > 7)
            {
                minimum = 3;
            }
            else if (length <= 7 && length > 4)
            {
                minimum = 4;
            }
            else if (length <= 4)
            {
                minimum = 5;
            }

            return minimum;
        }

        private int CalculateSimilarity(string first, string second)
        {
            var minLength = first.Length > second.Length ? second.Length : first.Length;

            var firstCopy = first;
            var secondCopy = second;

            int i = 0;

            while (i < minLength)
            {
                if (firstCopy[i] == secondCopy[i])
                {
                    firstCopy = firstCopy.Remove(i, 1);
                    secondCopy = secondCopy.Remove(i, 1);

                    minLength--;

                    i--;
                }

                i++;
            }

            var longLen = firstCopy.Length > secondCopy.Length ? firstCopy.Length : secondCopy.Length;

            if (longLen > 0)
            {
                firstCopy = firstCopy.PadLeft(longLen);
                secondCopy = secondCopy.PadLeft(longLen);

                while (i >= 0)
                {
                    if (firstCopy[i] == secondCopy[i])
                    {
                        firstCopy = firstCopy.Remove(i, 1);
                        secondCopy = secondCopy.Remove(i, 1);
                    }

                    i--;
                }

                firstCopy = firstCopy.Trim();
                secondCopy = secondCopy.Trim();

                longLen = firstCopy.Length > secondCopy.Length ? firstCopy.Length : secondCopy.Length;
            }

            return 6 - longLen;
        }

        private string EncodeWord(string word)
        {
            var codexWord = word.ToUpper();

            codexWord = codexStepOne.Replace(codexWord, "");
            codexWord = codexStepTwo.Replace(codexWord, "$1");

            if (codexWord.Length > 6)
            {
                var firstThree = codexWord.Substring(0, 3);
                var lastThree = codexWord.Substring(codexWord.Length - 3, 3);

                codexWord = firstThree + lastThree;
            }

            return codexWord;
        }

        private bool ValidateWord(string word)
        {
            if (wordValidator.IsMatch(word))
            {
                return true;
            }

            return false;
        }
    }
}
