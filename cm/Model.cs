using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cm
{
    internal class Model
    {
        private class AuthFile
        {
            public string Author { get; }
            public string Filename { get; }

            public AuthFile(string name, string filename)
            {
                Author = name;
                Filename = filename;
            }
        }

        public List<string> Files { get; } = new List<string>();

        #region . Build .

        public bool Build(string header, string target)
        {
            try
            {
                var nameMap = new List<AuthFile>();

                foreach (var file in Files)
                {
                    var key = GetAuthor(file);
                    nameMap.Add(new AuthFile(key, file));
                }



                return true;
            }
            catch (Exception e)
            {
                Log.Error("Ошибка сборки", e);
                return false;
            }
        }

        #endregion

        #region . Sort .

        public bool Sort()
        {
            try
            {
                var nameMap = new List<AuthFile>();

                foreach (var file in Files)
                {
                    var key = GetAuthor(file);
                    nameMap.Add(new AuthFile(key, file));
                }

                nameMap = nameMap.OrderBy(x => x.Author).ToList();

                Files.Clear();
                Files.AddRange(nameMap.Select(x => x.Filename));

                return true;
            }
            catch (Exception e)
            {
                Log.Error("Ошибка сортировки", e);
                return false;
            }
        }

        private const string AuthorTag = "author";

        private string GetAuthor(string file)
        {
            var builder = new StringBuilder(256);
            using (var reader = new StreamReader(file, Encoding.GetEncoding(1251)))
            {
                var tag = false;
                while (!reader.EndOfStream)
                {
                    var token = GetToken(reader);
                    if (string.IsNullOrEmpty(token))
                        continue;

                    if (tag && token.Trim().ToLower() == AuthorTag)
                    {
                        while (token != "{")
                            token = GetToken(reader);

                        token = GetToken(reader);

                        while (token != "\\" && token != "}")
                        {
                            builder.Append(token.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").Replace("\t", " "));
                            token = GetToken(reader);
                        }
                        break;
                    }

                    tag = token == "\\";
                }
            }

            var result = builder.ToString().Trim();

            return (result[0] > 'а' && result[0] < 'я')
                ? CyrillicName(result)
                : LatinName(result);
        }

        private string CyrillicName(string source)
        {
            return source;
        }

        private string LatinName(string source)
        {
            return source;
        }

        private readonly char[] _delimeter =
        {
            ' ', '{', '\\', '}', '(', ')', '\t', '\n', '\r'
        };

        private string GetToken(StreamReader reader)
        {
            if (reader.EndOfStream)
                return null;

            var c = (char)reader.Read();

            var result = new StringBuilder(256);
            result.Append(c);
            if (_delimeter.Contains(c))
                return result.ToString();

            while (!reader.EndOfStream)
            {
                var i = reader.Peek();
                c = (char)i;
                if (_delimeter.Contains(c))
                {
                    return result.ToString();
                }
                reader.Read();
                result.Append(c);
            }
            return result.ToString();
        }

        #endregion

    }
}
