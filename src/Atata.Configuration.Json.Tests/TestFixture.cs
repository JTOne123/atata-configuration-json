﻿using NUnit.Framework;

namespace Atata.Configuration.Json.Tests
{
    public class TestFixture
    {
        [TearDown]
        public virtual void TearDown()
        {
            JsonConfig.Current = null;
            JsonConfig.Global = null;
            CustomJsonConfig.Current = null;
            CustomJsonConfig.Global = null;

            AtataContext.GlobalConfiguration.Clear();
        }
    }
}
