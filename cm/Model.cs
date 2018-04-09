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

        public string DefaultTarget => $@"Сборник {DateTime.Today:yyyy-MM-dd}.tex";

        #region . Build .

        public bool Build(string header, string target)
        {
            if (string.IsNullOrEmpty(header))
                throw new ArgumentNullException(nameof(header), @"Путь к заголовочному файлу должен быть валидным");
            if (string.IsNullOrEmpty(target))
                throw new ArgumentNullException(nameof(target), @"Путь к результирующему файлу должен быть валидным");

            try
            {
                var nameMap = new List<AuthFile>();
                var body = Path.ChangeExtension(target, "body");
                if (File.Exists(body))
                    File.Delete(body);

                foreach (var file in Files)
                {
                    var key = BuildFile(file, body);
                    nameMap.Add(new AuthFile(key, body));
                }

                using (var output = File.Create(target))
                {
                    using (var h = File.OpenRead(header))
                    {
                        var bytes = new byte[h.Length];
                        h.Read(bytes, 0, bytes.Length);
                        output.Write(bytes, 0, bytes.Length);
                    }

                    using (var b = File.OpenRead(body))
                    {
                        var bytes = new byte[b.Length];
                        b.Read(bytes, 0, bytes.Length);
                        output.Write(bytes, 0, bytes.Length);
                    }

                    File.Delete(body);

                    {
                        var bytes = Encoding.GetEncoding(1251).GetBytes("\\end{document}");
                        output.Write(bytes, 0, bytes.Length);
                        output.Flush();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Error("Ошибка сборки", e);
                return false;
            }
        }

        private const string TitleTag = "\\title";

        private const string FinalTag = "\\end";

        private string BuildFile(string file, string target)
        {
            var builder = new StringBuilder(256);

            using (var output = File.AppendText(target))
            {
                output.WriteLine("%");
                output.WriteLine($"% --==[ {file} ]==--");
                output.WriteLine("%");

                using (var reader = new StreamReader(file, Encoding.GetEncoding(1251)))
                {
                    var body = false;
                    while (!reader.EndOfStream)
                    {
                        var token = GetToken(reader);
                        if (string.IsNullOrEmpty(token))
                            continue;

                        if (token == "\\")
                            token = string.Concat(token, GetToken(reader));

                        if (token.Trim().ToLower() == TitleTag)
                            body = true;

                        if (token.Trim().ToLower() == FinalTag)
                        {
                            var sb = new StringBuilder(token);
                            while (token != "{")
                            {
                                token = GetToken(reader);
                                sb.Append(token);
                            }

                            while (token != "}")
                            {
                                token = GetToken(reader);
                                sb.Append(token);
                                if (token.Trim().ToLower() == "document")
                                    body = false;
                            }

                            if (!body)
                                break;

                            output.Write(sb.ToString());
                        }
                        else if (body)
                            output.Write(token);

                        if (token.Trim().ToLower() == AuthorTag)
                        {
                            while (token != "{")
                            {
                                token = GetToken(reader);
                                output.Write(token);
                            }

                            token = GetToken(reader);
                            output.Write(token);

                            while (token != "\\" && token != "}")
                            {
                                builder.Append(token.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ")
                                    .Replace("\t", " "));
                                token = GetToken(reader);
                                output.Write(token);
                            }
                        }
                    }
                }

                output.Flush();
            }

            var result = builder.ToString().Trim();

            return (result[0] > 'а' && result[0] < 'я')
                ? CyrillicName(result)
                : LatinName(result);
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

        private const string AuthorTag = "\\author";

        private string GetAuthor(string file)
        {
            var builder = new StringBuilder(256);
            using (var reader = new StreamReader(file, Encoding.GetEncoding(1251)))
            {
                while (!reader.EndOfStream)
                {
                    var token = GetToken(reader);
                    if (string.IsNullOrEmpty(token))
                        continue;

                    if (token == "\\")
                        token = string.Concat(token, GetToken(reader));

                    if (token.Trim().ToLower() == AuthorTag)
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
