using ELibraryApp.Manager.Base;
using ELibraryApp.Manager.Contract;
using ELibraryApp.Model.Model;
using ELibraryApp.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Manager
{
    public class PublisherManager : BaseManager<Publisher>, IPublisherManager
    {
        private readonly IPublisherRepository _publisher;
        public PublisherManager(IPublisherRepository publisher):base(publisher) 
        {
            _publisher = publisher;
        }
    }
}
