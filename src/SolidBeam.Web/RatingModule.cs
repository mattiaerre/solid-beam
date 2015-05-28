using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SolidBeam.Domain;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System;

namespace SolidBeam.Web
{
    public class RatingModule : NancyModule
    {
        public RatingModule(IRatingModelFactory ratingModelFactory, IRatingEngine ratingEngine)
        {
            Get["/"] = parameters => Response.AsRedirect("/Content/app/rating/rating.html");

            var model = ratingModelFactory.Make();
            Get["/api/v0/rating/model"] = _ => JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), });

            Post["/api/v0/rating/quote"] = ctx =>
            {
                var data = this.Bind<PostedData>();
                var json = JObject.Parse(data.payload);

                var typeHandle = Activator.CreateInstance("SolidBeam.Domain", string.Format("SolidBeam.Domain.Types.{0}", json["type"].Value<string>()));
                var manufacturerHandle = Activator.CreateInstance("SolidBeam.Domain", string.Format("SolidBeam.Domain.Manufacturers.{0}", json["manufacturer"].Value<string>()));

                var quote = ratingEngine.Quote((IType)typeHandle.Unwrap(), (IManufacturer)manufacturerHandle.Unwrap());
                return JsonConvert.SerializeObject(new { quote });
            };
        }
    }
}
