﻿using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {

    

        services.AddScoped<IProductService, ProductManager>();

        services.AddScoped<ICategoryService, CategoryManager>();

        services.AddScoped<ProductBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();






        return services;
    }

}
