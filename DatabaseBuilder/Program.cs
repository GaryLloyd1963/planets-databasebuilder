using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseBuilder.Builder;
using DatabaseBuilder.Configuration;
using StructureMap;

namespace DatabaseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var builder = container.GetInstance<IDatabaseBuilder>();

            builder.BuildDatabases();

            Console.ReadKey();
        }

        private static Container CreateContainer()
        {
            return new Container(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });
        }
    }
}
