using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    public class Token
    {

        public Token()
        {
            this.Group = TokenGroup.Info;
            this.Kind = TokenKind.Token_Invalid;
            this.Value = String.Empty;
        }
        public TokenGroup Group;

        public TokenKind Kind;

        public string Value;
    }
}