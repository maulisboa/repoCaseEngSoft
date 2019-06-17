﻿using TwitterWidget;
using TwitterWidget.Models;
using TwitterWidget.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTwitterWidget(this IServiceCollection services, IConfiguration configuration = null)
        {
            if (configuration != null)
                services.Configure<TwitterOptions>(configuration);
            else
                services.TryAddSingleton<TwitterOptions, TwitterOptions>();

            services.TryAddSingleton<TwitterCache>();
            services.TryAddScoped<ITwitterService, TwitterService>();
            services.TryAddScoped<ITwitterCacheWrapperService, TwitterCacheWrapperService>();

            return services;
        }
    }
}