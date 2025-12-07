using ECInterfaces.Devices;
using ECInterfaces.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Reflection;

var services = new ServiceCollection();

services.AddLogging(builder =>
{
    builder.SetMinimumLevel(LogLevel.Information);
    builder.AddConsole();
});

//var assembly = Assembly.LoadFrom("StandardDevices.dll");

//var pluginAssemblies = Directory
//    .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
//    .Select(Assembly.LoadFrom);

// --- SCAN FOR DEVICES ---
//services.Scan(scan => scan
//    .FromAssemblies(pluginAssemblies)   // <-- ADD THIS
//    .AddClasses(c => c.AssignableTo<ILoadPortDevice>())
//    .AsImplementedInterfaces()
//    .WithTransientLifetime()
//);

// --- SCAN FOR MODULES ---
//services.Scan(scan => scan
//    .FromApplicationDependencies()
//    .AddClasses(c => c.AssignableTo<IModule>())
//    .AsImplementedInterfaces()
//    .WithTransientLifetime()
//);

services.AddTransient<EquipmentController.EquipmentController>();
var provider = services.BuildServiceProvider();

// Resolve the module
var module = provider.GetRequiredService<EquipmentController.EquipmentController>();

Console.WriteLine("Finished.");