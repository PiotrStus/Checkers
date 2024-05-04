using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Move
    {
        public int FromRow { get; set; }
        public int FromColumn { get; set; }
        public int ToRow { get; set; }
        public int ToColumn { get; set; }
    }
}
