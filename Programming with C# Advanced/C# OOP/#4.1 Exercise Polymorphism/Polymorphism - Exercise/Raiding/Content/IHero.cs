using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public interface IHero
    {
        string Name { get; set; }
        int Power { get; set; }
        string CastAbility();
    }
}
