using StringExtensions;

string word1 = "été";
string word2 = "bonjour";

Console.WriteLine($"{word1} est un palindrome : {word1.IsAPalindrome()}");
Console.WriteLine($"{word2} est un palindrome : {word2.IsAPalindrome()}");
