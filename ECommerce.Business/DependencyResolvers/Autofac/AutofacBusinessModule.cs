using Autofac;
using AutoMapper;
using ECommerce.Api.Validation;
using ECommerce.Application.Validation;
using ECommerce.Business.CacheManager;
using ECommerce.Business.Mapping;
using ECommerce.Business.Models;
using ECommerce.Business.Services.Abstract;
using ECommerce.Business.Services.Concrete;
using ECommerce.Core;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using ECommerce.Data;
using ECommerce.Service.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // CacheManager
            builder.RegisterType<CacheManager>().As<ICacheManager>().InstancePerLifetimeScope();

            // Services
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerDependency();
            builder.RegisterType<BasketService>().As<IBasketService>().InstancePerDependency();

            // Validator
            builder.RegisterType<ProductValidator>().As(typeof(IValidator<SaveProductDTO>)).InstancePerDependency();
            builder.RegisterType<CategoryValidator>().As(typeof(IValidator<SaveCategoryDTO>)).InstancePerDependency();


            // AutoMapper
            builder.RegisterAssemblyTypes(typeof(GeneralMapping).Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
