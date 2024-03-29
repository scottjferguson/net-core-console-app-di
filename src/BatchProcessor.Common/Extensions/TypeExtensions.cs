﻿using Core.Framework.Attributes;
using Core.Framework.Enums;
using System;
using System.Linq;

namespace BatchProcessor.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool UnlessAutoWiringOptOut(this Type type)
        {
            return !type.GetCustomAttributes(typeof(InjectableAttribute), true).Any() ||
                    type.GetCustomAttributes(typeof(InjectableAttribute), true).Select(ia => ((InjectableAttribute)ia).AutoWiring != Opt.Out).FirstOrDefault();
        }
    }
}
