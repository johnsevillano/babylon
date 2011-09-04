using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Babel.Services.Domain;


namespace Babel.Services.UnitTests
{

    [TestClass]
    public class SchemaGenerator
    {
        [TestMethod]
        public void GenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Profile).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }

    }

}
