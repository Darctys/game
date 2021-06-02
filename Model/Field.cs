using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public  class Field
    {
        public bool campfire { get; set; }
        public bool Tree { get; set; }
        public bool leather { get; set; }
        public bool player { get; set; }
        public bool wood { get; set; }
        public bool coal { get; set; }

        public bool End { get; set; }
        public  bool CanGO()
        {
            return Tree || End || campfire;
        }

    }
}
