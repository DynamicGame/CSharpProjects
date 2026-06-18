using System;
using System.Collections.Generic;
using System.Text;

namespace _03_CookieCookbook.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int ID { get; }
        public abstract string Name { get; }
        public virtual string InstructionOfPreparing => "Add to other imngredients.";
    }

}
