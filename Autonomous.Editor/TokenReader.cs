using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    public class TokenReader : IDisposable
    {
        private List<Token> _tokens;

        private int token_idx = -1;

        public TokenReader(List<Token> tokens)
        {
            _tokens = tokens;
        }

        public Token Read()
        {
            if (token_idx + 1 >= _tokens.Count)
            {
                return null;
            }

            // TODO Line and column count

            return _tokens[++token_idx];
        }

        public bool Read(out Token t)
        {
            t = this.Read();
            return t != null;
        }

        public Token Get()
        {
            if (token_idx >= _tokens.Count)
            {
                return null;
            }
            return _tokens[token_idx];
        }

        public bool Peek(out Token token)
        {
            token = this.Peek();
            return token != null;
        }

        private Token Peek()
        {
            if ((token_idx + 1) >= _tokens.Count)
            {
                return null;
            }
            return _tokens[token_idx + 1];
        }

        public List<Token> ReadUntil(TokenKind kind)
        {
            List<Token> tokens = new List<Token>();

            // Add current token
            tokens.Add(this.Get());

            Token t = null;
            while (this.Read(out t))
            {
                TokenKind curr_token_kind = t.Kind;

                if (curr_token_kind == kind)
                {
                    break;
                }

                tokens.Add(this.Get());
            }

            return tokens;
        }

        public void Dispose()
        {
            this._tokens.Clear();
            this.token_idx = 0;
        }
    }

}