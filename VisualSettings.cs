using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class VisualSettings
    {
        String mode;

        public VisualSettings() {
            using (StreamReader readtext = new StreamReader("visualoptions.txt"))
            {
                mode = readtext.ReadLine();
            }

        }

        public string Mode { get => mode; set => mode = value; }
    }
}
