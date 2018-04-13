using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        private class BuildResult
        {
            public string Filename { get; }
            public List<string> Labels { get; } = new List<string>();
            public List<string> Authors { get; } = new List<string>();

            public BuildResult(string file)
            {
                Filename = file;
            }

            public void Add(string label, string author)
            {
                Labels.Add(label);
                Authors.Add(author);
            }
        }

        private class AuthLabel
        {
            public string Author { get; }
            public List<string> Labels { get; }

            public AuthLabel(string name, string label)
            {
                Author = name;
                Labels = new List<string>{ label };
            }

            public override string ToString()
            {
                return $"\\\\{Author} \\dotfill {string.Join(", ", Labels.Select(x => $"\\pageref{{{x}}}"))}";
            }
        }

        public List<string> Files { get; } = new List<string>();

        public string DefaultTarget => $@"Сборник {DateTime.Today:yyyy-MM-dd}.tex";

        #region . Build .

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public bool Build(string header, string target)
        {
            if (string.IsNullOrEmpty(header))
                throw new ArgumentNullException(nameof(header), @"Путь к заголовочному файлу должен быть валидным");
            if (string.IsNullOrEmpty(target))
                throw new ArgumentNullException(nameof(target), @"Путь к результирующему файлу должен быть валидным");

            Log.Info($"Начало сборки {target}");

            var targetDir = Path.GetDirectoryName(target);

            try
            {
                var buildMap = new List<BuildResult>();
                var labelMap = new List<AuthLabel>();
                _index = 100;//исключительно для красоты

                foreach (var file in Files)
                {
                    Log.Info($"Сборка {file}");
                    var body = Path.Combine(
                        targetDir,
                        Path.ChangeExtension(Path.GetFileName(file), "converted.tex")
                    );
                    if (File.Exists(body))
                        File.Delete(body);

                    Log.Info($"Временный файл: {body}");
                    var result = BuildFile(file, body, labelMap);
                    buildMap.Add(result);
                }

                /*
                {
                    Log.Info("Файлы, авторы и метки:");
                    buildMap.ForEach(x =>
                    {
                        Log.Info($"\\input{{{Path.GetFileNameWithoutExtension(x.Filename)}}}");
                        Log.Info(
                            $"{string.Join(" ", x.Labels.Select(y => $"\\label{{{y}}}"))} % {string.Join(" % ", x.Authors)}");
                    });

                    Log.Info("Авторы и метки:");
                    foreach (var item in labelMap.OrderBy(x => x.Author))
                    {
                        Log.Info(item.ToString());
                    }
                }
                */

                using (var output = File.Create(target))
                {
                    using (var h = File.OpenRead(header))
                    {
                        Log.Info($"Вывод заголовка {header}");
                        var bytes = new byte[h.Length];
                        h.Read(bytes, 0, bytes.Length);
                        output.Write(bytes, 0, bytes.Length);
                    }

                    foreach (var item in buildMap)
                    {
                        PutString(output, "%");
                        PutString(output, "\\pagebreak");
                        PutString(output, "\\setcounter{equation}{0}");
                        PutString(output, $"{string.Join(" ", item.Labels.Select(y => $"\\label{{{y}}}"))} % {string.Join(" % ", item.Authors)}");
                        PutString(output, $"\\input{{{Path.GetFileNameWithoutExtension(item.Filename)}}}");
                    }

                    PutString(output, "");
                    PutString(output, "%------------------------------------------------------------------------------");
                    PutString(output, "\\pagebreak");
                    PutString(output, "\\markboth{ }{ }");
                    PutString(output, "\\vspace{-10mm}");
                    PutString(output, "\\begin{center} СПИСОК АВТОРОВ \\end{center}");
                    PutString(output, "\\vspace{-5mm}");
                    PutString(output, "\\label{List}");
                    PutString(output, "\\vspace{5mm}");
                    PutString(output, "\\noindent");

                    foreach (var item in labelMap.OrderBy(x => InterpretForSorting(x.Author)))
                    {
                        PutString(output, item.ToString());
                    }

                    {
                        PutString(output, "\\end{document}");
                        output.Flush();
                    }
                    Log.Info($"Сборка {target} завершена");

                }

                return true;
            }
            catch (Exception e)
            {
                Log.Error("Ошибка сборки", e);
                return false;
            }
        }

        private string InterpretForSorting(string s)
        {
            return (s[0] >= 'A' && s[0] <= 'Z')
                ? "ЯЯЯ" + s
                : s;
        }

        private void PutString(FileStream stream, string s)
        {
            var bytes = Encoding.GetEncoding(1251).GetBytes(s + "\n");
            stream.Write(bytes, 0, bytes.Length);
        }

        private const string TitleTag = "\\title";

        private const string FinalTag = "\\end";

        private int _index;

        private BuildResult BuildFile(string file, string target, List<AuthLabel> labelMap)
        {
            var result = new BuildResult(target);
            var builder = new StringBuilder(256);

            using (var output = File.AppendText(target))
            {
                using (var reader = new StreamReader(file, Encoding.GetEncoding(1251)))
                {
                    var body = false;
                    var authorsTaken = false;
                    while (!reader.EndOfStream)
                    {
                        var token = GetToken(reader);
                        if (string.IsNullOrEmpty(token))
                            continue;

                        if (token.Trim().ToLower() == TitleTag)
                            body = true;

                        #region . check for \end{document} .

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

                        #endregion

                        #region . list authors .

                        if (token.Trim().ToLower() == AuthorTag && !authorsTaken)
                        {
                            while (token != "{")
                            {
                                token = GetToken(reader);
                                output.Write(token);
                            }

                            token = GetToken(reader);
                            output.Write(token);

                            while (token != "}")
                            {
                                if (token.Trim().StartsWith("\\") || token.Trim() == ",")
                                {
                                    var author = builder.ToString().Trim(' ', ',');
                                    if (!string.IsNullOrWhiteSpace(author))
                                    {
                                        var label = $"lbl{++_index}";
                                        builder.Clear();

                                        var al = labelMap.FirstOrDefault(x => x.Author == author);
                                        if (al != null)
                                            al.Labels.Add(label);
                                        else
                                            labelMap.Add(new AuthLabel(author, label));
                                        result.Add(label, author);
                                    }

                                    token = GetToken(reader);
                                    output.Write(token);

                                    continue;
                                }

                                if (token == "{")
                                {
                                    while (token != "}")
                                        token = GetToken(reader);
                                    token = GetToken(reader);
                                    output.Write(token);

                                    continue;
                                }

                                builder.Append(token.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ")
                                    .Replace("\t", " "));

                                token = GetToken(reader);
                                output.Write(token);
                            }

                            authorsTaken = true;
                        }

                        //Последнего автора
                        if (builder.Length > 0)
                        {
                            var author = builder.ToString().Trim();

                            if (!string.IsNullOrWhiteSpace(author))
                            {
                                var label = $"lbl{++_index}";
                                var al = labelMap.FirstOrDefault(x => x.Author == author);
                                if (al != null)
                                    al.Labels.Add(label);
                                else
                                    labelMap.Add(new AuthLabel(author, label));
                                result.Add(label, author);
                                builder.Clear();
                            }
                        }

                        #endregion

                    }
                }

                output.Flush();
            }

            return result;
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

                    if (token.Trim().ToLower() == AuthorTag)
                    {
                        while (token != "{")
                            token = GetToken(reader);

                        token = GetToken(reader);

                        while (!token.StartsWith("\\") && token != "}")
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
            ' ', '{', '\\', '}', '(', ')', '\t', '\n', '\r', ','
        };

        private string GetToken(StreamReader reader)
        {
            if (reader.EndOfStream)
                return null;

            var c = (char)reader.Read();

            var result = new StringBuilder(256);
            result.Append(c);
            if (_delimeter.Contains(c))
                return c == '\\'
                    ? string.Concat(result, GetToken(reader))
                    : result.ToString();

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
