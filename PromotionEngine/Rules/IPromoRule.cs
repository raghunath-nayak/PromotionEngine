using PromotionEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Rules
{
    public interface IPromoRule
    {
        PromotionResult Evaluate(char[] itemsList);
    }    
}
