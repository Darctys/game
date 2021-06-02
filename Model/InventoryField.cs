using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame.Model
{
    class InventoryField
    {
        public bool wood { get; set; }
        public bool coal { get; set; }

        public  bool IsFull()
        {
            return wood || coal;
        }

    }
}
