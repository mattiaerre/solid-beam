using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System.Collections.Generic;

namespace SolidBeam.Web
{
    public class RatingModelFactory : IRatingModelFactory
    {
        private readonly IEnumerable<IType> _types;
        private readonly IEnumerable<IManufacturer> _manufacturers;

        public RatingModelFactory(IEnumerable<IType> types, IEnumerable<IManufacturer> manufacturers)
        {
            _types = types;
            _manufacturers = manufacturers;
        }

        public RatingModel Make()
        {
            return new RatingModel(_types, _manufacturers);
        }
    }
}