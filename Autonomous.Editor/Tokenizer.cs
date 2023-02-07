namespace Autonomous.Editor
{

    // https://lisperator.net/pltut/parser/token-stream

    public class Tokenizer
    {

        private string source_file;
        private List<Token> tokenized_document;

        public Tokenizer(string source_file)
        {
            this.source_file = source_file;
            this.tokenized_document = new List<Token>();

            this.tokenize();
        }

        public List<Token> GetTokens()
        {
            return this.tokenized_document;
        }

        private void tokenize()
        {
            var lines = File.ReadAllLines(source_file);

            int line_nr = 1;
            foreach (string line in lines)
            {
                // remove spaces from the begining and the end
                string prepared_line = line.Trim();

                // if the line is empty continue with next line
                if (string.IsNullOrEmpty(prepared_line))
                {
                    continue;
                }

                this.tokenized_document.AddRange(this.tokenize_line(prepared_line, line_nr));

                line_nr++;
            }


            // Determine TokenKind

            foreach (Token t in this.tokenized_document)
            {
                t.Kind = TokenUtil.MapToken(t.Group, t.Value);
            }

            // End of file

            this.tokenized_document.Add(new Token() { Group = TokenGroup.Info, Kind = TokenKind.Token_EOF, Value = String.Empty });


        }

        private List<Token> tokenize_line(string line, int line_nr)
        {
            List<Token> tokens = new List<Token>();
            StringReader reader = new StringReader(line);
            string prev_chars = string.Empty;

            while (reader.Peek() != -1)
            {
                char c = (char)reader.Read();

                // Handle comments
                {
                    if (c.Equals('/') && this.peekChar(reader).Equals('/'))
                    {
                        this.handlePrevChars(ref prev_chars, tokens);
                        return tokens;
                    }
                }

                // Handle strings
                {
                    if (c.Equals('"'))
                    {
                        this.handlePrevChars(ref prev_chars, tokens);
                        this.handleString(reader, c, tokens);
                        continue;
                    }
                }

                // Handle numbers
                {

                    if (char.IsDigit(c) && prev_chars.Equals(String.Empty))
                    {
                        this.handleNumber(reader, c, tokens);
                        continue;
                    }
                }

                // Handle whitespaces
                {
                    if (c.Equals(' '))
                    {
                        this.handleWhitespaces(reader);
                        this.handlePrevChars(ref prev_chars, tokens);
                        continue;
                    }
                }

                // Handle operators
                {
                    // -> Operator
                    if (c.Equals('-') && this.peekChar(reader).Equals('>'))
                    {
                        // Skip '>'
                        reader.Read();

                        this.handlePrevChars(ref prev_chars, tokens);
                        tokens.Add(new Token() { Group = TokenGroup.Operator, Value = "->" });
                        continue;
                    }

                    // = operator
                    if (c.Equals('='))
                    {
                        this.handlePrevChars(ref prev_chars, tokens);
                        tokens.Add(new Token() { Group = TokenGroup.Operator, Value = "=" });
                        continue;
                    }
                }

                // handle punctuation and delimiters
                {
                    if (TokenUtil.IsPunctuation(c))
                    {
                        this.handlePrevChars(ref prev_chars, tokens);
                        tokens.Add(new Token { Group = TokenGroup.Puctuation, Value = c.ToString() });
                        continue;
                    }

                    if (TokenUtil.IsDelimiter(c))
                    {
                        this.handlePrevChars(ref prev_chars, tokens);
                        tokens.Add(new Token { Group = TokenGroup.Delimeter, Value = c.ToString() });
                        continue;
                    }
                }

                prev_chars += c;
            }

            if (!prev_chars.Equals(String.Empty))
            {
                this.handlePrevChars(ref prev_chars, tokens);
            }

            return tokens;
        }

        private char peekChar(StringReader reader)
        {
            return (char)reader.Peek();
        }

        private void handleWhitespaces(StringReader r)
        {
            while (this.peekChar(r) == ' ')
            {
                r.Read();
            }
        }

        private void handleString(StringReader reader, char c, List<Token> tokens)
        {
            // Read string in a new loop
            string str = string.Empty;
            while (reader.Peek() != -1)
            {
                c = (char)reader.Read();

                // To skip escaped \"
                if (c.Equals('\\') && this.peekChar(reader).Equals('"'))
                {
                    reader.Read();
                    str += "\\\"";
                    continue;
                }

                if (c.Equals('\"'))
                {
                    break;
                }

                str += c;
            }

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
            {
                tokens.Add(new Token { Group = TokenGroup.String, Value = str });
            }

        }

        private void handleNumber(StringReader reader, char c, List<Token> tokens)
        {
            string number = c.ToString();
            char peeked_char = this.peekChar(reader);

            while (char.IsDigit(peeked_char) || peeked_char.Equals('.') || peeked_char.Equals('f'))
            {
                number += peeked_char;

                reader.Read();

                peeked_char = this.peekChar(reader);
            }

            tokens.Add(new Token { Group = TokenGroup.Number, Value = number });
        }

        private void handlePrevChars(ref string prev_chars, List<Token> tokens)
        {
            prev_chars = prev_chars.Trim();

            // Identifier always after a keyword and a literal always after the '=' op?

            if (!string.IsNullOrEmpty(prev_chars) && !string.IsNullOrWhiteSpace(prev_chars))
            {
                if (TokenUtil.IsKeyword(prev_chars))
                {
                    tokens.Add(new Token { Group = TokenGroup.Keyword, Value = prev_chars });
                }
                else
                {


                    if (TokenUtil.IsNumber(prev_chars))
                    {
                        tokens.Add(new Token { Group = TokenGroup.Number, Value = prev_chars });
                    }
                    else
                    {
                        tokens.Add(new Token { Group = TokenGroup.Identifier, Value = prev_chars });
                    }
                }
            }

            prev_chars = String.Empty;
        }

    }
}