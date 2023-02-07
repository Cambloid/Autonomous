using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    public class TokenUtil
    {
        public static TokenKind MapToken(TokenGroup token_group, string token)
        {
            switch (token_group)
            {
                case TokenGroup.Delimeter:
                    return TokenUtil.mapDelimiter(token);

                case TokenGroup.Puctuation:
                    return TokenUtil.mapPunctuation(token);

                case TokenGroup.Operator:
                    return TokenUtil.mapOperator(token);

                case TokenGroup.Number:
                    return TokenUtil.mapNumber(token);

                case TokenGroup.String:
                    return TokenKind.Token_String;

                case TokenGroup.Keyword:
                    return TokenUtil.mapKeyword(token);

                case TokenGroup.Identifier:
                    return TokenKind.Token_Identifier;
            }

            return TokenKind.Token_Invalid;
        }

        public static bool IsPunctuation(Token t)
        {
            if (t == null)
            {
                return false;
            }


            return
                t.Kind == TokenKind.Token_Comma ||
                t.Kind == TokenKind.Token_Period ||
                t.Kind == TokenKind.Token_Colon ||
                t.Kind == TokenKind.Token_Semicolon;
        }

        public static bool IsPunctuation(char c)
        {
            var punc = TokenUtil.mapPunctuation(c.ToString());
            return punc != TokenKind.Token_Invalid;
        }

        public static bool IsKeyword(Token t)
        {
            if (t == null)
            {
                return false;
            }

            return
                t.Kind == TokenKind.Token_Keyword_f32 ||
                t.Kind == TokenKind.Token_Keyword_i32 ||
                t.Kind == TokenKind.Token_Keyword_bool ||
                t.Kind == TokenKind.Token_Keyword_str ||
                t.Kind == TokenKind.Token_Keyword_char;
        }

        public static bool IsKeyword(string str)
        {
            var keyword = TokenUtil.mapKeyword(str);
            return keyword != TokenKind.Token_Invalid;
        }

        public static bool IsDelimiter(char c)
        {
            var delim = TokenUtil.mapDelimiter(c.ToString());

            return delim != TokenKind.Token_Invalid;
        }

        public static bool IsDelimiter(Token t)
        {
            if (t == null)
            {
                return false;
            }

            return
                t.Kind == TokenKind.Token_Angle_Brackets_Open ||
                t.Kind == TokenKind.Token_Braces_Open ||
                t.Kind == TokenKind.Token_Brackets_Open ||
                t.Kind == TokenKind.Token_Parentheses_Open ||
                t.Kind == TokenKind.Token_Angle_Brackets_Close ||
                t.Kind == TokenKind.Token_Braces_Close ||
                t.Kind == TokenKind.Token_Brackets_Close ||
                t.Kind == TokenKind.Token_Parentheses_Close;
        }

        public static bool IsNumber(string nr)
        {
            // https://stackoverflow.com/questions/290513/regex-pattern-for-numeric-values
            return TokenUtil.regex_numeric.IsMatch(nr);
        }

        public static TokenKind GetCloseDelimiter(TokenKind open_delimiter)
        {
            switch (open_delimiter)
            {
                case TokenKind.Token_Parentheses_Open:
                    return TokenKind.Token_Parentheses_Close;

                case TokenKind.Token_Brackets_Open:
                    return TokenKind.Token_Brackets_Close;

                case TokenKind.Token_Braces_Open:
                    return TokenKind.Token_Braces_Close;

                case TokenKind.Token_Angle_Brackets_Open:
                    return TokenKind.Token_Angle_Brackets_Close;
            }

            return TokenKind.Token_Invalid;
        }

        // Private

        private static Regex regex_numeric = new Regex(@"^\d+$");

        private static TokenKind mapDelimiter(string token)
        {
            TokenKind res = TokenKind.Token_Invalid;

            switch (token)
            {
                case "{":
                    res = TokenKind.Token_Braces_Open;
                    break;
                case "}":
                    res = TokenKind.Token_Braces_Close;
                    break;
                case "(":
                    res = TokenKind.Token_Parentheses_Open;
                    break;
                case ")":
                    res = TokenKind.Token_Parentheses_Close;
                    break;
                case "<":
                    res = TokenKind.Token_Angle_Brackets_Open;
                    break;
                case ">":
                    res = TokenKind.Token_Angle_Brackets_Close;
                    break;
                case "[":
                    res = TokenKind.Token_Brackets_Open;
                    break;
                case "]":
                    res = TokenKind.Token_Brackets_Close;
                    break;
            }

            return res;
        }

        private static TokenKind mapPunctuation(string token)
        {
            TokenKind res = TokenKind.Token_Invalid;

            switch (token)
            {
                case ".":
                    res = TokenKind.Token_Period;
                    break;
                case ":":
                    res = TokenKind.Token_Colon;
                    break;
                case ";":
                    res = TokenKind.Token_Semicolon;
                    break;
                case "!":
                    res = TokenKind.Token_Exclamation;
                    break;
                case ",":
                    res = TokenKind.Token_Comma;
                    break;
                case "\"":
                    res = TokenKind.Token_String_Literal_Identifier;
                    break;
                case "'":
                    res = TokenKind.Token_Character_Literal_Identifier;
                    break;
                case "@":
                    res = TokenKind.Token_At;
                    break;
                case "#":
                    res = TokenKind.Token_Hashtag;
                    break;
                case "\\":
                    res = TokenKind.Token_Backslash;
                    break;
            }

            return res;
        }

        private static TokenKind mapOperator(string token)
        {
            TokenKind res = TokenKind.Token_Invalid;

            switch (token)
            {
                case "+":
                    res = TokenKind.Token_Plus;
                    break;
                case "-":
                    res = TokenKind.Token_Minus;
                    break;
                case "*":
                    res = TokenKind.Token_Asterisk;
                    break;
                case "/":
                    res = TokenKind.Token_Slash;
                    break;
                case "%":
                    res = TokenKind.Token_Percent;
                    break;
                case "&":
                    res = TokenKind.Token_Ampersand;
                    break;
                case "^":
                    res = TokenKind.Token_Caret;
                    break;
                case "|":
                    res = TokenKind.Token_Pipe;
                    break;
                case "~":
                    res = TokenKind.Token_Tilde;
                    break;
                case "->":
                    res = TokenKind.Token_Arrow_Right;
                    break;
                case "++":
                    res = TokenKind.Token_Plus_Plus;
                    break;
                case "--":
                    res = TokenKind.Token_Minus_Minus;
                    break;
                case "+=":
                    res = TokenKind.Token_Plus_Eq;
                    break;
                case "-=":
                    res = TokenKind.Token_Minus_Eq;
                    break;
                case "*=":
                    res = TokenKind.Token_Asterisk_Eq;
                    break;
                case "/=":
                    res = TokenKind.Token_Slash_Eq;
                    break;

                case "==":
                    res = TokenKind.Token_Eq_Eq;
                    break;
                case "<=":
                    res = TokenKind.Token_Greater_Eq;
                    break;
                case ">=":
                    res = TokenKind.Token_Less_Eq;
                    break;

            }

            return res;
        }

        private static TokenKind mapNumber(string token)
        {
            // TODO: Determine if it is float or integer
            // For now only integers are supported
            return TokenKind.Token_Integer;
        }

        private static TokenKind mapKeyword(string token)
        {
            TokenKind res = TokenKind.Token_Invalid;

            switch (token)
            {
                case "i32":
                    res = TokenKind.Token_Keyword_i32;
                    break;
                case "f32":
                    res = TokenKind.Token_Keyword_f32;
                    break;
                case "str":
                    res = TokenKind.Token_Keyword_str;
                    break;
                case "char":
                    res = TokenKind.Token_Keyword_char;
                    break;
                case "bool":
                    res = TokenKind.Token_Keyword_bool;
                    break;
                case "cls":
                    res = TokenKind.Token_Keyword_cls;
                    break;
                case "fn":
                    res = TokenKind.Token_Keyword_fn;
                    break;
                case "return":
                    res = TokenKind.Token_Keyword_return;
                    break;
                case "import":
                    res = TokenKind.Token_Keyword_import;
                    break;
            }

            return res;
        }


    }
}