using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomous.Editor
{
    internal class CharReader
    {
        private FileInfo source_file = null;
        private string source_file_content = string.Empty;

        private int pos = 0;

        public CharReader(FileInfo source_file) {
            this.source_file = source_file;

            if(this.source_file.Exists)
            {
                this.source_file_content = File.ReadAllText(source_file.FullName);
            }

        }


        public bool Read(out char read_char)
        {
            
            if(this.pos < this.source_file_content.Length)
            {
                read_char = this.source_file_content[this.pos];
                this.pos++;
                return true;
            }

            read_char = ' ';

            return false;
        }

        public bool Peek(out char read_char)
        {

            int peek_index = this.pos + 1;

            if (peek_index < this.source_file_content.Length)
            {
                read_char = this.source_file_content[peek_index];
                
                return true;
            }

            read_char = ' ';

            return false;
        }

    }
}
