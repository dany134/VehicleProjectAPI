using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VehicleProject.WebAPI.Controllers;
using Ninject;

namespace VehicleProject.WebAPI.App_Start
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperconfig = CreateConfing();
            Bind<MapperConfiguration>().ToConstant(mapperconfig).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperconfig, type => ctx.Kernel.Get(type)));
            Bind<VehicleMakesController>().ToSelf().InTransientScope();
            Bind<VehicleModelsController>().ToSelf().InTransientScope();
        }
        private MapperConfiguration CreateConfing()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            return config;
        }

    }
   
}