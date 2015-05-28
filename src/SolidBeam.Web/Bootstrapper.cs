using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Nancy.Bootstrappers.Windsor;
using SolidBeam.Domain;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;

namespace SolidBeam.Web
{
    // see: https://github.com/NancyFx/Nancy.Bootstrappers.Windsor
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            // perform registrations here
            container.Register(Component.For<IRatingEngine>().ImplementedBy<RatingEngine>());
            container.Register(Component.For<IVehicleFactory>().ImplementedBy<VehicleFactory>());
            container.Register(Component.For<IRule>().ImplementedBy<BasicRule>());

            // model factories
            container.Register(Component.For<IRatingModelFactory>().ImplementedBy<RatingModelFactory>());

            // collections
            container.Register(Classes.FromAssembly(typeof(IType).Assembly).BasedOn<IType>().WithServiceFromInterface());
            container.Register(Classes.FromAssembly(typeof(IManufacturer).Assembly).BasedOn<IManufacturer>().WithServiceFromInterface());
        }
    }
}
