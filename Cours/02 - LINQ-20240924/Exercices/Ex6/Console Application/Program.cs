namespace StringExtensions
{
    public static class StringExtensions
    {
        public static bool IsAPalindrome(this string word) {
            // On retire les espaces, majuscules et autres caractères inutiles
            word = word.Replace(" ", "").ToLower();

            // On compare les caractères de début et de fin
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (word[i] != word[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }


    }

    
}
