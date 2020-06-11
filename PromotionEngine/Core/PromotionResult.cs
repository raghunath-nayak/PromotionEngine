using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core
{
   public class PromotionResult
    {
        public int Value { get; set; }
        public char[] ItemsUsed { get; set; }

        public PromotionResult()
        {
            Value = 0;
            ItemsUsed = null;   
        }

    }
}
        