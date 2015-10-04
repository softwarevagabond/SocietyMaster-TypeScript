using SocietyMaster.Business;
using SocietyMaster.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            return Init(null);
        }

        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogParts)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            //ToDO: Add items to catalog -- any one class from the assembly
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SocietyRepository).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SocietyEngine).Assembly));

            if (catalogParts != null)
            {
                foreach (var part in catalogParts)
                {
                    catalog.Catalogs.Add(part);
                }
            }

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
