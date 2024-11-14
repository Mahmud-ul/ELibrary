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
    public class WriterManager: BaseManager<Writer>, IWriterManager
    {
        private readonly IWriterRepository _writer;
        public WriterManager(IWriterRepository writer) : base(writer)
        {
            _writer = writer;
        }
    }
}
