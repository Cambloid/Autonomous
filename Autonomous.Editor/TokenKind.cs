using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    public enum TokenKind
    {

        // String
        Token_String_Literal_Identifier,    // "
        Token_Character_Literal_Identifier, // '
        Token_Hashtag, // #
        Token_Backslash, // \
        Token_Arrow_Right, // ->
        Token_At, // @

        // Delimeters
        Token_Parentheses_Open,     // (
        Token_Parentheses_Close,    // )
        Token_Brackets_Open,        // [
        Token_Brackets_Close,       // ]
        Token_Angle_Brackets_Open,  // <
        Token_Angle_Brackets_Close, // >
        Token_Braces_Open,          // {
        Token_Braces_Close,         // }

        // Bool oprator
        Token_Eq_Eq,           // ==
        Token_Greater_Eq,      // <=
        Token_Less_Eq,         // >=

        // Numerical Operators
        Token_Minus,           // -
        Token_Plus,            // +
        Token_Percent,         // %
        Token_Asterisk,        // *
        Token_Slash,           // /

        // Assign Operator
        Token_Equals,
        Token_Plus_Plus,       // ++
        Token_Minus_Minus,     // --
        Token_Asterisk_Eq,     // *=
        Token_Plus_Eq,         // +=
        Token_Slash_Eq,        // /=
        Token_Minus_Eq,        // -=

        // Binary Operators
        Token_Exclamation,     // !
        Token_Pipe,            // |
        Token_Caret,           // ^
        Token_Tilde,           // ~
        Token_Bit_Shift_Left,  // <<
        Token_Bit_Shift_Right, // >>
        Token_Ampersand,       // &

        // Punctuation
        Token_Semicolon,       // ;
        Token_Comma,           // ,
        Token_Period,          // .
        Token_Colon,           // :

        Token_Integer,
        Token_Float,
        Token_Identifier,
        Token_String,

        // -------------------------------
        // Keywords
        // -------------------------------

        // Code Import/Export
        Token_Keyword_import,

        // Datatypes
        Token_Keyword_i32,
        Token_Keyword_f32,
        Token_Keyword_str,
        Token_Keyword_char,
        Token_Keyword_bool,

        // Loops
        Token_Keyword_for,
        Token_Keyword_while,
        Token_Keyword_do,

        // Control flow
        Token_Keyword_if,
        Token_Keyword_else,
        Token_Keyword_switch,
        Token_Keyword_case,
        Token_Keyword_default,
        Token_Keyword_break,

        // Classes
        Token_Keyword_cls,
        Token_Keyword_public,
        Token_Keyword_private,
        Token_Keyword_protected,

        // Generics
        Token_Keyword_where,

        // Functions/Methods
        Token_Keyword_fn,
        Token_Keyword_return,

        // -------------------------------
        // Information
        // -------------------------------

        Token_EOF,
        Token_Invalid
    }
}