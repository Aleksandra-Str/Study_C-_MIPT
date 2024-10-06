using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_6
{
    public abstract class TaxiFactory
    {
        public abstract Driver CreateDriver(string name, int age, string liscenseNumber, int experienceYears);
        public abstract Movement CreateMovement();

    }

    public class HorseTaxiFactory : TaxiFactory
    {
        public override Driver CreateDriver(string name, int age, string liscenseNumber, int experienceYears)
        {
            return new Coachman(name, age, liscenseNumber, experienceYears);
        }

        public override Movement CreateMovement() => new Gallop();

    }

    public class TrackTaxiFactory : TaxiFactory
    {
        public override Driver CreateDriver(string name, int age, string liscenseNumber, int experienceYears)
        {
            return new Trackman(name, age, liscenseNumber, experienceYears);
        }

        public override Movement CreateMovement() => new Drag();

    }
}
