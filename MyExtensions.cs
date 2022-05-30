using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int _CompareTo(this string sourceString, string strA)
        {
            if (sourceString._IsNullOrEmpty() || strA._IsNullOrEmpty())
                throw new ArgumentException();
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] != strA[i])
                {
                    return sourceString[i] < strA[i] ? -1 : 1;
                }
            }

            return 0;
        }  
        public static string _Concat(this string sourceString, string strA)
        {
            if (sourceString == null || strA == null)
                throw new ArgumentNullException();
            return sourceString + strA;
        }
        public static bool _Contains(this string sourceString, string strA)
        {
            if (sourceString._IsNullOrEmpty() || strA._IsNullOrEmpty())
                throw new ArgumentNullException();
            if (strA.Length > sourceString.Length)
                return false;
            for (int i = 0; i <= sourceString.Length - strA.Length; i++)
            {
                if (sourceString[i] == strA[0])
                {
                    if (sourceString.Substring(i, strA.Length) == strA)
                        return true;
                }
            }

            return false;
        }
        public static bool _Equals(this string sourceString, string strA)
        {
            if (sourceString == null || strA == null)
                return sourceString == strA;

            if (sourceString.Length != strA.Length)
                return false;

            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] != strA[i])
                    return false;
            }

            return true;
        }
        public static bool _IsNullOrEmpty(this string sourceString)
        {
            return !(sourceString.Length > 0);
        }
        public static int _IndexOf(this string sourceString, string strA)
        {
            if (sourceString == null || strA == null || sourceString == String.Empty || strA == String.Empty)
                throw new ArgumentException();
            if (strA.Length > sourceString.Length)
                return -1;
            for (int i = 0; i <= sourceString.Length - strA.Length; i++)
            {
                if (sourceString[i] == strA[0])
                {
                    bool equals = true;
                    for (int j = 0; j < strA.Length; j++)
                    {
                        if (sourceString[i + j] != strA[j])
                            equals = false;
                    }

                    if (equals)
                        return i;
                }
            }

            return -1;
        }
        public static int _IndexOfAny(this string sourceString, char[] anyOf)
        {
            foreach (var c in anyOf)
            {
                var indexOf = sourceString._IndexOf(c.ToString());
                if (indexOf != -1) return indexOf;
            }

            return -1;
        }
        public static string _Insert(this string sourceString, string strA, int startIndex)
        {
            if (sourceString == null || strA == null || startIndex >= sourceString.Length)
                throw new ArgumentException();
            return sourceString._Substring(0, startIndex) + strA + sourceString._Substring(startIndex);
        }
        public static string _Join(this string sourceString, params string[] strings)
        {
            if (sourceString == null)
                throw new ArgumentException();
            StringBuilder output = new StringBuilder();
            foreach (var s in strings)
            {
                output.Append($"{s}{sourceString}");
            }

            return output.ToString()._Substring(0, output.Length - sourceString.Length);
        }
        public static int _LastIndexOf(this string sourceString, string strA)
        {
            if (sourceString == null || strA == null || sourceString == String.Empty || strA == String.Empty)
                throw new ArgumentException();
            if (strA.Length > sourceString.Length)
                return -1;
            for (int i = sourceString.Length - strA.Length; i >= 0; i--)
            {
                if (sourceString[i] == strA[0])
                {
                    bool equals = true;
                    for (int j = 0; j < strA.Length; j++)
                    {
                        if (sourceString[i + j] != strA[j])
                            equals = false;
                    }

                    if (equals)
                        return i;
                }
            }

            return -1;
        }
        public static string _Remove(this string sourceString, int startIndex, int count)
        {
            if (sourceString == null || startIndex < 0 || count < 0 || startIndex > sourceString.Length - 1 || startIndex + count > sourceString.Length)
                throw new ArgumentException();
            return sourceString._Substring(0, startIndex) + sourceString._Substring(startIndex + count);
        }
        public static string _Replace(this string sourceString, string strA, string strB)
        {
            if (sourceString == null || strB == null || strA == null || strA == String.Empty)
                throw new ArgumentException();
            if (!sourceString.Contains(strA))
                return sourceString;
            StringBuilder output = new StringBuilder();
            for (int i = 0; i <= sourceString.Length - strA.Length; i++)
            {
                if (sourceString[i] == strA[0])
                {
                    bool equals = true;
                    for (int j = 0; j < strA.Length; j++)
                    {
                        if (sourceString[i + j] != strA[j])
                            equals = false;
                    }

                    if (equals)
                    {
                        output.Append(strB);
                        i = i + strA.Length - 1;
                    }
                }
                else
                {
                    output.Append(sourceString[i]);
                }
            }

            return output.ToString();
        }
        public static string _Substring(this string sourceString, int startIndex, int count)
        {
            if (sourceString == null || startIndex < 0 || count < 0 || startIndex > sourceString.Length - 1 || startIndex + count > sourceString.Length)
                throw new ArgumentException();

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (i >= startIndex && i < startIndex + count)
                    output.Append(sourceString[i]);
            }

            return output.ToString();
        }
        public static string _Substring(this string sourceString, int startIndex)
        {
            if (sourceString == null || startIndex < 0 || startIndex > sourceString.Length - 1)
                throw new ArgumentException();
            int count = sourceString.Length - startIndex;
            return sourceString._Substring(startIndex, count);
        }
        public static string _ToLower(this string sourceString)
        {
            if (sourceString == null)
                throw new ArgumentException();
            StringBuilder output = new StringBuilder();
            foreach (var c in sourceString)
            {
                int code = c;

                if (code >= 65 && code <= 90)
                {
                    output.Append((char)(code + 32));
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }
        public static string _ToUpper(this string sourceString)
        {
            if (sourceString == null)
                throw new ArgumentException();
            StringBuilder output = new StringBuilder();
            foreach (var c in sourceString)
            {
                int code = c;

                if (code >= 97 && code <= 122)
                {
                    output.Append((char)(code - 32));
                }
                else
                {
                    output.Append(c);
                }
            }

            return output.ToString();
        }
        public static string _Trim(this string sourceString)
        {
            if (sourceString._IsNullOrEmpty())
                throw new ArgumentException();
            return sourceString._TrimStart().TrimEnd();
        }
        public static string _TrimStart(this string sourceString)
        {
            if (sourceString._IsNullOrEmpty())
                throw new ArgumentException();
            StringBuilder output = new StringBuilder();
            int length = sourceString.Length;
            bool startInside = false;
            for (int i = 0; i < length; i++)
            {
                if (!(startInside) && (sourceString[i] == ' ' || sourceString[i] == '\n' || sourceString[i] == '\r' || sourceString[i] == '\t'))
                {
                    continue;
                }
                else
                {
                    output.Append(sourceString[i]);
                    startInside = true;
                }
            }

            return output.ToString();
        }
        public static string _TrimEnd(this string sourceString)
        {
            if (sourceString._IsNullOrEmpty())
                throw new ArgumentException();
            int indexToTrim = -1;
            for (int i = sourceString.Length - 1; i <= 0; i--)
            {
                if (sourceString[i] == ' ' || sourceString[i] == '\n' || sourceString[i] == '\r' || sourceString[i] == '\t')
                {
                    indexToTrim = i;
                }
            }

            if (indexToTrim != -1)
            {
                return sourceString._Substring(0, indexToTrim);
            }

            return sourceString;
        }

    }
}
