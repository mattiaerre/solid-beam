using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System.Collections.Generic;

namespace SolidBeam.Web
{
    public class RatingModel
    {
        public IEnumerable<string> Types { get; private set; }
        public IEnumerable<string> Manufacturers { get; private set; }

        public RatingModel(IEnumerable<IType> types, IEnumerable<IManufacturer> manufacturers)
        {
            Types = types.ToTypeNames();
            Manufacturers = manufacturers.ToTypeNames();
        }
    }
}