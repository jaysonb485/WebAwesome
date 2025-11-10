using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
        public class TagRemovingEventArgs : EventArgs
        {
            public bool Cancel { get; set; } = false;
        }
}
