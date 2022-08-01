using System.Text;

namespace BootCamp.Chapter
{
    /// <summary>
    /// Part 1.
    /// </summary>
    public static class TextTable
    {
        /*

         Input: "Hello", 0
           +-----+
           |Hello|
           +-----+
           
         Input: $"Hello{Environment.NewLine}World!", 0
           +------+
           |Hello |
           |World!|
           +------+
           
         Input: "Hello", 1
           +-------+
           |       |
           | Hello |
           |       |
           +-------+

         */

        /// <summary>
        /// Build a table for given message with given padding.
        /// Padding means how many spaces will a message be wrapped with.
        /// Table itself is made of: "+-" symbols. 
        /// </summary>
        public static string Build(string message, int padding)
        {
            if (message == "") return "";

            var lines = new StringBuilder();
            var spaces = new StringBuilder();
            int width = message.Length + (padding*2);
            var final = new StringBuilder();
            string[] messages = new string[1];
            bool multiple = false;

            int longest = 0;

            if (message.Contains("\n"))
            {
                messages = message.Split("\n");
                multiple = true;

                foreach (string line in messages)
                {
                    if (longest < line.Length)
                    {
                        longest = line.Length;
                    }
                }

            }

            


            //initialise spacing

            if (multiple)
            {
                for (int i = 0; i < longest; i++)
                {
                    lines.Append("-");
                    spaces.Append(" ");
                }
            }
            else
            {
                for (int i = 0; i < width; i++)
                {
                    lines.Append("-");
                    spaces.Append(" ");
                }
            }
            

            //For top and bot
            string edge = $"+{lines}+";

            //padding bot
            final.AppendLine(edge);


            //for top and bot
            string pad = $"|{spaces}|";

            //padding top
            for (int i = 0; i < padding; i++)
            {
                final.AppendLine(pad);
            }

            //message
            if (multiple)
            {
                for (int i = 0; i < messages.Length; i++)
                {
                    message = messages[i].PadLeft(padding);
                    message = message.PadRight(padding);
                    final.AppendLine($"|{message}|");
                }
            }
            else
            {
                message = message.PadLeft(padding + message.Length);
                message = message.PadRight(padding + message.Length);
                final.AppendLine($"|{message}|");
            }
            
            
            //bottom pad
            for (int i = 0; i < padding; i++)
            {
                final.AppendLine(pad);
            }

            //bottom edge
            final.AppendLine(edge);

            return final.ToString();
        }
    }
}
