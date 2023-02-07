using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    internal class IncludeSearcher
    {

        private TokenReader tokenReader = null;
        private List<string> strings = new List<string>();

        public IncludeSearcher(TokenReader tokenReader)
        {
            this.tokenReader = tokenReader;

            findIncludes();
        }

        public List<string> GetIncludes()
        {
            return this.strings;
        }

        public void findIncludes()
        {

            // Find include lines
            // Ex
            // #include <iostream>
            // #include "foo/foo.h"


            Token t = null;
            while (tokenReader.Read(out t))
            {

                if (t.Kind == TokenKind.Token_Hashtag)
                {

                    if (tokenReader.Read(out t))
                    {

                        if (t.Kind == TokenKind.Token_Identifier)
                        {

                            if (tokenReader.Read(out t))
                            {

                                if (t.Kind == TokenKind.Token_String)
                                {
                                    strings.Add(t.Value);

                                } 
                                else if (t.Kind == TokenKind.Token_Angle_Brackets_Open || t.Kind == TokenKind.Token_String_Literal_Identifier)
                                {
                                    string include_str = string.Empty;
                                    while (
                                        tokenReader.Read(out t) &&
                                        t.Kind != TokenKind.Token_String_Literal_Identifier &&
                                        t.Kind != TokenKind.Token_Angle_Brackets_Close)
                                    {
                                        include_str += t.Value;
                                    }
                                    strings.Add(include_str);
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
